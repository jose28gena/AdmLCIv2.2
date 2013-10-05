namespace AdmLCI
{
    partial class admonReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admonReporte));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbHora2 = new System.Windows.Forms.ComboBox();
            this.cbHora1 = new System.Windows.Forms.ComboBox();
            this.dtpFecha3 = new System.Windows.Forms.DateTimePicker();
            this.rbHora = new System.Windows.Forms.RadioButton();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.rbLibre = new System.Windows.Forms.RadioButton();
            this.cbAnio2 = new System.Windows.Forms.ComboBox();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.dtpDia = new System.Windows.Forms.DateTimePicker();
            this.rbMes = new System.Windows.Forms.RadioButton();
            this.rbDia = new System.Windows.Forms.RadioButton();
            this.cbAnio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbJuDi = new System.Windows.Forms.RadioButton();
            this.rbEnJu = new System.Windows.Forms.RadioButton();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbRestricciones = new System.Windows.Forms.ComboBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.gbFiltrar = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbeq2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbMaquina = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rbSala = new System.Windows.Forms.RadioButton();
            this.tbsala2 = new System.Windows.Forms.TextBox();
            this.tbSala = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbFiltrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 25);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Reporte:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHora2);
            this.groupBox1.Controls.Add(this.cbHora1);
            this.groupBox1.Controls.Add(this.dtpFecha3);
            this.groupBox1.Controls.Add(this.rbHora);
            this.groupBox1.Controls.Add(this.dtpFecha2);
            this.groupBox1.Controls.Add(this.dtpFecha1);
            this.groupBox1.Controls.Add(this.rbLibre);
            this.groupBox1.Controls.Add(this.cbAnio2);
            this.groupBox1.Controls.Add(this.cbMes);
            this.groupBox1.Controls.Add(this.dtpDia);
            this.groupBox1.Controls.Add(this.rbMes);
            this.groupBox1.Controls.Add(this.rbDia);
            this.groupBox1.Controls.Add(this.cbAnio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbJuDi);
            this.groupBox1.Controls.Add(this.rbEnJu);
            this.groupBox1.Location = new System.Drawing.Point(12, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 217);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Periodo";
            // 
            // cbHora2
            // 
            this.cbHora2.Enabled = false;
            this.cbHora2.FormattingEnabled = true;
            this.cbHora2.Items.AddRange(new object[] {
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19"});
            this.cbHora2.Location = new System.Drawing.Point(138, 180);
            this.cbHora2.Name = "cbHora2";
            this.cbHora2.Size = new System.Drawing.Size(71, 21);
            this.cbHora2.TabIndex = 25;
            this.cbHora2.Text = "Seleccione hora";
            // 
            // cbHora1
            // 
            this.cbHora1.Enabled = false;
            this.cbHora1.FormattingEnabled = true;
            this.cbHora1.Items.AddRange(new object[] {
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19"});
            this.cbHora1.Location = new System.Drawing.Point(58, 180);
            this.cbHora1.Name = "cbHora1";
            this.cbHora1.Size = new System.Drawing.Size(74, 21);
            this.cbHora1.TabIndex = 24;
            this.cbHora1.Text = "Seleccione hora";
            this.cbHora1.SelectedIndexChanged += new System.EventHandler(this.cbHora1_SelectedIndexChanged);
            // 
            // dtpFecha3
            // 
            this.dtpFecha3.Enabled = false;
            this.dtpFecha3.Location = new System.Drawing.Point(58, 158);
            this.dtpFecha3.Name = "dtpFecha3";
            this.dtpFecha3.Size = new System.Drawing.Size(198, 20);
            this.dtpFecha3.TabIndex = 23;
            // 
            // rbHora
            // 
            this.rbHora.AutoSize = true;
            this.rbHora.Location = new System.Drawing.Point(9, 160);
            this.rbHora.Name = "rbHora";
            this.rbHora.Size = new System.Drawing.Size(53, 17);
            this.rbHora.TabIndex = 22;
            this.rbHora.Text = "Horas";
            this.rbHora.UseVisualStyleBackColor = true;
            this.rbHora.CheckedChanged += new System.EventHandler(this.rbHora_CheckedChanged);
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Location = new System.Drawing.Point(63, 41);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(198, 20);
            this.dtpFecha2.TabIndex = 4;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Location = new System.Drawing.Point(63, 17);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(198, 20);
            this.dtpFecha1.TabIndex = 3;
            // 
            // rbLibre
            // 
            this.rbLibre.AutoSize = true;
            this.rbLibre.Checked = true;
            this.rbLibre.Location = new System.Drawing.Point(9, 17);
            this.rbLibre.Name = "rbLibre";
            this.rbLibre.Size = new System.Drawing.Size(48, 17);
            this.rbLibre.TabIndex = 19;
            this.rbLibre.TabStop = true;
            this.rbLibre.Text = "Libre";
            this.rbLibre.UseVisualStyleBackColor = true;
            this.rbLibre.CheckedChanged += new System.EventHandler(this.rbLibre_CheckedChanged);
            // 
            // cbAnio2
            // 
            this.cbAnio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnio2.Enabled = false;
            this.cbAnio2.FormattingEnabled = true;
            this.cbAnio2.Location = new System.Drawing.Point(179, 136);
            this.cbAnio2.Name = "cbAnio2";
            this.cbAnio2.Size = new System.Drawing.Size(115, 21);
            this.cbAnio2.TabIndex = 18;
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.Enabled = false;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cbMes.Location = new System.Drawing.Point(58, 136);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(115, 21);
            this.cbMes.TabIndex = 17;
            // 
            // dtpDia
            // 
            this.dtpDia.Enabled = false;
            this.dtpDia.Location = new System.Drawing.Point(58, 114);
            this.dtpDia.Name = "dtpDia";
            this.dtpDia.Size = new System.Drawing.Size(198, 20);
            this.dtpDia.TabIndex = 16;
            // 
            // rbMes
            // 
            this.rbMes.AutoSize = true;
            this.rbMes.Location = new System.Drawing.Point(9, 137);
            this.rbMes.Name = "rbMes";
            this.rbMes.Size = new System.Drawing.Size(45, 17);
            this.rbMes.TabIndex = 15;
            this.rbMes.Text = "Mes";
            this.rbMes.UseVisualStyleBackColor = true;
            this.rbMes.CheckedChanged += new System.EventHandler(this.rbMes_CheckedChanged);
            // 
            // rbDia
            // 
            this.rbDia.AutoSize = true;
            this.rbDia.Location = new System.Drawing.Point(9, 114);
            this.rbDia.Name = "rbDia";
            this.rbDia.Size = new System.Drawing.Size(43, 17);
            this.rbDia.TabIndex = 14;
            this.rbDia.Text = "Día";
            this.rbDia.UseVisualStyleBackColor = true;
            this.rbDia.CheckedChanged += new System.EventHandler(this.rbDia_CheckedChanged);
            // 
            // cbAnio
            // 
            this.cbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnio.Enabled = false;
            this.cbAnio.FormattingEnabled = true;
            this.cbAnio.Location = new System.Drawing.Point(81, 84);
            this.cbAnio.Name = "cbAnio";
            this.cbAnio.Size = new System.Drawing.Size(115, 21);
            this.cbAnio.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Año";
            // 
            // rbJuDi
            // 
            this.rbJuDi.AutoSize = true;
            this.rbJuDi.Location = new System.Drawing.Point(9, 91);
            this.rbJuDi.Name = "rbJuDi";
            this.rbJuDi.Size = new System.Drawing.Size(57, 17);
            this.rbJuDi.TabIndex = 1;
            this.rbJuDi.Text = "Jul-Dic";
            this.rbJuDi.UseVisualStyleBackColor = true;
            this.rbJuDi.CheckedChanged += new System.EventHandler(this.rbJuDi_CheckedChanged);
            // 
            // rbEnJu
            // 
            this.rbEnJu.AutoSize = true;
            this.rbEnJu.Location = new System.Drawing.Point(9, 69);
            this.rbEnJu.Name = "rbEnJu";
            this.rbEnJu.Size = new System.Drawing.Size(64, 17);
            this.rbEnJu.TabIndex = 0;
            this.rbEnJu.Text = "Ene-Jun";
            this.rbEnJu.UseVisualStyleBackColor = true;
            this.rbEnJu.CheckedChanged += new System.EventHandler(this.rbEnJu_CheckedChanged);
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Reporte de acceso al LCI",
            "Reporte de software",
            "Reporte de equipos",
            "Reporte de reasignaciones"});
            this.cbTipo.Location = new System.Drawing.Point(63, 31);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(211, 21);
            this.cbTipo.TabIndex = 1;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbRestricciones);
            this.groupBox2.Location = new System.Drawing.Point(12, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 51);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restricciones";
            // 
            // cbRestricciones
            // 
            this.cbRestricciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRestricciones.FormattingEnabled = true;
            this.cbRestricciones.Location = new System.Drawing.Point(9, 19);
            this.cbRestricciones.Name = "cbRestricciones";
            this.cbRestricciones.Size = new System.Drawing.Size(243, 21);
            this.cbRestricciones.TabIndex = 2;
            this.cbRestricciones.SelectedIndexChanged += new System.EventHandler(this.cbRestricciones_SelectedIndexChanged);
            // 
            // btCancelar
            // 
            this.btCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(282, 62);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(77, 25);
            this.btCancelar.TabIndex = 53;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btAceptar
            // 
            this.btAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btAceptar.BackgroundImage")));
            this.btAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(282, 31);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(77, 25);
            this.btAceptar.TabIndex = 52;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // gbFiltrar
            // 
            this.gbFiltrar.Controls.Add(this.label5);
            this.gbFiltrar.Controls.Add(this.tbeq2);
            this.gbFiltrar.Controls.Add(this.label4);
            this.gbFiltrar.Controls.Add(this.rbMaquina);
            this.gbFiltrar.Controls.Add(this.label3);
            this.gbFiltrar.Controls.Add(this.rbSala);
            this.gbFiltrar.Controls.Add(this.tbsala2);
            this.gbFiltrar.Controls.Add(this.tbSala);
            this.gbFiltrar.Location = new System.Drawing.Point(12, 334);
            this.gbFiltrar.Name = "gbFiltrar";
            this.gbFiltrar.Size = new System.Drawing.Size(271, 124);
            this.gbFiltrar.TabIndex = 54;
            this.gbFiltrar.TabStop = false;
            this.gbFiltrar.Text = "Filtrar";
            this.gbFiltrar.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Sala:";
            // 
            // tbeq2
            // 
            this.tbeq2.Enabled = false;
            this.tbeq2.Location = new System.Drawing.Point(213, 99);
            this.tbeq2.Name = "tbeq2";
            this.tbeq2.Size = new System.Drawing.Size(48, 20);
            this.tbeq2.TabIndex = 16;
            this.tbeq2.TextChanged += new System.EventHandler(this.tbeq2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Num. de equipo:";
            // 
            // rbMaquina
            // 
            this.rbMaquina.AutoSize = true;
            this.rbMaquina.Location = new System.Drawing.Point(8, 78);
            this.rbMaquina.Name = "rbMaquina";
            this.rbMaquina.Size = new System.Drawing.Size(58, 17);
            this.rbMaquina.TabIndex = 14;
            this.rbMaquina.TabStop = true;
            this.rbMaquina.Text = "Equipo";
            this.rbMaquina.UseVisualStyleBackColor = true;
            this.rbMaquina.CheckedChanged += new System.EventHandler(this.rbMaquina_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sala:";
            // 
            // rbSala
            // 
            this.rbSala.AutoSize = true;
            this.rbSala.Location = new System.Drawing.Point(9, 19);
            this.rbSala.Name = "rbSala";
            this.rbSala.Size = new System.Drawing.Size(46, 17);
            this.rbSala.TabIndex = 2;
            this.rbSala.TabStop = true;
            this.rbSala.Text = "Sala";
            this.rbSala.UseVisualStyleBackColor = true;
            this.rbSala.CheckedChanged += new System.EventHandler(this.rbSala_CheckedChanged);
            // 
            // tbsala2
            // 
            this.tbsala2.Enabled = false;
            this.tbsala2.Location = new System.Drawing.Point(72, 98);
            this.tbsala2.Name = "tbsala2";
            this.tbsala2.Size = new System.Drawing.Size(51, 20);
            this.tbsala2.TabIndex = 1;
            this.tbsala2.TextChanged += new System.EventHandler(this.tbsala2_TextChanged);
            // 
            // tbSala
            // 
            this.tbSala.Enabled = false;
            this.tbSala.Location = new System.Drawing.Point(59, 41);
            this.tbSala.Name = "tbSala";
            this.tbSala.Size = new System.Drawing.Size(70, 20);
            this.tbSala.TabIndex = 0;
            this.tbSala.TextChanged += new System.EventHandler(this.tbSala_TextChanged);
            // 
            // admonReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(370, 336);
            this.Controls.Add(this.gbFiltrar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTipo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "admonReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.admonReporte_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbFiltrar.ResumeLayout(false);
            this.gbFiltrar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbRestricciones;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.ComboBox cbAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbJuDi;
        private System.Windows.Forms.RadioButton rbEnJu;
        private System.Windows.Forms.GroupBox gbFiltrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbSala;
        private System.Windows.Forms.TextBox tbsala2;
        private System.Windows.Forms.TextBox tbSala;
        private System.Windows.Forms.RadioButton rbMaquina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbeq2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbDia;
        private System.Windows.Forms.RadioButton rbMes;
        private System.Windows.Forms.DateTimePicker dtpDia;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbAnio2;
        private System.Windows.Forms.RadioButton rbLibre;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.RadioButton rbHora;
        private System.Windows.Forms.DateTimePicker dtpFecha3;
        private System.Windows.Forms.ComboBox cbHora2;
        private System.Windows.Forms.ComboBox cbHora1;
    }
}