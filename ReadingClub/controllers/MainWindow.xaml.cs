using ReadingClub.Controllers;
using System.Windows;

namespace ReadingClub.Controllers
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new SignIn());
        }
    }
}
