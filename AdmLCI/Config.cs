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
    public partial class Config : Form
    {
//        servidor:192.168.1.102
//usuario:denneb
//contrasenia:estaciones2
//basedatos:lciFinal
//contraseniaM:1414
        string[] contenido = new string[6];
        public Config()
        {
            InitializeComponent();

            String line="";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("config.txt");

                //Read the first line of text
                line = sr.ReadLine();
                int cont = 0;
                //Continue to read until you reach end of file
                while (line != null)
                {

                    if (line.StartsWith("servidor:"))
                    {
                        tbServidor.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[cont] = "servidor:" + tbServidor.Text;
                        
                    }
                    else if (line.StartsWith("usuario:"))
                    {
                        tbUsuarioBD.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[cont] = "usuario:" + tbUsuarioBD.Text;
                        
                    }
                    else if (line.StartsWith("contrasenia:"))
                    {
                        tbContraBD.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[cont] = "contrasenia:" + tbContraBD.Text;
                        
                    }
                    else if (line.StartsWith("basedatos:"))
                    {
                        tbNomBD.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[cont] = "basedatos:" + tbNomBD.Text;
                        
                    }
                    else if (line.StartsWith("contraseniaM:"))
                    {
                        tbContraM.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[cont] = "contraseniaM:" + tbContraM.Text;
                       
                    }
                    else if (line.StartsWith("servidorM:"))
                    {
                        tbServidorMago.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[cont] = "servidorM:" + tbServidorMago.Text;
                    }
                    //MessageBox.Show(contenido[cont]);
                    cont++;
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error al obtener los datos");
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
        }
        
        private void Config_Load(object sender, EventArgs e)
        {

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {

            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("config.txt");
                //StreamReader sr = new StreamReader("config.txt");
                
                for (int i = 0; i < contenido.Length; i++)
                {
                    
                    if (contenido[i].StartsWith("servidor:"))
                    {
                       // tbServidor.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[i] = "servidor:" + tbServidor.Text;

                    }
                    else if (contenido[i].StartsWith("usuario:"))
                    {

                        contenido[i] = "usuario:" + tbUsuarioBD.Text;

                    }
                    else if (contenido[i].StartsWith("contrasenia:"))
                    {
                       // tbContraBD.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[i] = "contrasenia:" + tbContraBD.Text;

                    }
                    else if (contenido[i].StartsWith("basedatos:"))
                    {
                       // tbNomBD.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[i] = "basedatos:" + tbNomBD.Text;

                    }
                    else if (contenido[i].StartsWith("contraseniaM:"))
                    {
                       // tbContraM.Text = line.Substring(line.IndexOf(":") + 1);
                        contenido[i] = "contraseniaM:" + tbContraM.Text;

                    }
                    else if (contenido[i].StartsWith("servidorM:"))
                    {
                       
                        contenido[i] = "servidorM:" + tbServidorMago.Text;
                    }


                    //MessageBox.Show(contenido[i]);
                    sw.WriteLine(contenido[i]);

                }

                sw.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
                
            }

            this.Close();
        }
    }
}
