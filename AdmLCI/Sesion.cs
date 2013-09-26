using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdmLCI
{
    public class Sesion
    {
        public string usuario, nombre, tipoUsuario;
        public DateTime fecha;
        public int idUsr = 0;

        public Sesion(string usr)
        {
            usuario = usr;


        }

        public bool inicioSesion(string pass)
        {
            Conexion con = new Conexion();
            string pwbd = con.consultaLibreS("select usr_contra from Usuario where usr_usuario='" + usuario + "'");
            if (pass.Equals(pwbd))
            {
                nombre = con.consultaLibreS("select usr_nombre from Usuario where usr_usuario='" + usuario + "'");
                tipoUsuario = con.consultaLibreS("SELECT tpusr_descr FROM Tipo_Usuario WHERE tpusr_id=(SELECT tpusr_id FROM Usuario WHERE usr_usuario='" + usuario + "')");
                idUsr = int.Parse(con.consultaLibreS("select usr_id from Usuario where usr_usuario='" + usuario + "'"));
                fecha = new DateTime();
                fecha = DateTime.Today;

                return true;
            }
            return false;
        }


    }
}
