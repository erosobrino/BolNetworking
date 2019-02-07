using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BolNetworking
{
    class Server
    {
        //Validado
        static void Main(string[] args)
        {
            string msg;
            string msgReturn = "";
            bool stop = false;
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 135);
            IPEndPoint ieBackUp = new IPEndPoint(IPAddress.Any, 31416);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket sClient;
            try
            {
                s.Bind(ie);
            }
            catch (SocketException)
            {
                try
                {
                    s.Bind(ieBackUp);
                    s.Listen(10);
                    while (!stop)
                    {
                        sClient = s.Accept();
                        IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
                        Console.WriteLine("Client connected:{0} at port {1}", ieClient.Address, ieClient.Port);
                        NetworkStream ns = new NetworkStream(sClient);
                        StreamReader sr = new StreamReader(ns);
                        StreamWriter sw = new StreamWriter(ns);
                        try
                        {
                            msg = sr.ReadLine();
                            if (msg != null)
                            {
                                switch (msg.ToUpper())
                                {
                                    case "HORA":
                                        msgReturn = DateTime.Now.ToString("hh:mm:ss");
                                        break;
                                    case "FECHA":
                                        msgReturn = DateTime.Now.ToString("dd/MM/yyyy");
                                        break;
                                    case "TODO":
                                        msgReturn = DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("dd/MM/yyyy");
                                        break;
                                    case "APAGAR":
                                        stop = true;
                                        msgReturn = "Apagado Correctamente";
                                        break;
                                    default:
                                        msgReturn = "Utiliza uno de estos comandos HORA (hora, minutos y segundos)), FECHA(día, mes y año), TODO(hora y fecha), APAGAR(El servidor se cierra";
                                        break;
                                }
                            }
                            Console.WriteLine(msg != null ? msg : "Client disconnected");
                            sw.WriteLine(msgReturn);
                            sw.Flush();
                            sw.Close();
                            sr.Close();
                            ns.Close();
                            sClient.Close();
                        }
                        catch (IOException)
                        {
                            break;
                        }
                    }
                }
                catch (SocketException) { }
                s.Close();
            }
        }
    }
}
