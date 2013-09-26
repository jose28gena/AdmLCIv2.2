using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using AdmLCI.Properties;
using System.Drawing;
namespace AdmLCI
{
   public class Locker : Button

    {
      
       public String lok_num, lok_sem, est_nombre, año_actual, estado,lok_inicio,lok_fin,expediente;
       public Locker[] locker;
       AdmnLockers a;

       public Locker()
       {

        
        
           asignarPropiedades();
           
       }

       public void asignarPropiedades()
       {
           this.Width = 70;
           this.Height = 84;
           this.ImageAlign = ContentAlignment.TopCenter;
           this.TextAlign = ContentAlignment.BottomCenter;
           this.FlatStyle = FlatStyle.Popup;
           this.Font = new Font(this.Font.Name, 7, FontStyle.Bold);
           this.Image = Resources.locker_empty;
          
       }


       public void asignarDatos(String num,String est,String fecha_inicio,String fecha_fin,String alum,String sem)
       {
           expediente = alum;
           lok_num = num;
           lok_sem = sem;
           est_nombre = alum;
           lok_inicio = fecha_inicio;
           lok_fin = fecha_fin;
           estado = est;
           this.Text = num.ToString();
           asignarPropiedades();
           if (estado.Equals("No disponible"))
               this.Image = Resources.Locker_asignado;


       }

     
     
       private void lock_img_asig() {

           this.Image = Resources.Locker_asignado;
       
       }
       private void lock_img_libre()
       {

           this.Image = Resources.locker_empty;

       }

       public void cambiarPosicion(int X, int Y)
       {
           this.Location = new System.Drawing.Point(X, Y);
       }
       public void borrarObjeto()
       {
           this.Dispose();
       }
    }
}
