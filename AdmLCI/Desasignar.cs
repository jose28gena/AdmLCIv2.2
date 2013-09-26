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
    public partial class Desasignar : Form
    {
        Equipo equipo;
        InfoEquipo infEq;

        public Desasignar(Equipo eq, InfoEquipo ie)
        {
            InitializeComponent();
            equipo = eq;
            infEq = ie;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
          
                Conexion con = new Conexion();

                if (cbComent.SelectedIndex < 0 || cbMotivo.SelectedIndex < 0) {
                    MessageBox.Show("Debe seleccionar un motivo y un comentario.");
                    return;
                }
                
                if (con.modificar("UPDATE InvEquipo SET ieq_estado = 'Disponible', est_expediente=0 WHERE sa_id=" + equipo.idSala + " and ieq_numero=" + equipo.numEquipo))
                {
                    DataTable dtUso = con.consultaLibreDT("select * from UsoEquipo where est_expediente="+equipo.AlumOcupante+" order by ueq_fecha DESC;");
                    int minSolicitados=0;
                    TimeSpan tiempoUsado=DateTime.Now.Subtract(DateTime.Now.AddHours(1));
                    if(dtUso.Rows.Count>0){
                        minSolicitados= int.Parse(dtUso.Rows[0]["ueq_tiempo"].ToString());
                    }
                    try
                    {
                        DateTime hrLlegada = Convert.ToDateTime(dtUso.Rows[0]["ueq_fecha"].ToString());
                        tiempoUsado = DateTime.Now.Subtract(hrLlegada);
                    }
                    catch(Exception ex){
                    
                    }
                   // MessageBox.Show("Tiempo usado "+tiempoUsado.TotalMinutes.ToString());
                   
                    bool especial = false;
                    try
                    {
                        int exp = Convert.ToInt32(equipo.AlumOcupante);
                    }
                    catch (FormatException fe)
                    {
                        especial = true;
                    }
                    if (especial == false)
                    {
                        double tu = Convert.ToDouble(tiempoUsado.TotalMinutes.ToString());
                        int tiempUs = Convert.ToInt32(tu);

                        int tiempoRestante = 0;
                        if (minSolicitados > tiempUs)
                            tiempoRestante = minSolicitados - tiempUs;
                        // MessageBox.Show("Tiempo restante: " + (tiempoRestante));
                        con.modificar("update UsuarioLCI set est_saldo=((select est_saldo from UsuarioLCI where est_expediente=" + equipo.AlumOcupante + ")+" + tiempoRestante + ") where est_expediente=" + equipo.AlumOcupante);
                    }
                  // MessageBox.Show(""+hrLlegada.Hour+" "+hrLlegada.Minute);

                    equipo.cambiarImagenLibre();
                    equipo.estado = "Disponible";
                    equipo.AlumOcupante = "0";
                    con.modificar("insert into desasignaciones(ieq_numero,ieq_sala,des_motivo,des_detalles,est_expediente,est_nombre,nombre) values('"+equipo.numEquipo+"','"+equipo.sala+"','"+cbMotivo.Items[cbMotivo.SelectedIndex]+"','"+cbComent.Items[cbComent.SelectedIndex]+"','"+infEq.lbExp.Text+"','"+infEq.lbNom.Text+"','"+tbNombre.Text+"')");
                    
                    //MessageBox.Show("bloquear" + ";" + equipo.sala + equipo.numEquipo);
                    if (Login.ventana != null)
                    {
                        try
                        {
                  
                            if (!infEq.lbExp.Text.Equals("-"))
                            {
                                con.modificar("insert into desasignaciones(ieq_numero, ieq_sala,des_motivo,des_detalles,est_expediente,est_nombre, est_carrera) values(" + equipo.numEquipo + ",'" + equipo.sala + "','" + cbMotivo.Items[cbMotivo.SelectedIndex] + "','" + cbComent.Items[cbComent.SelectedIndex] + "','" + infEq.lbExp.Text + "','" + infEq.lbNom.Text + "','" + infEq.lbCarrera.Text + "') ");
                                }
                           
                            
                            inOut.Enviar(PantallaPrincipal.Cliente, "MMBB;"+equipo.sala+equipo.numEquipo);
                            //MessageBox.Show("MMbloquear;" + equipo.sala + equipo.numEquipo);


                            equipo.cambiarImagenLibre();
                            equipo.estado = "Disponible"; 
                            equipo.AlumOcupante = "";

                            infEq.lbExp.Text = "-";
                            infEq.lbCarrera.Text = "-";
                            infEq.lbNom.Text = "-";

                            inOut.Enviar(PantallaPrincipal.Cliente, "MM" + equipo.sala + ";recepcion");

                            //Login.ventana.SendMessage(equipo.sala + ";recepcion");

                            if(cbMotivo.Items[cbMotivo.SelectedIndex].Equals("Falla de equipo"))
                            {
                                equipo.cambiarImagenMantenimiento();
                                con.modificar("UPDATE InvEquipo SET ieq_estado='Mantenimiento' WHERE sa_id=" + equipo.idSala + " and ieq_numero=" + equipo.numEquipo);
                                con.modificar("insert mntoeq(ieq_id,mnt_fecha,mnt_justificacion,mnt_detalles, ieq_sala, ieq_numEq, ieq_contraloria) values(" + equipo.idEquipo + ",GETDATE(), 'Falla de equipo','"+cbComent.Items[cbComent.SelectedIndex]+"','"+equipo.sala+"','"+equipo.numEquipo+"','"+equipo.serieContraloria+"')");
                                equipo.estado = "Mantenimiento";
                                //equipo.AlumOcupante ="0";
                                infEq.lbEstado.Text = "Mantenimiento";

                                infEq.lbCarrera.Text = "-";
                                infEq.lbExp.Text = "-";
                                infEq.lbNom.Text = "-";
                                infEq.Close();
                                //this.Close();
                            }
                            infEq.Close();
                            
                        }
                        catch(Exception ex) {
                            //MessageBox.Show("La aplicación del servidor está apagada.");
                            
                            equipo.cambiarImagenLibre();
                            equipo.estado = "Disponible";
                            equipo.AlumOcupante = "";
                            infEq.lbExp.Text = "-";
                            infEq.lbCarrera.Text = "-";
                            infEq.lbNom.Text = "-";
                            infEq.Close();
                        }
                    }
                   
                    if (Login.ventana != null)
                    {
                       // MessageBox.Show("Bloquear al ramon ");
                       // Login.ventana.SendMessage("bloquear" + ";" + equipo.sala + equipo.numEquipo);
                    }

                    infEq.llenarLabels();
         
                    this.Close();
                }
                else
                    MessageBox.Show("El equipo no pudo ser desasignado.");
           
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Desasignar_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbComent.Items.Clear();
            cbComent.Text = "Seleccione una opción";
            if (cbMotivo.SelectedIndex == 0) {
                cbComent.Items.Add("Cambio a computadora individual");
                cbComent.Items.Add("Cambio a computadora en equipo");
                cbComent.Items.Add("Otra causa");
            }
            else if (cbMotivo.SelectedIndex == 1)
            {
                cbComent.Items.Add("No funciona el teclado");
                cbComent.Items.Add("No funciona el mouse");
                cbComent.Items.Add("No funciona el monitor");
                cbComent.Items.Add("No tiene conexión a internet");
                cbComent.Items.Add("No funciona el software instalado");

            }
            else if (cbMotivo.SelectedIndex == 2)
            {

                cbComent.Items.Add("Equipo vacío");
            }
        }

        private void Desasignar_FormClosing(object sender, FormClosingEventArgs e)
        {
            infEq.Close();
        }

        
    }
}
