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
    //Validado
    public partial class Form1 : Form
    {
        string IP_SERVER = "127.0.0.1";
        int puerto = 31416;
        string msg;
        IPEndPoint ie;
        Socket server;
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;

        public Form1()
        {
            InitializeComponent();
        }

        private void Click_Boton(object sender, EventArgs e)
        {
            ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), Convert.ToInt32(puerto));
            server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ie);
                ns = new NetworkStream(server);
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);
                try
                {
                    sw.WriteLine(((Button)sender).Tag);
                    sw.Flush();
                    //Recibimos el mensaje del servidor
                    msg = sr.ReadLine();
                    lblResult.Text = msg;
                    sr.Close();
                    sw.Close();
                    ns.Close();
                    //Indicamos fin de transmisión.
                    server.Close();
                }
                catch (IOException)
                {
                    lblResult.Text = "No hay conexion con el servidor";
                }
            }
            catch (SocketException ee)
            {
                lblResult.Text = String.Format("Error connection: {0}\nError code: {1}({2})", ee.Message, (SocketError)ee.ErrorCode, ee.ErrorCode);
            }
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            try
            {
                IP_SERVER = txtIP.Text;
                IPAddress.Parse(IP_SERVER);
                puerto = Convert.ToInt32(txtPuerto.Text);
                if (puerto<0||puerto > 65535)
                {
                    throw new Exception();
                }
            }
            catch
            {
                IP_SERVER = "127.0.0.1";
                puerto = 31416;
                txtIP.Text = IP_SERVER;
                txtPuerto.Text = puerto + "";
                lblResult.Text = "Error en IP o Puerto, se usará el predefinido";
            }
        }
    }
}
