using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Net; 
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Drawing.Drawing2D; 


namespace AdmLCI
{
    public partial class AgregarSoft : Form

    {
        Conexion con = new Conexion();
  
        AdmnSoftware soft;

        public String Nombre_Imagen,Nombre_sft,Version_sft, Mostrar_text_boton,ID_doft;
        Boolean Flag_guardar;
        Validacion validar_campos = new Validacion();
        Sesion act;
      //  String cadenaConexion = "Data Source=Win8\\ISI;Initial Catalog=LCIFinal;User ID=Jose;Password=203203280  ;Trusted_Connection=False";
  //String cadenaConexion = "Data Source=148.225.26.18;Initial Catalog=lci;User ID=siscalc;Password=siscalc;Trusted_Connection=False";
     
       
        SqlConnection con2;

        public byte[] conver(Bitmap bitmap)
        {
            byte[] result = null;

            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, bitmap.RawFormat);
                result = stream.ToArray();
            }

            return result;
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
        public void cargar_imagen()
        {

            
            openFileDialog1.Title = "Seleccione una Imagen";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            openFileDialog1.FilterIndex = 3;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                Nombre_Imagen = openFileDialog1.FileName;
               

                
                if (string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    MessageBox.Show("Selecione un Imagen");
                  

                    return;
                    //Saliendo del procedimiento
                }
                else
                {


                    //Se inicailiza un flujo de archivo con la imagen seleccionada desde el disco.



                    FileStream stream = new FileStream(Nombre_Imagen, FileMode.Open, FileAccess.Read);


                    //Se inicializa un arreglo de Bytes del tamaño de la imagen
                    byte[] binData = new byte[stream.Length];
                    //Se almacena en el arreglo de bytes la informacion que se obtiene del flujo de archivos(foto)
                    //Lee el bloque de bytes del flujo y escribe los datos en un búfer dado.
                    stream.Read(binData, 0, Convert.ToInt32(stream.Length));


                    //Se muetra la imagen obtenida desde el flujo de datos
                    Stream str = new MemoryStream(binData);

                    Bitmap img = new Bitmap(str);
                    // write CreateBitmapFromBytes  

                    Bitmap newBitmap = new Bitmap(150, 150);
                    using (Graphics graphics = Graphics.FromImage(newBitmap))
                    {
                        graphics.DrawImage(img, new Rectangle(0, 0, 150, 150), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                    }

                    //  conver(newBitmap); // write CreateBytesFromBitmap

                    byte[] newimg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(newBitmap).ConvertTo(newBitmap, typeof(byte[]));


                    MemoryStream ms = new MemoryStream(newimg);
                    button3.Image = Image.FromStream(ms);

                    }
                   
            }
                  
                   
                

                
            
        }
        public AgregarSoft(AdmnSoftware sf,Sesion sc,Boolean guardar,String boton,String Identificador,String nombre,String version)
        {
           
            InitializeComponent();
            soft = sf;
            act = sc;
           button2.Text = boton;
            Flag_guardar= guardar;
            Nombre_sft = nombre;
           ID_doft = Identificador;
            Version_sft = version;

                       
            if(Flag_guardar){

                textBox1.Text = nombre;
                textBox2.Text = version;
                con2 = new SqlConnection(con.cadenaConexion);

                SqlCommand command = new SqlCommand("select sft_img from Software where sft_id=@id", con2);
                command.Parameters.AddWithValue("@id", ID_doft);

                //Representa un set de comandos que es utilizado para llenar un DataSet
                SqlDataAdapter dp = new SqlDataAdapter(command);
                //Representa un caché (un espacio) en memoria de los datos.
                DataSet ds = new DataSet("Software");

                //Arreglo de byte en donde se almacenara la foto en bytes
                byte[] MyData = new byte[0];

                //Llenamosel DataSet con la tabla. cliente es nombre de la tabla
                dp.Fill(ds, "Software");
                //Inicializamos una fila de datos en la cual se almacenaran todos los datos de la fila seleccionada
                DataRow myRow = ds.Tables["Software"].Rows[0];

                //Se almacena el campo foto de la tabla en el arreglo de bytes
                MyData = (byte[])myRow["sft_img"];
                //Se inicializa un flujo en memoria del arreglo de bytes
                MemoryStream stream = new MemoryStream(MyData);
                //En el picture box se muestra la imagen que esta almacenada en el flujo en memoria 
                //el cual contiene el arreglo de bytes
                button3.Image = Image.FromStream(stream);
            
            }
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (!(string.IsNullOrEmpty(Nombre_Imagen)))
            {
                

                con2 = new SqlConnection(con.cadenaConexion);
                if (Flag_guardar)
                {

                    con.consultaLibreS("Update Software set sft_nombre='" + textBox1.Text + "',sft_version='" + textBox2.Text + "' where sft_id=" + ID_doft);

                }
                else
                {
                    if (validar_campos.verificarEspacios(groupBox1))
                    {
                        MessageBox.Show("Porfavor es necesario ingresar todos los campos.", "Software", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    }
                    else
                    {


                        SqlCommand com ; 

                        con2 = new SqlConnection(con.cadenaConexion);
                        if (Flag_guardar)
                        {
                            com = new SqlCommand("Update Software set sft_nombre='" + textBox1.Text + "',sft_version='" + textBox2.Text + "',sft_img=@Pic", con2);

                        }
                        else
                        {
                            com = new SqlCommand("insert into Software(sft_nombre,sft_version,sft_img) values('" + textBox1.Text + "','" + textBox2.Text + "',@Pic)", con2);
                            con.modificar("INSERT INTO HistorialAcciones (ha_accion,usr_id,ha_objeto) VALUES('Agregar'," + act.idUsr + ",'SW-" + textBox1.Text + "')");
                        }


                        //Se inicailiza un flujo de archivo con la imagen seleccionada desde el disco.
                        FileStream stream = new FileStream(Nombre_Imagen, FileMode.Open, FileAccess.Read);


                        //Se inicializa un arreglo de Bytes del tamaño de la imagen
                        byte[] binData = new byte[stream.Length];
                        //Se almacena en el arreglo de bytes la informacion que se obtiene del flujo de archivos(foto)
                        //Lee el bloque de bytes del flujo y escribe los datos en un búfer dado.


                        //Se muetra la imagen obtenida desde el flujo de datos
                        Stream str = new MemoryStream(binData);
                        stream.Read(binData, 0, Convert.ToInt32(stream.Length));
                        Bitmap img = new Bitmap(str);
                        // write CreateBitmapFromBytes  

                        Bitmap newBitmap = new Bitmap(150, 150);
                        using (Graphics graphics = Graphics.FromImage(newBitmap))
                        {
                            graphics.DrawImage(img, new Rectangle(0, 0, 150, 150), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                        }

                        //  conver(newBitmap); // write CreateBytesFromBitmap

                        byte[] newimg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(newBitmap).ConvertTo(newBitmap, typeof(byte[]));


                        //   button3.Image = Image.FromStream(stream);


                        com.Parameters.AddWithValue("@Pic", newimg);
                        con2.Open();
                        //Ejecuta una instrucción SQL en la conexión y devuelve el número de filas afectadas.
                        com.ExecuteNonQuery();
                        con2.Close();

                      
                   
                    }

                }
            }
            else
            {

                MessageBox.Show("Selecione un Imagen");
                return;
            }
            soft.cargar_tabla1();
          
             this.Close();

        }
       

      
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            cargar_imagen();    
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            press_buttons(sender, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            press_buttons(sender, e);
        }

      

       

       
    }
}
