namespace AdmLCI
{
    partial class AsignarComp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignarComp));
            this.label1 = new System.Windows.Forms.Label();
            this.tbHrsDisp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbExpediente = new System.Windows.Forms.TextBox();
            this.btTresHr = new System.Windows.Forms.Button();
            this.btDosHr = new System.Windows.Forms.Button();
            this.btUnaHr = new System.Windows.Forms.Button();
            this.lblNoEquipo = new System.Windows.Forms.Label();
            this.lblSala = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Expediente:";
            // 
            // tbHrsDisp
            // 
            this.tbHrsDisp.Enabled = false;
            this.tbHrsDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHrsDisp.Location = new System.Drawing.Point(107, 61);
            this.tbHrsDisp.Name = "tbHrsDisp";
            this.tbHrsDisp.Size = new System.Drawing.Size(69, 20);
            this.tbHrsDisp.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Horas disponibles:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(540, 25);
            this.panel3.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btBuscar);
            this.groupBox1.Controls.Add(this.btLimpiar);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tbNombre);
            this.groupBox1.Controls.Add(this.tbExpediente);
            this.groupBox1.Controls.Add(this.btTresHr);
            this.groupBox1.Controls.Add(this.btDosHr);
            this.groupBox1.Controls.Add(this.btUnaHr);
            this.groupBox1.Controls.Add(this.lblNoEquipo);
            this.groupBox1.Controls.Add(this.lblSala);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pbFoto);
            this.groupBox1.Controls.Add(this.tbHrsDisp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(9, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 169);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // btLimpiar
            // 
            this.btLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btLimpiar.Image")));
            this.btLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLimpiar.Location = new System.Drawing.Point(423, 137);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(71, 28);
            this.btLimpiar.TabIndex = 26;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(423, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 28);
            this.button2.TabIndex = 25;
            this.button2.Text = "Cancelar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(107, 37);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(301, 20);
            this.tbNombre.TabIndex = 2;
            this.tbNombre.TextChanged += new System.EventHandler(this.tbNombre_TextChanged);
            // 
            // tbExpediente
            // 
            this.tbExpediente.Location = new System.Drawing.Point(107, 13);
            this.tbExpediente.Name = "tbExpediente";
            this.tbExpediente.Size = new System.Drawing.Size(252, 20);
            this.tbExpediente.TabIndex = 1;
            this.tbExpediente.TextChanged += new System.EventHandler(this.tbExpediente_TextChanged_1);
            this.tbExpediente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExpediente_KeyPress);
            // 
            // btTresHr
            // 
            this.btTresHr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btTresHr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTresHr.Image = ((System.Drawing.Image)(resources.GetObject("btTresHr.Image")));
            this.btTresHr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btTresHr.Location = new System.Drawing.Point(253, 87);
            this.btTresHr.Name = "btTresHr";
            this.btTresHr.Size = new System.Drawing.Size(64, 55);
            this.btTresHr.TabIndex = 7;
            this.btTresHr.Text = "3 Horas";
            this.btTresHr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btTresHr.UseVisualStyleBackColor = true;
            this.btTresHr.Click += new System.EventHandler(this.btTresHr_Click);
            // 
            // btDosHr
            // 
            this.btDosHr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDosHr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDosHr.Image = ((System.Drawing.Image)(resources.GetObject("btDosHr.Image")));
            this.btDosHr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btDosHr.Location = new System.Drawing.Point(182, 87);
            this.btDosHr.Name = "btDosHr";
            this.btDosHr.Size = new System.Drawing.Size(65, 55);
            this.btDosHr.TabIndex = 6;
            this.btDosHr.Text = "2 Horas";
            this.btDosHr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btDosHr.UseVisualStyleBackColor = true;
            this.btDosHr.Click += new System.EventHandler(this.btDosHr_Click);
            // 
            // btUnaHr
            // 
            this.btUnaHr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btUnaHr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUnaHr.Image = ((System.Drawing.Image)(resources.GetObject("btUnaHr.Image")));
            this.btUnaHr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btUnaHr.Location = new System.Drawing.Point(117, 87);
            this.btUnaHr.Name = "btUnaHr";
            this.btUnaHr.Size = new System.Drawing.Size(59, 55);
            this.btUnaHr.TabIndex = 5;
            this.btUnaHr.Text = "1 Hora";
            this.btUnaHr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btUnaHr.UseVisualStyleBackColor = true;
            this.btUnaHr.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNoEquipo
            // 
            this.lblNoEquipo.AutoSize = true;
            this.lblNoEquipo.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoEquipo.Location = new System.Drawing.Point(470, 113);
            this.lblNoEquipo.Name = "lblNoEquipo";
            this.lblNoEquipo.Size = new System.Drawing.Size(0, 29);
            this.lblNoEquipo.TabIndex = 21;
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSala.Location = new System.Drawing.Point(449, 111);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(0, 29);
            this.lblSala.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Nombre:";
            // 
            // pbFoto
            // 
            this.pbFoto.Image = global::AdmLCI.Properties.Resources.alumno;
            this.pbFoto.Location = new System.Drawing.Point(414, 12);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(97, 90);
            this.pbFoto.TabIndex = 3;
            this.pbFoto.TabStop = false;
            // 
            // btBuscar
            // 
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btBuscar.Image")));
            this.btBuscar.Location = new System.Drawing.Point(376, 13);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(21, 20);
            this.btBuscar.TabIndex = 27;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // AsignarComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(539, 208);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 652);
            this.MinimizeBox = false;
            this.Name = "AsignarComp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar equipo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AsignarComp_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AsignarComp_FormClosed);
            this.Load += new System.EventHandler(this.AsignarComp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHrsDisp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNoEquipo;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.Button btUnaHr;
        private System.Windows.Forms.Button btTresHr;
        private System.Windows.Forms.Button btDosHr;
        private System.Windows.Forms.TextBox tbExpediente;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btBuscar;
    }
}