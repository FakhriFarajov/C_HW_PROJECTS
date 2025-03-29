using Cars.Models;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cars.Service;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CarsService _carsService = new CarsService();
        public MainWindow()
        {
            InitializeComponent();
        }



        private async void GetWeather(object sender, RoutedEventArgs e)
        {
            try
            {
                var make = MakeEntry.Text;
                var model = ModelEntry.Text;
                var cars = await _carsService.GetVehicleDataAsync(make,model);
                var searchresult = JsonSerializer.Deserialize<Rootobject>(cars); 
                DataGrid.ItemsSource = searchresult.results;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " or there is no such city!");
            }
        }
    }
}