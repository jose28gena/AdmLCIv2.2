namespace AdmLCI
{
    partial class AgregarEquipo
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEquipo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gb = new System.Windows.Forms.GroupBox();
            this.tbNoMesa = new System.Windows.Forms.TextBox();
            this.tbNumEq = new System.Windows.Forms.TextBox();
            this.tbMonitor = new System.Windows.Forms.TextBox();
            this.tbCPU = new System.Windows.Forms.TextBox();
            this.tbContraloria = new System.Windows.Forms.TextBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.cbSala = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.gb);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 260);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 25);
            this.panel2.TabIndex = 24;
            // 
            // gb
            // 
            this.gb.Controls.Add(this.tbNoMesa);
            this.gb.Controls.Add(this.tbNumEq);
            this.gb.Controls.Add(this.tbMonitor);
            this.gb.Controls.Add(this.tbCPU);
            this.gb.Controls.Add(this.tbContraloria);
            this.gb.Controls.Add(this.cbTipo);
            this.gb.Controls.Add(this.label8);
            this.gb.Controls.Add(this.label7);
            this.gb.Controls.Add(this.btCancelar);
            this.gb.Controls.Add(this.btAceptar);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.pbImagen);
            this.gb.Controls.Add(this.cbSala);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.label4);
            this.gb.Controls.Add(this.label5);
            this.gb.Controls.Add(this.label6);
            this.gb.Location = new System.Drawing.Point(7, 28);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(396, 221);
            this.gb.TabIndex = 16;
            this.gb.TabStop = false;
            // 
            // tbNoMesa
            // 
            this.tbNoMesa.Location = new System.Drawing.Point(109, 130);
            this.tbNoMesa.Name = "tbNoMesa";
            this.tbNoMesa.Size = new System.Drawing.Size(204, 20);
            this.tbNoMesa.TabIndex = 6;
            this.tbNoMesa.TextChanged += new System.EventHandler(this.tbNoMesa_TextChanged);
            // 
            // tbNumEq
            // 
            this.tbNumEq.Location = new System.Drawing.Point(109, 106);
            this.tbNumEq.Name = "tbNumEq";
            this.tbNumEq.Size = new System.Drawing.Size(204, 20);
            this.tbNumEq.TabIndex = 5;
            this.tbNumEq.TextChanged += new System.EventHandler(this.tbNumEq_TextChanged);
            // 
            // tbMonitor
            // 
            this.tbMonitor.Location = new System.Drawing.Point(109, 58);
            this.tbMonitor.Name = "tbMonitor";
            this.tbMonitor.Size = new System.Drawing.Size(204, 20);
            this.tbMonitor.TabIndex = 3;
            this.tbMonitor.TextChanged += new System.EventHandler(this.tbMonitor_TextChanged);
            // 
            // tbCPU
            // 
            this.tbCPU.Location = new System.Drawing.Point(109, 35);
            this.tbCPU.Name = "tbCPU";
            this.tbCPU.Size = new System.Drawing.Size(204, 20);
            this.tbCPU.TabIndex = 2;
            this.tbCPU.TextChanged += new System.EventHandler(this.tbCPU_TextChanged);
            // 
            // tbContraloria
            // 
            this.tbContraloria.Location = new System.Drawing.Point(109, 13);
            this.tbContraloria.Name = "tbContraloria";
            this.tbContraloria.Size = new System.Drawing.Size(204, 20);
            this.tbContraloria.TabIndex = 1;
            this.tbContraloria.TextChanged += new System.EventHandler(this.tbContraloria_TextChanged);
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Individual",
            "Equipo"});
            this.cbTipo.Location = new System.Drawing.Point(109, 155);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(127, 21);
            this.cbTipo.TabIndex = 7;
            this.cbTipo.Text = "Selecione una opción";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tipo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "No. de mesa:";
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(202, 182);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(81, 28);
            this.btCancelar.TabIndex = 9;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btAceptar.Image")));
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(121, 182);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 28);
            this.btAceptar.TabIndex = 8;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "No. de contraloría:";
            // 
            // pbImagen
            // 
            this.pbImagen.Image = global::AdmLCI.Properties.Resources.computadoraAdd1;
            this.pbImagen.Location = new System.Drawing.Point(323, 14);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(67, 54);
            this.pbImagen.TabIndex = 1;
            this.pbImagen.TabStop = false;
            // 
            // cbSala
            // 
            this.cbSala.FormattingEnabled = true;
            this.cbSala.Location = new System.Drawing.Point(109, 82);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(127, 21);
            this.cbSala.TabIndex = 4;
            this.cbSala.Text = "Selecione una opción";
            this.cbSala.SelectedIndexChanged += new System.EventHandler(this.cbSala_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Serie de CPU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Serie de monitor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Sala:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "No. de equipo:";
            // 
            // AgregarEquipo
            // 
            this.AcceptButton = this.btAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(411, 257);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar equipo";
            this.Load += new System.EventHandler(this.AgregarEquipo_Load);
            this.panel1.ResumeLayout(false);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSala;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.TextBox tbContraloria;
        private System.Windows.Forms.TextBox tbCPU;
        private System.Windows.Forms.TextBox tbNumEq;
        private System.Windows.Forms.TextBox tbMonitor;
        private System.Windows.Forms.TextBox tbNoMesa;
    }
}

