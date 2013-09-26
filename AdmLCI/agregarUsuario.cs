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
    public partial class agregarUsuario : Form
    {
        admonUsuarios admonUsuario;
        bool modificar=false;
        DataTable datos;
        Validacion v = new Validacion();

        public agregarUsuario(admonUsuarios au)
        {
            InitializeComponent();
            admonUsuario = au;
            
        }
        
        public agregarUsuario(admonUsuarios au, DataTable d)
        {
            InitializeComponent();
            admonUsuario = au;
            this.Text = "Modificar usuario";
            modificar = true;
            datos = d;

            tbUsuario.Enabled = false;
            tbUsuario.Text=d.Rows[0]["usr_usuario"].ToString();
            tbApellidoP.Text = d.Rows[0]["usr_apellidoP"].ToString();
            tbApellidoM.Text = d.Rows[0]["usr_apellidoM"].ToString();
            tbNombre.Text = d.Rows[0]["usr_nombre"].ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
        private void button1_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            if (cbTipoUsuario.SelectedIndex>=0)
            {
               
                if (!v.verificarEspacios(groupBox1))
                {
                    if (!con.existe("usr_usuario", "Usuario", "usr_usuario=\'" + tbUsuario.Text.Trim() + "\'") && (tbContrasenia.Text.Trim().Equals(tbConfirmarContrasenia.Text.Trim())))
                    {
                       
                            con.modificar("insert into Usuario(usr_nombre, usr_apellidoP, usr_apellidoM, usr_contra, tpusr_id, usr_usuario) values('" + tbNombre.Text + "','" + tbApellidoP.Text + "','" + tbApellidoM.Text + "','" + tbContrasenia.Text + "','" + (cbTipoUsuario.SelectedIndex + 1) + "','" + tbUsuario.Text + "')");
                            admonUsuario.cargarUsuarios();
                            this.Close();
                        
                    }
                    else if (con.existe("usr_usuario", "Usuario", "usr_usuario=\'" + tbUsuario.Text + "\'") && (tbContrasenia.Text.Equals(tbConfirmarContrasenia.Text)) && modificar == true)
                    {
                        con.modificar("update Usuario set usr_nombre='" + tbNombre.Text + "', usr_apellidoP='" + tbApellidoP.Text + "', usr_apellidoM='" + tbApellidoM.Text + "', usr_contra='" + tbContrasenia.Text + "', tpusr_id='" + (cbTipoUsuario.SelectedIndex+1) + "', usr_usuario= '" + tbUsuario.Text + "' where usr_id="+datos.Rows[0][0]);
                        admonUsuario.cargarUsuarios();
                        this.Close();
                    }
                    else
                        MessageBox.Show("El usuario ya existe o las contraseñas no coinciden.");
                }
                else
                    MessageBox.Show("Debe llenar todos los campos.");
            }
            else
                MessageBox.Show("Debe elegir un tipo de usuario.");
        }

        private void agregarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {
            tbUsuario.Text = v.validar(tbUsuario.Text);
            tbUsuario.Select(tbUsuario.Text.Length, 0);
        }

        private void tbContrasenia_TextChanged(object sender, EventArgs e)
        {
            tbContrasenia.Text = v.validar(tbContrasenia.Text);
            tbContrasenia.Select(tbContrasenia.Text.Length, 0);
        }

        private void tbConfirmarContrasenia_TextChanged(object sender, EventArgs e)
        {
            tbConfirmarContrasenia.Text = v.validar(tbConfirmarContrasenia.Text);
            tbConfirmarContrasenia.Select(tbConfirmarContrasenia.Text.Length, 0);
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            tbNombre.Text = v.validar(tbNombre.Text);
            tbNombre.Select(tbNombre.Text.Length, 0);
        }

        private void tbApellidoP_TextChanged(object sender, EventArgs e)
        {
            tbApellidoP.Text = v.validar(tbApellidoP.Text);
            tbApellidoP.Select(tbApellidoP.Text.Length, 0);
        }

        private void tbApellidoM_TextChanged(object sender, EventArgs e)
        {
            tbApellidoM.Text = v.validar(tbApellidoM.Text);
            tbApellidoM.Select(tbApellidoM.Text.Length, 0);
        }

     
        
    }
}
