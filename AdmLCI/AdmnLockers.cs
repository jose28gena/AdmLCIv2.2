using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdmLCI
{
    public partial class AdmnLockers : Form
    {
        int semestre = 1;
        int p = 0;
        Boolean hist_act;

        List<String> inter = new List<String>();
        Conexion con = new Conexion(); 
        //Permite conectarse a una base de datos.
        Locker[] lockers;
        Tooltipslock[] tool;
        public string[] intervalos;
        Sesion sesion;
        int sem;
        String año_actual;
        public String num ="SELECT MAX(lok_no) FROM Locker "; 
        //cadena de consulta para obtener el total de lockers de la tabla Lockers.
        String numhist = "SELECT MAX(lok_no) FROM HistorialLocker ";
        //cadena de consulta para obtener el total de lockers de la tabla HistorialLockers.
        DataTable ds;

        public String actual;
        public string v;
        // linea de consulta para la tabla de lockers actual.
        public Boolean bandera = true;
        public void comboboxintervalos(String num)
        {
           


            //Metodo que mostrara los lockers en intervalos de 40 y agregara los intervalos en el combobox de intervalos.
            inter.Clear();
            comboBox3.Items.Clear();

          
            int numlock = 0;
            int cont = 1;
              int cont2 = 40;
               if (!String.IsNullOrEmpty( con.consultaLibreS(num))) {
                   numlock = int.Parse(con.consultaLibreS(num));
               }

              while (true)
              {
                  if (cont2 < numlock)
                  {
                      comboBox3.Items.Add(cont + "-" + cont2);
                      inter.Add(cont + "-" + cont2);
                      cont = cont2 + 1;
                      cont2 = cont2 + 40;
                      // Ciclo que va sumando a los contadores 40 hasta que el contador sea mayor que el numero de lockers dejara 
                      //de agregar intervalos.
                  }
                  else
                  {
                      if (numlock == 0)
                      {

                          comboBox3.Text = (0 + "-" + numlock);
                          comboBox3.Items.Add(0 + "-" + numlock);
                          //comboBox3.SelectedIndex = 0;
                          inter.Add(cont + "-" + numlock);


                      }
                      else
                      {
                          comboBox3.Items.Add(cont + "-" + numlock);
                          inter.Add(cont + "-" + numlock);
                          //MessageBox.Show("aqui");

                      }
                      break;
                  }

                  comboBox3.SelectedIndex = 0;
              }
           
           
        }
        public void comboboxlock()
        {
            //Metodo que alimenta al combobox con los años .
            try
            {
                sem = int.Parse(con.consultaLibreS("SELECT DISTINCT MIN(hl_año) FROM HistorialLocker "));

                for (int i = sem; i <= int.Parse(año_actual); i++)
                {
                    comboBox1.Items.Add(i);
                }
            }
            catch (Exception e) {

            }
        }
        public AdmnLockers(Sesion usuario)
        {
        
            sesion = usuario;
            InitializeComponent();
            año_actual = con.consultaLibreS("SELECT YEAR(GETDATE())");
            bandera = true;

            String fe = con.consultaLibreS("SELECT GETDATE()");


            DateTime asi = Convert.ToDateTime("30/06/" + año_actual);     
            comboBox1.Text = año_actual;
            if ((Convert.ToDateTime(fe).CompareTo(asi) == -1))
            {
                semestre = 1;
                comboBox2.Text = semestre+"";
            }
            else
            {
                semestre = 2;
                comboBox2.Text = semestre +"";
            }
            
          comboboxlock();
          comboboxintervalos(num);
          comboBox3.SelectedIndex = 0;
          hist_lock();
              
              
          /*
              //intervalos = inter[comboBox3.SelectedIndex].ToString().Split('-');
              listarlockers(actual);
           
           */
        }

        public void hist_lock()
        {
            try
            {

                limpiarPantalla();
                label3.Visible = false;
                if ((año_actual == comboBox1.Text) && (semestre == int.Parse(comboBox2.Text)))
                {


                    bandera = true;
                    hist_act = false;
                    intervalos = inter[p].ToString().Split('-');
                    actual = "Select lok_no AS 'no',lok_estado AS 'estado',CONVERT(VARCHAR(10),lok_fecha_inicio,101) AS 'inicio',CONVERT(VARCHAR(101), lok_fecha_fin,101) AS 'fin',lok_semestre,est_expediente AS 'exp',est_nombre,est_carrera from Locker  where  lok_no>=" + intervalos[0] + "and lok_no <=" + intervalos[1] + "ORDER BY lok_no";
                    listarlockers(actual);


                }
                else
                {

                    bandera = false;
                    hist_act = true;
                    intervalos = inter[p].ToString().Split('-');


                    v = "Select lok_no AS 'no' ,hl_estado AS 'estado',CONVERT (VARCHAR(10),hl_inicio,101) AS 'inicio',CONVERT(VARCHAR(101), hl_fin,101) AS 'fin',hl_semestre,est_expediente AS 'exp',hl_nombre,hl_carrera  From HistorialLocker Where hl_año=" + comboBox1.Text + " and hl_semestre =" + comboBox2.Text + "and lok_no>=" + intervalos[0] + "and lok_no <=" + intervalos[1] + "ORDER BY lok_no";

                    listarlockers(v);
                }

                
            }catch(ArgumentOutOfRangeException ){
            
            
            }
            if (lockers.Length == 0) { label3.Visible = true; }
        }
        public void limpiarPantalla()
        {
           try{
           
                for (int j = 0; j < lockers.Length; j++)
                {
                    
                    lockers[j].borrarObjeto();
                }
          }catch(NullReferenceException){}

        }
        public void lockers_Click(object sender, EventArgs args)
        {
             
            for (int i = 0; i < lockers.Length; i++)
            {
                if (sender.Equals(lockers[i]))
                {
                    if (String.IsNullOrEmpty(lockers[i].est_nombre.ToString()))
                    {
                        if (!hist_act)
                        {
                            AsignarLocker mostrar = new AsignarLocker(this, sesion, lockers[i].lok_num.ToString(), año_actual, semestre.ToString());
                            mostrar.ShowDialog();

                        }
                    }
                    else
                    {
                        
                            locker_info a = new locker_info(lockers[i].est_nombre.ToString(), lockers[i].lok_inicio.ToString(), lockers[i].lok_num.ToString(), lockers[i].lok_sem);

                            a.ShowDialog();
                        

                    }
                }
            }

        }
        public void listarlockers(String s/*,int inicio,int fin*/)
        {

            int X = 16;
            int Lockermax = 7;
            int y = 16;
            String fecha;
            String fecha2;
                      
           
            ds = con.consultaLibreDT(s);
            //Obtiene las salas de la base de datos.

            //Asigna el tamaño del arreglo, dependiendo del total de salas existentes.

            lockers = new Locker[ds.Rows.Count];
            tool = new Tooltipslock[ds.Rows.Count];

            
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                if (Lockermax >= i)
                {
                    fecha = ds.Rows[i][2].ToString();
                    fecha2 = ds.Rows[i][3].ToString();
                    lockers[i] = new Locker();
                  
                    tool[i] = new Tooltipslock();
                    lockers[i].cambiarPosicion(X, y);
                    tool[i].SetToolTip(lockers[i],
                        "Locker: " + ds.Rows[i][0].ToString() 
                        + "\nEstado: " + ds.Rows[i][1].ToString()
                        + "\nFecha inicio: " + fecha
                        + "\nFecha fin: " +fecha2
                        + "\nExpediente :" + ds.Rows[i][5].ToString()
                        + "\nNombre: " + ds.Rows[i][6].ToString() 
                        + "\nCarrera: " + ds.Rows[i][7].ToString());
                    
                        lockers[i].asignarDatos(ds.Rows[i][0].ToString(),  ds.Rows[i][1].ToString(), ds.Rows[i][2].ToString(), 
                            ds.Rows[i][3].ToString(), ds.Rows[i][5].ToString(),ds.Rows[i][4].ToString());
                        
                     lockers[i].Click += lockers_Click;
              
                    panel2.Controls.Add(lockers[i]);
                    X = X + 80;
                }
                else
                {
                    Lockermax = Lockermax + 8;
                    y = y + 90;
                    X = 16;
                    i--;

                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AgregarLocker mostrar = new AgregarLocker(this,sesion,año_actual,semestre.ToString());

            mostrar.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Eliminarlocker a = new Eliminarlocker(this, sesion);
            a.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsignarLocker mostrar = new AsignarLocker(this,sesion,"",año_actual,semestre.ToString());
            mostrar.ShowDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Desasignarlocker a = new Desasignarlocker(this,sesion);
            a.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((año_actual == comboBox1.Text) && (semestre == int.Parse(comboBox2.Text)))
                {
                    comboboxintervalos(num);
                }
                else
                {
                    comboboxintervalos(numhist + " Where hl_año=" + comboBox1.Text + " and hl_semestre =" + comboBox2.Text);
               
                }
            
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                p = comboBox3.SelectedIndex;
                hist_lock();
                if(comboBox3.SelectedItem.ToString().Equals("0-0")){
                    label3.Visible = true;
                
                }
              
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                if ((con.consultaLibreS("SELECT YEAR(GETDATE())") == comboBox1.Text) && (semestre == int.Parse(comboBox2.Text)))
                {
                    hist_act = false;
                    comboboxintervalos(num);
               
                }
                else
                {
                    hist_act = true;
                    comboboxintervalos(numhist + " Where hl_año=" + comboBox1.Text + " and hl_semestre =" + comboBox2.Text);

                }

            }
            catch (ArgumentOutOfRangeException) { }
        }

      




 
    
    


    }
}
