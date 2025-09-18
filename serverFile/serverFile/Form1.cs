using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serverFile
{
    public partial class Form1 : Form
    {
        private ArrayList alSockets;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            IPHostEntry IPHost = Dns.GetHostByName(Dns.GetHostName());
            LBStatus.Text = "My IP address is " + IPHost.AddressList[0].ToString();

            alSockets = new ArrayList();

           
            Thread thdListener = new Thread(new ThreadStart(listenerThread));
            thdListener.Start();
        }

        public void listenerThread()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 8080);
            tcpListener.Start();

            while (true)
            {
                Socket handlerSocket = tcpListener.AcceptSocket();
                if (handlerSocket.Connected)
                {
                    lbConnection.Invoke((MethodInvoker)delegate {
                        lbConnection.Items.Add(handlerSocket.RemoteEndPoint.ToString() + " connected.");
                    });

                    lock (this)
                    {
                        alSockets.Add(handlerSocket);
                    }

                    Thread thdHandler = new Thread(new ThreadStart(handlerThread));
                    thdHandler.Start();
                }
            }
        }

        public void handlerThread()
        {
            Socket handlerSocket = (Socket)alSockets[alSockets.Count - 1];
            NetworkStream networkStream = new NetworkStream(handlerSocket);
            BinaryReader reader = new BinaryReader(networkStream);

           
            string fileName = reader.ReadString();
           
            int fileSize = reader.ReadInt32();
            
            byte[] fileBuffer = reader.ReadBytes(fileSize);

          
            string savePath = Path.Combine("C:\\Users\\Public\\", fileName);
            File.WriteAllBytes(savePath, fileBuffer);

            lbConnection.Invoke((MethodInvoker)delegate {
                lbConnection.Items.Add(" File " + fileName + " berhasil diterima dan disimpan di " + savePath);
            });

            handlerSocket = null;
        }

    }
}
