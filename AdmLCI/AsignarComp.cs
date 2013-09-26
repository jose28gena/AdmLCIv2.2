using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdmLCI.Properties;
using System.IO;

namespace AdmLCI
{
    public partial class AsignarComp : Form
    {
        //En estas variables se guardaran las instancias a los objetos que ya existen para modificarlos.
        Equipo equipo;
        DataTable dtEst;
        DataTable dtEsp;
        InfoEquipo infEq;
        Validacion v = new Validacion();
        Conexion con = new Conexion();
        int bandera = 0;
        bool especial = false, maestro = false;

        //Declarar WebService
        webServiceLCI.Service webServiceLCI = new webServiceLCI.Service();
        

        public AsignarComp(Equipo btEq, InfoEquipo ie)
        {
            InitializeComponent();

            infEq = ie;
            equipo = btEq;
            //Se obtiene la informacion del equipo al que se le dio clic.
            lblNoEquipo.Text = equipo.numEquipo.ToString();
            lblSala.Text = btEq.sala;
            con.modificar("UPDATE InvEquipo SET ieq_estado='No Disponible' WHERE sa_id=" + equipo.idSala + " and ieq_numero=" + equipo.numEquipo); 
            equipo.cambiarImagenOcupada();
            tbNombre.Enabled = false;
           

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.modificar("UPDATE InvEquipo SET ieq_estado='Disponible' WHERE sa_id=" + equipo.idSala + " and ieq_numero=" + equipo.numEquipo);
            equipo.cambiarImagenLibre();
            this.Close();
           
        }

