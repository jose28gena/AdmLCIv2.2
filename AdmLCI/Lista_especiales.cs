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

    public partial class Lista_especiales : Form
    {
       
        
        Conexion abrir = new Conexion();
        String exp;
        String id;
        PantallaPrincipal a = new PantallaPrincipal();
       


        public Lista_especiales()
        {


            InitializeComponent();


        }

        private void Lista_especiales_Load(object sender, EventArgs e)
        {

            cargar();

        }

       

        public void cargar()
        {
            tabla1.DataSource = abrir.consultaLibreDT("SELECT ales_estado AS 'Estado', (ales_nombre+' '+ales_ape_pat+' '+ales_ape_mat) AS 'Nombre',ales_id AS 'Expediente interno' ,ales_exp_ext AS 'Expediente externo',ales_fecha_inicio AS 'Fecha inicio', ales_fecha_fin 'Fecha limite' FROM AlumnoEspecial where ales_nombre!='root'");
           

        }
        public void filtro()
        {

            int id_ales;
            bool conv = int.TryParse(textBox1.Text, out id_ales);
            if (!conv) { id_ales = 0; }
            if (!String.IsNullOrEmpty(textBox1.Text))
            {

                tabla1.DataSource = abrir.consultaLibreDT("SELECT ales_estado AS 'Estado',(ales_nombre+' '+ales_ape_pat+' '+ales_ape_mat) AS 'Nombre',ales_id AS 'Expediente interno'" +
                        ",ales_exp_ext AS 'Expediente externo',ales_fecha_inicio AS 'Fecha inicio',ales_fecha_fin 'Fecha limite' FROM AlumnoEspecial " +
                         "where ales_exp_ext='" + textBox1.Text + "' or ales_id =" + id_ales + " or ales_nombre +' '+ ales_ape_pat + ' '+ ales_ape_mat LIKE '%" + textBox1.Text + "%' and  ales_nombre!='root'");

                //((DataTable)this.tabla1.DataSource).DefaultView.RowFilter = "Nombre LIKE '%"+textBox1.Text+"%'" ;
            }
            else
            {
                MessageBox.Show("Ingresar expediente.", "Usuarios especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btBuscar_Click(object sender, EventArgs e)
        {
            filtro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AlumnosEspeciales ae = new AlumnosEspeciales(this, true, "", "");
            ae.ShowDialog();
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
             this.Close();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
  
            AlumnosEspeciales cambio = new AlumnosEspeciales(this, true, id, exp);
            cambio.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           try{

                exp = tabla1.CurrentRow.Cells["Expediente externo"].Value.ToString();
                id = tabla1.CurrentRow.Cells["Expediente interno"].Value.ToString();
                AlumnosEspeciales cambio = new AlumnosEspeciales(this, false, id, exp);
                cambio.ShowDialog();
            
             }catch(NullReferenceException){ 

       
          }
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
             this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                filtro();
            }   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                cargar();
            
            }
        }
            
        private void checkBox1_CheckedChanged(object sender, 
            EventArgs e)
        {
            if (checkBox1.Checked)
            {

              tabla1.DataSource = abrir.consultaLibreDT("SELECT ales_estado AS 'Estado', (ales_nombre+' '+ales_ape_pat+' '+ales_ape_mat) AS 'Nombre',ales_id AS 'Expediente interno' ,ales_exp_ext AS 'Expediente externo',ales_fecha_inicio AS 'Fecha inicio', ales_fecha_fin 'Fecha limite' FROM AlumnoEspecial where ales_nombre!='root' AND ales_estado='Activo'");

            }
            else
            {

                cargar();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {


            Eliminarespecial a = new Eliminarespecial(this);
            a.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
            ReactivarEsp a = new ReactivarEsp( this);
            a.ShowDialog();

             }catch(NullReferenceException){

                 MessageBox.Show("La lista de Usuarios especiales esta vacia.", "Usuarios Especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
          }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            InactivoEsp a = new InactivoEsp(this);
            a.ShowDialog();

        }
    }
}
