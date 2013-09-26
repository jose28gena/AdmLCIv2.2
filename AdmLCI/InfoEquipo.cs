using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AdmLCI
{
    public partial class InfoEquipo : Form
    {
        Equipo equipo;
        Sesion sesion;
        DataTable dtEq, dtAl;
        Conexion con = new Conexion();


        public InfoEquipo(Equipo eq, Sesion s)
        {
            InitializeComponent();
            equipo = eq;
            sesion = s;


            if (sesion.tipoUsuario.Equals("Manual") || sesion.tipoUsuario.Equals("Asesor"))
            {
                btMantenimiento.Enabled = false;
                btActivarEq.Enabled = false;
            }

            if (equipo.estado.Equals("No Disponible"))
            {
                btAsignarE.Enabled = false;
                btActivarEq.Enabled = false;
                
            }
            else if (equipo.estado.Equals("Espera"))
            {
                btAsignarE.Enabled = false;
                btDesasignar.Enabled = true;
                btActivarEq.Enabled = false;

            }
            else if (equipo.estado.Equals("Mantenimiento"))
            {
                btAsignarE.Enabled = false;
                btMantenimiento.Enabled = false;
                btDesasignar.Enabled = false;
                
            }
            else if (equipo.estado.Equals("Disponible"))
            {
                btActivarEq.Enabled = false;
                btAsignarE.Enabled = true;
                btDesasignar.Enabled = false;
            }
            
            dgvSoft.DataSource = con.consultaLibreDT("select sft_id as 'ID', sft_nombre as 'Nombre', sft_version as 'Versión' from Software inner join software_equipo on Software.sft_id=software_equipo.stw_id where software_equipo.ieq_id="+equipo.idEquipo);

            llenarLabels();


        }

        public void llenarLabels() {
            dtEq = con.consultaLibreDT("select * from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where InvEquipo.ieq_id=" + equipo.idEquipo);
            DataTable dtUso;

            if (!equipo.AlumOcupante.Equals(""))
            {
                dtAl = con.consultaLibreDT("select * from UsuarioLCI where est_expediente=" + equipo.AlumOcupante);
                
            }
            else
            {
                lbExp.Text = "-";
                lbCarrera.Text = "-";
                lbNom.Text = "-";
                pbFoto.Image = pbFoto.InitialImage;
                //dtAl.Rows.Clear();

            }

            lbNoContraloria.Text = dtEq.Rows[0]["ieq_contraloria"].ToString();
            lbMonitor.Text = dtEq.Rows[0]["ieq_noserie_mon"].ToString();
            lbCPU.Text = dtEq.Rows[0]["ieq_noserie_cpu"].ToString();
            lbNoEq.Text = dtEq.Rows[0]["ieq_numero"].ToString();
            lbSala.Text = dtEq.Rows[0]["sa_letra"].ToString();
            lbEstado.Text = dtEq.Rows[0]["ieq_estado"].ToString();
            lbTipo.Text= dtEq.Rows[0]["ieq_tipo"].ToString();
            if (dtAl!=null)
            {
                if (dtAl.Rows.Count > 0 && !dtAl.Rows[0]["est_nombre"].ToString().Equals("root"))
                {
                    lbExp.Text = dtAl.Rows[0]["est_expediente"].ToString();
                    lbCarrera.Text = dtAl.Rows[0]["est_carrera"].ToString();
                    lbNom.Text = dtAl.Rows[0]["est_nombre"].ToString();

                    if (dtAl.Rows[0]["est_foto"].ToString().Length > 3)
                        pbFoto.Image = Base64ToImage(dtAl.Rows[0]["est_foto"].ToString());

                    DateTime hrIn = new DateTime();
                    dtUso = con.consultaLibreDT("select * from UsoEquipo where est_expediente='" + dtAl.Rows[0]["est_expediente"].ToString() + "' order by ueq_fecha DESC;");
                    if (dtUso.Rows.Count > 0)
                    {
                        lblTiempoAs.Text = "" + (int.Parse(dtUso.Rows[0]["ueq_tiempo"].ToString()) / 60);
                        lblTiempoAs.Text += " hrs.";
                        
                        hrIn = (DateTime)dtUso.Rows[0]["ueq_fecha"];
                        
                        DateTime hrSa = new DateTime();
                        hrSa = hrIn;
                        //MessageBox.Show("" + int.Parse(dtUso.Rows[0]["ueq_tiempo"].ToString()));
                        hrSa.AddMinutes(int.Parse(dtUso.Rows[0]["ueq_tiempo"].ToString()));
                       // MessageBox.Show(hrIn + " - " + hrSa.AddMinutes(int.Parse(dtUso.Rows[0]["ueq_tiempo"].ToString())).Hour+":"+hrSa.AddMinutes(int.Parse(dtUso.Rows[0]["ueq_tiempo"].ToString())).Minute);
                        lbTiempoRes.Text = "" + hrSa.AddMinutes(int.Parse(dtUso.Rows[0]["ueq_tiempo"].ToString())).Hour + ":" + hrSa.AddMinutes(int.Parse(dtUso.Rows[0]["ueq_tiempo"].ToString())).Minute;
                    }
                    

                    
                    lblHr.Text = "" + hrIn.Hour + ":" + ((int.Parse(hrIn.Minute.ToString()) < 10) ? "0" + hrIn.Minute.ToString() : hrIn.Minute.ToString().ToString());
                }
                else
                {
                    lbExp.Text = "-";
                    lbCarrera.Text = "-";
                    lbNom.Text = "-";

                }
            }
        
        }

        private void InfoEquipo_Load(object sender, EventArgs e)
        {
            
            
        }

        private void InfoEquipo_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btAsignarE_Click(object sender, EventArgs e)
        {
            
            if (con.consultaLibreS("select ieq_estado from InvEquipo where ieq_id=" + equipo.idEquipo).Equals("Disponible"))
            {
                AsignarComp ac = new AsignarComp(equipo,this);
                ac.ShowDialog(this);
               
                
            }
            else
                MessageBox.Show("El equipo ya está asignado.");
        }

        private void btDesasignar_Click(object sender, EventArgs e)
        {
            Desasignar d = new Desasignar(equipo, this);
            d.ShowDialog(this);
            
        }

        private void btMantenimiento_Click(object sender, EventArgs e)
        {
            MantenimientoEquipo me = new MantenimientoEquipo(equipo, this);
            me.ShowDialog(this);
        }

        private void btActivarEq_Click(object sender, EventArgs e)
        {
            
            if (con.modificar("UPDATE InvEquipo SET ieq_estado='Disponible', est_expediente=0 WHERE sa_id=" + equipo.idSala + " and ieq_numero=" + equipo.numEquipo))
            {
                equipo.cambiarImagenLibre();
                equipo.estado = "Disponible";
                btAsignarE.Enabled = true;
                //button2.Enabled = true;
                MessageBox.Show("El equipo ha sido activado.");
                this.Close();
            }
        }

        /*El metodo Base64ToImage convierte una variable de tipo base64String a Image*/
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        /* Convierte una imagen a un tipo de dato base64String */
        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        /* Convierte un arreglo de byte a un tipo Image */
        public Image byteToImage(byte[] byteEntrante)
        {
            MemoryStream ms = new MemoryStream(byteEntrante);
            Image IMAGEN = Image.FromStream(ms);
            return IMAGEN;
        }

    }
}
