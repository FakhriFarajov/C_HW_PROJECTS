using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson5;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{ 
    public Server server = new Server();

    public MainWindow()
    {
        InitializeComponent();
        _ = server.StartAsync();
        _ = server.StartReceivingAsync(ChatBox);
    }
    
    private async void SendButton_Click(object sender, RoutedEventArgs e)
    {
        string msg = MessageBox.Text;
        if (!string.IsNullOrWhiteSpace(msg))
        {
            await server.SendMessageAsync(ChatBox, msg);
            MessageBox.Clear();
        }
    }
}