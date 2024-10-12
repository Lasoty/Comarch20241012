using System.Windows;
using Bibliotekarz.App.ViewModels;

namespace Bibliotekarz.App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void btnButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world!");
        }
    }
}