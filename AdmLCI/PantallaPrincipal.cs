﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdmLCI.Properties;
using System.Net.Sockets;
using System.Net;
using System.IO;


namespace AdmLCI
{
    /*
     Esta clase contiene todos los elementos gráficos de la ventana principal
     */
    public partial class PantallaPrincipal : Form
    {
        Conexion con=new Conexion(); //Permite conectarse a una base de datos.
        public Sala[] salas; //Crea un arreglo de objetos tipo 'Sala'. Cada objeto representa una sala existente en el LCI.
        int indiceSalaSeleccionada = -1; //Esta variable contendra el índice de la sala que está activa en la ventana principal.
        Sesion sesion;
        Login login;
     
        //Cliente-Servidor
        public static TcpClient Cliente = new TcpClient();
        public static String Recibido = "";
        public string IP;

        byte[] data;
        //Código del boton btnSignIn
        //(Se crea dándole doble click al botón)

        public PantallaPrincipal()
        {            
            InitializeComponent();
            listarSalas();
        }

        public PantallaPrincipal(Sesion s, Login log)
        {
            InitializeComponent();            
            sesion = s;
            listarSalas();
            login = log;
            lblNomUsuario.Text = s.nombre;
            lblTipoSesion.Text = s.tipoUsuario;
            lbHora.Text = "" + DateTime.Now.Hour + ":" + ((int.Parse(DateTime.Now.Minute.ToString()) < 10) ? "0" + DateTime.Now.Minute : DateTime.Now.Minute.ToString());
            
            //Reiniciar tiempos
            //con.modificar("update UsuarioLCI set est_saldo = 180");

            if (sesion.tipoUsuario.Equals("Asesor")){
                btEspeciales.Enabled = false;
                btReportes.Enabled = false;
                btSanciones.Enabled = false;
                btSoftware.Enabled = false;
                btUsuario.Enabled = false;
                gbOpcSala.Enabled = false;
                btEquipos.Enabled = false;
            }
            else if (sesion.tipoUsuario.Equals("Manual"))
            {
                btEspeciales.Enabled = false;
                btReportes.Enabled = false;
                btSanciones.Enabled = false;
                btSoftware.Enabled = false;
                btUsuario.Enabled = false;
                gbOpcSala.Enabled = false;
                btEquipos.Enabled = false;
                btLockers.Enabled = false;
                btConsultas.Enabled = false;
            }

            //conectarS();
            
        }


        public string obtenerIP() {
            String line = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("config.txt");

                //Read the first line of text
                line = sr.ReadLine();

                string ip = "127.0.0.1";
                //Continue to read until you reach end of file
                while (line != null)
                {

                    if (line.StartsWith("servidorM:"))
                    {
                       ip= line.Substring(line.IndexOf(":") + 1);
                     //  MessageBox.Show(ip);
                    }
                    
                    //Read the next line
                    line = sr.ReadLine();
                    
                }

                //close the file
                sr.Close();
                return ip;
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
            return "localhost";
        }
      


        //La subrutina ReceiveMessage lee los datos enviados
        //desde el servidor en forma asíncrona en otro thread
        //Cuando se reciben los datos se despliegan en el control
        //txtMessageHistory. 
        //Dado que los controles de Windows no funcionan correctamente
        //con los thread crearemos un delegado (delUpdateHistory)
        //para actualizar los datos del TextBox
       

        //Limpiará el contenido de la pantalla, es decir, quitará las computadoras que aparecen actualmente.
        public void limpiarPantalla() {

            if (indiceSalaSeleccionada >= 0)
            {
                if (salas[indiceSalaSeleccionada].mesas != null)
                {
                    for (int j = 0; j < salas[indiceSalaSeleccionada].mesas.Length; j++)
                    {
                        salas[indiceSalaSeleccionada].mesas[j].borrarObjeto();
                    }
                }
            }
        }

