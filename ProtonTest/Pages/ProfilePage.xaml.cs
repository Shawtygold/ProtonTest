using ProtonTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProtonTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            if (UserSession.CurrentUser != null)
            {
                UserNameText.Text = UserSession.CurrentUser.FullName;
                UserLoginText.Text = $"Табельный номер / Логин: {UserSession.CurrentUser.Username}";
                ResultsDataGrid.ItemsSource = UserSession.CurrentUser.Results;
            }
        }

        private void BackToCatalog_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DashboardPage());
        }
    }
}
