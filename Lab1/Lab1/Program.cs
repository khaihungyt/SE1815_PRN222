using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class ServerApp
{
    static void Main(string[] args)
    {
        // Define the port number for the server to listen on
        const int port = 8080;

        // Create a TcpListener to listen for incoming client connections
        TcpListener listener = new TcpListener(IPAddress.Any, port);

        try
        {
            // Start the server
            listener.Start();
            Console.WriteLine($"Server started. Listening on port {port}...");

            // Infinite loop to handle multiple client connections
            while (true)
            {
                // Accept a new client connection
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine($"Connection established with {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

                // Get the network stream to communicate with the client
                NetworkStream stream = client.GetStream();

                // Create a buffer to store incoming data
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                // Convert the received byte array to a string
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received: {receivedMessage}");

                // Process the message: convert it to uppercase
                string response = receivedMessage.ToUpper();

                // Send the processed message back to the client
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);
                Console.WriteLine($"Sent: {response}");

                // Close the client connection
                client.Close();
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions and print error messages
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            // Ensure the server is stopped when exiting
            listener.Stop();
            Console.WriteLine("Server stopped.");
        }
    }
}
