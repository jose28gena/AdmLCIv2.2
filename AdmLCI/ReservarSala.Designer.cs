namespace AdmLCI
{
    partial class ReservarSala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservarSala));
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMotivo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbHasta = new System.Windows.Forms.ComboBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAeptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDesde = new System.Windows.Forms.ComboBox();
            this.rbRango = new System.Windows.Forms.RadioButton();
            this.rbSala = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 22);
            this.panel2.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMotivo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbHasta);
            this.groupBox1.Controls.Add(this.btCancelar);
            this.groupBox1.Controls.Add(this.btAeptar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbDesde);
            this.groupBox1.Controls.Add(this.rbRango);
            this.groupBox1.Controls.Add(this.rbSala);
            this.groupBox1.Location = new System.Drawing.Point(10, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 187);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // cbMotivo
            // 
            this.cbMotivo.FormattingEnabled = true;
            this.cbMotivo.Items.AddRange(new object[] {
            "Mantenimiento regular de sala.",
            "Reservada para otro uso."});
            this.cbMotivo.Location = new System.Drawing.Point(9, 120);
            this.cbMotivo.Name = "cbMotivo";
            this.cbMotivo.Size = new System.Drawing.Size(186, 21);
            this.cbMotivo.TabIndex = 11;
            this.cbMotivo.Text = "Seleccione una opción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Motivo:";
            // 
            // cbHasta
            // 
            this.cbHasta.Enabled = false;
            this.cbHasta.FormattingEnabled = true;
            this.cbHasta.Location = new System.Drawing.Point(105, 80);
            this.cbHasta.Name = "cbHasta";
            this.cbHasta.Size = new System.Drawing.Size(90, 21);
            this.cbHasta.TabIndex = 9;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(111, 147);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(81, 28);
            this.btCancelar.TabIndex = 8;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btAeptar
            // 
            this.btAeptar.Image = ((System.Drawing.Image)(resources.GetObject("btAeptar.Image")));
            this.btAeptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAeptar.Location = new System.Drawing.Point(30, 147);
            this.btAeptar.Name = "btAeptar";
            this.btAeptar.Size = new System.Drawing.Size(75, 28);
            this.btAeptar.TabIndex = 7;
            this.btAeptar.Text = "Aceptar";
            this.btAeptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAeptar.UseVisualStyleBackColor = true;
            this.btAeptar.Click += new System.EventHandler(this.btAeptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desde:";
            // 
            // cbDesde
            // 
            this.cbDesde.Enabled = false;
            this.cbDesde.FormattingEnabled = true;
            this.cbDesde.Location = new System.Drawing.Point(9, 80);
            this.cbDesde.Name = "cbDesde";
            this.cbDesde.Size = new System.Drawing.Size(90, 21);
            this.cbDesde.TabIndex = 2;
            // 
            // rbRango
            // 
            this.rbRango.AutoSize = true;
            this.rbRango.Location = new System.Drawing.Point(9, 39);
            this.rbRango.Name = "rbRango";
            this.rbRango.Size = new System.Drawing.Size(115, 17);
            this.rbRango.TabIndex = 1;
            this.rbRango.Text = "Rango de equipos:";
            this.rbRango.UseVisualStyleBackColor = true;
            this.rbRango.CheckedChanged += new System.EventHandler(this.cbRango_CheckedChanged);
            // 
            // rbSala
            // 
            this.rbSala.AutoSize = true;
            this.rbSala.Checked = true;
            this.rbSala.Location = new System.Drawing.Point(9, 16);
            this.rbSala.Name = "rbSala";
            this.rbSala.Size = new System.Drawing.Size(83, 17);
            this.rbSala.TabIndex = 0;
            this.rbSala.TabStop = true;
            this.rbSala.Text = "Toda la sala";
            this.rbSala.UseVisualStyleBackColor = true;
            this.rbSala.CheckedChanged += new System.EventHandler(this.rbSala_CheckedChanged);
            // 
            // ReservarSala
            // 
            this.AcceptButton = this.btAeptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(234, 224);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReservarSala";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de sala";
            this.Load += new System.EventHandler(this.ReservarSala_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRango;
        private System.Windows.Forms.RadioButton rbSala;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDesde;
        private System.Windows.Forms.ComboBox cbHasta;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAeptar;
        private System.Windows.Forms.ComboBox cbMotivo;
        private System.Windows.Forms.Label label3;
    }
}