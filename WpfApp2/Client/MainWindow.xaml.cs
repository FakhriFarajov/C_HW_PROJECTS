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

namespace WpfApp2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ClientService clientService { get; } = new ClientService();
    
    public MainWindow()
    {
        InitializeComponent();
        clientService.Connect();
    }
    
    private void SendButton_Click(object sender, RoutedEventArgs e)
    {
        string message = MessageBox.Text;
        clientService.SendMessage(message, ChatBox);
        MessageBox.Clear();
    }
    
}