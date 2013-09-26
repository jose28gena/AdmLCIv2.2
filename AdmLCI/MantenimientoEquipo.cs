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
    public partial class MantenimientoEquipo : Form
    {
        Equipo equipo;
        InfoEquipo infEq;
        public MantenimientoEquipo(Equipo eq,InfoEquipo ie)
        {
            InitializeComponent();
            equipo = eq;
            infEq = ie;
            
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (cbJust.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una opción.");
                return;
            }
            
            DialogResult res = MessageBox.Show("¿Realmente desea poner en mantenimiento el equipo?", "Mantenimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Conexion con = new Conexion();
                Validacion v = new Validacion();
                if (con.modificar("UPDATE InvEquipo SET ieq_estado='Mantenimiento' WHERE sa_id=" + equipo.idSala + " and ieq_numero=" + equipo.numEquipo) && !v.verificarEspacios(groupBox1))
                {
                    equipo.cambiarImagenMantenimiento();
                    con.modificar("insert mntoeq(ieq_id,mnt_fecha,mnt_justificacion) values(" + equipo.idEquipo + ",GETDATE(), '"+cbJust.Items[cbJust.SelectedIndex].ToString()+"');");
                    equipo.estado = "Mantenimiento";
                    //equipo.AlumOcupante ="0";
                    infEq.lbEstado.Text = "Mantenimiento";
                  
                    infEq.lbCarrera.Text = "-";
                    infEq.lbExp.Text = "-";
                    infEq.lbNom.Text = "-";
                    infEq.Close();
                    this.Close();
                }
                else
                    MessageBox.Show("El equipo no pudo ser puesto en mantenimiento. Verifique si esta llenando toda la información solicitada.");
            }
        }

        private void MantenimientoEquipo_Load(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MantenimientoEquipo_FormClosing(object sender, FormClosingEventArgs e)
        {
            infEq.Close();
        }
    }
}
