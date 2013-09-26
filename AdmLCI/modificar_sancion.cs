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
    public partial class modificar_sancion : Form
    {
    
        Conexion abrir = new Conexion();
        Sanciones a;
        String id2;
        public modificar_sancion(Sanciones s, String fecha, String motivo,String id)
        {

            InitializeComponent(); 
         
            dateTimePicker1.MinDate = Convert.ToDateTime(fecha);
           
            richTextBox1.Text = motivo;

            a = s;
            id2 = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime h =Convert.ToDateTime( abrir.consultaLibreS("SELECT GETDATE()"));
            if (h.CompareTo(dateTimePicker1.Value) == 1)
            {
                MessageBox.Show("La fecha de sanción debe ser mayor a la fecha actual.", "Sanción",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            else
            {

                abrir.modificar("UPDATE Sancion SET sn_fecha_fin='" +
                             dateTimePicker1.Value.ToString("dd/MM/yyyy") +
                             "', sn_motivo='" + richTextBox1.Text + "' where sn_id="+id2);
                a.message = false;
                a.llenar();

                 this.Close();
               

            }

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            a.press_buttons(sender, e);
        }

 
      

 
    }
}
