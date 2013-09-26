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
    public partial class BuscarSoft : Form
    {
        DataTable dtS;
        DataTable dts;
        Conexion con = new Conexion();
        String name;
        DataTable sft_names;
        public BuscarSoft()
        {
            InitializeComponent();

            comboboxsft();
          
            cargarComboBox();
            comboBox1.Text = "Seleccione una sala";
            comboBox2.Text = "Seleccione un equipo";

           
        }
        public void cargarComboBox()
        {

            dtS = con.consultaLibreDT("SELECT * FROM Sala");

            for (int i = 0; i < dtS.Rows.Count; i++)
            {
                comboBox1.Items.Add(dtS.Rows[i][1].ToString());

            }
        }
        public void comboboxsft()
        {
            sft_names = con.consultaLibreDT("SELECT sft_nombre FROM Software");

            for (int i = 0; i < sft_names.Rows.Count; i++)
            {
                comboBox3.Items.Add(sft_names.Rows[i]["sft_nombre"]);
            }
        }
        public void cargar(String s) {
            name = s;
            dataGridView2.DataSource = con.consultaLibreDT("SELECT ieq_numero AS Equipo,sa_letra AS Sala,sft_nombre AS Nombre,sft_version AS Versión FROM software_equipo INNER JOIN Software ON (software_equipo.stw_id=Software.sft_id) INNER JOIN InvEquipo ON ( software_equipo.ieq_id=InvEquipo.ieq_id)INNER JOIN Sala ON (InvEquipo.sa_id= Sala.sa_id) WHERE sft_nombre='"+ name+"'");
            
        
        }
  
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            checkBox2.Checked = false;
            comboBox2.Text = "";
            checkBox1.Checked = false;


            dts = con.consultaLibreDT("SELECT ieq_id,ieq_numero FROM  InvEquipo INNER JOIN Sala ON (InvEquipo.sa_id= Sala.sa_id) WHERE sa_letra='" + comboBox1.SelectedItem.ToString() + "'");
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                comboBox2.Items.Add(dts.Rows[i][1].ToString()); 
            }
            dataGridView2.DataSource = con.consultaLibreDT("SELECT  ieq_numero AS Equipo,sa_letra AS Sala,sft_nombre AS Nombre,sft_version AS Versión FROM software_equipo INNER JOIN Software ON (software_equipo.stw_id=Software.sft_id) INNER JOIN InvEquipo ON ( software_equipo.ieq_id=InvEquipo.ieq_id)INNER JOIN Sala ON (InvEquipo.sa_id= Sala.sa_id) WHERE sa_letra ='" + comboBox1.SelectedItem.ToString() + "' AND sft_nombre ='" + name + "'");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            dataGridView2.DataSource = con.consultaLibreDT("SELECT ieq_numero AS Equipo,sa_letra AS Sala,sft_nombre AS Nombre,sft_version AS Versión FROM software_equipo INNER JOIN Software ON (software_equipo.stw_id=Software.sft_id) INNER JOIN InvEquipo ON ( software_equipo.ieq_id=InvEquipo.ieq_id)INNER JOIN Sala ON (InvEquipo.sa_id= Sala.sa_id) WHERE sa_letra ='" + comboBox1.SelectedItem.ToString() + "' AND sft_nombre ='" + name + "' AND ieq_numero= " + comboBox2.SelectedItem.ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked )
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    cargar(comboBox3.SelectedItem.ToString());   
                }
                checkBox2.Checked = false;
            }
            }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
          
            if (checkBox2.Checked)
            {
                if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
                {
                    dataGridView2.DataSource = con.consultaLibreDT("SELECT ieq_numero AS Equipo,sa_letra AS Sala,sft_nombre AS Nombre,sft_version AS Versión FROM software_equipo INNER JOIN Software ON (software_equipo.stw_id=Software.sft_id) INNER JOIN InvEquipo ON ( software_equipo.ieq_id=InvEquipo.ieq_id)INNER JOIN Sala ON (InvEquipo.sa_id= Sala.sa_id) WHERE sa_letra ='" + comboBox1.SelectedItem.ToString() + "' and software_equipo.ieq_id= " + dts.Rows[comboBox2.SelectedIndex]["ieq_id"].ToString());
                }
                checkBox1.Checked = false;
            }
         
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargar(comboBox3.SelectedItem.ToString());
        }
    }
}
