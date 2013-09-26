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
    public partial class ConsultaResultado : Form
    {

        Conexion con = new Conexion();
        public ConsultaResultado(DataTable cons, string tipo, string exp)
        {
            InitializeComponent();

            
            if (tipo.Equals("Alumno"))
            {
                
                label5.Text = "Expediente:";
                label9.Text = "Nombre:";
                label9.Visible = true;
                lbNoEq.Visible = true;
                lbSala.Text = exp;

                DataTable alum = con.consultaLibreDT("select est_nombre from UsuarioLCI where est_expediente="+lbSala.Text);
                lbNoEq.Text = ""+alum.Rows[0][0];
            }

            else if (tipo.Equals("Uso Equipo"))
            {
               
                label5.Visible = true;
                label9.Visible = false;
                lbSala.Text = exp;
                label5.Text = "Equipo";
                lbNoEq.Visible = false;
            }

            else if (tipo.Equals("Mantenimiento Equipo"))
            {

                label5.Visible = true;
                label9.Visible = false;
                lbSala.Text = exp;
                label5.Text = "Equipo";
                lbNoEq.Visible = false;
            }

            dgvConsulta.DataSource = cons;

        }

        private void dgvSoft_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConsultaResultado_Load(object sender, EventArgs e)
        {

        }
    }
}
