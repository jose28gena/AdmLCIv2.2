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
    public partial class AdmnSoftware : Form
    {
        
        Conexion abrir = new Conexion();
        DataTable id_soft;
        Sesion a;
        
        public AdmnSoftware(Sesion b)
        {
           
            InitializeComponent();
            a = b;
            cargar_tabla1();
            if (b.tipoUsuario == "Asesor")
            {

                button3.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = false;

            } 

        }

       public void cargar_tabla1(){
     
           dataGridView1.DataSource= abrir.consultaLibreDT("SELECT sft_nombre AS 'Nombre' ,sft_version AS 'Versión'   FROM Software ");

            id_soft = abrir.consultaLibreDT("SELECT sft_id FROM Software");

       }  

  


       private void button3_Click(object sender, EventArgs e)
       {
           AgregarSoft mostrar = new AgregarSoft(this,a,false,"Agregar","" ,"","");
           mostrar.ShowDialog();
       }

       private void button2_Click(object sender, EventArgs e)
       {
           Eliminarsoft s = new Eliminarsoft(this,a);
           s.ShowDialog();
       }

       private void button4_Click(object sender, EventArgs e)
       {
           
         
           SoftwareEquipo mostrar = new SoftwareEquipo(true);
           mostrar.ShowDialog();

       
       }

       private void button5_Click(object sender, EventArgs e)
       {
           try
           {
               
               SoftwareEquipo mostrar = new SoftwareEquipo( false);
               mostrar.ShowDialog();
           } catch(NullReferenceException){ 

        MessageBox.Show("La lista de Software se encuentra vacia.", "Software", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
       }

       private void button1_Click(object sender, EventArgs e)
       {
         
           BuscarSoft mostrar = new BuscarSoft();
           mostrar.ShowDialog();
       }

       private void btBuscar_Click(object sender, EventArgs e)
       {
           try{

           dataGridView1.DataSource = abrir.consultaLibreDT("SELECT  sft_nombre AS 'Nombre' ,sft_version AS 'Versión'   FROM Software where sft_nombre = '"+ tbBuscar.Text+"'");
       } 
           catch(NullReferenceException){ 

        MessageBox.Show("La lista de Software se encuentra vacia.", "Software", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
       
       }

       private void tbBuscar_TextChanged(object sender, EventArgs e)
       {
           if (tbBuscar.Text.Equals("")) {
               
               cargar_tabla1();
           }
       }

       private void tbBuscar_KeyPress(object sender, KeyPressEventArgs e)
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

       private void button6_Click(object sender, EventArgs e)
       {
           AgregarSoft mostrar = new AgregarSoft(this,a, true, "Guardar", id_soft.Rows[dataGridView1.CurrentRow.Index]["sft_id"].ToString(), dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString(), dataGridView1.CurrentRow.Cells["Versión"].Value.ToString());
           mostrar.ShowDialog();

       }

       private void AdmnSoftware_Load(object sender, EventArgs e)
       {

       }

      
   

      

      

       


    }
}
