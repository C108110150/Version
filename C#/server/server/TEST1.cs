
using Newtonsoft.Json;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace server
{
     class TEST1
    {
        public int A;
        public string B;
        public string C;
        public void sayhi()
        {
            Console.WriteLine(B);
        }
        public void SendMessage(object message , string IP, int PORT )
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
            Console.WriteLine("連線成功");
        
        sslStream.Close();
            client.Close();

        }
        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }
}
