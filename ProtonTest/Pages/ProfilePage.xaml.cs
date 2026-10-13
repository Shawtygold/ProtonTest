using Microsoft.EntityFrameworkCore;
using ProtonTest.Services;
using ProtonTest.Views;
using System.Windows;
using System.Windows.Controls;

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

                using (ApplicationContext context = new())
                {
                    ResultsDataGrid.ItemsSource = context.TestResults.Include(t => t.Test).Where(t => t.UserId == UserSession.CurrentUser.Id).ToList().Select(tr => new TestResultView(tr.Test.Title, tr.TotalQuestions, tr.CorrectAnswers, tr.DatePassed.ToString("dd.MM.yyyy HH:mm")));
                }
            }
        }

        private void BackToCatalog_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DashboardPage());
        }
    }
}
