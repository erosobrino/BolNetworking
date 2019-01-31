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
        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 31416);
            //Creacion del Socket
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Enlace de socket al puerto (y en cualquier interfaz de red)
            //Salta excepción si el puerto está ocupado
            s.Bind(ie);
            //Esperando una conexión y estableciendo cola de clientes pendientes
            s.Listen(10);
            //Esperamos y aceptamos la conexion del cliente (socket bloqueante)
            Socket sClient = s.Accept();
            //Obtenemos la info del cliente
            //El casting es necesario ya que RemoteEndPoint es del tipo EndPoint
            //mas genérico
            IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
            Console.WriteLine("Client connected:{0} at port {1}", ieClient.Address, ieClient.Port);
            //Creación del Stream de Red
            NetworkStream ns = new NetworkStream(sClient);
            //StreamReader y StreamWriter aceptan un Stream
            //como parámetro en el constructor
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            string msg;
            string msgReturn = "";
            bool stop = false;
            while (!stop)
            {
                try
                {
                    //Leemos el mensaje del cliente
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
                                break;
                            default:
                                msgReturn = "Utiliza uno de estos comandos HORA (hora, minutos y segundos)), FECHA(día, mes y año), TODO(hora y fecha), APAGAR(El servidor se cierra";
                                break;
                        }
                    }
                    Console.WriteLine(msg != null ? msg : "Client disconnected");
                    //Mandamos nuevamente el mensaje al cliente
                    sw.WriteLine(msgReturn);
                    sw.Flush();
                }
                // Si se cierra el cliente, salta excepción
                // Al siguiente readline
                catch (IOException e)
                {
                    break;
                }
            }
            Console.WriteLine("Connection closed");
            //El código del protocolo debe ir antes de esta línea
            //Siempre cerramos los Streams y sockets
            sw.Close();
            sr.Close();
            ns.Close();
            sClient.Close();
            s.Close();
        }
    }
}
