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
    class Tooltipslock : ToolTip 
    {
        public Tooltipslock[] tooltips;
        public String lok_num, lok_sem, est_nombre, año_actual, estado, lok_inicio, lok_fin;
        AdmnLockers a;
        
       public Tooltipslock()
       {

        
        
           asignarPropiedades();
           
       }
        public void asignarPropiedades()
        {
            
            this.UseFading = true;
            this.UseAnimation = true;
            this.IsBalloon = true;
            this.ShowAlways = true;
           this.AutoPopDelay = 5000;
            this.InitialDelay = 1000;
            this.ReshowDelay = 500;

        }
        public void asignarDatos(String num, String est, String fecha_inicio, String fecha_fin, String alum, String sem)
        {
            lok_num = num;
            lok_sem = sem;
            est_nombre = alum;
            lok_inicio = fecha_inicio;
            lok_fin = fecha_fin;
            estado = est;
            
            asignarPropiedades();
       
           

        }
        public void borrarObjeto()
        {
            this.Dispose();
        }
    }
}
