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
    public partial class admonEquipos : Form
    {
        Conexion con = new Conexion();
        PantallaPrincipal pantP;
        Sesion sesion;

        public admonEquipos( PantallaPrincipal pp, Sesion s)
        {
            InitializeComponent();
            sesion = s;
            mostrarEquipos();
            //pp.Enabled = false;
            //pantP = pp;
        }

        public string validar(string txt)
        {
            char[] texto = txt.ToCharArray();
            string textoAnt = txt;

            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] == '!' || texto[i] == '@' || texto[i] == '#' || texto[i] == '$' || texto[i] == '%' ||
                    texto[i] == '^' || texto[i] == '&' || texto[i] == '*' || texto[i] == '(' || texto[i] == ')' ||
                    texto[i] == '=' || texto[i] == '[' || texto[i] == ']' || texto[i] == '\'' || texto[i] == ';'
                    || texto[i] == '/' || texto[i] == '.' || texto[i] == ',' || texto[i] == '<' || texto[i] == '>'
                    || texto[i] == '?' || texto[i] == '\"' || texto[i] == ':' || texto[i] == '}' || texto[i] == '{'
                    || texto[i] == '+' || texto[i] == '_' || texto[i] == '~' || texto[i] == '`' || texto[i] == '\\'
                    || texto[i] == '|')
                {
                    return textoAnt.Substring(0, i) + textoAnt.Substring(i + 1);
                }


            }

            return textoAnt;

        }

        //Carga los equipos en el dataGridView
        public void mostrarEquipos() { 
           // DataTable equipos=con.consultaLibreDT("select ieq_id as 'ID', ieq_contraloria as 'No. contraloría',ieq_noserie_cpu as 'Serie CPU',ieq_noserie_mon as 'Serie monitor',Sala.sa_letra as 'Sala',ieq_numero as 'No. equipo',ieq_estado as 'Estado',ieq_tipo as 'Tipo',ieq_mesa as 'Mesa' from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id ORDER BY Sala.sa_letra");
            //dgvEquipos2.DataSource = con.consultaLibreDT("select ieq_id as 'ID', ieq_contraloria as 'No. contraloría',ieq_noserie_cpu as 'Serie CPU',ieq_noserie_mon as 'Serie monitor',Sala.sa_letra as 'Sala',ieq_numero as 'No. equipo',ieq_estado as 'Estado',ieq_tipo as 'Tipo',ieq_mesa as 'Mesa' from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id ORDER BY Sala.sa_letra");

            dgvEquipos.DataSource = con.consultaLibreDT("select ieq_contraloria as 'No. contraloría',ieq_noserie_cpu as 'Serie CPU',ieq_noserie_mon as 'Serie monitor',Sala.sa_letra as 'Sala',ieq_numero as 'No. equipo',ieq_estado as 'Estado',ieq_tipo as 'Tipo',ieq_mesa as 'Mesa' from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id ORDER BY Sala.sa_letra");
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //pantP.Enabled = true;
            this.Close();
        }

        //Agregar un equipo nuevo al inventario.
        private void btAgregar_Click(object sender, EventArgs e)
        {
            AgregarEquipo ae = new AgregarEquipo( this,sesion);
            ae.ShowDialog(this);
            
        }

        private void admonEquipos_Load(object sender, EventArgs e)
        {
          
        }

        //Eliminar un equipo
        private void btEliminar_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("delete from InvEquipo where ieq_contraloria=" + dgvEquipos.CurrentRow.Cells[0].Value.ToString());
            DialogResult res = MessageBox.Show("¿Realmente desea borrar la fila seleccionada?", "Eliminar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (res == DialogResult.Yes)
            {
               // MessageBox.Show("delete from InvEquipo where ieq_contraloria=" + dgvEquipos.Rows[dgvEquipos.CurrentRow.Index].Cells[0].Value.ToString());
                if (con.modificar("delete from InvEquipo where ieq_contraloria='" + dgvEquipos.Rows[dgvEquipos.CurrentRow.Index].Cells[0].Value.ToString()+"'"))
                {
                    //dgvEquipos2.Rows.RemoveAt(dgvEquipos.CurrentRow.Index);
                    con.modificar("insert into HistorialAcciones (ha_accion,usr_id,ha_objeto,ieq_contraloria,ha_fecha) values('Eliminar','" + sesion.idUsr + "', 'E-" + dgvEquipos.Rows[dgvEquipos.CurrentRow.Index].Cells[3].Value.ToString() + dgvEquipos.Rows[dgvEquipos.CurrentRow.Index].Cells[4].Value.ToString() + "','" + dgvEquipos.Rows[dgvEquipos.CurrentRow.Index].Cells[0].Value.ToString() + "','" + (DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute) + "') ");
                    dgvEquipos.Rows.RemoveAt(dgvEquipos.CurrentRow.Index);
                    
                }
            }
        }

        //Modificar un equipo.
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (dgvEquipos.RowCount > 0)
            {
                //string[] datosEq = new string[dgvEquipos.CurrentRow.Cells.Count];

               
                ////Se obtienen los datos del equipo que se desea modificar.
                //for (int i = 0; i < datosEq.Length; i++)
                //{
                //    datosEq[i] = dgvEquipos.Rows[dgvEquipos.CurrentRow.Index].Cells[i].Value.ToString();
                //   // MessageBox.Show("" + dgvEquipos.Rows[dgvEquipos.CurrentRow.Index].Cells[i].Value.ToString());
                //}
                AgregarEquipo ae = new AgregarEquipo(this, dgvEquipos.Rows[dgvEquipos.CurrentRow.Index].Cells[0].Value.ToString(),sesion);
                //ae.ShowDialog(this);
                ae.ShowDialog();
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (cbOpc.SelectedIndex >= 0) {
                if (!tbBuscar.Text.Trim().Equals(""))
                {
                    if(cbOpc.SelectedIndex==3)
                     
                        dgvEquipos.DataSource = con.consultaLibreDT("select ieq_contraloria as 'No. contraloría',ieq_noserie_cpu as 'Serie CPU',ieq_noserie_mon as 'Serie monitor',Sala.sa_letra as 'Sala',ieq_numero as 'No. equipo',ieq_estado as 'Estado',ieq_tipo as 'Tipo',ieq_mesa as 'Mesa' from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where Sala.sa_letra LIKE'%"+tbBuscar.Text.Trim()+"%' ORDER BY Sala.sa_letra");
                    
                    else if (cbOpc.SelectedIndex == 0)
                        dgvEquipos.DataSource = con.consultaLibreDT("select ieq_contraloria as 'No. contraloría',ieq_noserie_cpu as 'Serie CPU',ieq_noserie_mon as 'Serie monitor',Sala.sa_letra as 'Sala',ieq_numero as 'No. equipo',ieq_estado as 'Estado',ieq_tipo as 'Tipo',ieq_mesa as 'Mesa' from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where InvEquipo.ieq_noserie_cpu LIKE'%" + tbBuscar.Text.Trim() + "%' ORDER BY Sala.sa_letra");
                    else if (cbOpc.SelectedIndex == 1)
                        dgvEquipos.DataSource = con.consultaLibreDT("select ieq_contraloria as 'No. contraloría',ieq_noserie_cpu as 'Serie CPU',ieq_noserie_mon as 'Serie monitor',Sala.sa_letra as 'Sala',ieq_numero as 'No. equipo',ieq_estado as 'Estado',ieq_tipo as 'Tipo',ieq_mesa as 'Mesa' from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where InvEquipo.ieq_noserie_mon LIKE '%" + tbBuscar.Text.Trim() + "%' ORDER BY Sala.sa_letra");
                    else if (cbOpc.SelectedIndex == 2)
                        dgvEquipos.DataSource = con.consultaLibreDT("select ieq_contraloria as 'No. contraloría',ieq_noserie_cpu as 'Serie CPU',ieq_noserie_mon as 'Serie monitor',Sala.sa_letra as 'Sala',ieq_numero as 'No. equipo',ieq_estado as 'Estado',ieq_tipo as 'Tipo',ieq_mesa as 'Mesa' from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where InvEquipo.ieq_contraloria LIKE '%" + tbBuscar.Text.Trim() + "%' ORDER BY Sala.sa_letra"); 

                }
                else
                    MessageBox.Show("Debe escribir lo que desea encontrar en el campo.");
            }
            else
                MessageBox.Show("Debe seleccionar una opción para filtrar la búsqueda.");
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tbBuscar.Text.Trim().Equals(""))
                dgvEquipos.DataSource = con.consultaLibreDT("select ieq_id as 'ID', ieq_contraloria as 'No. contraloría',ieq_noserie_cpu as 'Serie CPU',ieq_noserie_mon as 'Serie monitor',Sala.sa_letra as 'Sala',ieq_numero as 'No. equipo',ieq_estado as 'Estado',ieq_tipo as 'Tipo',ieq_mesa as 'Mesa' from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id ORDER BY Sala.sa_letra"); 
        }

        private void tbBuscar_TextChanged_1(object sender, EventArgs e)
        {
            tbBuscar.Text = validar(tbBuscar.Text);
            tbBuscar.Select(tbBuscar.Text.Length, 0);
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        
    }
}
