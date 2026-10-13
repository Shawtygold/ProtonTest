using ProtonTest.Models;
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
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();

            //TestRepository.FillDatabase();
            if (UserSession.CurrentUser.Role != null)
            {
                if (UserSession.CurrentUser.Role.Name == Constants.ADMIN_ROLE_NAME)
                    CategoriesControl.ItemsSource = TestRepository.GetAllTests();
                else if(UserSession.CurrentUser.Role.Name == Constants.EMPLOYEE_ROLE_NAME)
                    CategoriesControl.ItemsSource = TestRepository.GetTestsForDepartment(UserSession.CurrentUser.DepartmentId);
            }
        }

        private void StartTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Test test)
            {
                using (ApplicationContext context = new())
                {
                    var questionCount = context.Questions.Where(q => q.TestId == test.Id).Count();
                    if (questionCount == 0)
                    {
                        MessageBox.Show("Тест еще не содержит вопросов. Попробуйте позже");
                        return;
                    }
                }

                NavigationService?.Navigate(new TestProcessPage(test));
            }
        }
    }
}
