using ProtonTest.Services;
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

namespace ProtonTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.LoginPage());
        }

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ToggleTheme();
        }

        public void UpdateHeaderState()
        {
            bool isLoggedIn = UserSession.CurrentUser != null;
            ProfileNavBtn.Visibility = isLoggedIn ? Visibility.Visible : Visibility.Collapsed;
            LogoutBtn.Visibility = isLoggedIn ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ProfileNav_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ProfilePage());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            UserSession.CurrentUser = null;
            UpdateHeaderState();
            MainFrame.Navigate(new Pages.LoginPage());
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            UpdateHeaderState();
        }
    }
}