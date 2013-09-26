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
    public partial class AgregarSala : Form
    {
        PantallaPrincipal pantPri;
        Sesion sesion;

        public AgregarSala(PantallaPrincipal pp, Sesion s)
        {
            InitializeComponent();
            sesion = s;
            pantPri = pp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validacion v = new Validacion();
            if (!v.verificarEspacios(groupBox1))
            {
                
                    Conexion con = new Conexion();

                    if (tbNomSala.Text.Trim().Length<=2 && !con.existe("sa_letra", "Sala", "sa_letra='" + tbNomSala.Text.Trim()+"'"))
                    {
                        con.modificar("insert into Sala(sa_letra) values('" + tbNomSala.Text.Trim() + "')");
                        con.modificar("insert into HistorialAcciones (ha_accion,usr_id,ha_objeto,ha_fecha) values('Agregar','" + sesion.idUsr + "', 'S-" + tbNomSala.Text + "','" + (DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute) + "') ");
                        pantPri.listarSalas();
                        this.Close();
                    }
                    else
                        MessageBox.Show("La sala ya existe o el nombre es muy largo. El tamaño máximo es de dos caracteres.", "Agregar sala", MessageBoxButtons.OK, MessageBoxIcon.Error);

                

            }
            else
                MessageBox.Show("Debe escribir un nombre a la sala.", "Agregar sala", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AgregarSala_Load(object sender, EventArgs e)
        {

        }

        private void tbNomSala_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tbNomSala_TextChanged(object sender, EventArgs e)
        {
            Validacion v = new Validacion();
            tbNomSala.Text = v.validar(tbNomSala.Text);
            tbNomSala.Select(tbNomSala.Text.Length, 0);
            tbNomSala.CharacterCasing = CharacterCasing.Upper;

            string txtAnt = tbNomSala.Text;
            if (tbNomSala.Text.Length > 1) {
                tbNomSala.Text = tbNomSala.Text.Substring(0, 1);
            }
        }

    }
}
