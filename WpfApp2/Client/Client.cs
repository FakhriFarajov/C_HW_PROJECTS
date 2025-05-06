using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Controls;

namespace WpfApp2;

public class ClientService
{
    private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    private IPAddress address;
    private byte[] buffer = new byte[1024];

    public ClientService(string address = "127.0.0.1")
    {
        this.address = IPAddress.Parse(address);
    }

    public void Connect()
    {
        try
        {
            var endPoint = new IPEndPoint(address, 3003);
            clientSocket.Connect(endPoint);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Connection failed: " + ex.Message);
        }
    }

    public void SendMessage(string message, TextBox chatBox)
    {
        if (string.IsNullOrWhiteSpace(message)) return;

        byte[] data = Encoding.UTF8.GetBytes(message);
        clientSocket.Send(data);

        chatBox.Dispatcher.Invoke(() => { chatBox.AppendText($"Client: {message}\n"); });

        ReceiveMessage(chatBox);
    }


    
    
    public void ReceiveMessage(TextBox ChatBox)
    {
        Task.Run(() =>
        {
            try
            {
                var buffer = new byte[1024];
                while (clientSocket != null && clientSocket.Connected)
                {
                    int bytesRead = clientSocket.Receive(buffer);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    ChatBox.Dispatcher.Invoke(() => { ChatBox.AppendText("ServerSolution: " + message + "\n"); });

                    if (message.ToLower() == "quit")
                    {
                        clientSocket.Shutdown(SocketShutdown.Both);
                        clientSocket.Close();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ChatBox.Dispatcher.Invoke(() => { ChatBox.AppendText("Disconnected.\n"); });
            }
        });
    }
}