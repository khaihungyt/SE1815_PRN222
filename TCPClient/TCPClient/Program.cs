using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        // Địa chỉ IP và cổng của server
        string serverIp = "127.0.0.1";
        int port = 12345;

        // Tạo một TCP/IP socket
        TcpClient client = new TcpClient(serverIp, port);
        Console.WriteLine("Connected to server!");

        // Gửi dữ liệu đến server
        NetworkStream stream = client.GetStream();
        string message = "Hello from client!";
        byte[] dataToSend = Encoding.ASCII.GetBytes(message);
        stream.Write(dataToSend, 0, dataToSend.Length);
        Console.WriteLine("Sent: " + message);

        // Nhận phản hồi từ server
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string responseReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Received: " + responseReceived);

        // Đóng kết nối
        client.Close();
    }
}