        public void borrarSalas() {  
                for (int j = 0; j < salas.Length; j++)
                {
                    salas[j].borrarObjeto();
                }
        }
        
        
        //El evento generado al dar clic en una sala.
        void salas_Click(object sender, EventArgs args)
        {
            //La pantalla se limpia antes de mostrar las computadoras de la sala seleccionada.
            limpiarPantalla();

            //El ciclo verifica de que sala provino el evento.
            for (int i = 0; i < salas.Length; i++)
            {
                salas[i].Enabled = true;
                if (sender.Equals(salas[i]))
                {
                    //Agrega las mesas y equipos a la pantalla principal.
                    salas[i].cargarMesas();
                    if (salas[i].estadoSala.Equals("Mantenimiento"))
                    {
                        btMantenimiento.Enabled = false;
                        btActivar.Enabled = true;
                    }
                    else if(salas[i].estadoSala.Equals("Disponible")) {
                        btMantenimiento.Enabled = true;
                        btActivar.Enabled = false;
                        
                    }
                        
                    salas[i].Enabled = false;
                    indiceSalaSeleccionada = i;
                    //MessageBox.Show("sala select " + indiceSalaSeleccionada);
                }       
            }
        }

        //Muestra las salas existentes en la base de datos.
        public void listarSalas()
        {
            int Y = 16;
            //Obtiene las salas de la base de datos.
            DataTable ds = con.consultaLibreDT("select * from Sala order by sa_letra"); 
            //Asigna el tamaño del arreglo, dependiendo del total de salas existentes.
            
            if (salas != null)
            {
                limpiarPantalla();
                for (int i = 0; i < salas.Length; i++)
                    salas[i].borrarObjeto();

            }

            salas = new Sala[ds.Rows.Count];
        
            //En el ciclo se crea cada objeto del arreglo con los parámetros requeridos, además de agregarle 
            //el evento y la información a cada sala.
            for (int i = 0; i < salas.Length; i++)
            {
                salas[i] = new Sala(this,Y,sesion);
                Y = Y + 64; 
                salas[i].asignarDatos(int.Parse(ds.Rows[i][0].ToString()), ds.Rows[i][1].ToString(), ds.Rows[i][2].ToString());                
                salas[i].Click += salas_Click;
                gbListaSalas.Controls.Add(salas[i]);
            }
        }

        private void btAgregarS_Click(object sender, EventArgs e)
        {
            //inOut.Enviar(Cliente,"wiiiii");
            AgregarSala a=new AgregarSala(this,sesion);
            a.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdmnLockers al = new AdmnLockers(sesion);
            al.ShowDialog(this);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Sanciones s = new Sanciones(sesion);
            s.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admonEquipos ae = new admonEquipos(this,sesion);
            ae.ShowDialog(this);         
            while (ae.Visible == true)
                this.Enabled = false;           
            
        }

        private void button48_Click(object sender, EventArgs e)
        {
            login.tbContrasenia.Text = "";
            login.tbUsuario.Text = "";
            login.Show();

          
            this.Close();      
      
        }

        private void PantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (Cliente.Connected == true)
            {
                inOut.Enviar(Cliente, "SS");
               
                //Desbloquear();
                Cliente.Close();
            }

