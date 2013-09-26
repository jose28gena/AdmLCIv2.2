using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace AdmLCI
{

    public class Mesa : GroupBox
    {
        public Equipo[] equipos;
        int numMesa;
        int numSala;
        Sesion sesion;
        PantallaPrincipal pantPr;

        public Mesa(int nsala, int nm, Sesion s, PantallaPrincipal pp)
        {
            sesion = s;
            pantPr = pp;
            numMesa = nm;
            numSala = nsala;
            this.Text = numMesa.ToString();
            asignarPropiedades();
            asignarDatos();
        }

        public void asignarPropiedades()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.Width = 50;
            this.Height = 50;
        }

        public void asignarDatos()
        {
            Conexion con = new Conexion();
            DataTable dt = con.consultaLibreDT("SELECT * FROM InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id WHERE InvEquipo.ieq_mesa=" + numMesa + " and InvEquipo.sa_id=" + numSala + " ORDER BY InvEquipo.ieq_numero");
            equipos = new Equipo[dt.Rows.Count];
            int x = 5;            
            for (int i = 0; i < equipos.Length; i++)
            {
                equipos[i] = new Equipo(sesion, pantPr);
                //MessageBox.Show("" + int.Parse(dt.Rows[i][0].ToString()) + " " + int.Parse(dt.Rows[i][7].ToString()) + " " + dt.Rows[i][8].ToString() + " " + dt.Rows[i][1].ToString() + " " + dt.Rows[i][2].ToString() + " " + dt.Rows[i][3].ToString() + " " + numSala + " " + numMesa + " " + dt.Rows[i][11].ToString());
                equipos[i].cambiarPosicion(x, 16);
                equipos[i].asignarDatos(int.Parse(dt.Rows[i]["ieq_id"].ToString()), int.Parse(dt.Rows[i]["ieq_numero"].ToString()), dt.Rows[i]["est_expediente"].ToString(), dt.Rows[i]["ieq_noserie_cpu"].ToString(), dt.Rows[i]["ieq_noserie_mon"].ToString(), dt.Rows[i][3].ToString(), numSala, numMesa, dt.Rows[i][12].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][9].ToString());
                
                this.Controls.Add(equipos[i]);
                x = x + 55;
            }            
        }
        
        public void cambiarPosicion(int X, int Y)
        {
            this.Location = new System.Drawing.Point(X, Y);
        }

        public void borrarObjeto()
        {
            this.Dispose();
        }

    }
}


