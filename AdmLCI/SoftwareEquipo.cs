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
    public partial class SoftwareEquipo : Form
    {
        Conexion con = new Conexion();
        DataTable dts;
        DataTable dtS;
        DataTable sft_names;
        int opc=2;
        List<String> sft_comp_no_agregado = new List<String>();
        List<int> lista = new List<int>();
        
    
    
        Boolean borrar;
        public void cargarComboBox()
        {
          
             dtS = con.consultaLibreDT("SELECT * FROM Sala ");
            
            for (int i = 0; i < dtS.Rows.Count; i++)
            {
                cbSala.Items.Add(dtS.Rows[i][1].ToString());
                
            }
        }
        public void comboboxsft (){
            sft_names = con.consultaLibreDT("SELECT sft_nombre FROM Software");

            for (int i = 0; i < sft_names.Rows.Count; i++)
            {
                comboBox1.Items.Add(sft_names.Rows[i]["sft_nombre"]);
            }
        }
        public SoftwareEquipo( Boolean mostrar)

        {


          
            InitializeComponent();
            cargarComboBox();
            comboboxsft();
            borrar = mostrar;
            if (!borrar) {
                checkBox1.Text = "Borrar a toda la sala";
                label2.Text = "Eliminar software de los equipos.";

            
            }
       
        
        }

           

   

        private void cbSala_SelectedIndexChanged_1(object sender, EventArgs e)
        {
         
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Text = "Seleccione equipo";

            if (checkBox2.Checked) {
                comboBox2.Text = "Desde";
                comboBox3.Text = "Hasta";

            }

           dts = con.consultaLibreDT("SELECT ieq_id,ieq_numero,ieq_tipo FROM  InvEquipo INNER JOIN Sala ON (InvEquipo.sa_id= Sala.sa_id) WHERE sa_letra='" + cbSala.SelectedItem.ToString() + "' ORDER BY ieq_numero");
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                comboBox2.Items.Add(dts.Rows[i]["ieq_numero"].ToString());
                comboBox3.Items.Add(dts.Rows[i]["ieq_numero"].ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                opc = 0;

              
              comboBox2.Enabled = (false);
              comboBox3.Enabled = (false);
              checkBox2.Enabled = false;
               
            }
            else {

                
                comboBox2.Enabled = (true);
              //  comboBox3.Enabled = (true);
                checkBox2.Enabled = true;
                opc = 2;
              
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                comboBox2.Text = "Desde";
                comboBox3.Text = "Hasta";

                comboBox3.Enabled = true;
                checkBox1.Enabled = false;
                opc = 1;


            }
            else {

                comboBox3.Enabled = false;
                checkBox1.Enabled = true;
                opc = 2;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                
                comboBox3.Items.Add(dts.Rows[i][1].ToString());
                
            }

            for (int i = comboBox2.SelectedIndex; i >=0; i--)
            {
                comboBox3.Items.RemoveAt(i);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String id_soft = con.consultaLibreS(" SELECT sft_id FROM Software WHERE sft_nombre='" + sft_names.Rows[comboBox1.SelectedIndex][0].ToString() + "'");
            if ((cbSala.SelectedIndex != -1)&&(comboBox1.SelectedIndex!=-1))
            {
                try
                {
                    switch (opc)
                    {
                        case 0:
                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                if (borrar)
                                {
                                    if (!con.existe("SELECT * FROM software_equipo WHERE stw_id=" + id_soft + " AND ieq_id =" + dts.Rows[i][0].ToString()))
                                    {
                                        con.consultaLibreS("INSERT INTO software_equipo(stw_id,ieq_id,ieq_Tipo) VALUES (" + id_soft + "," + dts.Rows[i][0].ToString() +",'"+ dts.Rows[i]["ieq_tipo"].ToString() + "')");

                                    }
                                    else
                                    {
                                        //   DataTable sf = con.consultaLibreDT("SELECT * FROM InvEquipo WHERE ieq_id =" + dts.Rows[i]["ieq_id"].ToString());
                                        sft_comp_no_agregado.Add(dts.Rows[i]["ieq_numero"].ToString());

                                    }
                                }
                                else
                                {
                                    con.consultaLibreS("DELETE FROM software_equipo WHERE stw_id=" + id_soft + " and ieq_id=" + dts.Rows[i][0].ToString());

                                }
                            }
                            if (borrar)
                            {
                                if (sft_comp_no_agregado.Count == 0)
                                {
                                   
                                }
                                else
                                {
                                    mostrarlista a = new mostrarlista(sft_comp_no_agregado);
                                    sft_comp_no_agregado.Clear();
                                    a.ShowDialog();
                                }
                                 DialogResult res = MessageBox.Show("¿Desea agregar otro software?", "Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                 if (res == DialogResult.No)
                                 {
                                     this.Close();
                                 }
                            }
                            else
                            { 
                                DialogResult res = MessageBox.Show("¿Desea eliminar otro software?", "Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.No)
                            {
                              
                                this.Close();
                            }
                            }



                            break;
                        case 1:
                            if ((comboBox2.SelectedIndex != -1) && (comboBox3.SelectedIndex != -1))
                            {
                                for (int i = comboBox2.SelectedIndex; i <= (comboBox2.SelectedIndex+comboBox3.SelectedIndex+1); i++)
                                {
                                    if (borrar)
                                    {
                                        if (!con.existe(" SELECT * FROM software_equipo WHERE stw_id=" + id_soft + " and ieq_id =" + dts.Rows[i]["ieq_id"].ToString() ))
                                        {

                                            con.consultaLibreS("INSERT INTO software_equipo(stw_id,ieq_id,ieq_Tipo) VALUES (" + id_soft + "," + dts.Rows[i]["ieq_id"].ToString() + ",'" + dts.Rows[i]["ieq_tipo"].ToString() + "')");



                                        }
                                        else
                                        {
                                            //  DataTable sf = con.consultaLibreDT("SELECT * FROM InvEquipo WHERE ieq_id =" + dts.Rows[i]["ieq_id"].ToString());
                                            sft_comp_no_agregado.Add(dts.Rows[i]["ieq_numero"].ToString());


                                        }

                                    }
                                    else
                                    {
                                        con.consultaLibreS("DELETE FROM software_equipo WHERE stw_id=" + id_soft + " and ieq_id=" + dts.Rows[i][0].ToString());

                                    }

                                }
                                if (borrar)
                                {
                                    if (sft_comp_no_agregado.Count == 0)
                                    {
                                        
                                    }
                                    else
                                    {
                                        mostrarlista a = new mostrarlista(sft_comp_no_agregado);
                                        sft_comp_no_agregado.Clear();
                                        a.ShowDialog();
                                    }
                                     DialogResult res = MessageBox.Show("¿Desea agregar otro software?", "Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                     if (res == DialogResult.No)
                                     {
                                         this.Close();
                                     }
                                }
                                else
                                {
                                    DialogResult res = MessageBox.Show("¿Desea quitar software de algun otro equipo?", "Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (res == DialogResult.No)
                                {
                                   
                                    this.Close();
                                }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione un equipo");

                            }


                            break;

                        case 2:
                            if (comboBox2.SelectedIndex != -1)
                            {
                                if (borrar)
                                {
                                    if (!con.existe(" SELECT * FROM software_equipo WHERE stw_id=" + id_soft + " and ieq_id = " + dts.Rows[comboBox2.SelectedIndex][0].ToString()))
                                    {
                                        con.consultaLibreS("INSERT INTO software_equipo(stw_id,ieq_id,ieq_Tipo) VALUES (" + id_soft + "," + dts.Rows[comboBox2.SelectedIndex][0].ToString() + ",'" + dts.Rows[comboBox2.SelectedIndex]["ieq_tipo"].ToString() + "')");

                                        DialogResult res = MessageBox.Show("¿Desea quitar software de algun otro equipo?", "Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                     if (res == DialogResult.No)
                                     {
                                         this.Close();
                                     }


                                    }
                                    else
                                    {
                                        //  DataTable sf = con.consultaLibreDT("SELECT * FROM InvEquipo WHERE ieq_id =" + dts.Rows[0]["ieq_id"].ToString());
                                        sft_comp_no_agregado.Add(dts.Rows[0]["ieq_numero"].ToString());  //aqui se ira creando la lista de los equipos a los cuales no se les asigno el software
                                    }
                                }
                                else
                                {
                                    con.consultaLibreS("DELETE FROM software_equipo WHERE stw_id=" + id_soft + " and ieq_id=" + dts.Rows[comboBox2.SelectedIndex][0].ToString());
                                   
                                     DialogResult res = MessageBox.Show("¿Desea quitar software de algun otro equipo?", "Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                     if (res == DialogResult.No)
                                     {
                                         this.Close();
                                     }

                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione un equipo");

                            }
                            break;

                    }



                }
                catch (NullReferenceException)
                {


                    MessageBox.Show("Campos sin seleccionar.");
                }
            }
            else
            {
                MessageBox.Show("Es necesario seleccionar alguna sala.");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             this.Close();
        }

      
        
          
    }
}
