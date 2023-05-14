using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using System;
using System.Net;
using System.Text;
using System.Net.Security;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    
    public partial class Form1 : Form
    {   
        //private StreamReader reader;
        private StreamWriter writer;
        private string message;
        private string D="F";

        public Form1()
        {
            InitializeComponent();
            MyMethod();
            MyMethod2();
            

        }

        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (writer = new StreamWriter("ServerIPset.txt"))
            {
                textBox3.Text = textBox2.Text;
                writer.WriteLine(textBox2.Text);
            }
            using (writer = new StreamWriter("ServerPortset.txt"))
            {
                textBox6.Text = textBox5.Text;
                writer.WriteLine(textBox5.Text);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            
           if (File.Exists("ServerIPset.txt"))
           {
           string text = File.ReadAllText("ServerIPset.txt");
           textBox3.Text = text;
           }

           if (File.Exists("ServerPortset.txt"))
           {
                string text = File.ReadAllText("ServerPortset.txt");
                textBox6.Text = text;
           }
            if (File.Exists("ClientIPset.txt"))
            {
                string text = File.ReadAllText("ClientIPset.txt");
                textBox11.Text = text;
            }

            if (File.Exists("ClientPortset.txt"))
            {
                string text = File.ReadAllText("ClientPortset.txt");
                textBox8.Text = text;
            }
            if (File.Exists("WiFiAccountset.txt"))
            {
                string text = File.ReadAllText("ClientIPset.txt");
                textBox16.Text = text;
            }

            if (File.Exists("WiFiAccountset.txt"))
            {
                string text = File.ReadAllText("ClientPortset.txt");
                textBox18.Text = text;
            }
            listView1.Columns.Add("Time1", 30000);

            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            comboBox1.Enabled = false;
            amount.Enabled = false;
            Compilation.Enabled = false;
            Dname.Enabled = false;
            comboBox1.Items.Add(new ComboBoxItem("0", "存入卡片"));
            comboBox1.Items.Add(new ComboBoxItem("1", "存手機條碼"));
            comboBox1.Items.Add(new ComboBoxItem("2", "列印發票"));
            comboBox1.Items.Add(new ComboBoxItem("3", "免開發票-列印收據"));
            comboBox1.Items.Add(new ComboBoxItem("4", "免開發票-不印收據"));
            comboBox1.Items.Add(new ComboBoxItem("5", "手開發票(不用電子發票)"));
            comboBox1.SelectedIndexChanged += (sender, e) => { label1.Text = comboBox1.SelectedIndex.ToString(); };
        }
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }
            public ComboBoxItem(string value, string text)
            {
                Value = value;
                Text = text;
            }
            public override string ToString()
            {
                return Text;
            }
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (writer = new StreamWriter("ClientIPset.txt"))
            {
                textBox11.Text = textBox12.Text;
                writer.WriteLine(textBox12.Text);
            }
            using (writer = new StreamWriter("ClientPortset.txt"))
            {
                textBox8.Text = textBox9.Text;
                writer.WriteLine(textBox9.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (writer = new StreamWriter("WiFiAccountset.txt"))
            {
                textBox16.Text = textBox15.Text;
                writer.WriteLine(textBox15.Text);
            }
            using (writer = new StreamWriter("WiFiPasswordset.txt"))
            {
                textBox18.Text = textBox17.Text;
                writer.WriteLine(textBox17.Text);
            }
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // 取得當前時間
         //   string currentTime = DateTime.Now.ToString("HH:mm:ss");

            // 新增 ListViewItem，並將當前時間加入到 ListView 中
         //   ListViewItem lvi = new ListViewItem(currentTime);
        //    listView1.Items.Add(lvi);
        }
        private async Task MyMethod()
        {

            if (File.Exists("ClientIPset.txt"))
            {
                string text = File.ReadAllText("ClientIPset.txt");
                textBox11.Text = text;
            }

            if (File.Exists("ClientPortset.txt"))
            {
                string text = File.ReadAllText("ClientPortset.txt");
                textBox8.Text = text;
            }
            var IP = textBox11.Text.Trim();
            var Port = textBox8.Text.Trim();
            var listener = new TcpListener(IPAddress.Parse(IP), int.Parse(Port));
            listener.Start();
            listView1.Items.Add("Waiting for connection...");

            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                var clientAddress = client.Client.RemoteEndPoint.ToString();
                listView1.Items.Add("Client 連線成功 " + DateTime.Now.ToString());
                try
                {
                    using (var stream = client.GetStream())
                    using (var reader = new StreamReader(stream))
                    {
                        while (true)
                        {

                            byte[] buffer = new byte[10024];
                            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                            message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                            D = "T";
                            listView1.Invoke((MethodInvoker)(() =>
                            {
                                listView1.Items.Add(message + DateTime.Now.ToString());
                            }));
                        }
                    }
                }
                catch (IOException)
                {
                    listView1.Items.Add("Client 斷開連線 " + DateTime.Now.ToString());

                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
        private async Task MyMethod2()
        {
            if (File.Exists("ServerIPset.txt"))
            {
                string text = File.ReadAllText("ServerIPset.txt");
                textBox3.Text = text;
            }

            if (File.Exists("ServerPortset.txt"))
            {
                string text = File.ReadAllText("ServerPortset.txt");
                textBox6.Text = text;
            }
            var IP = textBox3.Text.Trim(); ;
            var PORT = textBox6.Text.Trim(); ;
            
            

            while (true)
            {
                try
                {
                    TcpClient client = new TcpClient();
                    await client.ConnectAsync(IP, int.Parse(PORT));
                    NetworkStream stream = client.GetStream();
                    SslStream sslStream = new SslStream(stream, false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                    await sslStream.AuthenticateAsClientAsync(IP);
                    listView1.Items.Add("Server連線成功" + DateTime.Now.ToString());
                    try
                    {
                        using (var stream2 = client.GetStream())
                        using (var reader = new StreamReader(stream2))
                        {
                             while (true)
                            {
                                if (D == "T")
                                {
                                    var buffer = Encoding.UTF8.GetBytes(message + Environment.NewLine);
                                    await sslStream.WriteAsync(buffer, 0, buffer.Length);
                                    D = "F"; 
                                }
                                else
                                {
                                    await Task.Delay(100); // 等待 D 變成 T
                                }

                            }

                        }
                    }
                    catch (IOException)
                    {
                        listView1.Items.Add("Server連線中斷" + DateTime.Now.ToString());

                    }
                     
                }
                catch (Exception ex)
                {
                    listView1.Items.Add($"Server錯誤 : {ex.Message}" + DateTime.Now.ToString());
                    
                }
            }

        }
        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        public void SendMessage(object message, string IP, int PORT)
        {

            TcpClient client = new TcpClient(IP, PORT);

            SslStream sslStream = new SslStream(client.GetStream(), false, ValidateServerCertificate);

            sslStream.AuthenticateAsClient(IP);

            string jsonMessage = JsonConvert.SerializeObject(message);

            byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage);

            sslStream.Write(buffer, 0, buffer.Length);
            sslStream.Flush();

            var responseBuffer = new byte[1024];
            int bytesRead = sslStream.Read(responseBuffer, 0, responseBuffer.Length);

            string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
            Console.WriteLine(response);
            
            sslStream.Close();
            client.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //////Setting  IP、PORT固定寫死/////
            string IP = "192.168.4.1";
            int PORT = int.Parse("11999");
            //textBox15.Text感應器設定
            var message = new
            {
                cmd = "SettingSSID",
                cmd_seq = DateTime.Now.ToString(),
                ssid = textBox15.Text,
                password = textBox17.Text
            };
            SendMessage(message, IP, PORT);
            listView1.Items.Add("Setting成功" + DateTime.Now.ToString());
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //////SignOn/////
            string IP = textBox3.Text.Trim();
            int PORT = int.Parse(textBox6.Text.Trim());
            ////reader_no卡機號碼固定寫死、account_id、token  POST出來的固定寫死
            var message = new
            {
                cmd="SignOn",
                cmd_seq= DateTime.Now.ToString(),
                reader_no="TV1Q0319",
                account_id=251,
                account_name="winsnet",
                tax_type="TX",
                token="eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhcHBfYWNjb3VudF9pZCI6MjUxLCJhcHBfYWNjb3VudCI6IndpbnNuZXQiLCJzZWNyZXQiOiIxdzlmMndleG0zbiIsImV4cCI6MTY4NDQyNjA2NDczMX0.FsNPE0wtkEHdnmf9IX0QdlLm5QAG1twPKsblLHdpNSo"
                };
            SendMessage(message, IP, PORT);
            listView1.Items.Add("SignOn成功" + DateTime.Now.ToString());
            button6.Enabled = false ; // 設定按鈕唯讀
            button7.Enabled = true;
            button8.Enabled = true;
     //     button9.Enabled = true;          
            comboBox1.Enabled = true;
            amount.Enabled = true;
            Compilation.Enabled = true;
            Dname.Enabled = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /////Sign Out//////
            string IP = textBox3.Text.Trim();
            int PORT = int.Parse(textBox6.Text.Trim());
            var message = new
            {
                cmd = "SignOut",
                cmd_seq = DateTime.Now.ToString(),
                reader_no = "TV1Q0319",
                account_id = 251
            };
            SendMessage(message, IP, PORT);
            listView1.Items.Add("Sign Out成功" + DateTime.Now.ToString());
            button6.Enabled = true; // 設定按鈕唯讀
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            comboBox1.Enabled = false;
            amount.Enabled = false;
            Compilation.Enabled = false;
            Dname.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /////Balance//////
            string IP = textBox3.Text.Trim();
            int PORT = int.Parse(textBox6.Text.Trim());
            var message = new
            {
                cmd = "Balance",
                cmd_seq = DateTime.Now.ToString(),
                reader_no = "TV1Q0319",
                account_id = 251
            };
            SendMessage(message, IP, PORT);
            listView1.Items.Add("Balance成功" + DateTime.Now.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ////Deduct////mobile_barcode不知道要寫啥
            string IP = textBox3.Text.Trim();
            int PORT = int.Parse(textBox6.Text.Trim());
            var message = new
            {
                cmd = "Deduct",
                cmd_seq = DateTime.Now.ToString(),
                account_id = 251,
                reader_no = "TV1Q0319",
                deduct= amount.Text,
                invoice_method= label1.Text,
                mobile_barcode="",
                buyer_tax_id= Compilation.Text,
                buyer_name=Dname.Text
            };
            SendMessage(message, IP, PORT);
            listView1.Items.Add("Deduct成功" + DateTime.Now.ToString());

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                button9.Enabled = true;
            
        }
    }
}