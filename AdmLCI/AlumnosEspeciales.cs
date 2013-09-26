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
    public partial class AlumnosEspeciales : Form
    {
        
        Conexion abrir = new Conexion();
        DataTable info;
 
        String nombres = "";
        String Apellido1 = "";
        String Apellido2 = "";
        String exp1 = "";
        String exp2 = "";
        String date = "";
        String justificacion = "";
        String id;
      
        Boolean a;
     
        Lista_especiales vent;
        Validacion validar = new Validacion();

        public Boolean valid() { 
        Boolean flag=true;

         
        return flag;
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
        public AlumnosEspeciales(Lista_especiales x, Boolean s,String id_esp,String exp_esp)
        {
            id = id_esp;
            a = s;

            InitializeComponent();
            vent = x;

            dateTimePicker1.MinDate = Convert.ToDateTime(abrir.consultaLibreS("SELECT getdate()"));

            if (!a)
            {

                
                    DateTime h =Convert.ToDateTime( abrir.consultaLibreS("SELECT GETDATE()"));

                    if ((h.CompareTo(dateTimePicker1.Value) == 1))
                    {
                        if (!validar.verificarEspacios(groupBox1))
                        {
                            MessageBox.Show("La fecha de tiempo de uso debe ser mayor a la fecha actual.", "Sanción",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }else{

                    MessageBox.Show("Porfavor es necesario ingresar todos los campos.", "Usuarios especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                    }
                    else
                    {

                        
                        button1.Text = "Guardar";
                        info = abrir.consultaLibreDT("SELECT * FROM AlumnoEspecial WHERE ales_exp_ext='" + exp_esp + "' and ales_id = " + id);
                        textBox1.Text = info.Rows[0][1].ToString();
                        textBox2.Text = info.Rows[0][2].ToString();
                        textBox3.Text = info.Rows[0][3].ToString();
                        textBox4.Text = info.Rows[0][4].ToString();
                        
                        Justif.Text = info.Rows[0][7].ToString();
                        dateTimePicker1.Visible = false;
                        label8.Visible = false;

                        label5.Location = new Point(11, 117);
                        Justif.Location = new Point(14, 140);
                        button1.Location = new Point(14, 225);
                        button6.Location = new Point(88, 225);

                        this.Size = new Size(520, 340);
                        groupBox1.Size = new Size(494, 270);
                        }
              
             
                

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Lista_especiales ver = new Lista_especiales();
            ver.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String NombreComp;
            
                if (a)
                {
                    if (!validar.verificarEspacios(groupBox1))
                    {
                        
                      DateTime h = DateTime.Today;

                      if ((h.CompareTo(dateTimePicker1.Value) == 1))
                      {
                          MessageBox.Show("La fecha de tiempo de uso debe ser mayor a la fecha actual.", "Usuario especial",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);

                      }
                      else
                      {

                          date = dateTimePicker1.Value.ToString("dd-mm-yyyy");
                          nombres = textBox1.Text;
                          Apellido1 = textBox2.Text;
                          Apellido2 = textBox3.Text;

                          exp2 = textBox4.Text;

                          justificacion = Justif.Text;
                          NombreComp = nombres + " " + Apellido1 + " " + Apellido2;
                          if (!abrir.existe("SELECT * FROM AlumnoEspecial WHERE ales_nombre +' '+ ales_ape_pat + ' '+ ales_ape_mat LIKE '%" + NombreComp + "%'"))
                          {
                              //  if(abrir.existe("SELECT * FROM ALumnoEspecial WHERE ales_exp_ext='"+exp_e+"' "))
                              abrir.modificar("INSERT INTO AlumnoEspecial (ales_nombre,ales_ape_pat,ales_ape_mat,ales_exp_ext,ales_fecha_inicio,ales_fecha_fin,ales_motivo ) VALUES('" + nombres + "','" + Apellido1 + "','" + Apellido2 + "','" + exp2 + "',(getdate()),'" + (dateTimePicker1.Value.ToString("dd-MM-yyyy") + " 00:00:00.000") + " ','" + justificacion + "')");

                              MessageBox.Show("Se ha ingresado correctamente la informacion.", "Usuarios especiales",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                              vent.cargar();
                               this.Close();
                          }
                          else
                          {

                              MessageBox.Show("Ya existe un usuario con el nombre " + nombres + " " + Apellido1 + " " + Apellido2, "Usuarios especiales",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                          }
                      }
                }
                else
                {

                    MessageBox.Show("Porfavor es necesario ingresar todos los campos.", "Usuarios especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                }
                else
                {
                    if (!(string.IsNullOrEmpty(textBox4.Text)))
                    {


                        abrir.modificar("UPDATE AlumnoEspecial SET ales_nombre='" + textBox1.Text + "',ales_ape_pat='" + textBox2.Text + "',ales_ape_mat='" + textBox3.Text + "',ales_exp_ext='" + textBox4.Text + "'    ,ales_motivo='" + Justif.Text + "' WHERE ales_id=" + id);
                        MessageBox.Show("La información ha sido actualizada.", "Usuarios especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        vent.cargar();

                         this.Close();
                    }
                }

               
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void Justif_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (Char.IsNumber(e.KeyChar)) {
                e.Handled = false;
            }
               
            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            press_buttons(sender, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            press_buttons(sender, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            press_buttons(sender, e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            press_buttons(sender, e);
        }

        private void Justif_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            press_buttons(sender, e);
        }

        
    }
    }

