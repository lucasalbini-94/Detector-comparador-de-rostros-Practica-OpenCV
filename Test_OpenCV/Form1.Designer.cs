
namespace Test_OpenCV
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxVideo = new System.Windows.Forms.PictureBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnDetectarRostro = new System.Windows.Forms.Button();
            this.tbxNombrePersona = new System.Windows.Forms.TextBox();
            this.btnAgregarPersona = new System.Windows.Forms.Button();
            this.btnTren = new System.Windows.Forms.Button();
            this.btnReconocer = new System.Windows.Forms.Button();
            this.pbxDetectado = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pbxComparador1 = new System.Windows.Forms.PictureBox();
            this.pbxComparador2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDetectado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxComparador1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxComparador2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxVideo
            // 
            this.pbxVideo.Location = new System.Drawing.Point(12, 12);
            this.pbxVideo.Name = "pbxVideo";
            this.pbxVideo.Size = new System.Drawing.Size(550, 408);
            this.pbxVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxVideo.TabIndex = 0;
            this.pbxVideo.TabStop = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(568, 12);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(130, 23);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnDetectarRostro
            // 
            this.btnDetectarRostro.Location = new System.Drawing.Point(568, 41);
            this.btnDetectarRostro.Name = "btnDetectarRostro";
            this.btnDetectarRostro.Size = new System.Drawing.Size(130, 23);
            this.btnDetectarRostro.TabIndex = 3;
            this.btnDetectarRostro.Text = "Detectar rostro";
            this.btnDetectarRostro.UseVisualStyleBackColor = true;
            this.btnDetectarRostro.Click += new System.EventHandler(this.btnDetectarRostro_Click);
            // 
            // tbxNombrePersona
            // 
            this.tbxNombrePersona.Location = new System.Drawing.Point(568, 211);
            this.tbxNombrePersona.Name = "tbxNombrePersona";
            this.tbxNombrePersona.Size = new System.Drawing.Size(130, 20);
            this.tbxNombrePersona.TabIndex = 4;
            // 
            // btnAgregarPersona
            // 
            this.btnAgregarPersona.Location = new System.Drawing.Point(568, 70);
            this.btnAgregarPersona.Name = "btnAgregarPersona";
            this.btnAgregarPersona.Size = new System.Drawing.Size(130, 23);
            this.btnAgregarPersona.TabIndex = 5;
            this.btnAgregarPersona.Text = "Agregar persona";
            this.btnAgregarPersona.UseVisualStyleBackColor = true;
            this.btnAgregarPersona.Click += new System.EventHandler(this.btnAgregarPersona_Click);
            // 
            // btnTren
            // 
            this.btnTren.Location = new System.Drawing.Point(567, 266);
            this.btnTren.Name = "btnTren";
            this.btnTren.Size = new System.Drawing.Size(130, 23);
            this.btnTren.TabIndex = 6;
            this.btnTren.Text = "Imagenes de tren";
            this.btnTren.UseVisualStyleBackColor = true;
            this.btnTren.Click += new System.EventHandler(this.btnTren_Click);
            // 
            // btnReconocer
            // 
            this.btnReconocer.Location = new System.Drawing.Point(568, 295);
            this.btnReconocer.Name = "btnReconocer";
            this.btnReconocer.Size = new System.Drawing.Size(130, 23);
            this.btnReconocer.TabIndex = 7;
            this.btnReconocer.Text = "Reconocer persona";
            this.btnReconocer.UseVisualStyleBackColor = true;
            // 
            // pbxDetectado
            // 
            this.pbxDetectado.Location = new System.Drawing.Point(568, 99);
            this.pbxDetectado.Name = "pbxDetectado";
            this.pbxDetectado.Size = new System.Drawing.Size(130, 106);
            this.pbxDetectado.TabIndex = 8;
            this.pbxDetectado.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(568, 237);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(129, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pbxComparador1
            // 
            this.pbxComparador1.Location = new System.Drawing.Point(568, 324);
            this.pbxComparador1.Name = "pbxComparador1";
            this.pbxComparador1.Size = new System.Drawing.Size(58, 51);
            this.pbxComparador1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxComparador1.TabIndex = 10;
            this.pbxComparador1.TabStop = false;
            // 
            // pbxComparador2
            // 
            this.pbxComparador2.Location = new System.Drawing.Point(632, 324);
            this.pbxComparador2.Name = "pbxComparador2";
            this.pbxComparador2.Size = new System.Drawing.Size(66, 51);
            this.pbxComparador2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxComparador2.TabIndex = 11;
            this.pbxComparador2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 475);
            this.Controls.Add(this.pbxComparador2);
            this.Controls.Add(this.pbxComparador1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pbxDetectado);
            this.Controls.Add(this.btnReconocer);
            this.Controls.Add(this.btnTren);
            this.Controls.Add(this.btnAgregarPersona);
            this.Controls.Add(this.tbxNombrePersona);
            this.Controls.Add(this.btnDetectarRostro);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.pbxVideo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbxVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDetectado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxComparador1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxComparador2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxVideo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnDetectarRostro;
        private System.Windows.Forms.TextBox tbxNombrePersona;
        private System.Windows.Forms.Button btnAgregarPersona;
        private System.Windows.Forms.Button btnTren;
        private System.Windows.Forms.Button btnReconocer;
        private System.Windows.Forms.PictureBox pbxDetectado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pbxComparador1;
        private System.Windows.Forms.PictureBox pbxComparador2;
    }
}

