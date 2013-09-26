using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdmLCI.Properties;

namespace AdmLCI
{
    public partial class ReservarSala : Form
    {

        Sala sala;
        PantallaPrincipal pantPr;
        int numeroSala;

        public ReservarSala(Sala s, PantallaPrincipal pp, int numS)
        {
            InitializeComponent();
            sala=s;
            pantPr = pp;
            numeroSala = numS;

            Conexion con=new Conexion();
            DataTable dtSala = con.consultaLibreDT("select * from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where Sala.sa_letra='"+sala.nomSala+"'");
            for (int i = 0; i < dtSala.Rows.Count;i++ )
            {
                cbDesde.Items.Add(dtSala.Rows[i]["ieq_numero"]);
                cbHasta.Items.Add(dtSala.Rows[i]["ieq_numero"]);
            }

        }

        private void cbRango_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRango.Checked) {
                cbDesde.Enabled = true;
                cbHasta.Enabled = true;
            }
        }

        private void rbSala_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSala.Checked)
            {
                cbDesde.Enabled = false;
                cbHasta.Enabled = false;
            }

        }

        private void ReservarSala_Load(object sender, EventArgs e)
        {

        }

        private void btAeptar_Click(object sender, EventArgs e)
        {
            if (rbRango.Checked) {
                if (int.Parse(cbDesde.Items[cbDesde.SelectedIndex].ToString()) > int.Parse(cbHasta.Items[cbHasta.SelectedIndex].ToString())) {
                    MessageBox.Show("El número de equipo del campo \"Desde\" debe ser menor al del campo \"Hasta\"");
                }
            
            }

            if (cbMotivo.SelectedIndex < 0) {
                MessageBox.Show("Debe seleccionar un motivo.");
                return;
            }
            string contraMant = "1414";


            Conexion con = new Conexion();


            if (rbSala.Checked)
            {


                int bandera = 0;
                pantPr.btActivar.Enabled = true;
                pantPr.btMantenimiento.Enabled = false;


                DataTable dtEquipos = con.consultaLibreDT("select * from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where InvEquipo.sa_id=" + sala.idSala);
                con.modificar("update Sala set sa_estado='Mantenimiento' where sa_id=" + sala.idSala);
                con.modificar("update InvEquipo set ieq_estado='Mantenimiento', est_expediente='" + contraMant + "' where sa_id="+sala.idSala);

                for (int i = 0; i < dtEquipos.Rows.Count; i++)
                {
                    con.modificar("insert mntoeq(ieq_id,mnt_fecha,mnt_justificacion,ieq_numEq,ieq_sala,ieq_contraloria) values('" + dtEquipos.Rows[i]["ieq_id"] + "',GETDATE(), '"+cbMotivo.Items[cbMotivo.SelectedIndex]+"','" + dtEquipos.Rows[i]["ieq_numero"] + "','" + dtEquipos.Rows[i]["sa_letra"] + "','" + dtEquipos.Rows[i]["ieq_contraloria"] + "')");
                }




                pantPr.salas[numeroSala].estadoSala = "Mantenimiento";
                pantPr.salas[numeroSala].Image = Resources.salaMantenimiento;

                for (int j = 0; j < pantPr.salas[numeroSala].mesas.Length; j++)
                {
                    for (int k = 0; k < pantPr.salas[numeroSala].mesas[j].equipos.Length; k++)
                    {
                        if (pantPr.salas[numeroSala].mesas[j].equipos[k].estado.Equals("No Disponible"))
                            bandera = 1;
                        pantPr.salas[numeroSala].mesas[j].equipos[k].Image = Resources.computadoraMant2;
                        pantPr.salas[numeroSala].mesas[j].equipos[k].estado = "Mantenimiento";
                    }
                }

                this.Close();
            }
            else if(rbRango.Checked){
            
            }

        }

       
    }
}
