using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace AdmLCI
{
    public partial class AsignarLocker : Form
    {
        Conexion abrir = new Conexion();
        int f;
        
        AdmnLockers a;
        String actual = "select * from Locker ORDER BY lok_no";
        String actual_año;
        String sem;
        int semestre = 0;
        int año =  DateTime.Now.Year;
        int mes = DateTime.Now.Month;
        String carrera;
        DataTable lock_num;
        Sesion act;
        String nu;
        Boolean datos;
        Validacion vldr = new Validacion();
        String fecha ="SELECT CONVERT(date, GETDATE())";
        DataTable info;
         String esp = @"SELECT COUNT(*)
                              FROM AlumnoEspecial
                              WHERE ales_id = @Id or ales_exp_ext = @Id ";

       //webServiceLCI.Service webServiceLCI = new webServiceLCI.Service();
         DataTable alumno = new DataTable();
       
        public void comboboxlock()
        {
            lock_num = abrir.consultaLibreDT("SELECT lok_no FROM Locker where lok_estado ='Disponible' ORDER BY lok_no");

            for (int i = 0; i < lock_num.Rows.Count; i++)
            {
                comboBox1.Items.Add(lock_num.Rows[i]["lok_no"]);
            }
        }
        public byte[] StringToBytes(String cadena)
        {
            System.Text.ASCIIEncoding codificador = new System.Text.ASCIIEncoding();
            return codificador.GetBytes(cadena);
        }
        /*El metodo Base64ToImage convierte una variable de tipo base64String a Image*/
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

  public void EscribirenunDocumentoWord()
  {
      //Objeto del Tipo Word Application
      Word.Application objWordApplication;
      //Objeto del Tipo Word Document
      Word.Document objWordDocument;
      // Objeto para interactuar con el Interop
      Object oMissing = System.Reflection.Missing.Value;
      //Creamos una instancia de una Aplicación Word.
      objWordApplication = new Word.Application();
      //A la aplicación Word, le añadimos un documento.
      objWordDocument = objWordApplication.Documents.Add(ref oMissing,
                                                       ref oMissing,
                                                       ref oMissing, ref oMissing);
      //Activamos el documento recien creado, de forma que podamos escribir en el
      objWordDocument.Activate();
      //Encabezado
      objWordApplication.Selection.Font.Name = "Arial"; //Cambiamos el nombre
      objWordApplication.Selection.Font.Size = 16; //Cambiamos el tamaño
      objWordApplication.Selection.ParagraphFormat.Alignment =

      Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

      objWordApplication.Selection.TypeText("UNIVERSIDAD DE SONORA\n");
      objWordApplication.Selection.Font.Size = 11;
      objWordApplication.Selection.TypeText("DIRECCIÓN DE SERVICIOS UNIVERSITARIOS\n");
      objWordApplication.Selection.Font.Size = 14;
      objWordApplication.Selection.TypeText("LABORATORIO CENTRAL DE INFORMATICA\n");
      //Indicamos que el texto anterior es parte de un párrafo.
      objWordApplication.Selection.TypeParagraph();
      //Ahora veamos como cambiar el tipo y tamaño de la letra
      objWordApplication.Selection.Font.Size = 12;
      objWordApplication.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
      objWordApplication.Selection.TypeText("POLITICAS QUE ACEPTA EL USUARIO AL CONTRATAR EL SERVICIO DE ARRENDAMIENTO DE CASILLEROS\nEl Laboratorio Central de Informática le ofrece a usted arrendamiento de casilleros y se regirá bajo las siguientes reglas o condiciones:\n");
      objWordApplication.Selection.TypeText("a) El Laboratorio Central de Informática asignará uno de los 84 casilleros que se encuentren disponibles.\nb) El usuario se compromete a darle un buen uso al casillero asignado.\nc) El uso del casillero por parte del usuario es responsabilidad del mismo.\nd) El casillero será asignado por un tiempo determinado indicado al final de estas condiciones.\ne) Independientemente de la fecha de solicitud, el costo por asignación del casillero, así como la fecha de  vencimiento serán los mismos.\nf) El usuario es responsable de traer el candado para mantener el casillero cerrado, así como de retirarlo a la fecha de vencimiento.\ng) El Laboratorio Central de Informática se reserva el derecho de retirar candados y objetos dentro de los casilleros  cuando estos objetos afecten la limpieza y el ambiente del Laboratorio Central de Informática, llámense comida u otros artículos perecederos, sin tener responsabilidad para rembolsar el importe de candados destruidos, ni por los objetos contenidos.\nh) El Laboratorio Central de Informática dará un plazo máximo de 5 días hábiles después del vencimiento para que el  usuario retire el candado y objetos contenidos en el casillero, de lo contrario procederá a retirarlos sin previo aviso.\ni) El Laboratorio Central de Informática se reserva el derecho de retirar objetos y candados de los casilleros si se incumple con alguna(s) de las condiciones mencionadas, sin tener que rembolsar el importe pagado.\nj) Los casilleros estarán disponibles durante el período de arrendamiento en un horario de 7:00 a 20:00 horas de Lunes a Viernes y de 9:00 a 13:00 horas los días Sábado de acuerdo al calendario escolar.");

      objWordApplication.Selection.TypeText("\nNombre del alumno: " + textBox1.Text + "\nExpediente del alumno: " + Exp.Text + "\nCasillero No.: " + comboBox1.Text + "\n" + "Fecha de Inicio: " + textBox4.Text + "\nFecha de Término: " + textBox2.Text);

      objWordApplication.Selection.ParagraphFormat.Alignment =
     Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
      objWordApplication.Selection.TypeText("\n____________________________________________\nFIRMA DE ACEPTACION");
      //Indicamos que el texto anterior es un párrafo

      objWordApplication.Selection.TypeParagraph();

      //Hace visible la Aplicacion para que veas lo que se ha escrito

      objWordApplication.Visible = true;



  }


  public Boolean webservice()
  {
      try
      {
          //Guardar los datos de la BD del web service en el DataTable alumno
          DataTable alumno = new DataTable();
         // alumno = webServiceLCI.ObtenerInfoAlumno(Convert.ToInt32(Exp.Text));

          if (alumno.Rows.Count == 0)
          {
              MessageBox.Show("El expediente " + Exp.Text + " no existe.");
          }
          else if (alumno.Rows.Count != 0)
          {
              //Almacenar la informacion del alumno en la base de datos local. 
              Byte[] prueba = (byte[])alumno.Rows[0]["rFoto"];
              pictureBox1.Image = Base64ToImage(prueba.ToString());

              abrir.modificar("INSERT INTO UsuarioLCI (est_expediente, est_nombre, est_carrera, est_estado, est_saldo, est_foto) " +
              " VALUES (" + Convert.ToInt32(alumno.Rows[0]["iExpediente"].ToString()) + ", '" + alumno.Rows[0]["cNombre"] + "', '" +
              alumno.Rows[0]["cClaveCarrera"] + "', '" + alumno.Rows[0]["cEstatus"] + "', 180, '" +
              ImageToBase64(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Jpeg) + "')");

          }
     
          }
      
      catch { MessageBox.Show("Error en la conexión remota"); return false;  }
      return true;
  
  }

  public void fechasemestre() {
      DateTime fe = Convert.ToDateTime(abrir.consultaLibreS(fecha));
      String Semestre1 = "30/06/" + año;
      DateTime asi = DateTime.Parse(Semestre1);
      if ((fe.CompareTo(asi) == -1))
      {


          textBox2.Text = "30/06/" + año;
          semestre = 1;

      }
      else
      {
          Semestre1 = "31/12/" + año;

          textBox2.Text = Semestre1;
          semestre = 2;
      }
  }
        

        public void llenar()
        {

           button3.Enabled = true;
                pictureBox1.Image = null;
                if (!(Exp.Text.Equals("")))
                {
                   
                        String s = @"SELECT COUNT(*)
                              FROM UsuarioLCI
                              WHERE est_expediente = @Id ";

                      



                        if (abrir.Exists(Exp.Text, s))
                        {
                           
                            DataTable est = abrir.consultaLibreDT("SELECT est_nombre,est_carrera ,est_foto From UsuarioLCI WHERE est_expediente=" + Exp.Text);
                            if (est.Rows.Count == 0) { datos = false; } else { datos = true; }
                            if ((est.Rows[0]["est_carrera"].ToString()).Equals("null"))
                            {
                                carrera = "Maestro";
                            }
                            else
                            {

                                carrera = est.Rows[0]["est_carrera"].ToString();
                            }
                            textBox1.Text = est.Rows[0]["est_nombre"].ToString();

                            textBox3.Text = carrera;
                            textBox4.Text = abrir.consultaLibreS(fecha);
                            fechasemestre();
                            
                            if (!(String.IsNullOrEmpty((est.Rows[0]["est_foto"].ToString()))))
                            {

                                pictureBox1.Image = Base64ToImage(est.Rows[0]["est_foto"].ToString());
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;



                                //  pictureBox1.Image = Image.FromStream(ms);
                            }

                        }
                                   else if (abrir.Exists(Exp.Text, esp))
                                            {
                                                if (vldr.IsNumeric(Exp.Text))
                                                {
                                                    info = abrir.consultaLibreDT("SELECT * FROM AlumnoEspecial WHERE ales_exp_ext=" + Exp.Text + " or ales_id = " + Exp.Text);

                                                    datos = true;
                                                }
                                                else
                                                {
                                                    info = abrir.consultaLibreDT("SELECT * FROM AlumnoEspecial WHERE ales_exp_ext='" + Exp.Text + "' ");

                                                    datos = true;
                                                }
                                               
                                                textBox1.Text = info.Rows[0]["ales_nombre"].ToString() + " " + info.Rows[0]["ales_ape_pat"].ToString() + " " + info.Rows[0]["ales_ape_mat"].ToString();
                                                //  textBox4.Text = info.Rows[0][4].ToString();
                                                textBox4.Text = abrir.consultaLibreS(fecha);
                                                textBox3.Text = "Usuario especial";
                                                fechasemestre();
                            }




                        else if (webservice())
                        {
                           
                        }
                        
                    
                    
                }

            
        
        }
 

        public AsignarLocker(AdmnLockers e ,Sesion sesion,String locker,String año,String semestre)
        {
          
            InitializeComponent();
            comboboxlock();
            a = e;
            act = sesion;
            nu = locker;
            comboBox1.Text = nu;
            actual_año = año;
            sem = semestre;


        }





        private void button1_Click_1(object sender, EventArgs e)
        {
            if (datos)
            {
                String exp = "";
                exp = Exp.Text;


                DateTime h = DateTime.Today;


                String s = @"SELECT COUNT(*)
                              FROM Locker
                              WHERE est_expediente = @Id ";


                if (!abrir.Exists(exp, s))
                {
                    if ((comboBox1.SelectedIndex == -1))
                    {
                        MessageBox.Show("Seleccione un locker", "Lockers", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        abrir.modificar("UPDATE Locker SET est_expediente=" + exp.ToString() + ",lok_estado='No disponible',"
                             + "lok_fecha_inicio=getdate(), lok_fecha_fin ='" + textBox2.Text + " 00:00:00.000 ',lok_semestre=" + semestre + ",est_nombre='" + textBox1.Text + "',est_carrera='" + textBox3.Text + "' WHERE lok_no= " + comboBox1.Text);

                        abrir.modificar("UPDATE HistorialLocker set est_expediente='" + exp.ToString() + "',hl_estado='No disponible',lok_no=" + comboBox1.Text + ",hl_inicio=getdate(),hl_fin='" + textBox2.Text + " 00:00:00.000 ',hl_semestre=" + semestre + ",hl_nombre='" + textBox1.Text + "',hl_carrera='" + textBox3.Text + "' where hl_año=" + actual_año + " and hl_semestre=" + sem + "and  lok_no= " + comboBox1.Text);


                        abrir.modificar("INSERT INTO HistorialAcciones (ha_accion,usr_id,ha_objeto) VALUES('Asignar','" + act.idUsr + "','L" + comboBox1.Text + "')");


                        a.bandera = true;
                        a.limpiarPantalla();
                        a.hist_lock();
                        //a.listarlockers(a.actual, int.Parse(a.intervalos[0]), int.Parse(a.intervalos[1]));
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("El alumno ya cuenta con un locker asignado.", "Lockers",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
           
           
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exp_KeyPress(object sender, KeyPressEventArgs e)
        {
            press_buttons(sender, e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                llenar();
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

        private void Exp_TextChanged(object sender, EventArgs e)
        {
            
            if (Exp.Text.Length == 9)
            {
                llenar();

            }





        }

        public void validar(Object sender, KeyPressEventArgs e) 
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
                e.Handled = true;

            }
        }
        public string ImageToBase64(Image image,System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
       

        private void btBuscar_Click(object sender, EventArgs e)
        {
            llenar();

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
         EscribirenunDocumentoWord();
            
           
        }


    }
}