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
    class Client
    {
        static void Main(string[] args)
        {
            const string IP_SERVER = "127.0.0.1";
            const int puerto = 31416;
            string msg;
            string userMsg;
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), puerto);
            Console.WriteLine("Starting client. Press a key to init connection");
            Console.ReadKey();
            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ie);
                NetworkStream ns = new NetworkStream(server);
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                // Leemos mensaje de bienvenida ya que es lo primero que envía el servidor
                try
                {
                    msg = sr.ReadLine();
                    Console.WriteLine(msg);
                    while (true)
                    {
                        // Lo siguiente es pedir un mensaje al usuario
                        userMsg = Console.ReadLine();
                        // Establecemos como "comando" de protocolo
                        // la palabra "exit". Si se escribe, se finaliza.
                        if (userMsg.ToLower() == "exit")
                            break;
                        //Enviamos el mensaje de usuario al servidor
                        // que que el servidor está esperando que le envíen algo
                        sw.WriteLine(userMsg);
                        sw.Flush();
                        //Recibimos el mensaje del servidor
                        msg = sr.ReadLine();
                        Console.WriteLine(msg);
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("Conection lost.");
                }
                Console.WriteLine("Ending connection");
                sr.Close();
                sw.Close();
                ns.Close();
                //Indicamos fin de transmisión.
                server.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("Error connection: {0}\nError code: {1}({2})",
                e.Message, (SocketError)e.ErrorCode, e.ErrorCode);
                Console.ReadKey();
                return;
            }
            Console.ReadKey();
        }
    }
}
