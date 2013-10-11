using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdmLCI.Properties;

namespace AdmLCI
{
    public partial class AgregarEquipo : Form
    {
        admonEquipos admEq;
        DataTable datosEquipos;
        bool modificar = false;
        DataTable dtS;
        Validacion v = new Validacion();
        Sesion sesion;
        int idEquipo=0;

        //Constructor para la ventana de agregar equipo.
        public AgregarEquipo(admonEquipos ae, Sesion s)
        {
            InitializeComponent();
            sesion = s;
            admEq = ae;
            cargarComboBox();
            modificar = false;
           
            
        }

        //Constructor para la ventana que modifica un equipo.
        public AgregarEquipo(admonEquipos ae, string contraloria, Sesion s)
        {
            InitializeComponent();
            sesion = s;
            admEq = ae;

            Conexion con=new Conexion();
            datosEquipos = con.consultaLibreDT("select * from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where InvEquipo.ieq_contraloria='"+contraloria+"'");
            this.Text = "Modificar equipo";
            pbImagen.Image = Resources.modificarComp;
            modificar = true;
            
            //Cargar las salas existentes en el ComboBox.
            cargarComboBox();

            //Datos del equipo a modificar.
            if (datosEquipos.Rows.Count > 0)
            {
                tbContraloria.Text = datosEquipos.Rows[0]["ieq_contraloria"].ToString();
                tbCPU.Text = datosEquipos.Rows[0]["ieq_noserie_cpu"].ToString();
                tbMonitor.Text = datosEquipos.Rows[0]["ieq_noserie_mon"].ToString();
                tbNumEq.Text = datosEquipos.Rows[0]["ieq_numero"].ToString();
                tbNoMesa.Text = datosEquipos.Rows[0]["ieq_mesa"].ToString();
                cbTipo.SelectedIndex = (datosEquipos.Rows[0]["ieq_tipo"].ToString().Equals("Individual") ? 0 : 1);
                cbSala.SelectedItem = datosEquipos.Rows[0]["sa_letra"].ToString();
            }
            else {
                MessageBox.Show("Hubo un error al revisar los datos");
                this.Close();
            }

            //foreach (Control c in gb.Controls)
            //{
            //    if (c is TextBox)
            //    {
            //        c.KeyPress += TextBox_KeyPress;
                   
            //    }
            //}
        }

        //Toma las salas existentes en la base de datos para acomodarlas en el ComboBox de las salas
        public void cargarComboBox() {
            Conexion con = new Conexion();
            dtS = con.consultaLibreDT("SELECT * FROM Sala");
            
            for (int i = 0; i < dtS.Rows.Count; i++)                
                cbSala.Items.Add(dtS.Rows[i][1].ToString());              
       }
        
        public void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion v = new Validacion();
            if (v.validar(e))
                e.Handled = true;
            else
                e.Handled = false;
        }


