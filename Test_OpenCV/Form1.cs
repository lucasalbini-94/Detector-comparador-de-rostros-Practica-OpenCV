using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.Threading;
using System.Diagnostics;

namespace Test_OpenCV
{
    public partial class Form1 : Form
    {
        #region Variables
        private VideoCapture video = null;
        private Image<Bgr, Byte> cuadroActual = null;
        Mat cuadro = new Mat();
        private bool habilitarDetectorRostro = false;
        private CascadeClassifier clasificadorRostro = new CascadeClassifier(@"C:\opencv\build\etc\haarcascades\haarcascade_frontalface_alt.xml");
        Image<Bgr, Byte> resultadoRostro = null;
        List<Image<Gray, Byte>> rostrosEntrenados = new List<Image<Gray, byte>>();
        List<int> etiquetasPersona = new List<int>();
        private bool habilitarGuardarImagen = true;
        private static bool entrenando = false;
        EigenFaceRecognizer reconocedor;
        List<string> nombresPersona = new List<string>();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            video = new VideoCapture();
            video.ImageGrabbed += ProcesarCuadro;
            video.Start();
        }

        private void ProcesarCuadro(object sender, EventArgs e)
        {
            // Paso 1: Captura de video
            video.Retrieve(cuadro, 0);
            cuadroActual = cuadro.ToImage<Bgr, Byte>().Resize(pbxVideo.Width, pbxVideo.Height, Inter.Cubic);
            // Paso 2: Detectar rostro
            if (habilitarDetectorRostro)
            {
                // Convertir cuadro a gris
                Mat imagenGris = new Mat();
                CvInvoke.CvtColor(cuadroActual, imagenGris, ColorConversion.Bgr2Gray);
                // Mejorar imágen para obtener mejores resultados
                CvInvoke.EqualizeHist(imagenGris, imagenGris);

                Rectangle[] rostros = clasificadorRostro.DetectMultiScale(imagenGris, 1.1, 3, Size.Empty, Size.Empty);

                if (rostros.Length > 0)
                {

                    foreach (var rostro in rostros)
                    {
                        CvInvoke.Rectangle(cuadroActual, rostro, new Bgr(Color.Red).MCvScalar, 2);

                        // Paso 3: Agregar persona
                        // Asignar rostro al picture box de persona
                        Image<Bgr, Byte> resultadoImagen = cuadroActual.Convert<Bgr, Byte>();
                        resultadoImagen.ROI = rostro;
                        pbxDetectado.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbxDetectado.Image = resultadoImagen.Bitmap;

                        if (habilitarGuardarImagen)
                        {
                            // Crear directorio si no existe
                            string ruta = Directory.GetCurrentDirectory() + @"\ImagenesEntrenamiento";
                            if (!Directory.Exists(ruta))
                                Directory.CreateDirectory(ruta);

                            // Guardar 10 imágenes con retraso de segundo cada una
                            Task.Factory.StartNew(() =>
                            {
                                for (int x = 0; x < 10; x++)
                                {
                                    // Redimencionar imagen y guardar resultado
                                    resultadoImagen.Resize(200, 200, Inter.Cubic).Save(ruta + @"\" + tbxNombrePersona.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                    Thread.Sleep(1000);
                                }
                            });
                        }
                        habilitarGuardarImagen = false;

                        if (btnAgregarPersona.InvokeRequired)
                        {
                            btnAgregarPersona.Invoke(new ThreadStart(delegate
                            {
                                btnAgregarPersona.Enabled = true;
                            }));
                        }

                        // Paso 5: Reconocer rostros
                        if (entrenando)
                        {
                            Image<Gray, Byte> rostroGrisResultado = resultadoImagen.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                            CvInvoke.EqualizeHist(rostroGrisResultado, rostroGrisResultado);
                            var resultado = reconocedor.Predict(rostroGrisResultado);
                            pbxComparador1.Image = rostroGrisResultado.Bitmap;
                            if (resultado.Label >= 0 && resultado.Label > rostrosEntrenados.Count)
                                pbxComparador2.Image = rostrosEntrenados[resultado.Label].Bitmap;
                            else
                                Debug.WriteLine("El índice está fuera de rango:" + resultado.Label);
                            Debug.WriteLine(resultado.Label + ". ", resultado.Distance);
                            // Se encuentra un resultado de rostro
                            if (resultado.Label != -1 && resultado.Distance < 2000)
                            {
                                CvInvoke.PutText(cuadroActual, nombresPersona[resultado.Label], new Point(rostro.X - 2, rostro.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(cuadroActual, rostro, new Bgr(Color.Green).MCvScalar, 2);
                            }
                            // No se encuentra un resultado de rostro
                            else
                            {
                                CvInvoke.PutText(cuadroActual, "Desconocido", new Point(rostro.X - 2, rostro.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                            }
                        }

                    }
                }

            }

            //Renderizar el video en el cuadro de imágen
            pbxVideo.Image = cuadroActual.Bitmap;

        }

        private void btnDetectarRostro_Click(object sender, EventArgs e)
        {
            habilitarDetectorRostro = true;
        }

        private void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnAgregarPersona.Enabled = false;
            habilitarGuardarImagen = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            btnAgregarPersona.Enabled = true;
            habilitarGuardarImagen = false;
        }

        private void btnTren_Click(object sender, EventArgs e)
        {
            EntrenarImagenesDeDirectorio();
        }

        //Paso 4: Entrenar imágenes
        private bool EntrenarImagenesDeDirectorio()
        {
            int contadorImagenes = 0;
            double limite = -1;
            rostrosEntrenados.Clear();
            etiquetasPersona.Clear();
            nombresPersona.Clear();

            try
            {
                string ruta = Directory.GetCurrentDirectory() + @"\ImagenesEntrenamiento\";
                string[] archivos = Directory.GetFiles(ruta, "*.jpg", SearchOption.AllDirectories);

                foreach (var archivo in archivos)
                {
                    Image<Gray, byte> imagenEntrenamiento = new Image<Gray, byte>(archivo).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(imagenEntrenamiento, imagenEntrenamiento);
                    rostrosEntrenados.Add(imagenEntrenamiento);
                    etiquetasPersona.Add(contadorImagenes);
                    string nombre = archivo.Split('\\').Last().Split('_')[0];
                    nombresPersona.Add(nombre);
                    contadorImagenes++;
                }

                if (rostrosEntrenados.Count > 0)
                {
                    reconocedor = new EigenFaceRecognizer(contadorImagenes, limite);
                    reconocedor.Train(new Emgu.CV.Util.VectorOfMat(rostrosEntrenados.Select(img => img.Mat).ToArray()),
                        new Emgu.CV.Util.VectorOfInt(etiquetasPersona.ToArray()));


                    entrenando = true;
                    Debug.WriteLine(contadorImagenes);
                    Debug.WriteLine(entrenando);

                    return entrenando = true;
                }
                else
                {
                    entrenando = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                entrenando = false;
                MessageBox.Show("Error al entrenar imágenes: " + ex.Message);
                return entrenando = false;
            }
        }
    }
}
