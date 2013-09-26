using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace AdmLCI
{
    public partial class locker_info : Form
    {
        Conexion abrir = new Conexion();
        String Exp;
        String fec ;
        String fec2;
        String sem_1;
        String inicio;
        String []year; 
        public locker_info(String exp,String fecha,String ini,String sem)
        {
            Exp = exp;

            year = fecha.Split('/');
            
            sem_1 = sem;
           inicio=ini;
            InitializeComponent();

            cargar();

        }



  void cargar() {

    
      DataTable fechas = abrir.consultaLibreDT("Select * FROM HistorialLocker WHERE est_expediente=" + Exp + "and hl_año=" + year[2] + " and lok_no=" + inicio +" and hl_semestre="+sem_1 );
      if (!(fechas.Rows.Count == 0))
      {
          fec = fechas.Rows[0]["hl_inicio"].ToString();
          fec2 = fechas.Rows[0]["hl_fin"].ToString();
          textBox1.Text = fechas.Rows[0]["hl_nombre"].ToString();
          textBox2.Text = fechas.Rows[0]["hl_carrera"].ToString();
          textBox3.Text = DateTime.Parse(fec.ToString()).ToString("dd/MM/yyyy");
          textBox4.Text = DateTime.Parse(fec2.ToString()).ToString("dd/MM/yyyy");
          textBox5.Text = Exp;
          textBox6.Text = fechas.Rows[0]["lok_no"].ToString();
          textBox7.Text = fechas.Rows[0]["Hl_semestre"].ToString();
      }
  }

  private void button1_Click(object sender, EventArgs e)
  {

      EscribirenunDocumentoWord();
  }
  public void EscribirenunDocumentoWord()
  {
      //Objeto del Tipo Word Application
      Word.Application objWordApplication;
      //Objeto del Tipo Word Document
      Word.Document objWordDocument;
      // Objeto para interactuar con el Interop
      Object oMissing = System.Reflection.Missing.Value;
      //Creamos una instancia de una Aplicación Word.
      objWordApplication = new Word.Application();
      //A la aplicación Word, le añadimos un documento.
      objWordDocument = objWordApplication.Documents.Add(ref oMissing,
                                                       ref oMissing,
                                                       ref oMissing, ref oMissing);
      //Activamos el documento recien creado, de forma que podamos escribir en el
      objWordDocument.Activate();
      //Encabezado
      objWordApplication.Selection.Font.Name = "Arial"; //Cambiamos el nombre
      objWordApplication.Selection.Font.Size = 16; //Cambiamos el tamaño
      objWordApplication.Selection.ParagraphFormat.Alignment =

      Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

      objWordApplication.Selection.TypeText("UNIVERSIDAD DE SONORA\n");
      objWordApplication.Selection.Font.Size = 11;
      objWordApplication.Selection.TypeText("DIRECCIÓN DE SERVICIOS UNIVERSITARIOS\n");
      objWordApplication.Selection.Font.Size = 14;
      objWordApplication.Selection.TypeText("LABORATORIO CENTRAL DE INFORMATICA\n");
      //Indicamos que el texto anterior es parte de un párrafo.
      objWordApplication.Selection.TypeParagraph();
      //Ahora veamos como cambiar el tipo y tamaño de la letra
      objWordApplication.Selection.Font.Size = 12;
      objWordApplication.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
      objWordApplication.Selection.TypeText("POLITICAS QUE ACEPTA EL USUARIO AL CONTRATAR EL SERVICIO DE ARRENDAMIENTO DE CASILLEROS\nEl Laboratorio Central de Informática le ofrece a usted arrendamiento de casilleros y se regirá bajo las siguientes reglas o condiciones:\n");
      objWordApplication.Selection.TypeText("a) El Laboratorio Central de Informática asignará uno de los 84 casilleros que se encuentren disponibles.\nb) El usuario se compromete a darle un buen uso al casillero asignado.\nc) El uso del casillero por parte del usuario es responsabilidad del mismo.\nd) El casillero será asignado por un tiempo determinado indicado al final de estas condiciones.\ne) Independientemente de la fecha de solicitud, el costo por asignación del casillero, así como la fecha de  vencimiento serán los mismos.\nf) El usuario es responsable de traer el candado para mantener el casillero cerrado, así como de retirarlo a la fecha de vencimiento.\ng) El Laboratorio Central de Informática se reserva el derecho de retirar candados y objetos dentro de los casilleros  cuando estos objetos afecten la limpieza y el ambiente del Laboratorio Central de Informática, llámense comida u otros artículos perecederos, sin tener responsabilidad para rembolsar el importe de candados destruidos, ni por los objetos contenidos.\nh) El Laboratorio Central de Informática dará un plazo máximo de 5 días hábiles después del vencimiento para que el  usuario retire el candado y objetos contenidos en el casillero, de lo contrario procederá a retirarlos sin previo aviso.\ni) El Laboratorio Central de Informática se reserva el derecho de retirar objetos y candados de los casilleros si se incumple con alguna(s) de las condiciones mencionadas, sin tener que rembolsar el importe pagado.\nj) Los casilleros estarán disponibles durante el período de arrendamiento en un horario de 7:00 a 20:00 horas de Lunes a Viernes y de 9:00 a 13:00 horas los días Sábado de acuerdo al calendario escolar.");

      objWordApplication.Selection.TypeText("\nNombre del alumno: " + textBox1.Text + "\nExpediente del alumno: " + textBox5.Text + "\nCasillero No.: " + textBox6.Text + "\n" + "Fecha de Inicio: " + textBox3.Text + "\nFecha de Término: " + textBox4.Text);

      objWordApplication.Selection.ParagraphFormat.Alignment =
     Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
      objWordApplication.Selection.TypeText("\n____________________________________________\nFIRMA DE ACEPTACION");
      //Indicamos que el texto anterior es un párrafo

      objWordApplication.Selection.TypeParagraph();

      //Hace visible la Aplicacion para que veas lo que se ha escrito

      objWordApplication.Visible = true;



  }
       
     

        }

      
    }

