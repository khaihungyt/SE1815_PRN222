using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        // Địa chỉ IP và cổng mà server sẽ lắng nghe
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 12345;

        // Tạo một TCP/IP socket
        TcpListener listener = new TcpListener(ipAddress, port);

        // Bắt đầu lắng nghe kết nối từ client
        listener.Start();
        Console.WriteLine("Server is listening on port " + port);

        while (true)
        {
            // Chấp nhận kết nối từ client
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected!");

            // Nhận dữ liệu từ client
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received: " + dataReceived);

            // Gửi phản hồi lại cho client
            string response = "Hello from server!";
            byte[] responseData = Encoding.ASCII.GetBytes(response);
            stream.Write(responseData, 0, responseData.Length);
            Console.WriteLine("Sent: " + response);

            // Đóng kết nối
            client.Close();
        }
    }
}