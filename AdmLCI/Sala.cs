using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdmLCI.Properties;
using System.Data;
using System.Drawing;

namespace AdmLCI
{
    /*
     * Esta clase representa una sala existente en el LCI y contiene la información de la sala.
     * Hereda a la clase Button porque además de contener información de la sala será un objeto visible en la
     * aplicación y cumplirá las funciones de un botón.
     */
     public class Sala : Button
    {
        //Se crea un arreglo de objetos tipo "Mesa" y representa cada mesa existente en la sala actual.
        public Mesa[] mesas;
        public int idSala;
        public string nomSala;
        public string estadoSala;
        int posY;
        int posX = 8;
        Sesion sesion;

        PantallaPrincipal pantPr;

         //Método constructor del objeto Sala.
        public Sala(PantallaPrincipal pp, int Y, Sesion s) {
            posY = Y;
            asignarPropiedades();
            pantPr = pp;
            sesion = s;
        }

        //El siguiente método le asigna las propiedades visuales al objeto Sala.
        public void asignarPropiedades(){
            this.Width = 70;
            this.Height = 60;
            this.Location = new System.Drawing.Point(posX, posY);
            this.Image = Resources.salaIcono;
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.TextAlign = ContentAlignment.MiddleRight;
            this.FlatStyle = FlatStyle.Popup;
            this.Font = new Font(this.Font.Name, 11, FontStyle.Bold);         
        }

         //Recibe y asigna la información correspondiente al objeto Sala.
        public void asignarDatos(int idS, string nomS, string edoS) {
            idSala = idS;
            nomSala = nomS;
            estadoSala = edoS;
            this.Text = nomSala;

            if (estadoSala.Equals("Mantenimiento"))
                this.Image = Resources.salaMantenimiento;
        }

         //Con este método se carga el número de salas existentes en la Sala, esta información
         //se obtiene de la base de datos.
        public void cargarMesas() {
            //Se crea el objeto que establece conexión con la base de datos.
            Conexion con = new Conexion();

            //Se obtiene la información de las mesas existentes en la sala y se guardan en un objeto DataTable.
            DataTable dt = con.consultaLibreDT("select DISTINCT ieq_mesa from InvEquipo where sa_id="+idSala);
            
            //Se obtiene el total de mesas existentes en la BD.
            int totMesa = dt.Rows.Count;
            
            //Se inicializa el arreglo de mesas. El tamaño depende del total de mesas que hay en la sala.
            //Entonces si en la sala A hay 10 mesas el arreglo será de tamaño 10.
            mesas = new Mesa[totMesa];   
         
            //La variable "y" representa la posición del objeto mesa de arriba hacia abajo.
            //La variable "mesaMax" representa el ancho de la mesa más grande.
            int y=2,mesaMax=0;

            //El ciclo inicializa los objetos Mesa que aparecerán a la izquierda de la pantalla.
            for (int i = 0; i < mesas.Length;i=i+2 )
            {
                mesas[i] = new Mesa(idSala,int.Parse(dt.Rows[i][0].ToString()),sesion, pantPr);
                mesas[i].cambiarPosicion(3, y);
                y = y + 88;
                pantPr.pnContSala.Controls.Add(mesas[i]);
                if (mesaMax < mesas[i].Width) mesaMax = mesas[i].Width;
            }

            //Este ciclo inicializa los objetos Mesa que aparecen a la derecha de la pantalla.
            y = 2;
            for (int i = 1; i < mesas.Length; i = i + 2)
            {
                mesas[i] = new Mesa(idSala, int.Parse(dt.Rows[i][0].ToString()),sesion, pantPr);
                mesas[i].Location = new System.Drawing.Point(mesaMax+40, y);
                y = y + 88;
                pantPr.pnContSala.Controls.Add(mesas[i]);
            }
        }

         //Este método borra el objeto Sala.
        public void borrarObjeto()
        {
            this.Dispose();
        }


    }
}
