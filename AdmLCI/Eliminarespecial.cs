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
    public partial class Eliminarespecial: Form
    {
        
        Conexion abrir = new Conexion();
        DataTable info;

        Lista_especiales esp;
        Validacion validar = new Validacion();
        


        public void llenar()
        {
            try
            {
                if (!(String.IsNullOrEmpty(textBox6.Text)))
                {


                    if (validar.IsNumeric(textBox6.Text))
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
            catch (NullReferenceException)
            {


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
        public Eliminarespecial(Lista_especiales e)
        {
            

            InitializeComponent();


            esp = e;
                

            
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(String.IsNullOrEmpty(textBox6.Text)))
                {


                    abrir.consultaLibreS("DELETE FROM AlumnoEspecial Where ales_id=" + info.Rows[0]["ales_id"].ToString() + " and ales_exp_ext='" + info.Rows[0]["ales_exp_ext"].ToString() + "'");
                    esp.cargar();
                    this.Close();
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Porfavor ingrese un expediente.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
             this.Close();
        }



        private void btBuscar_Click(object sender, EventArgs e)
        {

            llenar();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

