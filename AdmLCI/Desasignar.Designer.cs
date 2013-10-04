namespace AdmLCI
{
    partial class Desasignar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Desasignar));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMotivo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbComent = new System.Windows.Forms.ComboBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel3.Location = new System.Drawing.Point(1, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 23);
            this.panel3.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Motivo";
            // 
            // cbMotivo
            // 
            this.cbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMotivo.FormattingEnabled = true;
            this.cbMotivo.Items.AddRange(new object[] {
            "Deseo del usuario",
            "Falla de equipo",
            "Equipo vacío"});
            this.cbMotivo.Location = new System.Drawing.Point(10, 32);
            this.cbMotivo.Name = "cbMotivo";
            this.cbMotivo.Size = new System.Drawing.Size(252, 21);
            this.cbMotivo.TabIndex = 27;
            this.cbMotivo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbNombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbComent);
            this.groupBox1.Controls.Add(this.btCancelar);
            this.groupBox1.Controls.Add(this.btAceptar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbMotivo);
            this.groupBox1.Location = new System.Drawing.Point(9, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 241);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 163);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 38);
            this.textBox1.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Observaciones";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(10, 122);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(252, 20);
            this.tbNombre.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Atendió:";
            // 
            // cbComent
            // 
            this.cbComent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComent.FormattingEnabled = true;
            this.cbComent.Location = new System.Drawing.Point(10, 79);
            this.cbComent.Name = "cbComent";
            this.cbComent.Size = new System.Drawing.Size(252, 21);
            this.cbComent.TabIndex = 32;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(129, 207);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(79, 28);
            this.btCancelar.TabIndex = 31;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btAceptar.Image")));
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(54, 207);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(69, 28);
            this.btAceptar.TabIndex = 30;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Comentarios";
            // 
            // Desasignar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(289, 278);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Desasignar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reasignar/Desasignar equipo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Desasignar_FormClosing);
            this.Load += new System.EventHandler(this.Desasignar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMotivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.ComboBox cbComent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}