using ProtonTest.Services;
using System.Windows;
using System.Windows.Navigation;

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
           // TestRepository.FillDatabase();
            MainFrame.Navigate(new Pages.LoginPage());
        }

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ToggleTheme();
        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.AdminTestsPage());
        }


        public void UpdateHeaderState()
        {
            bool isLoggedIn = UserSession.CurrentUser != null;

            if (isLoggedIn)
            {
                AdminPanelBtn.Visibility = UserSession.CurrentUser.RoleId == 1 ? Visibility.Visible : Visibility.Collapsed;
            }

            ProfileNavBtn.Visibility = isLoggedIn ? Visibility.Visible : Visibility.Collapsed;
            LogoutBtn.Visibility = isLoggedIn ? Visibility.Visible : Visibility.Collapsed;
            if (!isLoggedIn)
                AdminPanelBtn.Visibility = Visibility.Collapsed;
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