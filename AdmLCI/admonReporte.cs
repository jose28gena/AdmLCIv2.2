using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Reflection;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;




namespace AdmLCI
{
    public partial class admonReporte : Form
    {
        Conexion con = new Conexion();

        String [] soft={"Instalado por sala","Negaciones de Software","Uso de software"};
        String[] acceso = { "Servicios de utilización de equipo de cómputo por carrera", "Horas-usuario por carrera", "Usuarios únicos por carrera", "Reporte acumulado por tipo de usuario", "Accesos totales"};
        String[] equip = { "Equipos en mantenimiento", "Equipos totales por sala" };
        DataTable reporte=new DataTable();

        public admonReporte()
        {
            InitializeComponent();

            int anios = int.Parse(DateTime.Now.Year.ToString())-2012;

            for (int i = 0; i <= anios; i++)
            {
                cbAnio.Items.Add(int.Parse(DateTime.Now.Year.ToString()) - i);
                cbAnio2.Items.Add(int.Parse(DateTime.Now.Year.ToString()) - i);
            }

            cbHora1.SelectedIndex = 0;
            cbHora2.SelectedIndex = 1;


           
        }

        public string validar(string txt)
        {
            char[] texto = txt.ToCharArray();
            string textoAnt = txt;

            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] == '!' || texto[i] == '@' || texto[i] == '#' || texto[i] == '$' || texto[i] == '%' ||
                    texto[i] == '^' || texto[i] == '&' || texto[i] == '*' || texto[i] == '(' || texto[i] == ')' ||
                    texto[i] == '=' || texto[i] == '[' || texto[i] == ']' || texto[i] == '\'' || texto[i] == ';'
                    || texto[i] == '/' || texto[i] == '.' || texto[i] == ',' || texto[i] == '<' || texto[i] == '>'
                    || texto[i] == '?' || texto[i] == '\"' || texto[i] == ':' || texto[i] == '}' || texto[i] == '{'
                    || texto[i] == '+' || texto[i] == '_' || texto[i] == '~' || texto[i] == '`' || texto[i] == '\\'
                    || texto[i] == '|')
                {
                    return textoAnt.Substring(0, i) + textoAnt.Substring(i + 1);
                }


            }

            return textoAnt;

        }


        /*
         Recibe un DataTable y lo acomoda en un archivo .xls
         */
        public void mostrarExcel(DataTable dt, string titulo) {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;
            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;


                //Encabezado del reporte  
                oSheet.Cells[1,7] = ""+DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
                oSheet.Cells[1,1] = "Dirección de Servicios Universitarios";
                oSheet.get_Range("A1", "F1").Font.Bold = true;
                oSheet.get_Range("A1", "F1").Font.Size = 14;
                oSheet.get_Range("A1", "F1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "F1").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "F1").Merge();

                oSheet.Cells[2, 2] = "Laboratorio Central de Informática";
                oSheet.get_Range("A2", "F2").Font.Bold = true;
                oSheet.get_Range("A2", "F2").Font.Size = 14;
                oSheet.get_Range("A2", "F2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A2", "F2").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A2", "F2").Merge();

                oSheet.Cells[3, 3] = titulo;
                oSheet.get_Range("A3", "F3").Font.Bold = true;
                oSheet.get_Range("A3", "F3").Font.Size = 12;
                oSheet.get_Range("A3", "F3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A3", "F3").HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A3", "F3").Merge();


                


                //Llenar encabezados de la tabla
                for (int i = 1; i <= dt.Columns.Count;i++ )
                {
                    oSheet.Cells[5, i] = dt.Columns[i-1].ToString();
                    
                }

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A5", "H5").Font.Bold = true;

                
                oSheet.get_Range("A5", "H5").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;

                for (int i = 6; i <= dt.Rows.Count+5; i++) {
                    for (int j = 1; j <= dt.Columns.Count; j++)
                    {
                        oSheet.Cells[i, j]=dt.Rows[i-6][j-1].ToString();
                    }
                }
                oSheet.Protect(Type.Missing, oSheet.ProtectDrawingObjects,
                true, oSheet.ProtectScenarios, oSheet.ProtectionMode,
                oSheet.Protection.AllowFormattingCells,
                oSheet.Protection.AllowFormattingColumns,
                oSheet.Protection.AllowFormattingRows,
                oSheet.Protection.AllowInsertingColumns,
                oSheet.Protection.AllowInsertingRows,
                oSheet.Protection.AllowInsertingHyperlinks,
                oSheet.Protection.AllowDeletingColumns,
                oSheet.Protection.AllowDeletingRows,
                oSheet.Protection.AllowSorting,
                oSheet.Protection.AllowFiltering,
                oSheet.Protection.AllowUsingPivotTables);
                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;


                string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

                oWB = oXL.Workbooks.Open(@"E:\SSIS\ABC\Book1.xls",
                     Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value);
                oSheet = (Excel.Worksheet)oWB.Worksheets[1];

                oRng = oSheet.get_Range("A1", Missing.Value);
                oRng.Columns.ColumnWidth = 22.34;
                oRng = oSheet.get_Range("B1", Missing.Value);
                oRng.Columns.ColumnWidth = 22.34;
                oWB.SaveAs(@"Test.xlsx", Type.Missing, Type.Missing,
                  Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive,
                  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);





                string paramSourceBookPath = @"Test.xlsx";
                object paramMissing = Type.Missing;


                string paramExportFilePath = @"Test.pdf";
                Excel.XlFixedFormatType paramExportFormat = Excel.XlFixedFormatType.xlTypePDF;
                Excel.XlFixedFormatQuality paramExportQuality =
                    Excel.XlFixedFormatQuality.xlQualityStandard;
                bool paramOpenAfterPublish = false;
                bool paramIncludeDocProps = true;
                bool paramIgnorePrintAreas = true;
                object paramFromPage = Type.Missing;
                object paramToPage = Type.Missing;


                try
                {
                    // Open the source workbook.
                    oWB = oXL.Workbooks.Open(paramSourceBookPath,
                        paramMissing, paramMissing, paramMissing, paramMissing,
                        paramMissing, paramMissing, paramMissing, paramMissing,
                        paramMissing, paramMissing, paramMissing, paramMissing,
                        paramMissing, paramMissing);

                    // Save it in the target format.
                    if (oWB != null)
                        oWB.ExportAsFixedFormat(paramExportFormat,
                            paramExportFilePath, paramExportQuality,
                            paramIncludeDocProps, paramIgnorePrintAreas, paramFromPage,
                            paramToPage, paramOpenAfterPublish,
                            paramMissing);
                }
                catch (Exception ex)
                {
                    // Respond to the error.
                }
                finally
                {
                    // Close the workbook object.
                    if (oWB != null)
                    {
                        oWB.Close(false, paramMissing, paramMissing);
                        oWB = null;
                    }

                    // Quit Excel and release the ApplicationClass object.
                    if (oXL != null)
                    {
                        oXL.Quit();
                        oXL = null;
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }  
                
            }
            catch (Exception e) { }

        }

        private void admonReporte_Load(object sender, EventArgs e)
        {

        }


        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRestricciones.Text = "Seleccione una opción.";
            cbRestricciones.Enabled = true;
            switch (cbTipo.SelectedIndex) { 
                case 0:
                    cbRestricciones.Items.Clear();
                    for (int i = 0; i < acceso.Length; i++) 
                        cbRestricciones.Items.Add(acceso[i]);
                        break;
                case 1:
                        cbRestricciones.Items.Clear();
                    for (int i = 0; i < soft.Length; i++)
                            cbRestricciones.Items.Add(soft[i]);
                    break;
                case 2:
                    cbRestricciones.Items.Clear();
                    for (int i = 0; i < equip.Length; i++)
                        cbRestricciones.Items.Add(equip[i]);
                    break;


                case 3:
                    cbRestricciones.Enabled = false;
                    break;                
            
            }
        }


        public DataTable totales(DataTable dt) {
            dt.Rows.Add();

            dt.Rows[dt.Rows.Count-1][0]="Total: ";

            int sumaC = 0;

            for (int i = 0; i < dt.Rows.Count-1;i++ )
            {
                sumaC = sumaC + int.Parse(dt.Rows[i][1].ToString());
            }
           // MessageBox.Show(""+sumaC);
            dt.Rows[dt.Rows.Count - 1][1] = ""+sumaC;
            sumaC = 0;
            return dt;
        }

        public DataTable totalesSemestral(DataTable dt) {
            dt.Columns.Add("Total");
            dt.Rows.Add();

            dt.Rows[dt.Rows.Count-1][0]="Total";

            int sumaC=0;

            //Llenar totales de carrera
            for (int i = 0; i < dt.Rows.Count-1;i++ )
            {
                for (int j = 1; j < dt.Columns.Count-1; j++)
                {
                    sumaC =sumaC+ int.Parse(dt.Rows[i][j].ToString());
                }
                dt.Rows[i][7]=sumaC;
                sumaC = 0;
            }
            sumaC = 0;
            for (int i = 0; i < dt.Rows.Count - 1;i++ )
            {
                sumaC=sumaC+int.Parse(dt.Rows[i][7].ToString());
            }
            dt.Rows[dt.Rows.Count - 1][7]=sumaC;
            sumaC = 0;
            //Llenar totales meses
            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                int j = 0;
                for ( j = 0; j < dt.Rows.Count - 1; j++)
                {
                    sumaC = sumaC + int.Parse(dt.Rows[j][i].ToString());
                }
                dt.Rows[dt.Rows.Count-1][i] = sumaC;
                sumaC = 0;
            }

            return dt;
        
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            String fecha = dtpFecha1.Value.ToString("dd-MM-yyyy");
            String fecha2 = dtpFecha2.Value.ToString("dd-MM-yyyy");

   
            //Revisa que se haya seleccionado un reporte.
            if (cbRestricciones.SelectedIndex < 0 && cbTipo.SelectedIndex !=3)
            {
                MessageBox.Show("Debe seleccionar un reporte.");

                return;
            }


            switch (cbTipo.SelectedIndex)
            {
                    //Acceso
                case 0:



                    if (cbRestricciones.SelectedIndex == 0) //Servicios de utilización de equipo de cómputo por carreras
                    {
                        #region Acceso por carrera                        
                      
                        //Valida que se haya seleccionado un periodo para el reporte.
                        if (rbEnJu.Checked == false && rbJuDi.Checked == false && rbDia.Checked==false && rbMes.Checked==false && rbLibre.Checked==false && rbHora.Checked==false)
                        {
                             MessageBox.Show("Debe seleccionar un periodo");
                             return;
                        }

                        //Reporte mensual de enero-junio
                        if (rbEnJu.Checked)
                        {

                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT("Execute Reporte_servicios_utilizacion_EnJun " + cbAnio.Items[cbAnio.SelectedIndex]);

                            //Enviar el resultado de la consulta a Excel.
                            mostrarExcel(totalesSemestral(acceso), "Servicios de utilización de equipo de cómputo por carreras de Enero a Junio del " + cbAnio.Items[cbAnio.SelectedIndex]);

                        }

                        //Reporte mensual de julio-diciembre
                        if (rbJuDi.Checked)
                        {

                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }
                            DataTable acceso = con.consultaLibreDT("Execute Reporte_servicios_utilizacion_JulDic " + cbAnio.Items[cbAnio.SelectedIndex]);

                            mostrarExcel(totalesSemestral(acceso), "Servicios de utilización de equipo de cómputo por carreras de Julio a Diciembre del " + cbAnio.Items[cbAnio.SelectedIndex]);
                         
                        }
                        //Reporte del mes seleccionado.
                        if (rbMes.Checked) {

                            if (cbMes.SelectedIndex < 0 || cbAnio2.SelectedIndex<0) {
                                MessageBox.Show("Debe seleccionar un mes y un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT("SELECT  distinct( UsuarioLCI.est_carrera) AS Carrera," +
 " sum(case when (month(ueq_fecha) = " + (cbMes.SelectedIndex + 1) + " and YEAR(ueq_fecha)=" + cbAnio2.Items[cbAnio2.SelectedIndex] + " ) then 1 else 0 end) AS '"+cbMes.SelectedItem+"'" +
" FROM UsoEquipo FULL JOIN UsuarioLci  "+
" ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente)"+ 
" GROUP BY"+@" est_carrera 
                            UNION 
                            SELECT  'Usuarios Especiales' AS Carrera," +
 " sum(case when (month(ueq_fecha) = " + (cbMes.SelectedIndex + 1) + " and YEAR(ueq_fecha)=" + cbAnio2.Items[cbAnio2.SelectedIndex] 
 + " ) then 1 else 0 end) AS '"+cbMes.SelectedItem+"'" +
" FROM UsoEquipo FULL JOIN AlumnoEspecial  "+
" ON( UsoEquipo.ales_id=ALumnoEspecial.ales_id) where AlumnoEspecial.ales_id!=0");
                           mostrarExcel(acceso, "Servicios de utilización de equipo de cómputo por carreras de " + cbMes.Items[cbMes.SelectedIndex] + " del " + cbAnio2.Items[cbAnio2.SelectedIndex]);
                        }
                        //Reporte del dia seleccionado
                        if (rbDia.Checked) {

                            DataTable acceso = con.consultaLibreDT("SELECT  distinct( est_carrera) AS Carrera,"+
  " sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " ) then 1 else 0 end) AS '"+dtpDia.Value.Day+"-"+dtpDia.Value.Month+"-"+dtpDia.Value.Year+"'" +

 " FROM UsoEquipo FULL JOIN UsuarioLci"+
 " ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) where est_carrera!=''"+
 " GROUP BY"+
 " est_carrera union SELECT  'Usuarios Especiales' AS Carrera," +
  " sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " ) then 1 else 0 end) AS '" + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + "'" +

 " FROM UsoEquipo FULL JOIN AlumnoEspecial" +
 " ON( UsoEquipo.ales_id=AlumnoEspecial.ales_id) where AlumnoEspecial.ales_id!=0");
                            mostrarExcel(acceso, "Servicios de utilización de equipo de cómputo por carreras del día " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year);
                        }
                        //Reporte en un periodo seleccionado por el usuario
                        if (rbLibre.Checked) {
                           
                          
             DataTable acceso = con.consultaLibreDT("EXECUTE Reporte_Servicios_equipo_libre '" + fecha+"','" + fecha2+"'");
                         
                            
                           mostrarExcel(totales(acceso), "Servicios de utilización de equipo de cómputo por carreras del " + dtpFecha1.Value.Day + "-" + dtpFecha1.Value.Month + "-" + dtpFecha1.Value.Year + " al " + dtpFecha2.Value.Day + "-" + dtpFecha2.Value.Month + "-" + dtpFecha2.Value.Year);
                        }
                        if (rbHora.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT("SELECT  distinct( est_carrera) AS Carrera," +
                                " sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + " ) then 1 else 0 end) AS '" + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + " "+cbHora1.Items[cbHora1.SelectedIndex]+":00  a "+cbHora1.Items[cbHora1.SelectedIndex]+":00' " +

 " FROM UsoEquipo FULL JOIN UsuarioLci" +
 " ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) where est_carrera!=''" +
 " GROUP BY" +
 " est_carrera");
                            mostrarExcel(acceso, "Servicios de utilización de equipo de cómputo por carreras de "+ dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + " "+cbHora1.Items[cbHora1.SelectedIndex]+":00  a "+cbHora1.Items[cbHora1.SelectedIndex]+":00' " );
                        }
                        
                        #endregion

                    }

                    else if (cbRestricciones.SelectedItem.ToString().Equals("Horas-usuario por carrera")) //Horas-usuario por carrera
                    {
                        #region horas solicitadas
                        if (rbEnJu.Checked == false && rbJuDi.Checked == false && rbDia.Checked == false && rbMes.Checked == false && rbLibre.Checked == false && rbHora.Checked == false)
                        {
                            MessageBox.Show("Debe seleccionar un periodo");
                            return;

                        }

                        //Reporte enero-junio
                        if (rbEnJu.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT("SELECT  distinct( est_carrera) AS Carrera, "+
"( (sum(case when (month(ueq_fecha) = 01 and YEAR(ueq_fecha)="+cbAnio.Items[cbAnio.SelectedIndex]+"  ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Enero' "+
",( (sum(case when (month(ueq_fecha) = 02 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end) )/60) AS 'Febrero' " +
", ((sum(case when (month(ueq_fecha) = 03 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Marzo' " +
",(( sum(case when (month(ueq_fecha) = 04 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Abril' " +
",(( sum(case when (month(ueq_fecha) = 05 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Mayo' " +
",(( sum(case when (month(ueq_fecha) = 06 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Junio' " +

 "FROM UsoEquipo FULL JOIN UsuarioLci "+
 "ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) where UsuarioLCI.est_carrera!='' "+
 "GROUP BY "+
 "est_carrera");

                            //DataTable acceso = con.consultaLibreDT("select ra_carrera as 'columna1', ra_ene as 'columna2', ra_feb as 'columna3', ra_mar as 'columna4', ra_abr as 'columna5', ra_may as 'columna6', ra_jun as 'columna7' from rptAcceso where ra_anio=" + cbAnio.Items[cbAnio.SelectedIndex]);
                            mostrarExcel(totalesSemestral(acceso), "Horas-usuario por carrera de Enero a Junio del " + cbAnio.Items[cbAnio.SelectedIndex]);

                        }
                        
                        //Reporte julio-diciembre
                        if (rbJuDi.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }
                            DataTable acceso = con.consultaLibreDT("SELECT  distinct( est_carrera) AS Carrera, "+
"(( sum(case when (month(ueq_fecha) = 07 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Julio' " +
",(( sum(case when (month(ueq_fecha) = 08 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Agosto' " +
", ((sum(case when (month(ueq_fecha) = 09 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Septiembre' " +
", ((sum(case when (month(ueq_fecha) = 10 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Octubre' " +
", ((sum(case when (month(ueq_fecha) = 11 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Noviembre' " +
",(( sum(case when (month(ueq_fecha) = 12 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Diciembre' " +

 "FROM UsoEquipo FULL JOIN UsuarioLci "  +
 "ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) where UsuarioLCI.est_carrera!='' "+
 "GROUP BY "+
 "est_carrera");
                            mostrarExcel(totalesSemestral(acceso), "Horas-usuario por carrera de Julio a Diciembre del " + cbAnio.Items[cbAnio.SelectedIndex]);

                        }
                        //Reporte en un mes
                        if (rbMes.Checked)
                        {

                            if (cbMes.SelectedIndex < 0 || cbAnio2.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un mes y un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT(" SELECT  distinct( est_carrera) AS Carrera, "+
"( (sum(case when (month(ueq_fecha) = " + (cbMes.SelectedIndex + 1) + " and YEAR(ueq_fecha)=" + cbAnio2.Items[cbAnio2.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS '" + cbMes.Items[cbMes.SelectedIndex] + "' " +

 "FROM UsoEquipo FULL JOIN UsuarioLci  "+
 "ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) where UsuarioLCI.est_carrera!='' "+
 "GROUP BY "+
 "est_carrera");
                            mostrarExcel(acceso, "Horas-usuario por carrera de " + cbMes.Items[cbMes.SelectedIndex] + " del " + cbAnio2.Items[cbAnio2.SelectedIndex]);
                        }
                        //Reporte de un dia
                        if (rbDia.Checked)
                        {

                            DataTable acceso = con.consultaLibreDT("SELECT  distinct( est_carrera) AS Carrera,"+
"( (sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS '" + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + "' " +

 "FROM UsoEquipo FULL JOIN UsuarioLci  "+
 "ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) where UsuarioLCI.est_carrera!='' "+
 "GROUP BY "+
 "est_carrera");
                            mostrarExcel(acceso, "Horas-usuario por carrera del día " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year);
                        }
                        
                        if (rbLibre.Checked)
                        {
                           
                            DataTable acceso = con.consultaLibreDT("select distinct( est_carrera) AS Carrera, "+
 "( (sum(case when (ueq_fecha between  " + fecha + " and " + fecha2 + ") then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario' " +
 "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente where est_carrera!='' GROUP BY "+
 "est_carrera ");
                            mostrarExcel(totales(acceso), "Horas-usuario por carrera del " + dtpFecha1.Value.Day + "-" + dtpFecha1.Value.Month + "-" + dtpFecha1.Value.Year + " al " + dtpFecha2.Value.Day + "-" + dtpFecha2.Value.Month + "-" + dtpFecha2.Value.Year);
                        } if (rbHora.Checked)
                        {

                            DataTable acceso = con.consultaLibreDT("SELECT  distinct( est_carrera) AS Carrera," +
"( (sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + "and DAY(ueq_fecha)=" + dtpDia.Value.Day + " and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] +" ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS '" + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + " "+cbHora1.Items[cbHora1.SelectedIndex]+":00  a "+cbHora1.Items[cbHora1.SelectedIndex]+":00' " +

 "FROM UsoEquipo FULL JOIN UsuarioLci  " +
 "ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) where UsuarioLCI.est_carrera!='' " +
 "GROUP BY " +
 "est_carrera");
                            mostrarExcel(acceso, "Horas-usuario por carrera del día " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + " " + cbHora1.Items[cbHora1.SelectedIndex] + ":00  a " + cbHora1.Items[cbHora1.SelectedIndex] + ":00' ");
                        }

                        #endregion
                    }

                    else if (cbRestricciones.SelectedIndex == 2) //Usuarios unicos
                    {
                        #region usuarios unicos
                        if (rbEnJu.Checked == false && rbJuDi.Checked == false && rbDia.Checked == false && rbMes.Checked == false && rbLibre.Checked == false && rbHora.Checked == false)
                        {
                            MessageBox.Show("Debe seleccionar un periodo");
                            return;
                        }

                        if (rbEnJu.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }
                            DataTable acceso = con.consultaLibreDT(" EXECUTE Reporte_usuarios_unicos_EnJun " + cbAnio.Items[cbAnio.SelectedIndex]);

                            //DataTable acceso = con.consultaLibreDT("select ra_carrera as 'columna1', ra_ene as 'columna2', ra_feb as 'columna3', ra_mar as 'columna4', ra_abr as 'columna5', ra_may as 'columna6', ra_jun as 'columna7' from rptAcceso where ra_anio=" + cbAnio.Items[cbAnio.SelectedIndex]);
                            mostrarExcel(totalesSemestral( acceso), "Usuarios únicos por carrera de Enero a Junio del " + cbAnio.Items[cbAnio.SelectedIndex]);

                        }


                        if (rbJuDi.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }
                            DataTable acceso = con.consultaLibreDT(" EXECUTE Reporte_usuarios_unicos_JulDic " + cbAnio.Items[cbAnio.SelectedIndex]);
                            mostrarExcel(totalesSemestral(acceso), "Usuarios únicos por carrera Julio a Diciembre del " + cbAnio.Items[cbAnio.SelectedIndex]);

                        }
                        if (rbMes.Checked)
                        {

                            if (cbMes.SelectedIndex < 0 || cbAnio2.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un mes y un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT("SELECT  distinct( est_carrera) AS CARRERA, "+
 " COUNT (distinct case when (month(ueq_fecha) = " + (cbMes.SelectedIndex + 1) + " and YEAR(ueq_fecha)=" + cbAnio2.Items[cbAnio2.SelectedIndex] + " ) then UsoEquipo.est_expediente  end) AS '" + cbMes.Items[cbMes.SelectedIndex] + "' " +

 "FROM UsoEquipo FULL JOIN UsuarioLci  "+
 "ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) "+
 "GROUP BY "+
 "est_carrera");
                            mostrarExcel(acceso, "Usuarios únicos por carrera de " + cbMes.Items[cbMes.SelectedIndex] + " del " + cbAnio2.Items[cbAnio2.SelectedIndex]);
                        }
                        if (rbDia.Checked)
                        {
                           
                            DataTable acceso = con.consultaLibreDT("SELECT  distinct( est_carrera) AS CARRERA, "+
  "COUNT (distinct case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + ") then UsoEquipo.est_expediente  end) AS '"+ dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year+"' " +
 "FROM UsoEquipo FULL JOIN UsuarioLci  "+
 "ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) "+
 "GROUP BY est_carrera");
                            mostrarExcel(acceso, "Usuarios únicos por carrera del día " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year);
                        }

                        if (rbLibre.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT(" select distinct( est_carrera) AS Carrera, "+
  "COUNT (distinct case when (ueq_fecha between  " + fecha + " and " + fecha2 + ") AS 'Usuarios únicos' " +
 "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente where est_carrera!='' GROUP BY "+
 "est_carrera ");
                            mostrarExcel(totales(acceso), "Usuarios-únicos por carrera del " + dtpFecha1.Value.Day + "-" + dtpFecha1.Value.Month + "-" + dtpFecha1.Value.Year + " al " + dtpFecha2.Value.Day + "-" + dtpFecha2.Value.Month + "-" + dtpFecha2.Value.Year);
                       
                        } if (rbHora.Checked)
                        { 
                         DataTable acceso = con.consultaLibreDT("SELECT  distinct( est_carrera) AS CARRERA, "+
  "COUNT (distinct case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day  +" and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + ") then UsoEquipo.est_expediente  end) AS '" + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + "' " +
 "FROM UsoEquipo FULL JOIN UsuarioLci  "+
 "ON( UsoEquipo.est_expediente=UsuarioLCI.est_expediente) "+
 "GROUP BY est_carrera");
                         mostrarExcel(acceso, "Usuarios únicos por carrera de " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + " " + cbHora1.Items[cbHora1.SelectedIndex] + ":00  a " + cbHora1.Items[cbHora1.SelectedIndex] + ":00' ");
                        
                        
                        
                        }

                        #endregion 
                    }

                        //Reporte acumulado por tipo de usuario
                    else if (cbRestricciones.SelectedItem.ToString().Equals("Reporte acumulado por tipo de usuario")) 
                    {
                        #region Reporte acumulado por tipo de usuario
                        if (rbEnJu.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0) 
                            {

                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT(
                                   @"EXECUTE Reporte_acceso_totales_EnJun " + cbAnio.Items[cbAnio.SelectedIndex]);
                            mostrarExcel(acceso, "Reporte acumulado por tipo de usuario de Enero a Junio del " + cbAnio.Items[cbAnio.SelectedIndex]);
                       
                        }
                        
                        if (rbJuDi.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }
                            DataTable acceso = con.consultaLibreDT(
                                    @"EXECUTE Reporte_acceso_totales_JulDic " + cbAnio.Items[cbAnio.SelectedIndex]);
                            mostrarExcel(acceso, "Reporte acumulado por tipo de usuario de Julio a Diciembre del " + cbAnio.Items[cbAnio.SelectedIndex]);
                        }

                        if (rbMes.Checked)
                        {

                            if (cbMes.SelectedIndex < 0 || cbAnio2.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un mes y un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT(
                                    @"select 'Alumno' as Tipo,Isnull(((sum( UsoEquipo.ueq_tiempo ))/60),0) AS 'Horas usuario',
                            COUNT (UsoEquipo.est_expediente) AS 'Solicitudes',
COUNT ( distinct UsoEquipo.est_expediente) AS 'Usuarios unicos'
 From UsoEquipo  where  LEN ( UsoEquipo.est_expediente)=9 and UsoEquipo.ales_id=0
 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + @"and MONTH(ueq_fecha)=01
 UNION

select 'Maestro' as Tipo,isnull(((sum( UsoEquipo.ueq_tiempo ))/60),0) AS 'Horas usuario',
COUNT (UsoEquipo.est_expediente) AS 'Solicitudes',
COUNT ( distinct UsoEquipo.est_expediente) AS 'Usuarios unicos'
 From UsoEquipo  where  LEN ( UsoEquipo.est_expediente)=5 and UsoEquipo.ales_id=0
 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + @"
 union
select 'Usuario especial' as Tipo ,isnull(((sum( UsoEquipo.ueq_tiempo ))/60),0) AS 'Horas usuario',
COUNT (UsoEquipo.est_expediente) AS 'Solicitudes',
COUNT ( distinct UsoEquipo.est_expediente) AS 'Usuarios unicos'
 From UsoEquipo  where  UsoEquipo.ales_id!=0
 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex]); 
                            mostrarExcel(acceso, "Reporte acumulado por tipo de usuario del mes " + cbMes.Items[cbMes.SelectedIndex] + " del " + cbAnio2.Items[cbAnio2.SelectedIndex]);

                        }
                        if (rbDia.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT("select distinct(UsuarioLCI.est_tipo) as 'Usuario', "+
"sum(case when (month(ueq_fecha) = "+dtpDia.Value.Month+"  and YEAR(ueq_fecha)="+dtpDia.Value.Year+" and DAY(ueq_fecha)="+dtpDia.Value.Day+" ) then 1 else 0 end) AS 'Solicitudes', "+
"( (sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + "  and DAY(ueq_fecha)=" + dtpDia.Value.Day + ") then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
  " COUNT (distinct case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + ") then UsoEquipo.est_expediente  end) AS 'Usuario único' " +
 "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente group by UsuarioLCI.est_tipo");

                            DataTable acceso2 = con.consultaLibreDT("select 'Especial' as 'Usuario', "+
 "sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day+ " ) then 1 else 0 end) AS 'Solicitudes', " +
 "( (sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
 "COUNT (distinct case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " ) then UsoEquipo.est_expediente  end) AS 'Usuario único' " +
 "from UsoEquipo FULL join AlumnoEspecial on UsoEquipo.ales_id=AlumnoEspecial.ales_id;");

                            if (acceso2.Rows.Count > 0)
                            {
                                acceso.Merge(acceso2);
                                if (acceso.Rows[2][1].ToString().Equals(""))
                                {
                                    acceso.Rows[2][1] = "0";
                                }
                                if (acceso.Rows[2][2].ToString().Equals(""))
                                {
                                    acceso.Rows[2][2] = "0";
                                }
                                if (acceso.Rows[2][3].ToString().Equals(""))
                                {
                                    acceso.Rows[2][3] = "0";
                                }
                            }

                            mostrarExcel(acceso, "Reporte acumulado por tipo de usuarios del día " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year);
                        
                        }
                        if (rbHora.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT("select distinct(UsuarioLCI.est_tipo) as 'Usuario', " +
"sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + " ) then 1 else 0 end) AS 'Solicitudes', " +
"( (sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + "  and DAY(ueq_fecha)=" + dtpDia.Value.Day + " and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + ") then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
  " COUNT (distinct case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + ") then UsoEquipo.est_expediente  end) AS 'Usuario único' " +
 "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente group by UsuarioLCI.est_tipo");

                            DataTable acceso2 = con.consultaLibreDT("select 'Especial' as 'Usuario', " +
 "sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + " ) then 1 else 0 end) AS 'Solicitudes', " +
 "( (sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + "and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + ") then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
 "COUNT (distinct case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + ") then UsoEquipo.est_expediente  end) AS 'Usuario único' " +
 "from UsoEquipo FULL join AlumnoEspecial on UsoEquipo.ales_id=AlumnoEspecial.ales_id;");

                            if (acceso2.Rows.Count > 0)
                            {
                                acceso.Merge(acceso2);
                                if (acceso.Rows[2][1].ToString().Equals(""))
                                {
                                    acceso.Rows[2][1] = "0";
                                }
                                if (acceso.Rows[2][2].ToString().Equals(""))
                                {
                                    acceso.Rows[2][2] = "0";
                                }
                                if (acceso.Rows[2][3].ToString().Equals(""))
                                {
                                    acceso.Rows[2][3] = "0";
                                }
                            }

                            mostrarExcel(acceso, "Reporte acumulado por tipo de usuarios de  " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year);

                        }

                     
                        if (rbLibre.Checked) {
                            DataTable acceso = con.consultaLibreDT("select distinct(UsuarioLCI.est_tipo) as 'Usuario', "+
"sum(case when (ueq_fecha between  " + fecha + " and " + fecha2 + ") then 1 else 0 end) AS 'Solicitudes', " +
"( (sum(case when (ueq_fecha between  " + fecha + " and " + fecha2 + ") then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
 "  COUNT (distinct case when (ueq_fecha between  " + fecha + " and " + fecha2 + ") then UsoEquipo.est_expediente  end) AS 'Usuario único' " +
 "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente group by UsuarioLCI.est_tipo");

                            
                            DataTable acceso2 = con.consultaLibreDT("select 'Especial' as 'Usuario', "+
 "sum(case when (ueq_fecha between  " + fecha + " and " + fecha2 + ") then 1 else 0 end) AS 'Solicitudes', " +
 "( (sum(case when (ueq_fecha between  " + fecha + " and " + fecha2 + "))/60) AS 'Horas-usuario', " +
 "COUNT (distinct case when (ueq_fecha between  " + fecha + " and " + fecha2 + ")) AS 'Usuario único' " +
 "from UsoEquipo FULL join AlumnoEspecial on UsoEquipo.ales_id=AlumnoEspecial.ales_id");

                            if (acceso2.Rows.Count > 0)
                            {
                                acceso.Merge(acceso2);
                                if (acceso.Rows[2][1].ToString().Equals("")) {
                                    acceso.Rows[2][1] = "0";
                                }
                                if (acceso.Rows[2][2].ToString().Equals(""))
                                {
                                    acceso.Rows[2][2] = "0";
                                }
                                if (acceso.Rows[2][3].ToString().Equals(""))
                                {
                                    acceso.Rows[2][3] = "0";
                                }
                            }


                            mostrarExcel(acceso, "Reporte acumulado por tipo de usuario del día " + dtpFecha1.Value.Day + "-" + dtpFecha1.Value.Month + "-" + dtpFecha1.Value.Year + " al " + dtpFecha2.Value.Day + "-" + dtpFecha2.Value.Month + "-" + dtpFecha2.Value.Year);

                        }

