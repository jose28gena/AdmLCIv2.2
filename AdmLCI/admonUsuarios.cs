using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdmLCI
{
    public partial class admonUsuarios : Form
    {
        Conexion con = new Conexion();
        DataTable dtUsr;

        public admonUsuarios()
        {
            InitializeComponent();
            cargarUsuarios();
        }

        public void cargarUsuarios() {
            dtUsr = con.consultaLibreDT("SELECT Usuario.usr_id AS 'ID',Usuario.usr_nombre AS 'Nombre', Usuario.usr_usuario AS 'Usuario',Tipo_Usuario.tpusr_descr AS 'Tipo de usuario' FROM Usuario INNER JOIN Tipo_Usuario on Usuario.tpusr_id=Tipo_Usuario.tpusr_id");
            dgvUsr.DataSource = dtUsr;
            dgvUsr.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            agregarUsuario au = new agregarUsuario(this);
            au.Show();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

        }

        private void admonUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = con.consultaLibreDT("select * from Usuario inner join Tipo_Usuario on Usuario.tpusr_id=Tipo_Usuario.tpusr_id where Usuario.usr_id=" + dgvUsr.CurrentRow.Cells[0].Value.ToString());
            agregarUsuario au = new agregarUsuario(this,dt);
            au.Show();
        }
    }
}
