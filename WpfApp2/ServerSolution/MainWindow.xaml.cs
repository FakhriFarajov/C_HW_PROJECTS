using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServerSolution;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public Server server = new Server();

    public MainWindow()
    {
        InitializeComponent();
        server.Start();
        server.Run(ChatBox);
    }


    private void SendButton_Click(object sender, RoutedEventArgs e)
    {
        string msg = MessageBox.Text;
        if (!string.IsNullOrWhiteSpace(msg))
        {
            server.SendToClient(msg, ChatBox);
            MessageBox.Clear();
        }
    }

}