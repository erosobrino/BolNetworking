using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        string IP_SERVER;
        int puerto;
        string msg;
        IPEndPoint ie;
        Socket server;
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;
        bool conectado = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Click_Boton(object sender, EventArgs e)
        {
            if (conectado)
            {
                try
                {
                    sw.WriteLine(((Button)sender).Tag);
                    sw.Flush();
                    //Recibimos el mensaje del servidor
                    msg = sr.ReadLine();
                    lblResult.Text = msg;
                }
                catch (IOException)
                {
                    lblResult.Text = "No hay conexion con el servidor";
                }
            }
            else
            {
                lblResult.Text = "Conectate primero";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                sr.Close();
                sw.Close();
                ns.Close();
                //Indicamos fin de transmisión.
                server.Close();
            }
            catch (NullReferenceException) { }
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            try
            {
                ie = new IPEndPoint(IPAddress.Parse(txtIP.Text), Convert.ToInt32(txtPuerto.Text));
                server = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ie);
                    ns = new NetworkStream(server);
                    sr = new StreamReader(ns);
                    sw = new StreamWriter(ns);
                    Console.WriteLine("Utiliza uno de estos comandos HORA, FECHA, TODO, APAGAR");
                }
                catch (SocketException ee)
                {
                    lblResult.Text = String.Format("Error connection: {0}\nError code: {1}({2})", ee.Message, (SocketError)ee.ErrorCode, ee.ErrorCode);
                }
            }
            catch
            {
                lblResult.Text = "Error en IP o Puerto";
            }
            conectado = true;
        }
    }
}
