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
   

    public partial class AgregarLocker: Form
    {
       Conexion abrir = new Conexion();
       AdmnLockers a;
        Sesion act ;
        String actual_año;
        String sem;


        public void agregar_lock() {

            String Dato = textBox1.Text;
            int Num_lock;
            bool conv = int.TryParse(Dato, out Num_lock);
            if (conv == true)
            {

                if (!(abrir.existe("lok_no", "Locker", "lok_no=" + Dato)))
                {
                    abrir.modificar("INSERT INTO Locker (lok_no,lok_semestre) VALUES('" + Dato + "'," + sem + ")");
                    abrir.modificar("INSERT INTO HistorialLocker (lok_no,hl_semestre)  VALUES('" + Dato + "'," + sem + ")");
                    abrir.modificar("INSERT INTO HistorialAcciones (ha_accion,usr_id,ha_objeto, ha_fecha) VALUES('Agregar'," + act.idUsr + ",'L"+textBox1.Text+"', getdate())");

                    a.limpiarPantalla();
                    a.intervalos[1] = (int.Parse(a.intervalos[1]) + 1).ToString();

                    a.comboboxintervalos(a.num);
                    a.hist_lock();
                

                }
                else
                {

                    textBox1.Text = "";
                    MessageBox.Show("El locker ya existe.Porfavor intenta con otro numero", "Lockers",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
                MessageBox.Show("Ingrese un numero.", "Lockers",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Text = "";
        }
       
        public void press_buttons(object sender, KeyPressEventArgs e)
        {

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }


            else
            {
                
                    e.Handled = true;
                
            }

        }
        public AgregarLocker(AdmnLockers e,Sesion sesion,String año , String semestre)
        {
            InitializeComponent();
            a = e;
            act=sesion;
            actual_año = año;
            sem = semestre;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            agregar_lock();
       
           DialogResult res = MessageBox.Show("¿Desea agregar otro Locker?", "Lockers", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
            if (res == DialogResult.No)
           {
               this.Close();
             

           }
           
              
        }

   

        private void button3_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            press_buttons(sender, e);

        }
      
}
    }