#endregion
                    }

                    else if (cbRestricciones.SelectedItem.ToString().Equals("Accesos totales"))
                    {
                        #region Acceso totales
                        if (rbEnJu.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }
                            DataTable acceso = con.consultaLibreDT(@"EXECUTE Reporte_acceso_totales_EnJun " + cbAnio.Items[cbAnio.SelectedIndex]);
                            mostrarExcel(acceso, "Accesos totales de Enero a Junio del " + cbAnio.Items[cbAnio.SelectedIndex]);
                        }

                        if (rbJuDi.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }
                            DataTable acceso = con.consultaLibreDT("select sum(case when (month(ueq_fecha) >= 07 and month(ueq_fecha) <= 12  and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + "  ) then 1 else 0 end) AS 'Solicitudes de usuario', " +
 "( (sum(case when (month(ueq_fecha) >= 07 and month(ueq_fecha) <= 12 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + "  ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
    "COUNT (distinct case when (month(ueq_fecha) >= 07 and month(ueq_fecha) <= 12 and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] + ") then UsoEquipo.est_expediente  end) AS 'Usuarios únicos' " +
  "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente");
                            mostrarExcel(acceso, "Accesos totales de Julio a Diciembre del " + cbAnio.Items[cbAnio.SelectedIndex]);
                        }

                        if (rbMes.Checked)
                        {

                            if (cbMes.SelectedIndex < 0 || cbAnio2.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un mes y un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT(" select sum(case when (month(ueq_fecha) = "+(cbMes.SelectedIndex+1)+"  and YEAR(ueq_fecha)="+cbAnio2.Items[cbAnio2.SelectedIndex]+"  ) then 1 else 0 end) AS 'Solicitudes de usuario', "+
"( (sum(case when (month(ueq_fecha) = " + (cbMes.SelectedIndex + 1) + "  and YEAR(ueq_fecha)=" + cbAnio2.Items[cbAnio2.SelectedIndex] + "  ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
  " COUNT (distinct case when (month(ueq_fecha) = " + (cbMes.SelectedIndex + 1) + " and YEAR(ueq_fecha)=" + cbAnio2.Items[cbAnio2.SelectedIndex] + " ) then UsoEquipo.est_expediente  end) AS 'Usuarios únicos' " +
 "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente");
                            mostrarExcel(acceso, "Accesos totales del mes " + cbMes.Items[cbMes.SelectedIndex] + " del " + cbAnio2.Items[cbAnio2.SelectedIndex]);

                        }
                        if (rbDia.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT("select sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " ) then 1 else 0 end) AS 'Solicitudes de usuario', " +
"( (sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
 "  COUNT (distinct case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day + " ) then UsoEquipo.est_expediente  end) AS 'Usuarios únicos' " +
 "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente");
                            mostrarExcel(acceso, "Accesos totales del día " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year);

                        }

                        if (rbLibre.Checked) {
                            DataTable acceso = con.consultaLibreDT("select sum(case when (ueq_fecha between '" + dtpFecha1.Value.Day + "-" + dtpFecha1.Value.Month + "-" + dtpFecha1.Value.Year + "' and '" + dtpFecha2.Value.Day + "-" + dtpFecha2.Value.Month + "-" + dtpFecha2.Value.Year + "') then 1 else 0 end) AS 'Solicitudes de usuario', " +
"( (sum(case when (ueq_fecha between  " + fecha + " and " + fecha2 + ") ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
 "  COUNT (distinct case when (ueq_fecha between  " + fecha + " and " + fecha2 + ") then UsoEquipo.est_expediente  end) AS 'Usuarios únicos' " +
 "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente ");
                            mostrarExcel(acceso, "Accesos totales del "+dtpFecha1.Value.Day+"-"+dtpFecha1.Value.Month+"-"+dtpFecha1.Value.Year+" al "+dtpFecha2.Value.Day+"-"+dtpFecha2.Value.Month+"-"+dtpFecha2.Value.Year);
                        }
                        if (rbHora.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT("select sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day +" and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + " ) then 1 else 0 end) AS 'Solicitudes de usuario', " +
"( (sum(case when (month(ueq_fecha) = " + dtpDia.Value.Month + "  and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day +" and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + " ) then UsoEquipo.ueq_tiempo else 0 end))/60) AS 'Horas-usuario', " +
 "  COUNT (distinct case when (month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + " and DAY(ueq_fecha)=" + dtpDia.Value.Day +" and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] + " and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + " ) then UsoEquipo.est_expediente  end) AS 'Usuarios únicos' " +
 "from UsuarioLCI FULL join UsoEquipo on UsoEquipo.est_expediente=UsuarioLCI.est_expediente");
                            mostrarExcel(acceso, "Accesos totales de " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + " " + cbHora1.Items[cbHora1.SelectedIndex] + ":00 a " + cbHora1.Items[cbHora1.SelectedIndex]+":00");

                        }