            login.tbContrasenia.Text = "";
            login.tbUsuario.Text = "";
            login.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            admonUsuarios au = new admonUsuarios();
            au.ShowDialog(this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < salas.Length; i++)
            {
                if (salas[i].Enabled == false)
                {

                    ReservarSala rs = new ReservarSala(salas[i],this,i);
                    rs.ShowDialog(this);

                    //DialogResult res = MessageBox.Show("¿Realmente desea poner en mantenimiento la sala "+salas[i].nomSala+"?", "Mantenimiento", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //if (res == DialogResult.Yes)
                    //{
                    //    Conexion con = new Conexion();
                    //    string []nomParam={"salaId"};
                    //    string[] param = { ""+salas[i].idSala };
                    //    int bandera=0;
                    //    btActivar.Enabled = true;
                    //    btMantenimiento.Enabled = false;
                    //    con.procedimiento(nomParam,param,"mantenimiento_sala");
                    //    con.modificar("UPDATE InvEquipo SET ieq_estado='Mantenimiento', est_expediente=1414 WHERE sa_id=" + salas[i].idSala);
                    //    salas[i].estadoSala = "Mantenimiento";
                    //    salas[i].Image = Resources.salaMantenimiento;
                    //    for (int j = 0; j < salas[i].mesas.Length;j++ ) {
                    //        for (int k = 0; k < salas[i].mesas[j].equipos.Length; k++) {
                    //            if (salas[i].mesas[j].equipos[k].estado.Equals("No Disponible"))
                    //                bandera = 1;
                    //            salas[i].mesas[j].equipos[k].Image = Resources.computadoraMant2;
                    //            salas[i].mesas[j].equipos[k].estado = "Mantenimiento";
                    //        }                        
                    //    }
                        
                    //    if(bandera==1)
                    //        MessageBox.Show("Hubo uno o más equipos que estaban ocupados y fueron desasignados automáticamente.","Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < salas.Length; i++)
            {
                if (salas[i].Enabled == false)
                {
                    DialogResult res = MessageBox.Show("¿Realmente desea activar la sala " + salas[i].nomSala + "?", "Mantenimiento", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        Conexion con = new Conexion();
                        string[] nomParam = { "salaId" };
                        string[] param = { "" + salas[i].idSala };
                        salas[i].estadoSala = "Disponible";
                        btActivar.Enabled = false;
                        btMantenimiento.Enabled = true;
                        con.procedimiento(nomParam, param, "quitar_mantenimiento_sala");
                        salas[i].Image = Resources.salaIcono;
                        for (int j = 0; j < salas[i].mesas.Length; j++)
                        {
                            for (int k = 0; k < salas[i].mesas[j].equipos.Length; k++)
                            {
                                salas[i].mesas[j].equipos[k].Image = Resources.compLibre;
                                salas[i].mesas[j].equipos[k].estado = "Disponible";
                            }

                        }
                    }
                }
            }
        }

        private void btEspeciales_Click(object sender, EventArgs e)
        {
            Lista_especiales le = new Lista_especiales();
            le.ShowDialog();
        }

        private void btSoftware_Click(object sender, EventArgs e)
        {
            AdmnSoftware mostrar = new AdmnSoftware(sesion);
            mostrar.ShowDialog(this);
        }

        private void btReportes_Click(object sender, EventArgs e)
        {
            admonReporte ar = new admonReporte();
            ar.ShowDialog(this);
        }

        private void btConsultas_Click(object sender, EventArgs e)
        {
            Consulta c = new Consulta();
            c.ShowDialog(this);
        }

        private void btBorrarSala_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("¿Realmente desea borrar la sala " + salas[indiceSalaSeleccionada].nomSala + "?", "Eliminar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
             if (res == DialogResult.Yes)
             {
                 con.modificar("delete Sala where Sala.sa_id=" + salas[indiceSalaSeleccionada].idSala);
                 con.modificar("insert into HistorialAcciones (ha_accion,usr_id,ha_objeto,ha_fecha) values('Eliminar','" + sesion.idUsr + "', 'S-" + salas[indiceSalaSeleccionada].nomSala + "','" + (DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute) + "') ");
                
                    
                 listarSalas();

                 salas[0].cargarMesas();
                 if (salas[0].estadoSala.Equals("Mantenimiento"))
                 {
                     btMantenimiento.Enabled = false;
                     btActivar.Enabled = true;
                 }
                 else if (salas[0].estadoSala.Equals("Disponible"))
                 {
                     btMantenimiento.Enabled = true;
                     btActivar.Enabled = false;

                 }

                 salas[0].Enabled = false;
                 indiceSalaSeleccionada = 0;
             }
            
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            tmrServidor.Enabled = true;
        }

        private void btReservar_Click(object sender, EventArgs e)
        {
            try
            {
                inOut.Enviar(Cliente, "DD" + salas[indiceSalaSeleccionada].nomSala);
                MessageBox.Show("Sala " + salas[indiceSalaSeleccionada].nomSala + " desbloqueada.");
            }catch(Exception ee){
                MessageBox.Show("La sala no pudo ser desbloqueada.");
            }
            
        }

        
        private void tmrHora_Tick(object sender, EventArgs e)
        {
            lbHora.Text=DateTime.Now.ToLongTimeString();
            //lbHora.Text = "" + DateTime.Now.Hour + ":" + ((int.Parse(DateTime.Now.Minute.ToString()) < 10) ? "0" + DateTime.Now.Minute : DateTime.Now.Minute.ToString());
        }

        private void btConfig_Click(object sender, EventArgs e)
        {
            Config c = new Config();
            c.ShowDialog(this);
        }

        private void tmrServidor_Tick(object sender, EventArgs e)
        {
            //IP = Properties.Settings.Default.IP;
            IP = obtenerIP();
        
            //MessageBox.Show(IP);
            try
            {
               // Actualizar(".");
                if (Cliente != null && Cliente.Connected == false)
                {
                    //Actualizar("0");
                    Cliente.Connect(IPAddress.Parse(IP), 4000);
                    //label2.Text = "Conectando con el servicio..." + IP;
                }
                else
                {
                    if (Cliente.Available > 0)
                    {
                        Recibido = inOut.Recibir(Cliente);
                       // label2.Text = Recibido;
                        //MessageBox.Show("Estado y Recibido: " + lblEstado.Text);
                        Cliente.Close();
                        Cliente = new TcpClient();
                        tmrServidor.Enabled = false;
                        tmrCliente.Enabled = true;
                        //botonCIP.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {
                tmrServidor.Enabled = false;
                tmrCliente.Enabled = false;/*Cliente = new TcpClient();*/
                MessageBox.Show("Error en la conexión.");
                //label2.Text = "Error de conexión... Es probable que la IP del servidor sea incorrecta o el \r\nservidor este apagado.";
        
            }
        }

        private void tmrCliente_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Cliente != null && Cliente.Connected == false)
                {
                    Cliente.Connect(IPAddress.Parse(IP), Convert.ToInt32(Recibido));
                   //label2.Text = Cliente.Client.RemoteEndPoint.ToString();
                    inOut.Enviar(Cliente, "NN;" + "recepcion");
                    //MessageBox.Show("Estado: " + lblEstado.Text);
                }
                else
                {
                    
                    if (Cliente.Available > 0)
                    {
                        Recibido = inOut.Recibir(Cliente);
                       MessageBox.Show("Recibido: " + Recibido);


                        if (Recibido == "SS")
                        {
                          // Actualizar(Recibido);
                            Cliente.Close();
                            Cliente = new TcpClient();
                            tmrServidor.Enabled = true;
                            tmrCliente.Enabled = false;
                        }
                        else
                        {

                            if (salas != null && indiceSalaSeleccionada >= 0)
                            {

                                if (salas[indiceSalaSeleccionada].nomSala.Equals(Recibido))
                                {

                                    limpiarPantalla();
                                    salas[indiceSalaSeleccionada].cargarMesas();
                                }
                            }
                        }
                        
                    }
                }
            }
            catch (Exception)
            {
                //label2.Text = "Error de conexion 1"; tmrServidor.Enabled = true;
                tmrCliente.Enabled = false; Cliente = new TcpClient();
            }
        }

        private void PantallaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Cliente.Connected == true)
            {
                inOut.Enviar(Cliente, "SS");
                //Desbloquear();
                Cliente.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                inOut.Enviar(Cliente, "BB" + salas[indiceSalaSeleccionada].nomSala);
                MessageBox.Show("Sala " + salas[indiceSalaSeleccionada].nomSala + " Bloqueada.");
            }
            catch (Exception ee)
            {
                MessageBox.Show("La sala no pudo ser desbloqueada.");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}