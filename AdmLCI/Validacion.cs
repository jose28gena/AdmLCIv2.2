using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdmLCI
{
    public class Validacion
    {

        public bool validar(KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar))            
                return false;
            
            else if (Char.IsControl(e.KeyChar))            
                return false;
            
            else if (Char.IsSeparator(e.KeyChar))            
                return false;
            
            else if (Char.IsNumber(e.KeyChar)) 
                return false;
                          
            else            
                return true;
                       
        }

        public bool IsNumeric(object x)
        {
            bool isNumber;
            double isItNumeric;
            isNumber = Double.TryParse(Convert.ToString(x), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out isItNumeric);
            return isNumber;

        }

        public string validar(string txt)
        {
            char[] texto = txt.ToCharArray();
            string textoAnt = txt;

            for (int i = 0; i < texto.Length; i++)
            {
               
                if (texto[i] == '^' || texto[i] == '&' || texto[i] == '*' || texto[i] == '(' || texto[i] == ')' ||
                    texto[i] == '=' || texto[i] == '[' || texto[i] == ']' || texto[i] == '\'' || texto[i] == ';'
                    || texto[i] == '/' || texto[i] == '.' || texto[i] == ',' || texto[i] == '<' || texto[i] == '>'
                    || texto[i] == '?' || texto[i] == '\"' || texto[i] == ':' || texto[i] == '}' || texto[i] == '{'
                    || texto[i] == '+' || texto[i] == '~' || texto[i] == '`' || texto[i] == '\\'
                    || texto[i] == '|' || texto[i] == '!' || texto[i] == '#' || texto[i] == '$' || texto[i] == '%')
                {
                    return textoAnt.Substring(0, i) + textoAnt.Substring(i + 1);
                }


            }

            return textoAnt;

        }

        public bool validarSinEspacio(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                return false;

            else if (Char.IsControl(e.KeyChar))
                return false;

            else if (Char.IsNumber(e.KeyChar))
                return false;

            else
                return true;

        }
        
        public bool validarLetras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                return false;

            else if (Char.IsControl(e.KeyChar))
                return false;

            else if (Char.IsSeparator(e.KeyChar))
                return false;

            else if (Char.IsNumber(e.KeyChar))
                return false;

            else
                return true;

        }


        public bool verificarEspacios(GroupBox gb)
        {
            
            foreach (Control c in gb.Controls)
            {
                if (c is TextBox)
                {
                    
                    if (c.Text.Trim().Equals("") )
                    {                        
                        return true;
                    }
                }
            }
            return false;
        }

        

        public bool verificarEspacios(Panel p)
        {
            foreach (Control c in p.Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text.Trim().Equals(""))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
