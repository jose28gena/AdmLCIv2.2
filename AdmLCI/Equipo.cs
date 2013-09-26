using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using AdmLCI.Properties;
using System.Drawing;

namespace AdmLCI
{
    public class Equipo : Button
    {
        public int idEquipo=0, numEquipo=0, idSala=0, numMesa=0;
        public string serieCPU="", serieMonitor="", serieContraloria="", AlumOcupante="", sala="", estado="", tipo="";
        Sesion sesion;
        PantallaPrincipal pantPr;
        static InfoEquipo ie;

        public Equipo(Sesion s, PantallaPrincipal pp) {
            sesion = s;
            pantPr = pp;
            this.Click += equipoClick;
            this.MouseHover += equipoMouseHover;
        }

        public void asignarPropiedades(){
            this.Width = 48;
            this.Height = 55;    
            this.ImageAlign = ContentAlignment.TopCenter;
            this.TextAlign = ContentAlignment.BottomCenter;
            this.FlatStyle = FlatStyle.Popup;
            this.Font = new Font(this.Font.Name, 7, FontStyle.Bold);
            this.Image = Resources.compLibre;
        }

        public void asignarDatos(int iEq, int nEq, string AlOc, string cpu, string mon, string contr, int idS, int nm, string s, string edo, string tp) { 
            idEquipo=iEq;
            numEquipo=nEq; 
            AlumOcupante=AlOc;
            serieCPU = cpu;
            serieMonitor = mon;
            serieContraloria = contr;
            idSala = idS;
            numMesa = nm;
            sala=s;
            this.Text = nEq.ToString();
            asignarPropiedades();
            estado = edo;
            tipo = tp;

            if (numEquipo == 0)
                this.Enabled = false;

            if (estado.Equals("No Disponible") || estado.Equals("Espera"))
                this.Image = Resources.compOcupada;
            else if (estado.Equals("Mantenimiento"))
                this.Image = Resources.computadoraMant2;
            else
                this.Image = Resources.compLibre;
        }

        public void cambiarPosicion(int X, int Y) {
            this.Location = new System.Drawing.Point(X, Y);
        }

        public void asignarEquipo(string estado) { 
            
        }

        public void cambiarImagenOcupada()
        {
            this.Image = Resources.compOcupada;
        }

        public void cambiarImagenMantenimiento()
        {
            this.Image = Resources.computadoraMant2;
        }

        public void cambiarImagenLibre()
        {
            this.Image = Resources.compLibre;
        }

        private void equipoMouseHover(object sender, EventArgs e)
        {
            pantPr.lbNombre.Text = "-";
            pantPr.lbDetalles.Text = "-";
            pantPr.lbEstado.Text = "-";
            pantPr.lbExp.Text = "-";
            pantPr.lbTiempo.Text = "-";
            pantPr.lbEq.Text = numEquipo.ToString();
            pantPr.lbSala.Text=sala;

            pantPr.lbExp.Text = AlumOcupante;
            pantPr.lbEstado.Text = estado;
            Conexion con= new Conexion();
            if (!AlumOcupante.Equals("0") && !AlumOcupante.Equals(""))
            {
                //MessageBox.Show("select * from UsoEquipo inner join UsuarioLCI on UsoEquipo.est_expediente=UsuarioLCI.est_expediente where UsuarioLCI.est_expediente="+AlumOcupante);
                DataTable dtAlum = con.consultaLibreDT("select * from UsoEquipo inner join UsuarioLCI on UsoEquipo.est_expediente=UsuarioLCI.est_expediente where UsuarioLCI.est_expediente=" + AlumOcupante + " order by ueq_fecha DESC");

                if (dtAlum.Rows.Count > 0)
                {
                    int tiempo=int.Parse(dtAlum.Rows[0]["ueq_tiempo"].ToString())/60;
                    pantPr.lbNombre.Text = dtAlum.Rows[0]["est_nombre"].ToString();
                    pantPr.lbTiempo.Text = tiempo == 0 ? "1" : tiempo.ToString(); 

                }                
                                
            }

            if (estado.Equals("Mantenimiento"))
            {
                //MessageBox.Show("condicion mantenimiento");
                DataTable dtMant = con.consultaLibreDT("select * from mntoeq where ieq_id= " + idEquipo + " order by mnt_fecha desc");
                if (dtMant.Rows.Count > 0)
                {
                    pantPr.lbDetalles.Text = dtMant.Rows[0]["mnt_justificacion"].ToString();
                }


            }
            
        }

        public void equipoClick(object sender, EventArgs args)
        {           
                if (sender.Equals(this))
                {
                   
                    ie= new InfoEquipo(this,sesion);
                    ie.ShowDialog();                 
                }
        }
    }
}
