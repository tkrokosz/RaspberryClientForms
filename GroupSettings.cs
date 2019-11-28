using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace RaspberryClientForms
{
    public partial class GroupSettings : UserControl
    {
        public GroupSettings()
        {
            InitializeComponent();
            comboBox1.Items.Add("Termometry");
            comboBox1.Items.Add("Okna");
            comboBox1.Items.Add("Drzwi");
        }

        private void GroupSettings_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = "";
            label5.Text = "";
          

            if (comboBox1.Text == "Okna" || comboBox1.Text == "Drzwi")
            {
                panel2.Visible = false;
                panel1.Visible = true;
                panel1.BringToFront();
            }

            if (comboBox1.Text == "Termometry")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel2.BringToFront();
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label5.Text = "";
            if (comboBox1.Text == "Okna")
            {
                string response = Connect("10.7.51.13", ("50406f70-ed8a-11e8-beca-0bb8c0a45e52" + "____" + "Eob1SIwHlCNxHNMZHhl6" + "____" + "is_open" + "____" + "U" + "____" + "1").ToString(), "U");
                string response_sec = Connect("10.7.51.13", ("592002e0-ed8a-11e8-beca-0bb8c0a45e52" + "____" + "4WzklLxMRMeJ9Xjc3djO" + "____" + "is_open" + "____" + "U" + "____" + "1").ToString(), "U");
                label3.Text = "Dane zostały zapisane";
            }

            if (comboBox1.Text == "Drzwi")
            {
                string response = Connect("10.7.51.13", ("36ca5ad0-ed83-11e8-95e9-dff0cb60bee7" + "____" + "oxDpzDcpUTOY00MJ2khy" + "____" + "is_open" + "____" + "U" + "____" + "1").ToString(), "U");
                string response_sec = Connect("10.7.51.13", ("42b99f40-ed83-11e8-beca-0bb8c0a45e52" + "____" + "Q8Y58BN25ydNUnwA4xgC" + "____" + "is_open" + "____" + "U" + "____" + "1").ToString(), "U");
                label3.Text = "Dane zostały zapisane";
            }
        }

        static string Connect(String server, String message, string operation)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 1194;
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Wysłano: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[1024];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Otrzymano: {0}", responseData);


                // Close everything.
                stream.Close();
                client.Close();

                return responseData;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Enter - zamknij");
            Console.Read();
            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label5.Text = "";
            if (comboBox1.Text == "Okna")
            {
                string response = Connect("10.7.51.13", ("50406f70-ed8a-11e8-beca-0bb8c0a45e52" + "____" + "Eob1SIwHlCNxHNMZHhl6" + "____" + "is_open" + "____" + "U" + "____" + "0").ToString(), "U");
                string response_sec = Connect("10.7.51.13", ("592002e0-ed8a-11e8-beca-0bb8c0a45e52" + "____" + "4WzklLxMRMeJ9Xjc3djO" + "____" + "is_open" + "____" + "U" + "____" + "0").ToString(), "U");
                label3.Text = "Dane zostały zapisane";
            }

            if (comboBox1.Text == "Drzwi")
            {
                string response = Connect("10.7.51.13", ("36ca5ad0-ed83-11e8-95e9-dff0cb60bee7" + "____" + "oxDpzDcpUTOY00MJ2khy" + "____" + "is_open" + "____" + "U" + "____" + "0").ToString(), "U");
                string response_sec = Connect("10.7.51.13", ("42b99f40-ed83-11e8-beca-0bb8c0a45e52" + "____" + "Q8Y58BN25ydNUnwA4xgC" + "____" + "is_open" + "____" + "U" + "____" + "0").ToString(), "U");
                label3.Text = "Dane zostały zapisane";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string response = Connect("10.7.51.13", ("ee8b7660-e813-11e8-b45e-f1cc3c52f3a0" + "____" + "eaqEiOLJ6jFuxLYmFBLd" + "____" + "temperature" + "____" + "U" + "____" + textBox1.Text).ToString(), "U");
            string response_sec = Connect("10.7.51.13", ("eda0d2d0-e814-11e8-b45e-f1cc3c52f3a0" + "____" + "xsLOnOFrrLC1fOuJm8zN" + "____" + "temperature" + "____" + "U" + "____" + textBox1.Text).ToString(), "U");
            label5.Text = "Dane zostały zapisane";
        }
    }
}
