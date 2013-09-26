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
    public partial class ReactivarEspecial : Form
    {
        String id;
        Conexion abrir = new Conexion();
        Lista_especiales inst_esp = new Lista_especiales();
        DateTime h = DateTime.Today;
        public ReactivarEspecial(String ales_id, Lista_especiales e)
        {
            id = ales_id;
            InitializeComponent();
            inst_esp = e;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((h.CompareTo(dateTimePicker1.Value) == 1))
            {
                MessageBox.Show("La fecha de reactivacion debe ser mayor a la fecha actual.", "Alumnos Especiales",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                abrir.modificar("UPDATE AlumnoEspecial SET ales_estado='Activo',ales_fecha_fin = '" + (dateTimePicker1.Value.ToString("dd-MM-yyyy")+ " 00:00:00.000'") + " WHERE ales_id =" + id);
                inst_esp.cargar();
              
                 this.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             this.Close();
        }


       
    }
}
