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
    public partial class VerSancionados : Form
    {
        Conexion abrir = new Conexion();
        String[] alias = { "ID",    "Motivo ", "Fecha de inicio", "Fecha de fin","Expediente" };
        String[] campos = {"sn_id", "sn_motivo","sn_fecha_inicio","sn_fecha_fin","est_expediente"};
        string sancion;
        Boolean filtro;
        Sanciones vnt_sn;
     
        public VerSancionados(string e,Sanciones r)
        {
          
            InitializeComponent();
            sancion = e;
               textBox1.Text=sancion;
               vnt_sn = r;
               cargar();

   
        }

     

      

        public void cargar() {


            if (!sancion.Equals(""))
            {
                if (abrir.existe("SELECT * FROM UsuarioLCI WHERE est_expediente =" + textBox1.Text))
                {
                    if (!filtro)
                    {
                        //  dataGridView1.DataSource = abrir.consultaLibreDT("SELECT sn_id AS 'ID',sn_motivo AS 'Motivo', sn_fecha_inicio AS 'Inicio de sanción' , sn_fecha_fin AS 'Fin de la sancion' ,usr_nombre AS 'Usuario' ,tpusr_id AS 'Tipo de usuario' FROM Sancion  INNER JOIN Usuario ON (Sancion.usr_id=Usuario.usr_id) Where est_expediente='" + sancion + "'");
                        dataGridView1.DataSource = abrir.consultaLibreDT("SELECT est_expediente AS 'Expediente',hs_motivo AS 'Motivo', hs_inicio AS 'Inicio sanción' , hs_fin AS 'Fin sanción' ,usr_nombre AS 'Nombre' ,tpusr_id AS 'Usuario'  FROM HistorialSancion INNER JOIN Usuario ON (HistorialSancion.usr_id=Usuario.usr_id) Where est_expediente='" + sancion + "'");
                    }
                }
                else
                {

                    MessageBox.Show("El alumno no se encuentra en la base de datos.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {

                sancion = textBox1.Text;
                dataGridView1.DataSource = abrir.consultaLibreDT("SELECT est_expediente AS 'Expediente',hs_motivo AS 'Motivo', hs_inicio AS 'Inicio sanción' , hs_fin AS 'Fin sanción' ,usr_nombre AS 'Nombre' ,tpusr_id AS 'Usuario'  FROM HistorialSancion INNER JOIN Usuario ON (HistorialSancion.usr_id=Usuario.usr_id) Where est_expediente='" + sancion + "'");
                filtro = false;
            }
     }

       

        private void button6_Click(object sender, EventArgs e)
        {
             this.Close();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
              
                cargar();
            
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            sancion = textBox1.Text;

            cargar();
        }


      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 9)
            {

                cargar();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            vnt_sn.press_buttons(sender, e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cargar();
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
       
       

       


     
    }
}
