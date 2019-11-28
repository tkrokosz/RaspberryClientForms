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
    public partial class Stats : UserControl
    {
        public Stats()
        {
            InitializeComponent();
            
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            label14.Text = "A";
            label3.Text = "";
            label4.Text = "";
            label8.Text = "";
            label6.Text = "";
            label12.Text = "";
            label10.Text = "";
            string response = Connect("10.7.51.13", ("ee8b7660-e813-11e8-b45e-f1cc3c52f3a0" + "____" + "eaqEiOLJ6jFuxLYmFBLd" + "____" + "temperature" + "____" + "R" + "____" + "empty").ToString(), "R");

            string[] resp_after_split = response.Split('_');

            var a = resp_after_split;

            Regex regex = new Regex("value\":\"" + @"\d+\""");
            Match match = regex.Match(resp_after_split[0]);

           
            if (match.Success)
            {
                Regex regex1 = new Regex(@"\d+");
                Match match1 = regex1.Match(match.Value);
                if (match1.Success)
                {
                    label3.Text = match1.Value;
                    // label3.Text = first;
                }

            }
            else
                label3.Text = response;

            string temp_resp_sec = Connect("10.7.51.13", ("eda0d2d0-e814-11e8-b45e-f1cc3c52f3a0" + "____" + "xsLOnOFrrLC1fOuJm8zN" + "____" + "temperature" + "____" + "R" + "____" + "empty").ToString(), "R");

            string[] temp_resp_sec_after_split = temp_resp_sec.Split('_');

            Match temp_second_match = regex.Match(temp_resp_sec_after_split[0]);

            if (temp_second_match.Success)
            {
                Regex regex1 = new Regex(@"\d+");
                Match match1 = regex1.Match(temp_second_match.Value);
                if (match1.Success)
                {
                    label4.Text = match1.Value;
                }

            }
            else
                label4.Text = temp_resp_sec;


            //Window

            string response_ = Connect("10.7.51.13", ("50406f70-ed8a-11e8-beca-0bb8c0a45e52" + "____" + "Eob1SIwHlCNxHNMZHhl6" + "____" + "is_open" + "____" + "R" + "____" + "empty").ToString(), "R");

            string[] window_resp_after_split = response_.Split('_');

            Match window_match = regex.Match(window_resp_after_split[1]);

            if (window_match.Success)
            {
                Regex regex1 = new Regex(@"\d+");
                Match match1 = regex1.Match(window_match.Value);
                if (match1.Success)
                {
                    label8.Text = (match1.Value == "1" ? ("Otwarte") : (match1.Value == "0" ? ("Zamknięte") : "B"));
                }

            }
            else
                label8.Text = response_;

            string response_sec_ = Connect("10.7.51.13", ("592002e0-ed8a-11e8-beca-0bb8c0a45e52" + "____" + "4WzklLxMRMeJ9Xjc3djO" + "____" + "is_open" + "____" + "R" + "____" + "empty").ToString(), "R");

            string[] sec_window_resp_after_split = response_sec_.Split('_');

            Match sec_window_match = regex.Match(sec_window_resp_after_split[1]);

            if (sec_window_match.Success)
            {
                Regex regex1 = new Regex(@"\d+");
                Match match1 = regex1.Match(sec_window_match.Value);
                if (match1.Success)
                {
                    label6.Text = (match1.Value == "1" ? ("Otwarte") : (match1.Value == "0" ? ("Zamknięte") : "B"));
                }

            }
            else
                label6.Text = response_sec_;


            //Door

            string door_response = Connect("10.7.51.13", ("36ca5ad0-ed83-11e8-95e9-dff0cb60bee7" + "____" + "oxDpzDcpUTOY00MJ2khy" + "____" + "is_open" + "____" + "R" + "____" + "empty").ToString(), "R");

            string[] door_resp_after_split = door_response.Split('_');

            Match door_match = regex.Match(door_resp_after_split[1]);

            if (door_match.Success)
            {
                Regex regex1 = new Regex(@"\d+");
                Match match1 = regex1.Match(door_match.Value);
                if (match1.Success)
                {
                    label12.Text = (match1.Value == "1" ? ("Otwarte") : (match1.Value == "0" ? ("Zamknięte") : ""));
                }

            }
            else
                label12.Text = door_response;

            string door_response_sec = Connect("10.7.51.13", ("42b99f40-ed83-11e8-beca-0bb8c0a45e52" + "____" + "Q8Y58BN25ydNUnwA4xgC" + "____" + "is_open" + "____" + "R" + "____" + "empty").ToString(), "R");

            string[] door_resp_after_split_sec = door_response_sec.Split('_');

            Match door_match_sec = regex.Match(door_resp_after_split_sec[1]);

            if (door_match_sec.Success)
            {
                Regex regex1 = new Regex(@"\d+");
                Match match1 = regex1.Match(door_match_sec.Value);
                if (match1.Success)
                {
                    label10.Text = (match1.Value == "1" ? ("Otwarte") : (match1.Value == "0" ? ("Zamknięte") : ""));
                }

            }
            else
                label10.Text = door_response_sec;

            label14.Text = "";
        }
    }
}
