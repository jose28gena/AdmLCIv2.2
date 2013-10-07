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
    public partial class Consulta : Form
    {
        string[] opcConEq = { "Uso del equipo", "Mantenimiento del equipo" };
        string[] opcConEst = { "Visitas" };
        string[] opcConHist = { "Lockers agregados","Lockers eliminados","Equipos agregados","Equipos eliminados","Salas agregadas","Salas eliminadas" };
        Validacion v = new Validacion();
        DataTable dts;

        public Consulta()
        {
            InitializeComponent();
            dtpInicio.CustomFormat = "dd'/'MM'/'yyyy'";
            dtpFin.CustomFormat = "dd'/'MM'/'yyyy'";
        }
        
        
        private void cbConsulta_SelectedValueChanged(object sender, EventArgs e)
        {
            cbCondicion.Items.Clear();
            if (cbConsulta.SelectedItem.ToString().Equals("Equipo"))
            {
                lbl1.Visible = true;
                lbl1.Text = "No. equipo:";
                lbl2.Visible = true;
                tb2.Visible = true;
                tb1.Visible = true;
                comboBox1.Visible = true;
                Conexion con = new Conexion();

                comboBox1.DataSource = con.consultaLibreDT("Select * from Sala");
                comboBox1.ValueMember = "sa_id";
                comboBox1.DisplayMember = "sa_letra";
                
                for (int i = 0; i < opcConEq.Length; i++)
                    cbCondicion.Items.Add(opcConEq[i]);
            }
            else if (cbConsulta.SelectedItem.ToString().Equals("Alumno"))
            {
                
                for (int i = 0; i < opcConEst.Length; i++)
                    cbCondicion.Items.Add(opcConEst[i]);
                
                lbl1.Text = "Expediente:";
                tb1.Visible = true;
                lbl2.Visible = false;
                tb2.Visible = false;                
                cbCondicion.Text = "Seleccione una opción";
            }
            else if (cbConsulta.SelectedItem.ToString().Equals("Historial"))
            {

                for (int i = 0; i < opcConHist.Length; i++)
                    cbCondicion.Items.Add(opcConHist[i]);

                lbl1.Text = "Expediente:";
                tb1.Visible = false;
                lbl2.Visible = false;
                tb2.Visible = false;
                lbl1.Visible = false;
                cbCondicion.Text = "Seleccione una opción";
            }   

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            
            if (!(cbCondicion.SelectedIndex >= 0 && cbConsulta.SelectedIndex >= 0))
            {
                MessageBox.Show("Debe seleccionar una consulta.");
                return;
            }
            dgvConsulta.DataSource = null;
            string tipo="";
            string exp="";
            Conexion con = new Conexion();
            //select UsoEquipo.ueq_fecha as 'Fecha', ueq_tiempo/60 as 'Tiempo',UsoEquipo.est_expediente as 'Expediente', UsuarioLCI.est_nombre as 'Nombre', UsuarioLCI.est_ape_pat as 'Apellido paterno', UsuarioLCI.est_ape_mat as 'Apellido materno' from UsoEquipo, UsuarioLCI, InvEquipo where UsoEquipo.est_expediente=UsuarioLCI.est_expediente and UsoEquipo.ieq_id=InvEquipo.ieq_id and InvEquipo.;
            
            DataTable info=new DataTable();
            if (cbConsulta.SelectedItem.ToString().Equals("Equipo")) {
                if (cbCondicion.SelectedItem.ToString().Equals("Uso del equipo"))
                {
                    if (comboBox2.GetItemText(comboBox2.SelectedItem).Equals(""))
                    {
                        MessageBox.Show("Debe escribir la sala y el número de equipo.");
                        return;
                    }
                    tipo = "Uso Equipo";
                    exp = tb2.Text + tb1.Text;
                    //MessageBox.Show(exp);
                    //MessageBox.Show("" + dtpInicio.Value.Year + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Day);
                    info = con.consultaLibreDT("select UsoEquipo.ueq_fecha as 'Fecha', ueq_tiempo/60 as 'Tiempo',UsoEquipo.est_expediente as 'Expediente', UsuarioLCI.est_nombre as 'Nombre' from UsoEquipo, UsuarioLCI, InvEquipo where UsoEquipo.est_expediente=UsuarioLCI.est_expediente and UsoEquipo.ieq_id=InvEquipo.ieq_id and InvEquipo.ieq_id=(select ieq_id from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where InvEquipo.ieq_numero=" + comboBox2.GetItemText(comboBox2.SelectedItem) + " and Sala.sa_letra='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "') and UsoEquipo.ueq_fecha between '" + dtpInicio.Value.Day + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Year + "' and '" + dtpFin.Value.Day + "-" + dtpFin.Value.Month + "-" + dtpFin.Value.Year + "'");
                    if (info.Rows.Count == 0) {
                        info = con.consultaLibreDT("select UsoEquipo.ueq_fecha as 'Fecha', ueq_tiempo/60 as 'Tiempo',UsoEquipo.ales_id as 'ID Alumno especial', AlumnoEspecial.ales_nombre as 'Nombre', AlumnoEspecial.ales_ape_pat as 'Apellido paterno', AlumnoEspecial.ales_ape_mat as 'Apellido materno' from UsoEquipo, AlumnoEspecial, InvEquipo where UsoEquipo.ales_id=AlumnoEspecial.ales_id and UsoEquipo.ieq_id=InvEquipo.ieq_id and InvEquipo.ieq_id=(select ieq_id from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where InvEquipo.ieq_numero=" + comboBox2.GetItemText(comboBox2.SelectedItem) + " and Sala.sa_letra='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "') and UsoEquipo.ueq_fecha between '" + dtpInicio.Value.Day + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Year + "' and '" + dtpFin.Value.Day + "-" + dtpFin.Value.Month + "-" + dtpFin.Value.Year + "'");
                        tipo="Uso Equipo";
                        
                    }
                }
                else if (cbCondicion.SelectedItem.ToString().Equals("Mantenimiento del equipo"))
                {

                    info = con.consultaLibreDT("select mnt_fecha as 'Fecha', mnt_justificacion as 'Justificación', mnt_detalles as 'Detalles' from mntoeq inner join InvEquipo on InvEquipo.ieq_id=mntoeq.ieq_id where mntoeq.ieq_id=(select ieq_id from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id where InvEquipo.ieq_numero=" + comboBox2.GetItemText(comboBox2.SelectedItem) + " and Sala.sa_letra='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "') and mntoeq.mnt_fecha between '" + dtpInicio.Value.Day + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Year + "' and '" + dtpFin.Value.AddDays(1).Day + "-" + dtpFin.Value.AddDays(1).Month + "-" + dtpFin.Value.AddDays(1).Year + "'");
                    tipo="Mantenimiento Equipo";
                    exp = tb2.Text + tb1.Text;
                }
            }

            else if (cbConsulta.SelectedItem.ToString().Equals("Alumno")) {
                if (cbCondicion.SelectedItem.ToString().Equals("Visitas"))
                {
                    if (tb1.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Debe escribir el expediente.");
                        return;
                    }
                    if (!con.existe("select * from UsuarioLCI where est_expediente=" + tb1.Text)) {
                        MessageBox.Show("El usuario no existe.");
                        return;
                    }
                    info = con.consultaLibreDT("select ieq_sala as 'Sala', ieq_numEq as 'Equipo', ueq_fecha as 'Fecha', ueq_tiempo as 'Tiempo (horas)' from UsoEquipo where est_expediente="+tb1.Text+" order by ueq_fecha DESC;");
                    tipo = "Alumno";
                    exp = tb1.Text;
                }
            }
            else if (cbConsulta.SelectedItem.ToString().Equals("Historial"))
            {
                tipo = "Historial";
                if (cbCondicion.Items[cbCondicion.SelectedIndex].Equals("Lockers agregados"))
                {
                    info = con.consultaLibreDT("select usr_nombre as 'Nombre', usr_apellidoP+' '+usr_apellidoM as 'Apellidos', SUBSTRING(ha_objeto, 3, LEN(ha_objeto)) as 'Locker', ha_fecha as 'Fecha' from HistorialAcciones inner join Usuario on HistorialAcciones.usr_id=Usuario.usr_id where ha_objeto LIKE 'L%' AND ha_accion = 'Agregar' AND ha_fecha between '" + dtpInicio.Value.Day + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Year + "' and '" + dtpFin.Value.AddDays(1).Day + "-" + dtpFin.Value.AddDays(1).Month + "-" + dtpFin.Value.AddDays(1).Year + "'");
                }
                else if (cbCondicion.Items[cbCondicion.SelectedIndex].Equals("Lockers eliminados"))
                {
                    info = con.consultaLibreDT("select usr_nombre as 'Nombre', usr_apellidoP+' '+usr_apellidoM as 'Apellidos', SUBSTRING(ha_objeto, 3, LEN(ha_objeto)) as 'Locker', ha_fecha as 'Fecha' from HistorialAcciones inner join Usuario on HistorialAcciones.usr_id=Usuario.usr_id where ha_objeto LIKE 'L%' AND ha_accion = 'Eliminar' AND ha_fecha between '" + dtpInicio.Value.Day + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Year + "' and '" + dtpFin.Value.AddDays(1).Day + "-" + dtpFin.Value.AddDays(1).Month + "-" + dtpFin.Value.AddDays(1).Year + "'");
                }
                else if (cbCondicion.Items[cbCondicion.SelectedIndex].Equals("Equipos agregados"))
                {
                    info = con.consultaLibreDT("select usr_nombre as 'Nombre', usr_apellidoP+' '+usr_apellidoM as 'Apellidos', SUBSTRING(ha_objeto, 3, LEN(ha_objeto)) as 'Equipo', ieq_contraloria as 'No. de contraloría', ha_fecha as 'Fecha' from HistorialAcciones inner join Usuario on HistorialAcciones.usr_id=Usuario.usr_id where ha_objeto LIKE 'E-%' AND ha_accion = 'Agregar' AND ha_fecha between '" + dtpInicio.Value.Day + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Year + "' and '" + dtpFin.Value.AddDays(1).Day + "-" + dtpFin.Value.AddDays(1).Month + "-" + dtpFin.Value.AddDays(1).Year + "'");
                }
                else if (cbCondicion.Items[cbCondicion.SelectedIndex].Equals("Equipos eliminados"))
                {
                    info = con.consultaLibreDT("select usr_nombre as 'Nombre', usr_apellidoP+' '+usr_apellidoM as 'Apellidos', SUBSTRING(ha_objeto, 3, LEN(ha_objeto)) as 'Equipo', ieq_contraloria as 'No. de contraloría', ha_fecha as 'Fecha' from HistorialAcciones inner join Usuario on HistorialAcciones.usr_id=Usuario.usr_id where ha_objeto LIKE 'E-%' AND ha_accion = 'Eliminar' AND ha_fecha between '" + dtpInicio.Value.Day + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Year + "' and '" + dtpFin.Value.AddDays(1).Day + "-" + dtpFin.Value.AddDays(1).Month + "-" + dtpFin.Value.AddDays(1).Year + "'");
                }
                else if (cbCondicion.Items[cbCondicion.SelectedIndex].Equals("Salas agregadas"))
                {
                    info = con.consultaLibreDT("select usr_nombre as 'Nombre', usr_apellidoP+' '+usr_apellidoM as 'Apellidos', SUBSTRING(ha_objeto, 3, LEN(ha_objeto)) as 'Sala', ha_fecha as 'Fecha' from HistorialAcciones inner join Usuario on HistorialAcciones.usr_id=Usuario.usr_id where ha_objeto LIKE 'S-%' AND ha_accion = 'Agregar' AND ha_fecha between '" + dtpInicio.Value.Day + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Year + "' and '" + dtpFin.Value.AddDays(1).Day + "-" + dtpFin.Value.AddDays(1).Month + "-" + dtpFin.Value.AddDays(1).Year + "'");
                }
                else if (cbCondicion.Items[cbCondicion.SelectedIndex].Equals("Salas eliminadas"))
                {

                    info = con.consultaLibreDT("select usr_nombre as 'Nombre', usr_apellidoP+' '+usr_apellidoM as 'Apellidos', SUBSTRING(ha_objeto, 3, LEN(ha_objeto)) as 'Locker', ha_fecha as 'Fecha' from HistorialAcciones inner join Usuario on HistorialAcciones.usr_id=Usuario.usr_id where ha_objeto LIKE 'S-%' AND ha_accion = 'Eliminar' AND ha_fecha between '" + dtpInicio.Value.Day + "-" + dtpInicio.Value.Month + "-" + dtpInicio.Value.Year + "' and '" + dtpFin.Value.AddDays(1).Day + "-" + dtpFin.Value.AddDays(1).Month + "-" + dtpFin.Value.AddDays(1).Year + "'");
                }
                //info = con.consultaLibreDT("select ha_accion as 'Acción', usr_nombre as 'Nombre', usr_apellidoP+' '+usr_apellidoM as 'Apellidos', ha_objeto as 'Afecto a:' from HistorialAcciones inner join Usuario on HistorialAcciones.usr_id=Usuario.usr_id;");
                
            }
            //MessageBox.Show(""+tipo);

            dgvConsulta.DataSource = info;
            //ConsultaResultado cr = new ConsultaResultado(info,tipo,exp);
            //cr.ShowDialog(this);
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            dtpFin.MaxDate = DateTime.Now.AddDays(1);
            dtpInicio.MaxDate = DateTime.Now.AddDays(-1);
            comboBox1.Visible = false;
            comboBox2.Visible = false;
        }

        private void cbCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            tb1.Text = v.validar(tb1.Text);
            tb1.Select(tb1.Text.Length, 0);
        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {
            tb2.Text = v.validar(tb2.Text);
            tb2.Select(tb2.Text.Length, 0);
            tb2.CharacterCasing = CharacterCasing.Upper;
        }

        private void cbConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCondicion.Text = "Seleccione una opción";
            if (cbConsulta.Items[cbConsulta.SelectedIndex].Equals("Alumno")) {
                lbl1.Visible = true;
                tb1.Visible = true;
                lbl2.Visible = false;
                tb2.Visible = false;
                lbl1.Text = "Expediente";
                tb1.Mask = "";
            }
            else if (cbConsulta.Items[cbConsulta.SelectedIndex].Equals("Equipo"))
            {
                lbl1.Visible = true;
                tb1.Visible = true;
                lbl2.Visible = true;
                tb2.Visible = true;
                lbl1.Text = "Equipo";
                tb1.Mask = "000";
            }
            else if (cbConsulta.Items[cbConsulta.SelectedIndex].Equals("Historial"))
            {
                lbl1.Visible = false;
                tb1.Visible = false;
                lbl2.Visible = false;
                tb2.Visible = false;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb2_TextChanged_1(object sender, EventArgs e)
        {
            tb2.CharacterCasing = CharacterCasing.Upper;
        }

        private void tb1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            dtpInicio.MaxDate = dtpFin.Value.AddDays(-1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();


            Conexion con = new Conexion();

            String query =
              "SELECT ieq_numero FROM  InvEquipo INNER JOIN Sala ON (InvEquipo.sa_id= Sala.sa_id) WHERE sa_letra='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "' ORDER BY ieq_numero";
            comboBox2.Visible = true;
            dts = con.consultaLibreDT(query);
            
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                comboBox2.Items.Add(dts.Rows[i]["ieq_numero"].ToString());
            }
            comboBox2.Text = "";
        }
    }
}
