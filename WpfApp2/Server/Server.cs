using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Controls;

namespace Server;

public class Server
{
    private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private Socket clientSocket; // only one client
    private IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

    public void Start()
    {
        var endPoint = new IPEndPoint(ipAddress, 3003);

        try
        {
            serverSocket.Bind(endPoint);
            serverSocket.Listen(1);
            Console.WriteLine("Server started. Waiting for client...");

            clientSocket = serverSocket.Accept();
            Console.WriteLine("Client connected.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Server error: " + ex.Message);
        }
    }

    public void Run(TextBox chatBox)
    {
        Task.Run(() =>
        {
            var buffer = new byte[1024];
            while (clientSocket != null && clientSocket.Connected)
            {
                try
                {
                    int bytesRead = clientSocket.Receive(buffer);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    chatBox.Dispatcher.Invoke(() =>
                    {
                        chatBox.AppendText("Client: " + message + "\n");
                    });

                    if (message.ToLower() == "quit")
                    {
                        clientSocket.Shutdown(SocketShutdown.Both);
                        clientSocket.Close();
                        break;
                    }
                }
                catch
                {
                    break;
                }
            }
        });
    }

    public void SendToClient(string message, TextBox chatBox)
    {
        if (clientSocket == null || !clientSocket.Connected) return;

        byte[] msgBytes = Encoding.UTF8.GetBytes(message);
        clientSocket.Send(msgBytes);

        chatBox.Dispatcher.Invoke(() =>
        {
            chatBox.AppendText("Server: " + message + "\n");
        });

        if (message.ToLower() == "quit")
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
}
