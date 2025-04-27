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

namespace Client;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    ClientServer client= new ClientServer();

    public MainWindow()
    {
        InitializeComponent();
        _ = client.ConnectAsync(); //We cant place await here because when there are two of them they are continueWith
        _ = client.StartReceivingAsync(ChatBox);
    }
    
    
    
    private async void SendButton_Click(object sender, RoutedEventArgs e)
    {
        string msg = MessageBox.Text;
        if (!string.IsNullOrWhiteSpace(msg))
        {
            await client.SendMessageAsync(ChatBox, msg);
            MessageBox.Clear();
        }
    }
}