// ClientServer.cs
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Client;

public class ClientServer
{
    private TcpClient _client;
    private NetworkStream _stream;
    private StreamReader _reader;
    private StreamWriter _writer;

    public async Task ConnectAsync()
    {
        _client = new TcpClient();
        await _client.ConnectAsync("127.0.0.1", 3003);
        _stream = _client.GetStream();
        _reader = new StreamReader(_stream, Encoding.UTF8);
        _writer = new StreamWriter(_stream, Encoding.UTF8) { AutoFlush = true };
    }

    public async Task StartReceivingAsync(TextBox chatBox)
    {
        try
        {
            while (true)
            {
                var message = await _reader.ReadLineAsync();
                if (message == null) break;

                chatBox.Dispatcher.Invoke(() =>
                {
                    chatBox.AppendText("Server: " + message + "\n");
                });
            }
        }
        catch
        {
            chatBox.Dispatcher.Invoke(() =>
            {
                chatBox.AppendText(" Server disconnected or an error occurred.\n");
            });
        }
    }

    public async Task SendMessageAsync(TextBox chatBox, string message)
    {
        try
        {
            await _writer.WriteLineAsync(message);
        }
        catch
        {
            chatBox.Dispatcher.Invoke(() =>
            {
                chatBox.AppendText(" Failed to send message.\n");
            });
        }
    }

    public void Disconnect()
    {
        _writer?.Close();
        _reader?.Close();
        _stream?.Close();
        _client?.Close();
    }
}