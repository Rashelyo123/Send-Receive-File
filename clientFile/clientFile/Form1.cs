using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace clientFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            tbFilename.Text = openFileDialog.FileName;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = tbFilename.Text;
                string fileName = Path.GetFileName(filePath); 
                byte[] fileBuffer = File.ReadAllBytes(filePath);

                TcpClient clientSocket = new TcpClient(tbServer.Text, 8080);
                NetworkStream networkStream = clientSocket.GetStream();
                BinaryWriter writer = new BinaryWriter(networkStream);

                
                writer.Write(fileName);
               
                writer.Write(fileBuffer.Length);
               
                writer.Write(fileBuffer);

                writer.Close();
                clientSocket.Close();

                MessageBox.Show(" File berhasil dikirim!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }
        }
    }
}
