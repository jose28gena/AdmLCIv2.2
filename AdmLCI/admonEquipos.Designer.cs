namespace AdmLCI
{
    partial class admonEquipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admonEquipos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSalir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.cbOpc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 20);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSalir);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btAgregar);
            this.groupBox1.Controls.Add(this.btEliminar);
            this.groupBox1.Location = new System.Drawing.Point(8, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 388);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // btSalir
            // 
            this.btSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSalir.Image = ((System.Drawing.Image)(resources.GetObject("btSalir.Image")));
            this.btSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalir.Location = new System.Drawing.Point(6, 296);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(81, 85);
            this.btSalir.TabIndex = 8;
            this.btSalir.Text = "Salir";
            this.btSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(6, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 85);
            this.button1.TabIndex = 7;
            this.button1.Text = "Modificar equipo";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btAgregar
            // 
            this.btAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btAgregar.Image")));
            this.btAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregar.Location = new System.Drawing.Point(6, 23);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(81, 85);
            this.btAgregar.TabIndex = 0;
            this.btAgregar.Text = "Agregar equipo";
            this.btAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btEliminar.Image")));
            this.btEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEliminar.Location = new System.Drawing.Point(6, 205);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(81, 85);
            this.btEliminar.TabIndex = 1;
            this.btEliminar.Text = "Eliminar equipo";
            this.btEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AllowUserToOrderColumns = true;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipos.Location = new System.Drawing.Point(112, 63);
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(696, 356);
            this.dgvEquipos.TabIndex = 2;
            // 
            // cbOpc
            // 
            this.cbOpc.FormattingEnabled = true;
            this.cbOpc.Items.AddRange(new object[] {
            "Serie CPU",
            "Serie monitor",
            "No. de contraloría",
            "Sala"});
            this.cbOpc.Location = new System.Drawing.Point(311, 33);
            this.cbOpc.Name = "cbOpc";
            this.cbOpc.Size = new System.Drawing.Size(133, 21);
            this.cbOpc.TabIndex = 3;
            this.cbOpc.Text = "Seleccione una opción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtrar";
            // 
            // btBuscar
            // 
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btBuscar.Image")));
            this.btBuscar.Location = new System.Drawing.Point(450, 30);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(32, 26);
            this.btBuscar.TabIndex = 6;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // tbBuscar
            // 
            this.tbBuscar.Location = new System.Drawing.Point(149, 34);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(156, 20);
            this.tbBuscar.TabIndex = 7;
            this.tbBuscar.TextChanged += new System.EventHandler(this.tbBuscar_TextChanged_1);
            // 
            // admonEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btSalir;
            this.ClientSize = new System.Drawing.Size(816, 426);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbOpc);
            this.Controls.Add(this.dgvEquipos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(832, 464);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(832, 464);
            this.Name = "admonEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de equipos";
            this.Load += new System.EventHandler(this.admonEquipos_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.DataGridView dgvEquipos;
        private System.Windows.Forms.ComboBox cbOpc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.Button btSalir;
    }
}