#endregion
                    }
                    break;
                    //Software
                case 1:
                    //Software instalado por sala
                    #region software instalado por sala
                     //Valida que se haya seleccionado un periodo para el reporte.
                        if (rbEnJu.Checked == false && rbJuDi.Checked == false && rbDia.Checked==false && rbMes.Checked==false && rbLibre.Checked==false && rbHora.Checked==false)
                        {
                             MessageBox.Show("Debe seleccionar un periodo");
                             return;
                        }
                        if (cbRestricciones.SelectedItem.ToString().Equals("Instalado por sala"))
                        {
                         DataTable rep = con.consultaLibreDT("SELECT sa_letra as 'Sala', ieq_numero as 'Equipo',sft_nombre as 'Software' from InvEquipo " +
                        "INNER JOIN software_equipo on InvEquipo.ieq_id = software_equipo.ieq_id " +
                        "INNER JOIN Software on software_equipo.stw_id = Software.sft_id " +
                        "INNER JOIN Sala on InvEquipo.sa_id = Sala.sa_id  WHERE sa_letra = '" + tbSala.Text + "' ");

                        mostrarExcel(rep,"");

                    }
                    #endregion
                    //Negaciones de soft
                    else if (cbRestricciones.SelectedItem.ToString().Equals("Negaciones de Software"))
                    {
                        #region negacion software
                        // tipoReporte = "SoftwareNoConforme";
                        DataTable rep = con.consultaLibreDT("SELECT sft_nom AS 'Software', nc_fecha AS 'Fecha', est_expediente as 'Expediente', est_nombre as 'Nombre' FROM noConforme");

                        mostrarExcel(rep,"");
                        #endregion

                    }
                    //Uso de soft por carrera
                    else if (cbRestricciones.SelectedItem.ToString().Equals("Uso de software"))
                    {
                        #region Uso de software
                        if (rbEnJu.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }
                            DataTable acceso = con.consultaLibreDT(@"EXECUTE Reporte_acceso_totales_EnJun " + cbAnio.Items[cbAnio.SelectedIndex]);
                            mostrarExcel(acceso, "Uso de software de Enero a Junio del " + cbAnio.Items[cbAnio.SelectedIndex]);
                        }

                        if (rbJuDi.Checked)
                        {
                            if (cbAnio.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un año.");
                                return;
                            }
                            DataTable acceso = con.consultaLibreDT(@" select  UsoEquipo.est_expediente AS Expediente, 
CONVERT(varchar(10),ueq_fecha ,111) AS Fecha,  
CONVERT(VARCHAR,ueq_fecha,108) AS Hora  ,
est_nombre AS Nombre, 
Software.sft_nombre AS Software

from UsuarioLCI inner join UsoEquipo ON UsuarioLCI.est_expediente= UsoEquipo.est_expediente 
inner join  Software on UsoEquipo.sfw_id= Software.sft_id 
(month(ueq_fecha) >= 07 and month(ueq_fecha) <= 12  and YEAR(ueq_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex] 
                                + " ");
                            mostrarExcel(acceso, "Accesos totales de Julio a Diciembre del " + cbAnio.Items[cbAnio.SelectedIndex]);
                        }

                        if (rbMes.Checked)
                        {

                            if (cbMes.SelectedIndex < 0 || cbAnio2.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un mes y un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT(@"
select  UsoEquipo.est_expediente AS Expediente, 
CONVERT(varchar(10),ueq_fecha ,111) AS Fecha,  
CONVERT(VARCHAR,ueq_fecha,108) AS Hora  ,
est_nombre AS Nombre, 
Software.sft_nombre AS Software

from UsuarioLCI inner join UsoEquipo ON UsuarioLCI.est_expediente= UsoEquipo.est_expediente 
inner join  Software on UsoEquipo.sfw_id= Software.sft_id 
where month(ueq_fecha) = " + (cbMes.SelectedIndex + 1) + " and YEAR(ueq_fecha)=" + cbAnio2.Items[cbAnio2.SelectedIndex]       + @" 
 
union

select AlumnoEspecial.ales_id AS Expediente ,
CONVERT(varchar(10),ueq_fecha ,111) AS Fecha,  
CONVERT(VARCHAR,ueq_fecha,108) AS Hora  ,
 
 AlumnoEspecial.ales_ape_pat+' '+ AlumnoEspecial.ales_ape_mat+' '+ ales_nombre AS Nombre ,
 Software.sft_nombre AS Software
 from AlumnoEspecial inner join UsoEquipo ON AlumnoEspecial.ales_id= UsoEquipo.est_expediente 
inner join  Software on UsoEquipo.sfw_id= Software.sft_id            
where month(ueq_fecha) = " + (cbMes.SelectedIndex + 1) + " and YEAR(ueq_fecha)=" + cbAnio2.Items[cbAnio2.SelectedIndex]                                 );


                            mostrarExcel(acceso, "Uso de software del mes " + cbMes.Items[cbMes.SelectedIndex] + " del " + cbAnio2.Items[cbAnio2.SelectedIndex]);

                        }
                        if (rbDia.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT(@"
select  UsoEquipo.est_expediente AS Expediente, 
CONVERT(varchar(10),ueq_fecha ,111) AS Fecha,  
CONVERT(VARCHAR,ueq_fecha,108) AS Hora  ,
est_nombre AS Nombre, 
Software.sft_nombre AS Software

from UsuarioLCI inner join UsoEquipo ON UsuarioLCI.est_expediente= UsoEquipo.est_expediente 
inner join  Software on UsoEquipo.sfw_id= Software.sft_id 
where month(ueq_fecha) = " + dtpDia.Value.Month + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + "and DAY(ueq_fecha)=" + dtpDia.Value.Day + @" 
 
union

select AlumnoEspecial.ales_id AS Expediente ,
CONVERT(varchar(10),ueq_fecha ,111) AS Fecha,  
CONVERT(VARCHAR,ueq_fecha,108) AS Hora  ,
 
 AlumnoEspecial.ales_ape_pat+' '+ AlumnoEspecial.ales_ape_mat+' '+ ales_nombre AS Nombre ,
 Software.sft_nombre AS Software
 from AlumnoEspecial inner join UsoEquipo ON AlumnoEspecial.ales_id= UsoEquipo.ales_id 
inner join  Software on UsoEquipo.sfw_id= Software.sft_id            
where month(ueq_fecha) = " + dtpDia.Value.Month 
                           + " and YEAR(ueq_fecha)=" + dtpDia.Value.Year + "and DAY(ueq_fecha)=" + dtpDia.Value.Day);
                            mostrarExcel(acceso, "Uso del software del día " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year);

                        }

                        if (rbLibre.Checked)
                        {
                             DataTable acceso = con.consultaLibreDT(@"
select  UsoEquipo.est_expediente AS Expediente, 
CONVERT(varchar(10),ueq_fecha ,111) AS Fecha,  
CONVERT(VARCHAR,ueq_fecha,108) AS Hora  ,
est_nombre AS Nombre, 
Software.sft_nombre AS Software

from UsuarioLCI inner join UsoEquipo ON UsuarioLCI.est_expediente= UsoEquipo.est_expediente 
inner join  Software on UsoEquipo.sfw_id= Software.sft_id 
where ueq_fecha between  " + fecha + " and " + fecha2 + @"  
union

select AlumnoEspecial.ales_id AS Expediente ,
CONVERT(varchar(10),ueq_fecha ,111) AS Fecha,  
CONVERT(VARCHAR,ueq_fecha,108) AS Hora  ,
 
 AlumnoEspecial.ales_ape_pat+' '+ AlumnoEspecial.ales_ape_mat+' '+ ales_nombre AS Nombre ,
 Software.sft_nombre AS Software
 from AlumnoEspecial inner join UsoEquipo ON AlumnoEspecial.ales_id= UsoEquipo.ales_id 
inner Join  Software on UsoEquipo.sfw_id= Software.sft_id            
where ueq_fecha between  " + fecha + " and " + fecha2);
                            mostrarExcel(acceso, "Uso del software del " + dtpFecha1.Value.Day + "-" + dtpFecha1.Value.Month + "-" + dtpFecha1.Value.Year + " al " + dtpFecha2.Value.Day + "-" + dtpFecha2.Value.Month + "-" + dtpFecha2.Value.Year);
                        }
                        if (rbHora.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT(@"
select  UsoEquipo.est_expediente AS Expediente, 
CONVERT(varchar(10),ueq_fecha ,111) AS Fecha,  
CONVERT(VARCHAR,ueq_fecha,108) AS Hora  ,
est_nombre AS Nombre, 
Software.sft_nombre AS Software

from UsuarioLCI  join UsoEquipo ON UsuarioLCI.est_expediente= UsoEquipo.est_expediente 
FULL join  Software on UsoEquipo.sfw_id= Software.sft_id 
where month(ueq_fecha) = " + dtpFecha3.Value.Month + " and YEAR(ueq_fecha)=" + dtpFecha3.Value.Year + "and DAY(ueq_fecha)=" + dtpFecha3.Value.Year
                         + "and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] 
                         + "and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex] + @" 
 
union

select AlumnoEspecial.ales_id AS Expediente ,
CONVERT(varchar(10),ueq_fecha ,111) AS Fecha,  
CONVERT(VARCHAR,ueq_fecha,108) AS Hora  ,
 
 AlumnoEspecial.ales_ape_pat+' '+ AlumnoEspecial.ales_ape_mat+' '+ ales_nombre AS Nombre ,
 Software.sft_nombre AS Software
 from AlumnoEspecial inner join UsoEquipo ON AlumnoEspecial.ales_id= UsoEquipo.ales_id 
FULL join  Software on UsoEquipo.sfw_id= Software.sft_id            
where month(ueq_fecha) = " + dtpFecha3.Value.Month + " and YEAR(ueq_fecha)=" + dtpFecha3.Value.Year + "and DAY(ueq_fecha)=" + dtpFecha3.Value.Year
                         + "and DATEPART(hh,ueq_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex] 
                         + "and DATEPART(hh,ueq_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex]);
                            mostrarExcel(acceso, "Accesos totales de" + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + " " + cbHora1.Items[cbHora1.SelectedIndex] + "0:00 a " + cbHora1.Items[cbHora1.SelectedIndex] + ":00");

                        }
                      
                        #endregion
                    }
                    
                    break;
                    //Equipos
                case 2:
                    if (rbEnJu.Checked == false && rbJuDi.Checked == false && rbDia.Checked == false && rbMes.Checked == false && rbLibre.Checked == false && rbHora.Checked == false)
                    {
                        MessageBox.Show("Debe seleccionar un periodo");
                        return;
                    }
                    if (cbRestricciones.SelectedItem.ToString().Equals("Equipos en mantenimiento")) //Equipos en mantenimiento
                    {
                        #region equipos en mantenimiento
                        if (rbEnJu.Checked && rbSala.Checked == false && rbMaquina.Checked == false)
                        {
                            DataTable rep = con.consultaLibreDT("SELECT sa_letra as 'columna1',ieq_numero as 'columna2',ieq_tipo AS 'columna3', " +
                            "ieq_contraloria AS 'columna4',mnt_fecha AS 'columna5',mnt_justificacion AS 'columna6' " +
                            "FROM mntoeq INNER JOIN InvEquipo ON mntoeq.ieq_id = InvEquipo.ieq_id " +
                            "INNER JOIN Sala ON InvEquipo.sa_id = Sala.sa_id WHERE mnt_fecha BETWEEN '" + cbAnio.Items[cbAnio.SelectedIndex] + "-01-01 00:00:00.000' " +
                            "AND '" + cbAnio.Items[cbAnio.SelectedIndex] + "-06-30 00:00:00.000' ORDER BY mnt_fecha DESC");
                            mostrarExcel(rep,"");
                         
                        }
                        else if (rbJuDi.Checked && rbSala.Checked == false && rbMaquina.Checked == false)
                        {
                            DataTable rep = con.consultaLibreDT("SELECT sa_letra as 'columna1',ieq_numero as 'columna2',ieq_tipo AS 'columna3', " +
                            "ieq_contraloria AS 'columna4',mnt_fecha AS 'columna5',mnt_justificacion AS 'columna6' " +
                            "FROM mntoeq INNER JOIN InvEquipo ON mntoeq.ieq_id = InvEquipo.ieq_id " +
                            "INNER JOIN Sala ON InvEquipo.sa_id = Sala.sa_id WHERE mnt_fecha BETWEEN '" + cbAnio.Items[cbAnio.SelectedIndex] + "-07-01 00:00:00.000' " +
                            "AND '" + cbAnio.Items[cbAnio.SelectedIndex] + "-12-31 00:00:00.000' ORDER BY mnt_fecha DESC");
                            mostrarExcel(rep,"");
                   
                        }
                        /*Modificacion de RAMON*/
                        if (rbSala.Checked && rbEnJu.Checked)
                        {
                            DataTable rep = con.consultaLibreDT("SELECT sa_letra as 'columna1',ieq_numero as 'columna2',ieq_tipo AS 'columna3',ieq_contraloria AS 'columna4',mnt_fecha AS 'columna5',mnt_justificacion AS 'columna6' " +
                            "FROM mntoeq INNER JOIN InvEquipo ON mntoeq.ieq_id = InvEquipo.ieq_id " +
                            "INNER JOIN Sala ON InvEquipo.sa_id = Sala.sa_id WHERE sa_letra = '" + tbSala.Text + "' AND " +
                            "mnt_fecha BETWEEN '" + cbAnio.Items[cbAnio.SelectedIndex] + "-01-01 00:00:00.000' " +
                            "AND '" + cbAnio.Items[cbAnio.SelectedIndex] + "-06-30 00:00:00.000' ORDER BY mnt_fecha DESC");
                            mostrarExcel(rep,"");
                      
                        }
                        else if (rbSala.Checked && rbJuDi.Checked)
                        {
                            DataTable rep = con.consultaLibreDT("SELECT sa_letra as 'columna1',ieq_numero as 'columna2',ieq_tipo AS " +
                            "'columna3',ieq_contraloria AS 'columna4',mnt_fecha AS 'columna5',mnt_justificacion AS 'columna6' " +
                            "FROM mntoeq INNER JOIN InvEquipo ON mntoeq.ieq_id = InvEquipo.ieq_id " +
                            "INNER JOIN Sala ON InvEquipo.sa_id = Sala.sa_id WHERE sa_letra = '" + tbSala.Text + "' AND " +
                            "mnt_fecha BETWEEN '" + cbAnio.Items[cbAnio.SelectedIndex] + "-07-01 00:00:00.000' " +
                            "AND '" + cbAnio.Items[cbAnio.SelectedIndex] + "-12-31 00:00:00.000' ORDER BY mnt_fecha DESC");
                            mostrarExcel(rep,"");
                         
                        }
                        else if (rbMaquina.Checked && rbEnJu.Checked)
                        {
                            DataTable rep = con.consultaLibreDT("SELECT sa_letra as 'columna1',ieq_numero as 'columna2',ieq_tipo AS 'columna3', " +
                            "ieq_contraloria AS 'columna4',mnt_fecha AS 'columna5',mnt_justificacion AS 'columna6' " +
                            "FROM mntoeq INNER JOIN InvEquipo ON mntoeq.ieq_id = InvEquipo.ieq_id " +
                            "INNER JOIN Sala ON InvEquipo.sa_id = Sala.sa_id WHERE sa_letra + CONVERT(varchar(1),ieq_numero) = '" + tbsala2.Text + tbeq2.Text + "' " +
                            "AND mnt_fecha BETWEEN '" + cbAnio.Items[cbAnio.SelectedIndex] + "-01-01 00:00:00.000' " +
                            "AND '" + cbAnio.Items[cbAnio.SelectedIndex] + "-06-30 00:00:00.000' ORDER BY mnt_fecha DESC");
                            mostrarExcel(rep,"");
                          
                        }
                        else if (rbMaquina.Checked && rbJuDi.Checked)
                        {
                            DataTable rep = con.consultaLibreDT("SELECT sa_letra as 'columna1',ieq_numero as 'columna2',ieq_tipo AS 'columna3', " +
                            "ieq_contraloria AS 'columna4',mnt_fecha AS 'columna5',mnt_justificacion AS 'columna6' " +
                            "FROM mntoeq INNER JOIN InvEquipo ON mntoeq.ieq_id = InvEquipo.ieq_id " +
                            "INNER JOIN Sala ON InvEquipo.sa_id = Sala.sa_id WHERE sa_letra + CONVERT(varchar(1),ieq_numero) = '" + tbsala2.Text + tbeq2.Text + "' " +
                            "AND mnt_fecha BETWEEN '" + cbAnio.Items[cbAnio.SelectedIndex] + "-07-01 00:00:00.000' " +
                            "AND '" + cbAnio.Items[cbAnio.SelectedIndex] + "-12-31 00:00:00.000' ORDER BY mnt_fecha DESC");
                            mostrarExcel(rep,"");

                        }
                        #endregion
                    }
                    else if (cbRestricciones.SelectedItem.ToString().Equals("Equipos totales por sala")) //Equipos totales por sala
                    {
                        #region equipos totales por sala
                        DataTable equip = con.consultaLibreDT("select Sala.sa_letra as 'Sala', COUNT(Sala.sa_letra) as 'Total' from InvEquipo inner join Sala on InvEquipo.sa_id=Sala.sa_id group by Sala.sa_letra");
                        mostrarExcel(equip,"");
                        #endregion
                    }
                    break;
                case 3:
                    if (rbEnJu.Checked == false && rbJuDi.Checked == false && rbDia.Checked == false && rbMes.Checked == false && rbLibre.Checked == false && rbHora.Checked == false)
                    {
                        MessageBox.Show("Debe seleccionar un periodo");
                        return;
                    }

                    //Reporte mensual de enero-junio
                    if (rbEnJu.Checked)
                    {

                        if (cbAnio.SelectedIndex < 0)
                        {
                            MessageBox.Show("Debe seleccionar un año.");
                            return;
                        }

                        DataTable acceso = con.consultaLibreDT(@"Select 
 convert(varchar, des_fecha, 105) as Fecha
 ,convert(varchar, des_fecha, 8) as Hora
 ,est_expediente as Expediente
 ,est_nombre As Nombre
 ,des_motivo As Motivo
 ,des_detalles AS Detalles
 ,ieq_numero As Equipo
 ,Sala.sa_letra AS Sala
 from desasignaciones inner join Sala on desasignaciones.ieq_sala=Sala.sa_id       
where month(des_fecha)>=01 and month(des_fecha)<=06 and YEAR(des_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex]);
                        //Enviar el resultado de la consulta a Excel.
                        mostrarExcel(totales(acceso), "Desasignaciones de Enero a Junio del " + cbAnio.Items[cbAnio.SelectedIndex]);

                    }

                    //Reporte mensual de julio-diciembre
                    if (rbJuDi.Checked)
                    {

                        if (cbAnio.SelectedIndex < 0)
                        {
                            MessageBox.Show("Debe seleccionar un año.");
                            return;
                        }
                        DataTable acceso = con.consultaLibreDT(@"Select 
 convert(varchar, des_fecha, 105) as Fecha
 ,convert(varchar, des_fecha, 8) as Hora
 ,est_expediente as Expediente
 ,est_nombre As Nombre
 ,des_motivo As Motivo
 ,des_detalles AS Detalles
 ,ieq_numero As Equipo
 ,Sala.sa_letra AS Sala
 from desasignaciones inner join Sala on desasignaciones.ieq_sala=Sala.sa_id       
where month(des_fecha)>=07 and month(des_fecha)<=12 and YEAR(des_fecha)=" + cbAnio.Items[cbAnio.SelectedIndex]);
                        mostrarExcel(totales(acceso), "Desasignaciones de Julio a Diciembre del " + cbAnio.Items[cbAnio.SelectedIndex]);

                    }
                        if (rbMes.Checked)
                        {

                            if (cbMes.SelectedIndex < 0 || cbAnio2.SelectedIndex < 0)
                            {
                                MessageBox.Show("Debe seleccionar un mes y un año.");
                                return;
                            }

                            DataTable acceso = con.consultaLibreDT(@"Select 
 convert(varchar, des_fecha, 105) as Fecha
 ,convert(varchar, des_fecha, 8) as Hora
 ,est_expediente as Expediente
 ,est_nombre As Nombre
 ,des_motivo As Motivo
 ,des_detalles AS Detalles
 ,ieq_numero As Equipo
 ,Sala.sa_letra AS Sala
 from desasignaciones inner join Sala on desasignaciones.ieq_sala=Sala.sa_id       
where month(des_fecha) = " + (cbMes.SelectedIndex + 1) + " and YEAR(des_fecha)=" + cbAnio2.Items[cbAnio2.SelectedIndex]);


                            mostrarExcel(acceso, "Desasignaciones del mes " + cbMes.Items[cbMes.SelectedIndex] + " del " + cbAnio2.Items[cbAnio2.SelectedIndex]);

                        }
                        if (rbDia.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT(@"Select 
 convert(varchar, des_fecha, 105) as Fecha
 ,convert(varchar, des_fecha, 8) as Hora
 ,est_expediente as Expediente
 ,est_nombre As Nombre
 ,des_motivo As Motivo
 ,des_detalles AS Detalles
 ,ieq_numero As Equipo
 ,Sala.sa_letra AS Sala
 from desasignaciones inner join Sala on desasignaciones.ieq_sala=Sala.sa_id           
where month(des_fecha) = " + dtpDia.Value.Month
                           + " and YEAR(des_fecha)=" + dtpDia.Value.Year + "and DAY(des_fecha)=" + dtpDia.Value.Day);
                            mostrarExcel(acceso, "Desasignaciones del día " + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year);

                        }

                        if (rbLibre.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT(@"   Select 
 convert(varchar, des_fecha, 105) as Fecha
 ,convert(varchar, des_fecha, 8) as Hora
 ,est_expediente as Expediente
 ,est_nombre As Nombre
 ,des_motivo As Motivo
 ,des_detalles AS Detalles
 ,ieq_numero As Equipo
 ,Sala.sa_letra AS Sala
 from desasignaciones inner join Sala on desasignaciones.ieq_sala=Sala.sa_id         
where des_fecha between  " + fecha + " and " + fecha2);
                            mostrarExcel(acceso, "Desasignaciones del " + dtpFecha1.Value.Day + "-" + dtpFecha1.Value.Month + "-" + dtpFecha1.Value.Year + " al " + dtpFecha2.Value.Day + "-" + dtpFecha2.Value.Month + "-" + dtpFecha2.Value.Year);
                        }
                        if (rbHora.Checked)
                        {
                            DataTable acceso = con.consultaLibreDT(@" Select 
 convert(varchar, des_fecha, 105) as Fecha
 ,convert(varchar, des_fecha, 8) as Hora
 ,est_expediente as Expediente
 ,est_nombre As Nombre
 ,des_motivo As Motivo
 ,des_detalles AS Detalles
 ,ieq_numero As Equipo
 ,Sala.sa_letra AS Sala
 from desasignaciones inner join Sala on desasignaciones.ieq_sala=Sala.sa_id          
where month(des_fecha) = " + dtpFecha3.Value.Month + " and YEAR(des_fecha)=" + dtpFecha3.Value.Year + "and DAY(des_fecha)=" + dtpFecha3.Value.Year
                         + "and DATEPART(hh,des_fecha)<=" + cbHora1.Items[cbHora1.SelectedIndex]
                         + "and DATEPART(hh,des_fecha)>=" + cbHora2.Items[cbHora2.SelectedIndex]);
                            mostrarExcel(acceso, "Desasignaciones del" + dtpDia.Value.Day + "-" + dtpDia.Value.Month + "-" + dtpDia.Value.Year + " " + cbHora1.Items[cbHora1.SelectedIndex] + ":00 a " + cbHora1.Items[cbHora1.SelectedIndex] + ":00");

                        }
                      
                    break;

            }
        }

    

        private void rbSala_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSala.Checked == true) {
                tbsala2.Enabled = false;
                tbeq2.Enabled = false;
                tbSala.Enabled=true;
            }
        }

        private void rbMaquina_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaquina.Checked == true) {
                tbsala2.Enabled = true;
                tbeq2.Enabled = true;
                tbSala.Enabled = false;
            }
        }

        private void cbRestricciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRestricciones.Items[cbRestricciones.SelectedIndex].ToString()=="Equipos en mantenimiento")
                gbFiltrar.Visible = true;

            else if (cbRestricciones.Items[cbRestricciones.SelectedIndex].ToString() == "Instalado por sala")
                gbFiltrar.Visible = true;

            else
                gbFiltrar.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbSala_TextChanged(object sender, EventArgs e)
        {
            tbSala.Text = validar(tbSala.Text);
            tbSala.Select(tbSala.Text.Length, 0);
        }

        private void tbsala2_TextChanged(object sender, EventArgs e)
        {
            tbsala2.Text = validar(tbsala2.Text);
            tbsala2.Select(tbsala2.Text.Length, 0);
        }

        private void tbeq2_TextChanged(object sender, EventArgs e)
        {
            tbeq2.Text = validar(tbeq2.Text);
            tbeq2.Select(tbeq2.Text.Length, 0);
        }

        private void rbMes_CheckedChanged(object sender, EventArgs e)
        {
            dtpDia.Enabled = false;
            cbAnio.Enabled = false;
            if (rbMes.Checked)
            {
                cbMes.Enabled = true;
                cbAnio2.Enabled = true;
            }
            else
            {
                cbMes.Enabled = true;
                cbAnio2.Enabled = false;
            }
        }

        private void rbDia_CheckedChanged(object sender, EventArgs e)
        {
            cbMes.Enabled = false;
            cbAnio.Enabled = false;
            if (rbDia.Checked)
            {
                dtpDia.Enabled = true;
            }
            else {
                dtpDia.Enabled = true;
            }
        }

        private void rbEnJu_CheckedChanged(object sender, EventArgs e)
        {
            cbAnio.Enabled = true;
            dtpDia.Enabled = false;
            cbMes.Enabled = false;

        }

        private void rbJuDi_CheckedChanged(object sender, EventArgs e)
        {
            cbAnio.Enabled = true;
            dtpDia.Enabled = false;
            cbMes.Enabled = false;
        }

        private void rbLibre_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rbLibre.Checked)
            {
                dtpFecha1.Enabled = true;
                dtpFecha2.Enabled = true;
            }
            else
            {
                dtpFecha1.Enabled = false;
                dtpFecha2.Enabled = false;
            }
        }

        private void cbHora1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbHora_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHora.Checked)
            {
                dtpFecha3.Enabled = true;
                cbHora1.Enabled = true;
                cbHora2.Enabled = true;

            }
            else
            {
                dtpFecha3.Enabled = false;
                cbHora1.Enabled = false;
                cbHora2.Enabled = false;
            }
        }
    }
}
