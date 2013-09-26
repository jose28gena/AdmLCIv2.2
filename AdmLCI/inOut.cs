using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace AdmLCI
{
    public class inOut
    {
        public static void Enviar(TcpClient cliente, String Dato)
        {
            try
            {
                NetworkStream netstream = cliente.GetStream();
                StreamWriter escribir = new StreamWriter(netstream);
                escribir.WriteLine(Dato);
                escribir.Flush();
            }
            catch (Exception) { }
        }

        public static String Recibir(TcpClient cliente)
        {
            try
            {
                NetworkStream netstream = cliente.GetStream();
                StreamReader leer = new StreamReader(netstream);
                return leer.ReadLine();
            }
            catch (Exception) { return ""; }
        }
    }
}