        public void asignarComp(int hrAsig) {
            if (tbNombre.Text.Length > 0 && especial==false)
            {
                //Obtener informacion del equipo que posee el alumno (si es que ya tiene uno).
                DataTable compu = con.consultaLibreDT("select * from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where est_expediente=" + tbExpediente.Text);

                int nuevaHrDisp=0;
                if (dtEst.Rows[0]["est_saldo"] != null) {
                    int minutosTotales = int.Parse(dtEst.Rows[0]["est_saldo"].ToString());                   
                    int minutosRestantes=minutosTotales-hrAsig;
                    nuevaHrDisp = int.Parse(dtEst.Rows[0]["est_saldo"].ToString()) - hrAsig;
                
                }
                    nuevaHrDisp = int.Parse(dtEst.Rows[0]["est_saldo"].ToString())-hrAsig;
                //Si se le asigna mas tiempo del que el alumno posee el nuevo tiempo disponible dentro de la BD sera 0.
                if (nuevaHrDisp <= 0)
                    nuevaHrDisp = 0;
                    
                    if (compu.Rows.Count == 0)
                    {
                        //update UsuarioLCI SET est_saldo=@nvoSaldo where est_expediente=@estExp;
                        //UPDATE InvEquipo SET ieq_estado='Espera', est_expediente=@estExp WHERE sa_id=@idSala and ieq_numero=@numEq;
                        con.modificar("update UsuarioLCI SET est_saldo=" + nuevaHrDisp + " where est_expediente=" + tbExpediente.Text);
                        con.modificar("UPDATE InvEquipo SET ieq_estado='Espera', est_expediente="+tbExpediente.Text+" WHERE sa_id="+equipo.idSala+" and ieq_numero="+equipo.numEquipo);
                        con.modificar("insert into UsoEquipo(ieq_id,ieq_sala,ieq_numEq,est_expediente,ueq_fecha,ales_id,sfw_id,ueq_tiempo,ieq_contraloria) values("+equipo.idEquipo+",'"+equipo.sala+"','"+equipo.numEquipo+"','"+tbExpediente.Text+"','"+(DateTime.Now.Day+"-"+DateTime.Now.Month+"-"+DateTime.Now.Year+" "+DateTime.Now.Hour+":"+DateTime.Now.Minute)+"',0,0,"+hrAsig+",'"+equipo.serieContraloria+"')");
                        inOut.Enviar(PantallaPrincipal.Cliente,"MM"+equipo.sala+";recepcion");
                        equipo.estado = "No Disponible";
                        equipo.AlumOcupante = tbExpediente.Text;
                        equipo.cambiarImagenOcupada();

                        try {
                           // MessageBox.Show("Enviar mensaje al servidor " + equipo.sala);
                            //inOut.Enviar();
                            //Login.ventana.SendMessage(equipo.sala + ";recepcion");

                        } catch (Exception ex) {
                            //MessageBox.Show("La aplicación del servidor esta cerrada");
                            //Se cambia la informacion del objeto equipo con la actual.
                            equipo.estado = "No Disponible";
                            equipo.AlumOcupante = tbExpediente.Text;
                            equipo.cambiarImagenOcupada();
                        }
                        
                        
                        infEq.llenarLabels();
                        bandera = 1;
                        infEq.Close();
                        
                        this.Close();
                    }
                    else
                        MessageBox.Show("El alumno ya tiene el equipo " + compu.Rows[0]["sa_letra"] + compu.Rows[0]["ieq_numero"] + " asignado.");
           
            }
            else if (especial == true)
            {
                #region especial
                //Obtener informacion del equipo que posee el alumno (si es que ya tiene uno).
                DataTable compu = con.consultaLibreDT("select * from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where ales_externo=" + tbExpediente.Text);

                int nuevaHrDisp = 0;
                if (dtEsp.Rows[0]["ales_tiempo"] != null)
                {
                    int minutosTotales = int.Parse(dtEsp.Rows[0]["ales_tiempo"].ToString());
                    int minutosRestantes = minutosTotales - hrAsig;
                    nuevaHrDisp = int.Parse(dtEsp.Rows[0]["ales_tiempo"].ToString()) - hrAsig;

                }
                nuevaHrDisp = int.Parse(dtEsp.Rows[0]["ales_tiempo"].ToString()) - hrAsig;
                //Si se le asigna mas tiempo del que el alumno posee el nuevo tiempo disponible dentro de la BD sera 0.
                if (nuevaHrDisp <= 0)
                    nuevaHrDisp = 0;

                if (compu.Rows.Count == 0 && dtEsp.Rows.Count>0)
                {
                    //update UsuarioLCI SET est_saldo=@nvoSaldo where est_expediente=@estExp;
                    //UPDATE InvEquipo SET ieq_estado='Espera', est_expediente=@estExp WHERE sa_id=@idSala and ieq_numero=@numEq;
                    con.modificar("update AlumnoEspecial SET ales_tiempo=" + nuevaHrDisp + " where ales_exp_ext=" + tbExpediente.Text);
                    con.modificar("UPDATE InvEquipo SET ieq_estado='Espera', est_expediente='"+dtEsp.Rows[0]["ales_id"]+"',  ales_externo=" + tbExpediente.Text + " WHERE sa_id=" + equipo.idSala + " and ieq_numero=" + equipo.numEquipo);
                    con.modificar("insert into UsoEquipo(ieq_id,ieq_sala,ieq_numEq,est_expediente,ueq_fecha,ales_id,sfw_id,ueq_tiempo,ieq_contraloria) values(" + equipo.idEquipo + ",'" + equipo.sala + "','" + equipo.numEquipo + "','"+dtEsp.Rows[0]["ales_id"]+"','" + (DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute) + "',"+tbExpediente.Text+",0," + hrAsig + ",'" + equipo.serieContraloria + "')");
                    inOut.Enviar(PantallaPrincipal.Cliente, "MM" + equipo.sala + ";recepcion");
                    equipo.estado = "No Disponible";
                    equipo.AlumOcupante = tbExpediente.Text;
                    equipo.cambiarImagenOcupada();

                    try
                    {
                        // MessageBox.Show("Enviar mensaje al servidor " + equipo.sala);
                        //inOut.Enviar();
                        //Login.ventana.SendMessage(equipo.sala + ";recepcion");

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("La aplicación del servidor esta cerrada");
                        //Se cambia la informacion del objeto equipo con la actual.
                        equipo.estado = "No Disponible";
                        equipo.AlumOcupante = tbExpediente.Text;
                        equipo.cambiarImagenOcupada();
                    }


                    infEq.llenarLabels();
                    bandera = 1;
                    infEq.Close();

                    this.Close();
                }
                else
                    MessageBox.Show("El alumno ya tiene el equipo " + compu.Rows[0]["sa_letra"] + compu.Rows[0]["ieq_numero"] + " asignado.");
           

                #endregion
            }
            else
            {
                MessageBox.Show("Debe escribir el expediente completo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
          
        private void AsignarComp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bandera == 0)
            {
                con.modificar("UPDATE InvEquipo SET ieq_estado='Disponible' WHERE sa_id=" + equipo.idSala + " and ieq_numero=" + equipo.numEquipo);
                equipo.cambiarImagenLibre();
            }

        }

        private void AsignarComp_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            asignarComp(60);
        }

       

