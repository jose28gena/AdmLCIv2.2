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
   

    public partial class Desasignarlocker: Form
    {
       Conexion abrir = new Conexion();
       AdmnLockers a;
       String carrera;
       Sesion act;

       String actual = "select * from Locker ORDER BY lok_no";
       DataTable lock_num;
       public void comboboxlock()
       {
           lock_num = abrir.consultaLibreDT("SELECT lok_no FROM Locker where lok_estado='No Disponible'");

           for (int i = 0; i < lock_num.Rows.Count; i++)
           {
               comboBox1.Items.Add(lock_num.Rows[i]["lok_no"]);
           }
       }


       public Desasignarlocker(AdmnLockers e,Sesion s)
        {
            InitializeComponent();
            comboboxlock();
            a = e;
            act=s;

        }

        private void button3_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((comboBox1.SelectedIndex == -1))
                {
                    MessageBox.Show("Seleccione un locker", "Lockers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    DialogResult res = MessageBox.Show("¿Realmente desea desasignar el locker seleccionado?", "Lockers", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        abrir.modificar("UPDATE Locker SET est_nombre=null,est_carrera=null,est_expediente= null,lok_fecha_inicio=null,lok_fecha_fin=null,lok_estado='Disponible'"
                               + " WHERE lok_no= " + comboBox1.SelectedItem.ToString());

                        abrir.modificar("INSERT INTO HistorialAcciones (ha_accion,usr_id,ha_objeto) VALUES('Desasingar'," + act.idUsr + ",'L" + comboBox1.SelectedItem.ToString() + "')");

                        
                        a.limpiarPantalla();
                        a.hist_lock();
                        this.Close();
                    }
                }
            }
            catch (NullReferenceException) { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           cargar( abrir.consultaLibreS("Select est_expediente From Locker where lok_no="+comboBox1.SelectedItem.ToString()));
        }



        void cargar(String Exp)
        {

          
            DataTable fechas = abrir.consultaLibreDT("SELECT * FROM Locker WHERE est_expediente=" + Exp);
            if ((fechas.Rows[0]["est_carrera"].ToString()).Equals("null"))
            {
                carrera = "Maestro";
            }
            else
            {

                carrera = fechas.Rows[0]["est_carrera"].ToString();
            }
            textBox1.Text = fechas.Rows[0]["est_nombre"].ToString();
            textBox2.Text = carrera;
            textBox3.Text = DateTime.Parse(fechas.Rows[0]["lok_fecha_inicio"].ToString()).ToShortDateString();
            textBox4.Text = DateTime.Parse(fechas.Rows[0]["lok_fecha_fin"].ToString()).ToShortDateString();
            textBox5.Text = Exp;
            textBox6.Text = fechas.Rows[0]["lok_no"].ToString();
            textBox7.Text = fechas.Rows[0]["lok_semestre"].ToString();
        }

       
      
}
    }

