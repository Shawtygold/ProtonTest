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
            CategoriesControl.ItemsSource = TestRepository.GetCategories();
        }

        private void StartTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is TestCategory category)
            {
                NavigationService?.Navigate(new TestProcessPage(category));
            }
        }
    }
}