        //Evento para agregar un nuevo equipo o modificar uno que ya existe.
        private void button1_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            if (cbSala.SelectedIndex >= 0 && cbTipo.SelectedIndex >= 0)
            {
                Validacion v = new Validacion();
                if (!v.verificarEspacios(gb))
                {
                    
                    //Si el equipo ya existe se modificará la información
                    if (modificar && !con.existe("select * from InvEquipo where (ieq_contraloria='" + datosEquipos.Rows[0]["ieq_contraloria"].ToString() + "' or ieq_noserie_cpu='" + datosEquipos.Rows[0]["ieq_noserie_cpu"].ToString() + "' or ieq_noserie_mon='" + datosEquipos.Rows[0]["ieq_noserie_mon"].ToString() + "') and ieq_id!=" + datosEquipos.Rows[0]["ieq_id"].ToString()))
                    {
                        //MessageBox.Show("Modificiar datos");
                        con.modificar("update InvEquipo set ieq_contraloria='" + tbContraloria.Text.Trim() + "', ieq_noserie_cpu='" + tbCPU.Text.Trim() + "',ieq_noserie_mon='" + tbMonitor.Text.Trim() + "', sa_id='" + (cbSala.SelectedIndex + 1) + "', ieq_numero='" + tbNumEq.Text.Trim() + "', ieq_mesa='" + tbNoMesa.Text.Trim() + "',ieq_tipo='" + cbTipo.SelectedItem + "' where ieq_id="+datosEquipos.Rows[0]["ieq_id"].ToString());
                        admEq.mostrarEquipos();
                        this.Close();
                    }
                    //Si no existe se agrega un nuevo equipo.
                    else if (modificar == false && !con.existe("select * from InvEquipo where ieq_contraloria='" + tbContraloria.Text + "' or ieq_noserie_cpu='" + tbCPU.Text + "' or ieq_noserie_mon='" + tbMonitor.Text + "'"))
                    {

                        if (!con.existe("SELECT ieq_numero FROM  InvEquipo INNER JOIN Sala ON (InvEquipo.sa_id= Sala.sa_id) WHERE sa_letra='"+cbSala.GetItemText(cbSala.SelectedItem)+"' and ieq_numero="+tbNumEq.Text+" ORDER BY ieq_numero;"))
                        {
                            string[] campos = { "ieq_noserie_cpu", "ieq_noserie_mon", "ieq_contraloria", "sa_id", "ieq_numero", "ieq_mesa", "ieq_tipo" };
                            string[] datos = { "'" + tbCPU.Text.Trim() + "'", "'" + tbMonitor.Text.Trim() + "'", "'" + tbContraloria.Text.Trim() + "'", "'" + (dtS.Rows[cbSala.SelectedIndex][0].ToString()) + "'", tbNumEq.Text.Trim(), tbNoMesa.Text.Trim(), "'" + cbTipo.Items[cbTipo.SelectedIndex].ToString() + "'" };
                            con.insertarEnTabla(campos, datos, "InvEquipo");
                            con.modificar("insert into HistorialAcciones (ha_accion,usr_id,ha_objeto,ieq_contraloria, ha_fecha) values('Agregar','" + sesion.idUsr + "', 'E-" + cbSala.Items[cbSala.SelectedIndex].ToString() + tbNumEq.Text + "','" + tbContraloria.Text + "','" + (DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute) + "') ");
                            admEq.mostrarEquipos();
                            this.Close();
                        }
                        else { MessageBox.Show("Ya hay una computadora con ese número, favor de revisarlo"); }
                       
                    }
                    else
                        MessageBox.Show("Verifique que no esta duplicando el número de contraloría, número de serie del CPU o el número de serie del monitor.");
                    
                }
                else
                    MessageBox.Show("Debe llenar todos los campos para agregar un equipo nuevo.", "Error al agregar equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Debe seleccionar una sala y un tipo para el equipo.", "Error al agregar equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
        
        //Botón de cancelar.
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarEquipo_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbSala_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbContraloria_TextChanged(object sender, EventArgs e)
        {
            tbContraloria.Text = v.validar(tbContraloria.Text);
            tbContraloria.Select(tbContraloria.Text.Length, 0);
            tbContraloria.CharacterCasing = CharacterCasing.Upper;
        }

        private void tbCPU_TextChanged(object sender, EventArgs e)
        {
            tbCPU.Text = v.validar(tbCPU.Text);
            tbCPU.Select(tbCPU.Text.Length, 0);
            tbCPU.CharacterCasing = CharacterCasing.Upper;
        }

        private void tbMonitor_TextChanged(object sender, EventArgs e)
        {
            tbMonitor.Text = v.validar(tbMonitor.Text);
            tbMonitor.Select(tbMonitor.Text.Length, 0);
            tbMonitor.CharacterCasing = CharacterCasing.Upper;
        }

        private void tbNumEq_TextChanged(object sender, EventArgs e)
        {
            tbNumEq.Text = v.validar(tbNumEq.Text);
            tbNumEq.Select(tbNumEq.Text.Length, 0);
        }

        private void tbNoMesa_TextChanged(object sender, EventArgs e)
        {
            tbNoMesa.Text = v.validar(tbNoMesa.Text);
            tbNoMesa.Select(tbNoMesa.Text.Length, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

       /* public Boolean validarPc()
        {
            Boolean NoExiste=true;
            String query = "SELECT ieq_numero FROM  InvEquipo INNER JOIN Sala ON (InvEquipo.sa_id= Sala.sa_id) WHERE sa_letra='" + cbSala.GetItemText(cbSala.SelectedItem) + "' ORDER BY ieq_numero";
            Conexion con = new Conexion();
            DataTable dt = con.consultaLibreDT(query);
            return NoExiste;
        }*/
    }
}
