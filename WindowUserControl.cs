using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Sockets;

namespace RaspberryClientForms
{
    public partial class WindowUserControl : UserControl
    {
        public WindowUserControl()
        {
            InitializeComponent();
            comboBox1.Items.Add("Okno 1 (sala nr 1)");
            comboBox1.Items.Add("Okno 2 (sala nr 2)");
        }

        private void WindowUserControl_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Show();
            label4.Text = "";

            string device_no = "";
            string token = "";
            string type = "";
            string operation = "";

            if (comboBox1.Text == "Okno 1 (sala nr 1)")
            {
                device_no = "50406f70-ed8a-11e8-beca-0bb8c0a45e52";
                token = "Eob1SIwHlCNxHNMZHhl6";
                type = "is_open";
                operation = "R";
            }

            if (comboBox1.Text == "Okno 2 (sala nr 2)")
            {
                device_no = "592002e0-ed8a-11e8-beca-0bb8c0a45e52";
                token = "4WzklLxMRMeJ9Xjc3djO";
                type = "is_open";
                operation = "R";
            }

            string response = Connect("10.11.12.35", (device_no + "____" + token + "____" + type + "____" + operation + "____" + "empty").ToString(), "R");

            string[] resp_after_split = response.Split('_');

            var a = resp_after_split;

            Regex regex = new Regex("value\":\"" + @"\d+\""");
            Match match = regex.Match(resp_after_split[1]);

            string first = "";

            comboBox2.Items.Clear();

            if (match.Success)
            {
                Regex regex1 = new Regex(@"\d+");
                Match match1 = regex1.Match(match.Value);
                if (match1.Success)
                {
                    label4.Text = (match1.Value == "1" ? ("Otwarte") : (match1.Value == "0" ? ("Zamknięte") : ""));

                    if (match1.Value == "1")
                    {
                        comboBox2.Items.Add("Zamknij");
                        pictureBox1.Load("../../bin/Debug/img/open_window.png");
                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (match1.Value == "0")
                    {
                        comboBox2.Items.Add("Otwórz");
                        pictureBox1.Load("../../bin/Debug/img/close_window.png");
                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    if (match1.Value != "1" && match1.Value != "0")
                    {
                        comboBox2.Items.Add("Otwórz");
                        comboBox2.Items.Add("Zamknij");
                    }
                }

            }
            else
                label4.Text = response;


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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string device_no = "";
            string token = "";
            string type = "";
            string operation = "";
            if (comboBox1.Text == "Okno 1 (sala nr 1)")
            {
                device_no = "50406f70-ed8a-11e8-beca-0bb8c0a45e52";
                token = "Eob1SIwHlCNxHNMZHhl6";
                type = "is_open";
                operation = "U";
            }

            if (comboBox1.Text == "Okno 2 (sala nr 2)")
            {
                device_no = "592002e0-ed8a-11e8-beca-0bb8c0a45e52";
                token = "4WzklLxMRMeJ9Xjc3djO";
                type = "is_open";
                operation = "U";
            }

            string set_ = (comboBox2.Text == "Zamknij" ? "0" : (comboBox2.Text == "Otwórz" ? "1" : "0"));

            string response = Connect("10.11.12.35", (device_no + "____" + token + "____" + type + "____" + operation + "____" + set_).ToString(), operation);

            string response_ = Connect("10.11.12.35", (device_no + "____" + token + "____" + type + "____" + "R" + "____" + "empty").ToString(), "R");

            string[] resp_after_split = response_.Split('_');

            var a = resp_after_split;

            Regex regex = new Regex("value\":\"" + @"\d+\""");
            Match match = regex.Match(resp_after_split[1]);

            string first = "";

            comboBox2.Items.Clear();

            if (match.Success)
            {
                Regex regex1 = new Regex(@"\d+");
                Match match1 = regex1.Match(match.Value);
                if (match1.Success)
                {
                    label4.Text = (match1.Value == "1" ? ("Otwarte") : (match1.Value == "0" ? ("Zamknięte") : ""));

                    if (match1.Value == "1")
                    {
                        comboBox2.Items.Add("Zamknij");
                        pictureBox1.Load("../../bin/Debug/img/open_window.png");
                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (match1.Value == "0")
                    {
                        comboBox2.Items.Add("Otwórz");
                        pictureBox1.Load("../../bin/Debug/img/close_window.png");
                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    if (match1.Value != "1" && match1.Value != "0")
                    {
                        comboBox2.Items.Add("Otwórz");
                        comboBox2.Items.Add("Zamknij");
                    }
                }

            }
            else
                label4.Text = response_;
        }
    }
}
