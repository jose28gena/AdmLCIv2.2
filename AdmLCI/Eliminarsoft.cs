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
    public partial class Eliminarsoft : Form
    {
        Conexion abrir = new Conexion();
        AdmnSoftware a;
        Sesion act;
        DataTable sft_names;
        public void comboboxsft()
        {
            sft_names = abrir.consultaLibreDT("SELECT sft_nombre,sft_id FROM Software");

            for (int i = 0; i < sft_names.Rows.Count; i++)
            {
                comboBox1.Items.Add(sft_names.Rows[i]["sft_nombre"]);
            }
        }
        public Eliminarsoft(AdmnSoftware e, Sesion b)
        {
            a = e;
            act = b;
            InitializeComponent();
            comboboxsft();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex == -1))
            {
                MessageBox.Show("Software", "Seleccione software ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                DialogResult res = MessageBox.Show("¿Realmente desea borrar el software seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                   abrir.modificar("DELETE FROM software WHERE sft_id =" + sft_names.Rows[comboBox1.SelectedIndex]["sft_id"]);
                   abrir.modificar("DELETE FROM software_equipo WHERE stw_id =" + sft_names.Rows[comboBox1.SelectedIndex]["sft_id"]);
                   abrir.modificar("INSERT INTO HistorialAcciones (ha_accion,usr_id,ha_objeto) VALUES('Eliminar'," + act.idUsr + ",'SW-" + comboBox1.SelectedItem.ToString() + "')");
                    a.cargar_tabla1();
                    this.Close();
                }
            }
        }
    }
}
