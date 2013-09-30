using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace AdmLCI
{
    class Conexion
    {
        public string cadenaConexion;
        SqlConnection con;
        
        public Conexion() {
            

            //cadenaConexion = "Data Source=DNB-PC\\SQLEXPRESS;Initial Catalog=lciFinal;User ID=denneb;Password=estaciones2;Trusted_Connection=False";
            try
            {
          //cadenaConexion = "Data Source=" + obtenerServidor() +              ";Initial Catalog=" + obtenerBD() + ";User ID=" + obtenerUsr() + ";Password=" + obtenerPass() + ";Trusted_Connection=False";
          // esta es la buena
                
         cadenaConexion="Data Source=148.225.26.18;Initial Catalog=lci;User ID=siscalc;Password=siscalc;Trusted_Connection=False";
      //   cadenaConexion = "Data Source=Win8\\ISI;Initial Catalog=LCIFinal;User ID=Jose;Password=203203280  ;Trusted_Connection=False";

                con = new SqlConnection(cadenaConexion);
            }
            catch (SqlException se) {
                MessageBox.Show("No se pudo realizar la conexión con la base de datos.");
            }  
        }

        public string obtenerBD()
        {
            String line = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("config.txt");

                //Read the first line of text
                line = sr.ReadLine();

                string bd = "";
                //Continue to read until you reach end of file
                while (line != null)
                {

                    if (line.StartsWith("basedatos:"))
                    {
                        bd= line.Substring(line.IndexOf(":") + 1);

                    }

                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                return bd;
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error al obtener los datos");
                //con.Close();
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
            return "";
        }

        public string obtenerServidor()
        {
            String line = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("config.txt");

                //Read the first line of text
                line = sr.ReadLine();
 
                string srv = "";
                //Continue to read until you reach end of file
                while (line != null)
                {

                    if (line.StartsWith("servidor:"))
                    {
                        srv = line.Substring(line.IndexOf(":") + 1);

                    }

                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                return srv;
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                //con.Close();
                //MessageBox.Show("Error al obtener los datos");
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
            return "";
        }

        public string obtenerUsr()
        {
            String line = "";
            try
            {
                
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("config.txt");

                //Read the first line of text
                line = sr.ReadLine();

                string usr = "";
                //Continue to read until you reach end of file
                while (line != null)
                {

                    if (line.StartsWith("usuario:"))
                    {
                        usr= line.Substring(line.IndexOf(":") + 1);

                    }

                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                return usr;
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error al obtener los datos");
                //con.Close();
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
            return "localhost";
        }

        public string obtenerPass()
        {
            String line = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("config.txt");

                //Read the first line of text
                line = sr.ReadLine();

                string pass = "";
                //Continue to read until you reach end of file
                while (line != null)
                {

                    if (line.StartsWith("contrasenia:"))
                    {
                        pass = line.Substring(line.IndexOf(":") + 1);

                    }

                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                return pass;
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                //con.Close();
                //MessageBox.Show("Error al obtener los datos");
            }
            finally
            {
                //Console.WriteLine("Executing finally block.");
            }
            return "localhost";
        }

        public bool Exists(String Id, string sql)
        {

            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("Id", Id);

            con.Open();

            int count = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            if (count == 0)
                return false;
            else
                return true;


        }

        public int procedimiento(string[] nomParam, string[] param, string nombre)
        {
            try
            {
                try
                {
                    con.Open();
                }
                catch(SqlException sql){
                    MessageBox.Show("Hubo un error en la conexión.");
                    return 0;
                }
                SqlCommand command = new SqlCommand(nombre, con);
                command.CommandType = CommandType.StoredProcedure;

                if (nomParam.Length == param.Length)
                {
                    for (int i = 0; i < nomParam.Length; i++)
                        command.Parameters.AddWithValue(nomParam[i], param[i]);
                }
                else
                    MessageBox.Show("No se pudo realizar la operación");

                int rowsAffected = command.ExecuteNonQuery();

                con.Close();

                if (rowsAffected > 0)
                    return 1;
                else
                    return 0;
            }
            catch(SqlException ex){
                MensajeError(ex);
                con.Close();
            }
            return 1;
            
        }

        public bool modificar(string consulta) {
            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión.");
                    return false;
                }
                SqlCommand comando = new SqlCommand(consulta, con);
                comando.ExecuteNonQuery();                
                con.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MensajeError(ex);
                con.Close();
                return false;

            }
        }     

        public int contarRegistros(string consulta)
        {
            int tot = 0;
            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión a la base de datos.");
                    return 0;
                }
                SqlCommand comando = new SqlCommand(consulta, con);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    tot = int.Parse(reader[0].ToString());
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                //con.Close();
                MensajeError(ex);
            }
            return tot;
        }

        
        public bool existe(string columna, string tabla, string condicion){
            bool bandera = false;

            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión a la base de datos.");
                    return false;
                }
                SqlCommand comando = new SqlCommand("select " + columna + " from " + tabla + " where " + condicion, con);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    bandera = true;
                }
                con.Close();
            }
            catch (SqlException ex)
            {
               // con.Close();
                MensajeError(ex);
            }
          
            return bandera;        
        }

        public bool existe(string consulta)
        {
            bool bandera = false;

            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión a la base de datos.");
                    return false;
                }
                SqlCommand comando = new SqlCommand(consulta, con);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    bandera = true;
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                MensajeError(ex);
               // con.Close();
            }
           

            return bandera;
        }

        public void MensajeError(SqlException ex)
        {
            StringBuilder errorMessages = new StringBuilder();
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                errorMessages.Append("Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Numero: " + ex.Errors[i].Number + "\n");
            }
            MessageBox.Show(errorMessages.ToString());
        }

        public void abrirConexion() {
                    
            try
            {
                con.Open();                 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }
                        
        }

        public void cerrarConexion() {            
            con.Close();
        }

        /*Recibe la linea de consulta completa y regresa un string con el resultado*/

        public string consultaLibreS(string consulta) {
            string resultado = "";
            try
            {
                abrirConexion();
                SqlCommand comm = new SqlCommand(consulta,con);
                SqlDataReader reader = comm.ExecuteReader();
                if(reader.Read())
                    resultado = reader[0].ToString();
                cerrarConexion();
                return resultado;
            }
            catch (SqlException ex)
            {
                MensajeError(ex);
                //con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
               // con.Close();
            }
            return "";
        }

        /*Recibe la linea de consulta completa y regresa un DataTable con el resultado*/
        public DataTable consultaLibreDT(string lineaConsulta)
        {
            DataTable t = new DataTable();
            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión a la base de datos.");
                    con.Close();
                    return t;
                }
                SqlDataAdapter adapter = new SqlDataAdapter(lineaConsulta, con);
                adapter.Fill(t);
                cerrarConexion();                
            }
            catch (SqlException ex)
            {
                MensajeError(ex);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            return t;
        }

      
        //Permite insertar datos en una tabla.
        public string insertarVarchar(string[] campos, string[] datos, string tabla)
        {
            string consulta = "INSERT INTO " + tabla + " (";
            for (int i = 0; i < campos.Length; i++)
            {
                consulta = consulta + campos[i];
                if (i < campos.Length - 1)
                    consulta = consulta + ",";
            }
            consulta = consulta + ") VALUES (";
            for (int i = 0; i < datos.Length; i++)
            {
                consulta = consulta + "\'"+datos[i]+"\'";
                if (i < datos.Length - 1)
                    consulta = consulta + ",";
            }
            consulta = consulta + ")";
            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión a la base de datos.");
                    con.Close();
                    return "";
                }
                SqlCommand comando = new SqlCommand(consulta, con);
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                MensajeError(ex);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return consulta;
        }

        //Permite insertar datos en una tabla.
        public string insertarEnTabla(string[] campos, string[] datos, string tabla)
        {
            string consulta = "INSERT INTO " + tabla + " (";
            for (int i = 0; i < campos.Length; i++)
            {
                consulta = consulta + campos[i];
                if (i < campos.Length - 1)
                    consulta = consulta + ",";
            }
            consulta = consulta + ") VALUES (";
            for (int i = 0; i < datos.Length; i++)
            {
                consulta = consulta + datos[i];
                if (i < datos.Length - 1)
                    consulta = consulta + ",";
            }
            consulta = consulta + ")";
            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión a la base de datos.");
                    return "";
                }
                SqlCommand comando = new SqlCommand(consulta, con);
                comando.ExecuteNonQuery();
                cerrarConexion();
            }
            catch (SqlException ex)
            {
                MensajeError(ex);
               // con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return consulta;
        }
       
       

        public bool borrarRegistro(string condicion, string tabla) {
            string consulta = "DELETE FROM "+tabla+" WHERE "+condicion;
            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión a la base de datos.");
                    return false;
                }
                SqlCommand comando = new SqlCommand(consulta, con);
                comando.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (Exception e) { con.Close(); 
                MessageBox.Show("No se pudo borrar el registro de la base de datos"); return false; }

            
        }

        public bool Validar_exp(string a)
        {
            bool flag = true;

            if ((!a.Equals("")) && (a.Length == 9))
            {
                for (int n = 0; n < a.Length; n++)
                {
                    if (!Char.IsNumber(a, n))

                        flag = false;
                }

            }
            else
            {

                flag = false;
            }
            return flag;
        }

        public DataTable consulta(string[] campos, string tabla, string[] nombreCampos)
        {
            string consulta = "SELECT ";
            DataTable t = new DataTable();
            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión a la base de datos.");
                    con.Close();
                    return t;
                }
                //El ciclo crea la cadena consulta con los campos recibidos.
                for (int i = 0; i < campos.Length; i++)
                {
                    consulta = consulta + campos[i] + " AS " + "\"" + nombreCampos[i] + "\"";
                    if (i < campos.Length - 1)
                        consulta = consulta + ",";
                }
                consulta = consulta + " FROM " + tabla;
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
                adapter.Fill(t);
                cerrarConexion();
            }
            catch (Exception e) { }

            return t;
        }

        public DataTable consulta(string[] campos, string tabla, string[] nombreCampos, string condicion)
        {
            string consulta = "SELECT ";
            DataTable t = new DataTable();
            try
            {
                try
                {
                    con.Open();
                }
                catch (SqlException sql)
                {
                    MessageBox.Show("Hubo un error en la conexión a la base de datos.");
                    return t;
                }
                //El ciclo crea la cadena consulta con los campos recibidos.
                for (int i = 0; i < campos.Length; i++)
                {
                    consulta = consulta + campos[i] + " AS " + "\"" + nombreCampos[i] + "\"";
                    if (i < campos.Length - 1)
                        consulta = consulta + ",";
                }
                consulta = consulta + " FROM " + tabla + " WHERE " + condicion;
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
                adapter.Fill(t);
                con.Close();
            }
            catch (Exception e) { }

            return t;
        }


    }
}
