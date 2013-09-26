using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdmLCI
{
   

    public partial class Eliminarlocker: Form
    {
       Conexion abrir = new Conexion();
       AdmnLockers a;
       Sesion act;
     

       DataTable lock_num;
       public void comboboxlock()
       {
           lock_num = abrir.consultaLibreDT("SELECT lok_no FROM Locker ");

           for (int i = 0; i < lock_num.Rows.Count; i++)
           {
               comboBox1.Items.Add(lock_num.Rows[i]["lok_no"]);
           }

       }
       
       
        public Eliminarlocker(AdmnLockers e,Sesion sesion)
        {
            InitializeComponent();
            comboboxlock();
            a = e;
            act = sesion;

        }

        private void button3_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex == -1)) {
                MessageBox.Show("Lockers","Seleccione un locker",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {

                DialogResult res = MessageBox.Show("¿Realmente desea borrar el locker seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    abrir.modificar("DELETE FROM Locker WHERE lok_no =" + comboBox1.SelectedItem.ToString());
                    abrir.modificar("INSERT INTO HistorialAcciones (ha_accion,usr_id,ha_objeto,ha_fecha) VALUES('Eliminar'," + act.idUsr + ",'L-" + comboBox1.SelectedItem.ToString() + "',getdate())");

                            
                    a.limpiarPantalla();
                    a.intervalos[1] = (int.Parse(a.intervalos[1]) - 1).ToString();
                 a.listarlockers(a.actual);
                    a.comboboxintervalos(a.num); 
                    this.Close();
                }
            }
        }

     

       
      
}
    }

