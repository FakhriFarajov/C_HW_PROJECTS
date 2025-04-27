// Server.cs
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Lesson5;

public class Server
{
    private TcpListener _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 3003);
    private TcpClient _client;
    private NetworkStream _stream;
    private StreamReader _reader;
    private StreamWriter _writer;

    public async Task StartAsync()
    {
        _listener.Start();
        _client = await _listener.AcceptTcpClientAsync();
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
                    chatBox.AppendText("Client: " + message + "\n");
                });
            }
        }
        catch
        {
            chatBox.Dispatcher.Invoke(() =>
            {
                chatBox.AppendText(" Client disconnected or an error occurred.\n");
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
                chatBox.AppendText(" Failed to send message. Connection may be closed.\n");
            });
        }
    }

    public void Stop()
    {
        _writer?.Close();
        _reader?.Close();
        _stream?.Close();
        _client?.Close();
        _listener?.Stop();
    }
}