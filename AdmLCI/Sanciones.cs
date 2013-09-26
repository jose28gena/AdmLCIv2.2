using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AdmLCI
{
    public partial class Sanciones : Form
    {
        Conexion abrir = new Conexion();
        String Hora =  DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second ;
        DateTime h = DateTime.Today;
        String expediente;
        Sesion recivir_sesion;
        DataTable est;
        DataTable sn;
        String carrera;
       public Boolean message;
       public Boolean message2;
     
        public Sanciones(Sesion sesion)
        {
            InitializeComponent();
            textBox5.Text = h.ToShortDateString();
            recivir_sesion = sesion;
            
            dateTimePicker1.MinDate = Convert.ToDateTime(abrir.consultaLibreS("SELECT getdate()"));

           }

        public void llenar()
        {
            label1.Visible = false;
            label3.Visible = false;
          est = abrir.consultaLibreDT("SELECT * From UsuarioLCI WHERE est_expediente=" + textBox1.Text);
          sn = abrir.consultaLibreDT("SELECT * From Sancion WHERE est_expediente=" + textBox1.Text);
          message = abrir.existe("est_expediente", "Sancion", "est_expediente=" + textBox1.Text);
          message2 = abrir.existe("SELECT est_expediente From HistorialSancion WHERE est_expediente=" + textBox1.Text);
          pictureBox1.Image = null;
                 if ((abrir.existe("est_expediente", "UsuarioLCI", "est_expediente=" + textBox1.Text)))
                {
                    if (!(abrir.existe("est_expediente", "Sancion", "est_expediente=" + textBox1.Text)))
                    {
                        if ((est.Rows[0]["est_carrera"].ToString()).Equals("null"))
                        {
                            carrera = "Maestro";
                        }
                        else
                        {
                            carrera = est.Rows[0]["est_carrera"].ToString();
                        }
                        button4.Enabled = true;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        textBox2.Text = est.Rows[0]["est_nombre"].ToString();
                        textBox3.Text =carrera;
                        textBox5.Text = h.ToString("dd/MM/yyyy");

                        if (!(String.IsNullOrEmpty((est.Rows[0]["est_foto"].ToString()))))
                        {

                            pictureBox1.Image = Base64ToImage(est.Rows[0]["est_foto"].ToString());
                        }

                    }
                    else {
                       
             if ((est.Rows[0]["est_carrera"].ToString()).Equals("null"))
             {
                 carrera = "Maestro";
             }
             else
             {

                 carrera = est.Rows[0]["est_carrera"].ToString();
             }
                        textBox2.Text = est.Rows[0]["est_nombre"].ToString();
                        textBox3.Text = carrera;
                        textBox5.Text = Convert.ToDateTime( sn.Rows[0]["sn_fecha_inicio"].ToString()).ToShortDateString();

                        Justif.Text = sn.Rows[0]["sn_motivo"].ToString();
                       
                       dateTimePicker1.MinDate =Convert.ToDateTime( sn.Rows[0]["sn_fecha_fin"].ToString());
                       dateTimePicker1.Enabled = false;
                       button4.Enabled = false;
                       button2.Enabled = true;
                       button1.Enabled = true;

                       if (!(String.IsNullOrEmpty((est.Rows[0]["est_foto"].ToString()))))
                       {

                            pictureBox1.Image = Base64ToImage(est.Rows[0]["est_foto"].ToString());
                        }

                    
                    }
                
                 }
                 else
                 {


                    MessageBox.Show("No se encuentra el expediente ingresado.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                 if (message && message2)
                 {
                     label1.Visible = true;

                     label3.Visible = true;
                 }
                 else if (message)
                 {
                     label3.Visible = true;
                     label3.Location = new Point(19, 281);

                 }
                 else if (message2)
                 {
                     label1.Visible = true;
                     label1.Location = new Point(19, 281);
                 }
            
        }
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dt1 = new DateTime();
            dt1 = Convert.ToDateTime(this.dateTimePicker1.Value);
          

                if (!Justif.Text.Equals(""))
                {
                    if ((h.CompareTo(dateTimePicker1.Value) == 1))
                    {
                        MessageBox.Show("La fecha de sanción debe ser mayor a la fecha actual.", "Sanción",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {


                        abrir.modificar("INSERT INTO Sancion (sn_motivo,sn_fecha_inicio,sn_fecha_fin,est_expediente,usr_id) VALUES('"
                           + Justif.Text + "',(getdate()),'" + (dateTimePicker1.Value.ToString("dd-MM-yyyy") + " " + Hora) + "','" + textBox1.Text + "'," + recivir_sesion.idUsr.ToString() + ")");
                        MessageBox.Show("Se a ingresado correctamente la sanción", "Sanción",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {

                    MessageBox.Show("Es necesario ingresar un motivo para la sanción .", "Sanción",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
       

        }
  

     
        private void button1_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            press_buttons(sender, e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                llenar();
            }                 
               
         }


      
     

        private void button3_Click(object sender, EventArgs e)
        {
            VerSancionados mostrar = new VerSancionados(textBox1.Text,this);
            mostrar.Show();
            expediente = textBox1.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime dt1 = new DateTime();
            dt1 = Convert.ToDateTime(this.dateTimePicker1.Value);
           

                if (!Justif.Text.Equals(""))
                {
                    if ((h.CompareTo(dateTimePicker1.Value) == 1))
                    {

                        MessageBox.Show("La fecha de sanción debe ser mayor a la fecha actual.", "Sanción",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if(abrir.existe("SELECT * FROM UsuarioLCI WHERE est_expediente =" + textBox1.Text)){
                        abrir.modificar("INSERT INTO Sancion (sn_motivo,sn_fecha_inicio,sn_fecha_fin,est_expediente,usr_id) VALUES('"
                           + Justif.Text + "',(getdate()),'" + (dateTimePicker1.Value.ToString("dd-MM-yyyy") + " " + Hora) + "','" + textBox1.Text + "'," + recivir_sesion.idUsr.ToString() + ")");
                        abrir.modificar("INSERT INTO HistorialSancion (hs_motivo,hs_inicio,hs_fin,est_expediente,usr_id) VALUES('"
                         + Justif.Text + "',(getdate()),'" + (dateTimePicker1.Value.ToString("dd-MM-yyyy") + " " + Hora) + "','" + textBox1.Text + "'," + recivir_sesion.idUsr.ToString() + ")");
                        MessageBox.Show("La sanción se ha ingresado correctamente.", "Sanción",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else{

                            MessageBox.Show("El alumno no se encuentra en la base de datos.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                          }

                    }
                }
                else
                {

                    MessageBox.Show("Es necesario ingresar un motivo para la sanción .", "Sanción",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            VerSancionados mostrar = new VerSancionados(textBox1.Text,this);
            mostrar.Show();
            expediente = textBox1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void Justif2(object sender, KeyPressEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 9)
            {

                llenar();
            }
            else
            {

                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                Justif.Text = "";
                dateTimePicker1.Text = "";
          
                dateTimePicker1.Enabled = true;
                pictureBox1.Image = null;
         
            }

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
         

            llenar();

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

        private void button1_Click_1(object sender, EventArgs e)
        {
              try
            {
                if (MessageBox.Show("¿Seguro que desea borrar la sancion actual?", "Sanciones", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {

                    abrir.modificar("DELETE FROM Sancion WHERE est_expediente =" + textBox1.Text + "" + "and sn_id = " + sn.Rows[0]["sn_id"].ToString() + "");
             
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox5.Text = "";
                        Justif.Text = "";
                        dateTimePicker1.MinDate = Convert.ToDateTime(abrir.consultaLibreS("SELECT getdate()"));
                        pictureBox1.Image = null;
                        button2.Enabled = false;
                        button4.Enabled = true;
                        button1.Enabled = false;
                    
                }
            }
            catch (NullReferenceException)
            {

              

            }
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                DateTime h = DateTime.Today;

                if ((h.CompareTo(dateTimePicker1.Value) == 1))
                {
                    MessageBox.Show("La sanción seleccionada ya no puede ser modificada.", "Sanción",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    modificar_sancion a = new modificar_sancion(this,sn.Rows[0]["sn_fecha_fin"].ToString(), sn.Rows[0]["sn_motivo"].ToString(), sn.Rows[0]["sn_id"].ToString());

                    a.Show();
                }
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("La lista de sancionados esta vacia.", "Sanciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

     
  

         
         

    }
}
