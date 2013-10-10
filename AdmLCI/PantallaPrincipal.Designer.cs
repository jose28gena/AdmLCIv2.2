namespace AdmLCI
{
    partial class PantallaPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gbListaSalas = new System.Windows.Forms.GroupBox();
            this.pnContSala = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTipoSesion = new System.Windows.Forms.Label();
            this.lblNomUsuario = new System.Windows.Forms.Label();
            this.lbTipUsr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbOpcSala = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btReservar = new System.Windows.Forms.Button();
            this.btBorrarSala = new System.Windows.Forms.Button();
            this.btMantenimiento = new System.Windows.Forms.Button();
            this.btActivar = new System.Windows.Forms.Button();
            this.btAgregarS = new System.Windows.Forms.Button();
            this.btReportes = new System.Windows.Forms.Button();
            this.btSanciones = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.btUsuario = new System.Windows.Forms.Button();
            this.btSoftware = new System.Windows.Forms.Button();
            this.btEspeciales = new System.Windows.Forms.Button();
            this.btLockers = new System.Windows.Forms.Button();
            this.btEquipos = new System.Windows.Forms.Button();
            this.btConsultas = new System.Windows.Forms.Button();
            this.lbHora = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tmrHora = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbSala = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbEq = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDetalles = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbEstado = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTiempo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbExp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btConfig = new System.Windows.Forms.Button();
            this.R_ReceiveMessage = new System.Windows.Forms.TextBox();
            this.L_Information = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.R_SendMessage = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbOpcSala.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1040, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gbListaSalas
            // 
            this.gbListaSalas.AutoSize = true;
            this.gbListaSalas.Location = new System.Drawing.Point(2, 2);
            this.gbListaSalas.Name = "gbListaSalas";
            this.gbListaSalas.Size = new System.Drawing.Size(87, 75);
            this.gbListaSalas.TabIndex = 105;
            this.gbListaSalas.TabStop = false;
            this.gbListaSalas.Text = "Salas";
            // 
            // pnContSala
            // 
            this.pnContSala.AutoScroll = true;
            this.pnContSala.BackColor = System.Drawing.SystemColors.Control;
            this.pnContSala.Location = new System.Drawing.Point(106, 104);
            this.pnContSala.Name = "pnContSala";
            this.pnContSala.Size = new System.Drawing.Size(597, 589);
            this.pnContSala.TabIndex = 106;
            this.pnContSala.Paint += new System.Windows.Forms.PaintEventHandler(this.pnContSala_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTipoSesion);
            this.groupBox3.Controls.Add(this.lblNomUsuario);
            this.groupBox3.Controls.Add(this.lbTipUsr);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(711, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 62);
            this.groupBox3.TabIndex = 108;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sesión";
            // 
            // lblTipoSesion
            // 
            this.lblTipoSesion.AutoSize = true;
            this.lblTipoSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoSesion.Location = new System.Drawing.Point(91, 38);
            this.lblTipoSesion.Name = "lblTipoSesion";
            this.lblTipoSesion.Size = new System.Drawing.Size(21, 13);
            this.lblTipoSesion.TabIndex = 7;
            this.lblTipoSesion.Text = "tip";
            // 
            // lblNomUsuario
            // 
            this.lblNomUsuario.AutoSize = true;
            this.lblNomUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUsuario.Location = new System.Drawing.Point(54, 19);
            this.lblNomUsuario.Name = "lblNomUsuario";
            this.lblNomUsuario.Size = new System.Drawing.Size(24, 13);
            this.lblNomUsuario.TabIndex = 6;
            this.lblNomUsuario.Text = "usr";
            // 
            // lbTipUsr
            // 
            this.lbTipUsr.AutoSize = true;
            this.lbTipUsr.Location = new System.Drawing.Point(8, 38);
            this.lbTipUsr.Name = "lbTipUsr";
            this.lbTipUsr.Size = new System.Drawing.Size(83, 13);
            this.lbTipUsr.TabIndex = 5;
            this.lbTipUsr.Text = "Tipo de usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gbListaSalas);
            this.panel1.Location = new System.Drawing.Point(1, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 589);
            this.panel1.TabIndex = 109;
            // 
            // gbOpcSala
            // 
            this.gbOpcSala.Controls.Add(this.button1);
            this.gbOpcSala.Controls.Add(this.btReservar);
            this.gbOpcSala.Controls.Add(this.btBorrarSala);
            this.gbOpcSala.Controls.Add(this.btMantenimiento);
            this.gbOpcSala.Controls.Add(this.btActivar);
            this.gbOpcSala.Controls.Add(this.btAgregarS);
            this.gbOpcSala.Location = new System.Drawing.Point(709, 227);
            this.gbOpcSala.Name = "gbOpcSala";
            this.gbOpcSala.Size = new System.Drawing.Size(323, 174);
            this.gbOpcSala.TabIndex = 110;
            this.gbOpcSala.TabStop = false;
            this.gbOpcSala.Text = "Opciones de sala";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(202, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 70);
            this.button1.TabIndex = 5;
            this.button1.Text = "Bloquear equipos";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btReservar
            // 
            this.btReservar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btReservar.Image = ((System.Drawing.Image)(resources.GetObject("btReservar.Image")));
            this.btReservar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btReservar.Location = new System.Drawing.Point(109, 94);
            this.btReservar.Name = "btReservar";
            this.btReservar.Size = new System.Drawing.Size(82, 70);
            this.btReservar.TabIndex = 4;
            this.btReservar.Text = "Desbloquear equipos";
            this.btReservar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btReservar.UseVisualStyleBackColor = true;
            this.btReservar.Click += new System.EventHandler(this.btReservar_Click);
            // 
            // btBorrarSala
            // 
            this.btBorrarSala.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBorrarSala.Image = ((System.Drawing.Image)(resources.GetObject("btBorrarSala.Image")));
            this.btBorrarSala.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btBorrarSala.Location = new System.Drawing.Point(16, 94);
            this.btBorrarSala.Name = "btBorrarSala";
            this.btBorrarSala.Size = new System.Drawing.Size(82, 70);
            this.btBorrarSala.TabIndex = 3;
            this.btBorrarSala.Text = "Eliminar sala";
            this.btBorrarSala.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btBorrarSala.UseVisualStyleBackColor = true;
            this.btBorrarSala.Click += new System.EventHandler(this.btBorrarSala_Click);
            // 
            // btMantenimiento
            // 
            this.btMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btMantenimiento.Image = ((System.Drawing.Image)(resources.GetObject("btMantenimiento.Image")));
            this.btMantenimiento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btMantenimiento.Location = new System.Drawing.Point(202, 18);
            this.btMantenimiento.Name = "btMantenimiento";
            this.btMantenimiento.Size = new System.Drawing.Size(87, 70);
            this.btMantenimiento.TabIndex = 2;
            this.btMantenimiento.Text = "Mantenimiento";
            this.btMantenimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btMantenimiento.UseVisualStyleBackColor = true;
            this.btMantenimiento.Click += new System.EventHandler(this.button9_Click);
            // 
            // btActivar
            // 
            this.btActivar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btActivar.Image = ((System.Drawing.Image)(resources.GetObject("btActivar.Image")));
            this.btActivar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btActivar.Location = new System.Drawing.Point(109, 18);
            this.btActivar.Name = "btActivar";
            this.btActivar.Size = new System.Drawing.Size(82, 70);
            this.btActivar.TabIndex = 1;
            this.btActivar.Text = "Activar sala";
            this.btActivar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btActivar.UseVisualStyleBackColor = true;
            this.btActivar.Click += new System.EventHandler(this.button8_Click);
            // 
            // btAgregarS
            // 
            this.btAgregarS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAgregarS.Image = ((System.Drawing.Image)(resources.GetObject("btAgregarS.Image")));
            this.btAgregarS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAgregarS.Location = new System.Drawing.Point(16, 18);
            this.btAgregarS.Name = "btAgregarS";
            this.btAgregarS.Size = new System.Drawing.Size(82, 70);
            this.btAgregarS.TabIndex = 0;
            this.btAgregarS.Text = "Agregar sala";
            this.btAgregarS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAgregarS.UseVisualStyleBackColor = true;
            this.btAgregarS.Click += new System.EventHandler(this.btAgregarS_Click);
            // 
            // btReportes
            // 
            this.btReportes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btReportes.Image = ((System.Drawing.Image)(resources.GetObject("btReportes.Image")));
            this.btReportes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btReportes.Location = new System.Drawing.Point(570, 27);
            this.btReportes.Name = "btReportes";
            this.btReportes.Size = new System.Drawing.Size(75, 75);
            this.btReportes.TabIndex = 104;
            this.btReportes.Text = "Reportes";
            this.btReportes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btReportes.UseVisualStyleBackColor = true;
            this.btReportes.Click += new System.EventHandler(this.btReportes_Click);
            // 
            // btSanciones
            // 
            this.btSanciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSanciones.Image = ((System.Drawing.Image)(resources.GetObject("btSanciones.Image")));
            this.btSanciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSanciones.Location = new System.Drawing.Point(489, 27);
            this.btSanciones.Name = "btSanciones";
            this.btSanciones.Size = new System.Drawing.Size(75, 75);
            this.btSanciones.TabIndex = 103;
            this.btSanciones.Text = "Sanciones";
            this.btSanciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSanciones.UseVisualStyleBackColor = true;
            this.btSanciones.Click += new System.EventHandler(this.button49_Click);
            // 
            // button48
            // 
            this.button48.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button48.Image = ((System.Drawing.Image)(resources.GetObject("button48.Image")));
            this.button48.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button48.Location = new System.Drawing.Point(944, 27);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(84, 75);
            this.button48.TabIndex = 102;
            this.button48.Text = "Cerrar sesión";
            this.button48.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.button48_Click);
            // 
            // btUsuario
            // 
            this.btUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btUsuario.Image")));
            this.btUsuario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btUsuario.Location = new System.Drawing.Point(408, 27);
            this.btUsuario.Name = "btUsuario";
            this.btUsuario.Size = new System.Drawing.Size(75, 75);
            this.btUsuario.TabIndex = 101;
            this.btUsuario.Text = "Cuenta de usuario";
            this.btUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btUsuario.UseVisualStyleBackColor = true;
            this.btUsuario.Click += new System.EventHandler(this.button6_Click);
            // 
            // btSoftware
            // 
            this.btSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSoftware.Image = ((System.Drawing.Image)(resources.GetObject("btSoftware.Image")));
            this.btSoftware.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSoftware.Location = new System.Drawing.Point(327, 27);
            this.btSoftware.Name = "btSoftware";
            this.btSoftware.Size = new System.Drawing.Size(75, 75);
            this.btSoftware.TabIndex = 100;
            this.btSoftware.Text = "Catálogo de Software";
            this.btSoftware.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSoftware.UseVisualStyleBackColor = true;
            this.btSoftware.Click += new System.EventHandler(this.btSoftware_Click);
            // 
            // btEspeciales
            // 
            this.btEspeciales.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btEspeciales.Image = ((System.Drawing.Image)(resources.GetObject("btEspeciales.Image")));
            this.btEspeciales.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEspeciales.Location = new System.Drawing.Point(246, 27);
            this.btEspeciales.Name = "btEspeciales";
            this.btEspeciales.Size = new System.Drawing.Size(75, 75);
            this.btEspeciales.TabIndex = 99;
            this.btEspeciales.Text = "Usuarios Especiales";
            this.btEspeciales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEspeciales.UseVisualStyleBackColor = true;
            this.btEspeciales.Click += new System.EventHandler(this.btEspeciales_Click);
            // 
            // btLockers
            // 
            this.btLockers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btLockers.Image = ((System.Drawing.Image)(resources.GetObject("btLockers.Image")));
            this.btLockers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btLockers.Location = new System.Drawing.Point(4, 27);
            this.btLockers.Name = "btLockers";
            this.btLockers.Size = new System.Drawing.Size(75, 75);
            this.btLockers.TabIndex = 98;
            this.btLockers.Text = "Lockers";
            this.btLockers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btLockers.UseVisualStyleBackColor = true;
            this.btLockers.Click += new System.EventHandler(this.button3_Click);
            // 
            // btEquipos
            // 
            this.btEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btEquipos.Image = ((System.Drawing.Image)(resources.GetObject("btEquipos.Image")));
            this.btEquipos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEquipos.Location = new System.Drawing.Point(166, 27);
            this.btEquipos.Name = "btEquipos";
            this.btEquipos.Size = new System.Drawing.Size(75, 75);
            this.btEquipos.TabIndex = 97;
            this.btEquipos.Text = "Equipos";
            this.btEquipos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEquipos.UseVisualStyleBackColor = true;
            this.btEquipos.Click += new System.EventHandler(this.button2_Click);
            // 
            // btConsultas
            // 
            this.btConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btConsultas.Image = ((System.Drawing.Image)(resources.GetObject("btConsultas.Image")));
            this.btConsultas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btConsultas.Location = new System.Drawing.Point(85, 27);
            this.btConsultas.Name = "btConsultas";
            this.btConsultas.Size = new System.Drawing.Size(75, 75);
            this.btConsultas.TabIndex = 96;
            this.btConsultas.Text = "Consultas";
            this.btConsultas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConsultas.UseVisualStyleBackColor = true;
            this.btConsultas.Click += new System.EventHandler(this.btConsultas_Click);
            // 
            // lbHora
            // 
            this.lbHora.AutoSize = true;
            this.lbHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.Location = new System.Drawing.Point(13, 17);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(16, 24);
            this.lbHora.TabIndex = 111;
            this.lbHora.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbHora);
            this.groupBox1.Location = new System.Drawing.Point(711, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 50);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hora:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tmrHora
            // 
            this.tmrHora.Enabled = true;
            this.tmrHora.Interval = 1000;
            this.tmrHora.Tick += new System.EventHandler(this.tmrHora_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbSala);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbEq);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbDetalles);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbEstado);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lbTiempo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lbNombre);
            this.groupBox2.Controls.Add(this.lbExp);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(711, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 165);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de equipo:";
            // 
            // lbSala
            // 
            this.lbSala.AutoSize = true;
            this.lbSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSala.Location = new System.Drawing.Point(196, 25);
            this.lbSala.Name = "lbSala";
            this.lbSala.Size = new System.Drawing.Size(11, 13);
            this.lbSala.TabIndex = 21;
            this.lbSala.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Sala:";
            // 
            // lbEq
            // 
            this.lbEq.AutoSize = true;
            this.lbEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEq.Location = new System.Drawing.Point(63, 25);
            this.lbEq.Name = "lbEq";
            this.lbEq.Size = new System.Drawing.Size(11, 13);
            this.lbEq.TabIndex = 19;
            this.lbEq.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Equipo:";
            // 
            // lbDetalles
            // 
            this.lbDetalles.AutoSize = true;
            this.lbDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetalles.Location = new System.Drawing.Point(66, 128);
            this.lbDetalles.Name = "lbDetalles";
            this.lbDetalles.Size = new System.Drawing.Size(11, 13);
            this.lbDetalles.TabIndex = 17;
            this.lbDetalles.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Detalles:";
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstado.Location = new System.Drawing.Point(107, 108);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(11, 13);
            this.lbEstado.TabIndex = 15;
            this.lbEstado.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Estado del equipo:";
            // 
            // lbTiempo
            // 
            this.lbTiempo.AutoSize = true;
            this.lbTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTiempo.Location = new System.Drawing.Point(100, 87);
            this.lbTiempo.Name = "lbTiempo";
            this.lbTiempo.Size = new System.Drawing.Size(11, 13);
            this.lbTiempo.TabIndex = 13;
            this.lbTiempo.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tiempo asignado:";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.Location = new System.Drawing.Point(56, 67);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(11, 13);
            this.lbNombre.TabIndex = 11;
            this.lbNombre.Text = "-";
            // 
            // lbExp
            // 
            this.lbExp.AutoSize = true;
            this.lbExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExp.Location = new System.Drawing.Point(87, 48);
            this.lbExp.Name = "lbExp";
            this.lbExp.Size = new System.Drawing.Size(11, 13);
            this.lbExp.TabIndex = 10;
            this.lbExp.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Expediente:";
            // 
            // btConfig
            // 
            this.btConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btConfig.Image = ((System.Drawing.Image)(resources.GetObject("btConfig.Image")));
            this.btConfig.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btConfig.Location = new System.Drawing.Point(849, 27);
            this.btConfig.Name = "btConfig";
            this.btConfig.Size = new System.Drawing.Size(89, 75);
            this.btConfig.TabIndex = 114;
            this.btConfig.Text = "Configuración";
            this.btConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConfig.UseVisualStyleBackColor = true;
            this.btConfig.Click += new System.EventHandler(this.btConfig_Click);
            // 
            // R_ReceiveMessage
            // 
            this.R_ReceiveMessage.Location = new System.Drawing.Point(806, 609);
            this.R_ReceiveMessage.Name = "R_ReceiveMessage";
            this.R_ReceiveMessage.Size = new System.Drawing.Size(112, 20);
            this.R_ReceiveMessage.TabIndex = 116;
            // 
            // L_Information
            // 
            this.L_Information.AutoSize = true;
            this.L_Information.Location = new System.Drawing.Point(717, 591);
            this.L_Information.Name = "L_Information";
            this.L_Information.Size = new System.Drawing.Size(71, 13);
            this.L_Information.TabIndex = 117;
            this.L_Information.Text = "L_Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(719, 609);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "Mensajes";
            // 
            // R_SendMessage
            // 
            this.R_SendMessage.Location = new System.Drawing.Point(806, 635);
            this.R_SendMessage.Name = "R_SendMessage";
            this.R_SendMessage.Size = new System.Drawing.Size(112, 20);
            this.R_SendMessage.TabIndex = 119;
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 693);
            this.Controls.Add(this.R_SendMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.L_Information);
            this.Controls.Add(this.R_ReceiveMessage);
            this.Controls.Add(this.btConfig);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbOpcSala);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnContSala);
            this.Controls.Add(this.btReportes);
            this.Controls.Add(this.btSanciones);
            this.Controls.Add(this.button48);
            this.Controls.Add(this.btUsuario);
            this.Controls.Add(this.btSoftware);
            this.Controls.Add(this.btEspeciales);
            this.Controls.Add(this.btLockers);
            this.Controls.Add(this.btEquipos);
            this.Controls.Add(this.btConsultas);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PantallaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PantallaPrincipal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PantallaPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.PantallaPrincipal_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbOpcSala.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btReportes;
        private System.Windows.Forms.Button btSanciones;
        private System.Windows.Forms.Button button48;
        private System.Windows.Forms.Button btUsuario;
        private System.Windows.Forms.Button btSoftware;
        private System.Windows.Forms.Button btEspeciales;
        private System.Windows.Forms.Button btLockers;
        private System.Windows.Forms.Button btEquipos;
        private System.Windows.Forms.Button btConsultas;
        private System.Windows.Forms.GroupBox gbListaSalas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTipoSesion;
        private System.Windows.Forms.Label lblNomUsuario;
        private System.Windows.Forms.Label lbTipUsr;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel pnContSala;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbOpcSala;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer tmrHora;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lbNombre;
        public System.Windows.Forms.Label lbExp;
        public System.Windows.Forms.Label lbTiempo;
        public System.Windows.Forms.Label lbEstado;
        public System.Windows.Forms.Label lbDetalles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lbSala;
        public System.Windows.Forms.Label lbEq;
        private System.Windows.Forms.Button btConfig;
        public System.Windows.Forms.Button btAgregarS;
        public System.Windows.Forms.Button btMantenimiento;
        public System.Windows.Forms.Button btActivar;
        public System.Windows.Forms.Button btBorrarSala;
        public System.Windows.Forms.Button btReservar;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox R_ReceiveMessage;
        private System.Windows.Forms.Label L_Information;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox R_SendMessage;
    }
}

