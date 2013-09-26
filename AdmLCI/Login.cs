using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AdmLCI
{
    public partial class Login : Form
    {

        public static PantallaPrincipal ventana;
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sesion s = new Sesion(tbUsuario.Text);
            
            if (!tbContrasenia.Text.Equals("") || !tbUsuario.Text.Equals(""))
            {
                if (s.inicioSesion(tbContrasenia.Text))
                {
                   ventana = new PantallaPrincipal(s, this);
                    ventana.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("El usuario o la contraseña son incorrectos. Intente de nuevo.");
            }
            else
                MessageBox.Show("Debe llenar ambos campos para iniciar sesión");
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

      

        public void validarTB(object sender, KeyEventArgs e)
        {
            
            if(!e.KeyCode.Equals(e.Shift))
            MessageBox.Show(""+e.KeyCode+" ");
        }

       

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {

            tbUsuario.Text= validar(tbUsuario.Text);
            tbUsuario.Select(tbUsuario.Text.Length, 0);
            
        }

        public string validar(string txt){
            char[] texto = txt.ToCharArray();
            string textoAnt = txt;

            for (int i = 0; i < texto.Length; i++) {
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

        private void tbContrasenia_TextChanged(object sender, EventArgs e)
        {
            tbContrasenia.Text = validar(tbContrasenia.Text);
            tbContrasenia.Select(tbContrasenia.Text.Length, 0);
        }

        private void tbContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) {
                Sesion s = new Sesion(tbUsuario.Text);

                if (!tbContrasenia.Text.Equals("") || !tbUsuario.Text.Equals(""))
                {
                    if (s.inicioSesion(tbContrasenia.Text))
                    {
                        PantallaPrincipal ventana = new PantallaPrincipal(s, this);
                        ventana.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("El usuario o la contraseña son incorrectos. Intente de nuevo.");
                }
                else
                    MessageBox.Show("Debe llenar ambos campos para iniciar sesión");
            
            }
        }

        private void btConfg_Click(object sender, EventArgs e)
        {
            Config c = new Config();
            c.ShowDialog(this);
        }

        
    }
}
