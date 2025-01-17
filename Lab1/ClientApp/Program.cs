using System;
using System.Net.Sockets;
using System.Text;

class ClientApp
{
    static void Main(string[] args)
    {
        // Define the server address and port number to connect to
        const string server = "127.0.0.1"; // Localhost
        const int port = 8080;

        try
        {
            while (true)
            {
                // Create a TcpClient to connect to the server
                TcpClient client = new TcpClient();
                Console.WriteLine($"Connecting to server at {server}:{port}...");

                // Connect to the server
                client.Connect(server, port);
                Console.WriteLine("Connected to server.");

                // Get the network stream to communicate with the server
                NetworkStream stream = client.GetStream();
                // Prompt the user to enter a message to send
                Console.Write("Enter a message to send: ");
                string message = Console.ReadLine();

                // Convert the message to a byte array and send it to the server
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Message sent.");

                // Create a buffer to store the server's response
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                // Convert the received byte array to a string
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Response from server: {response}");
                // Close the client connection
                client.Close();
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions and print error messages
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