        private void tbExpediente_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void btDosHr_Click(object sender, EventArgs e)
        {
            asignarComp(120);
        }

        private void btTresHr_Click(object sender, EventArgs e)
        {
            asignarComp(180);
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

        private void tbExpediente_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tbExpediente_TextChanged_1(object sender, EventArgs e)
        {
            tbExpediente.Text = v.validar(tbExpediente.Text);
            tbExpediente.Select(tbExpediente.Text.Length, 0);
        }

        private void tbExpediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                bool banderaNum = true;
                try
                {
                    int exp = Convert.ToInt32(tbExpediente.Text);
                }
                catch (FormatException fe) {
                    especial = true;
                }

                if (especial == false)
                {
                    if (con.existe("est_expediente", "UsuarioLCI", "est_expediente=" + tbExpediente.Text))
                    {
                        DataTable dtSancion = con.consultaLibreDT("select * from Sancion where est_expediente=" + tbExpediente.Text + " and GETDATE() between sn_fecha_inicio and sn_fecha_fin");
                        if (dtSancion.Rows.Count > 0)
                        {
                            MessageBox.Show("No se puede asignar el equipo porque el alumno está sancionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }

                        dtEst = con.consultaLibreDT("select * from UsuarioLCI where est_expediente=" + tbExpediente.Text);
                        tbNombre.Text = dtEst.Rows[0]["est_nombre"].ToString();
                        float res = (int.Parse(dtEst.Rows[0]["est_saldo"].ToString()) % 60);
                        //MessageBox.Show("" + res);
                        //res = res * 60;

                        int mins = Convert.ToInt32(res);
                        tbHrsDisp.Text = "" + (int.Parse(dtEst.Rows[0]["est_saldo"].ToString()) / 60) + ":" + mins;
                        tbExpediente.Enabled = false;
                        if (dtEst.Rows[0]["est_foto"].ToString().Length > 3)
                            pbFoto.Image = Base64ToImage(dtEst.Rows[0]["est_foto"].ToString());


                    }
                    else if (con.existe("ales_id", "AlumnoEspecial", "ales_id=" + tbExpediente.Text))
                    {
                        dtEst = con.consultaLibreDT("select * from AlumnoEspecial where ales_id=" + tbExpediente.Text);
                        tbNombre.Text = dtEst.Rows[0]["ales_nombre"].ToString();
                        tbHrsDisp.Text = "" + (int.Parse(dtEst.Rows[0]["ales_tiempo"].ToString()) / 60);
                        tbExpediente.Enabled = false;
                        especial = true;
                    }
                    else
                    {
                        try
                        {
                            DataTable alumno = new DataTable();
                            alumno = webServiceLCI.ObtenerInfoAlumno(Convert.ToInt32(tbExpediente.Text));

                            DataTable academico = new DataTable();
                            academico = webServiceLCI.ObtenerInfoAcademico(Convert.ToInt32(tbExpediente.Text));

                            if (alumno.Rows.Count == 0 && academico.Rows.Count==0 && especial==false)
                            {
                                MessageBox.Show("El expediente " + tbExpediente.Text + " no existe.");
                            }
                            else if (alumno.Rows.Count != 0)
                            {
                                //cadenaByte = 
                                //string biteDecodificado = Convert.ToBase64String(cadenaByte);
                                Byte[] prueba = (byte[])alumno.Rows[0]["rFoto"];
                                pbFoto.Image = byteToImage(prueba);


                                con.modificar("INSERT INTO UsuarioLCI (est_expediente, est_nombre, est_estado, est_saldo, est_foto) " +
                                " VALUES (" + Convert.ToInt32(alumno.Rows[0]["iExpediente"].ToString()) + ", '" + alumno.Rows[0]["cNombre"] + "', 'A'', 180, '" +
                                ImageToBase64(pbFoto.Image, System.Drawing.Imaging.ImageFormat.Jpeg) + "')");

                                dtEst = con.consultaLibreDT("select * from UsuarioLCI where est_expediente=" + tbExpediente.Text);
                                tbNombre.Text = dtEst.Rows[0]["est_nombre"].ToString();
                                tbHrsDisp.Text = "" + (int.Parse(dtEst.Rows[0]["est_saldo"].ToString()) / 60);
                                tbExpediente.Enabled = false;
                                if (dtEst.Rows[0]["est_foto"].ToString().Length > 3)
                                    pbFoto.Image = Base64ToImage(dtEst.Rows[0]["est_foto"].ToString());


                            }
                            else if (academico.Rows.Count != 0) {

                                Byte[] prueba = (byte[])academico.Rows[0]["rFoto"];
                                pbFoto.Image = byteToImage(prueba);

                                con.modificar("INSERT INTO UsuarioLCI(est_expediente, est_nombre, est_carrera, est_estado, est_foto, est_tipo)" +
                                    "VALUES(" + academico.Rows[0]["iNoemp"] + ", '" + academico.Rows[0]["cNombre"] + "', '', 'A', '" +
                                    ImageToBase64(pbFoto.Image, System.Drawing.Imaging.ImageFormat.Jpeg) + "', 'Maestro') ");

                                dtEst = con.consultaLibreDT("select * from UsuarioLCI where est_expediente=" + tbExpediente.Text);
                                tbNombre.Text = dtEst.Rows[0]["est_nombre"].ToString();
                                tbHrsDisp.Text = "" + (int.Parse(dtEst.Rows[0]["est_saldo"].ToString()) / 60);
                                tbExpediente.Enabled = false;
                                if (dtEst.Rows[0]["est_foto"].ToString().Length > 3)
                                    pbFoto.Image = Base64ToImage(dtEst.Rows[0]["est_foto"].ToString());
                            
                            }
                        }
                        catch { MessageBox.Show("Error en la conexión remota"); }

                    }
                }
                else if (especial == true) {
                    dtEsp=con.consultaLibreDT("select * from AlumnoEspecial where ales_exp_ext='"+tbExpediente.Text+"'");

                    

                    if (dtEsp.Rows.Count > 0) {
                       
                        tbNombre.Text = dtEsp.Rows[0]["ales_nombre"].ToString();
                        tbHrsDisp.Text = "" + (int.Parse(dtEsp.Rows[0]["ales_tiempo"].ToString()) / 60);
                        tbExpediente.Enabled = false;
                        
                    }

                }
                    
            
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            tbNombre.Text = v.validar(tbNombre.Text);
            tbNombre.Select(tbNombre.Text.Length, 0);
        }

        private void AsignarComp_FormClosing(object sender, FormClosingEventArgs e)
        {
            infEq.Close();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            tbExpediente.Text = "";
            tbExpediente.Enabled = true;
            tbHrsDisp.Text = "";
            tbNombre.Text = "";
            especial = false;
        }
    }
}
