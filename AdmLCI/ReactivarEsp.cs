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
    public partial class ReactivarEsp: Form
    {
        
        Conexion abrir = new Conexion();
        DataTable info;
        Lista_especiales inst_esp = new Lista_especiales();
        DateTime h = DateTime.Today;
        Lista_especiales esp;
        Validacion validar = new Validacion();
        public static bool IsNumeric(object x)

{
      bool isNumber;
      double isItNumeric;
      isNumber = Double.TryParse(Convert.ToString(x), System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo, out isItNumeric );
      return isNumber;
}

        public void llenar() 
        {
            try
            {
                if (!(String.IsNullOrEmpty( textBox6.Text))){


                    if (IsNumeric(textBox6.Text))
                    {
                        String s = @"SELECT COUNT(*)
                              FROM AlumnoEspecial
                              WHERE ales_id = @Id or ales_exp_ext = @Id ";

                        if (abrir.Exists(textBox6.Text, s))
                        {
                            info = abrir.consultaLibreDT("SELECT * FROM AlumnoEspecial WHERE ales_exp_ext='" + textBox6.Text + "' or ales_id = " + textBox6.Text);
                            textBox1.Text = info.Rows[0]["ales_nombre"].ToString() + " " + info.Rows[0]["ales_ape_pat"].ToString() + " " + info.Rows[0]["ales_ape_mat"].ToString();
                            //  textBox4.Text = info.Rows[0][4].ToString();
                            textBox5.Text = info.Rows[0][5].ToString();
                            Justif.Text = info.Rows[0]["ales_motivo"].ToString();
                        }
                    }
                    else
                    {
                        String s = @"SELECT COUNT(*)
                              FROM AlumnoEspecial
                              WHERE ales_exp_ext = @Id ";

                        if (abrir.Exists(textBox6.Text, s))
                        {

                            info = abrir.consultaLibreDT("SELECT * FROM AlumnoEspecial WHERE ales_exp_ext='" + textBox6.Text + "' ");
                            textBox1.Text = info.Rows[0]["ales_nombre"].ToString() + " " + info.Rows[0]["ales_ape_pat"].ToString() + " " + info.Rows[0]["ales_ape_mat"].ToString();
                            // textBox4.Text = info.Rows[0][4].ToString();
                            textBox5.Text = info.Rows[0][5].ToString();
                            Justif.Text = info.Rows[0]["ales_motivo"].ToString();
                        }
                    }
                    
                 }
            }
            catch (NullReferenceException) { 
            
            
            }
 
        }

        public void press_buttons(object sender, KeyPressEventArgs e)
        {

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }


            else
            {
                if (e.KeyChar.ToString().Equals("."))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }

        }
        public ReactivarEsp(Lista_especiales e)
        {
            

            InitializeComponent();

            dateTimePicker1.MinDate = Convert.ToDateTime(abrir.consultaLibreS("SELECT getdate()"));
            esp = e;
                

            
        }
      
 

        private void button6_Click(object sender, EventArgs e)
        {
             this.Close();
        }



        private void btBuscar_Click(object sender, EventArgs e)
        {

            llenar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(textBox6.Text)))
            {
                if ((h.CompareTo(dateTimePicker1.Value) == 1))
                {
                    MessageBox.Show("La fecha de reactivacion debe ser mayor a la fecha actual.", "Alumnos Especiales",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (IsNumeric(textBox6.Text))
                    {

                        abrir.modificar("UPDATE AlumnoEspecial SET ales_estado = 'Activo' WHERE ales_id =" + textBox6.Text+" or ales_exp_ext="+textBox6.Text);
                    }
                    else
                    {
                        abrir.modificar("UPDATE AlumnoEspecial SET ales_estado = 'Activo' WHERE ales_exp_ext ='" + textBox6.Text+"'");
                    }

                    this.Close();
                    esp.tabla1.DataSource = abrir.consultaLibreDT("SELECT ales_estado AS 'Estado', (ales_nombre+' '+ales_ape_pat+' '+ales_ape_mat) AS 'Nombre',ales_id AS 'Expediente interno' ,ales_exp_ext AS 'Expediente externo',ales_fecha_inicio AS 'Fecha inicio', ales_fecha_fin 'Fecha limite' FROM AlumnoEspecial where ales_nombre!='root'");
           
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                llenar();
            }



        }

     
   
     
      

        
    }
    }

