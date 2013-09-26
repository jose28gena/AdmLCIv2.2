namespace AdmLCI
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btEntrar = new System.Windows.Forms.Button();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbContrasenia = new System.Windows.Forms.TextBox();
            this.btConfg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btCancelar.BackgroundImage")));
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btCancelar.Location = new System.Drawing.Point(236, 188);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(84, 33);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.Text = "CANCELAR";
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // btEntrar
            // 
            this.btEntrar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btEntrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btEntrar.BackgroundImage")));
            this.btEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEntrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btEntrar.Location = new System.Drawing.Point(86, 188);
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.Size = new System.Drawing.Size(76, 33);
            this.btEntrar.TabIndex = 3;
            this.btEntrar.Text = "ENTRAR";
            this.btEntrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btEntrar.UseVisualStyleBackColor = false;
            this.btEntrar.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbUsuario
            // 
            this.tbUsuario.BackColor = System.Drawing.Color.Silver;
            this.tbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsuario.Location = new System.Drawing.Point(121, 82);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(266, 29);
            this.tbUsuario.TabIndex = 1;
            this.tbUsuario.TextChanged += new System.EventHandler(this.tbUsuario_TextChanged);
            // 
            // tbContrasenia
            // 
            this.tbContrasenia.BackColor = System.Drawing.Color.Silver;
            this.tbContrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContrasenia.Location = new System.Drawing.Point(121, 119);
            this.tbContrasenia.Name = "tbContrasenia";
            this.tbContrasenia.PasswordChar = '*';
            this.tbContrasenia.Size = new System.Drawing.Size(266, 29);
            this.tbContrasenia.TabIndex = 2;
            this.tbContrasenia.TextChanged += new System.EventHandler(this.tbContrasenia_TextChanged);
            this.tbContrasenia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbContrasenia_KeyDown);
            // 
            // btConfg
            // 
            this.btConfg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btConfg.Image = ((System.Drawing.Image)(resources.GetObject("btConfg.Image")));
            this.btConfg.Location = new System.Drawing.Point(387, 218);
            this.btConfg.Name = "btConfg";
            this.btConfg.Size = new System.Drawing.Size(29, 29);
            this.btConfg.TabIndex = 5;
            this.btConfg.UseVisualStyleBackColor = true;
            this.btConfg.Click += new System.EventHandler(this.btConfg_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(422, 251);
            this.Controls.Add(this.btConfg);
            this.Controls.Add(this.tbContrasenia);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.btEntrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(422, 251);
            this.Name = "Login";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btEntrar;
        public System.Windows.Forms.TextBox tbUsuario;
        public System.Windows.Forms.TextBox tbContrasenia;
        private System.Windows.Forms.Button btConfg;
    }
}