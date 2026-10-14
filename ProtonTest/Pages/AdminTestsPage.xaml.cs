using Microsoft.EntityFrameworkCore;
using ProtonTest.Models;
using ProtonTest.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using static System.Net.Mime.MediaTypeNames;

namespace ProtonTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminTestsPage.xaml
    /// </summary>
    public partial class AdminTestsPage : Page
    {
        public AdminTestsPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (ApplicationContext context = new())
            {
                AdminDepartmentCombo.ItemsSource = context.Departments.ToList();
                if (AdminDepartmentCombo.Items.Count > 0)
                    AdminDepartmentCombo.SelectedIndex = 0;

                TestsListBox.ItemsSource = context.Tests.Include(t => t.Department).Include(t => t.Questions).ToList();
            }
        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            if (AdminDepartmentCombo.SelectedValue == null || string.IsNullOrWhiteSpace(TestTitleBox.Text))
            {
                MessageBox.Show("Заполните название теста и выберите департамент.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int deptId = (int)AdminDepartmentCombo.SelectedValue;
            Test newTest = new(deptId, TestTitleBox.Text, TestDescBox.Text);

            using (ApplicationContext context = new())
            {
                context.Tests.Add(newTest);
                context.SaveChanges();

                NavigationService?.Navigate(new TestBuilderPage(newTest));
            }
        }

        private void OpenBuilder_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Test test)
            {
                NavigationService?.Navigate(new TestBuilderPage(test));
            }
        }

        private void DeleteTest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Test test)
            {
                if (MessageBox.Show($"Удалить тест \"{test.Title}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    using (ApplicationContext context = new())
                    {
                        var t = context.Tests.Find(test.Id);
                        if (t != null)
                        {
                            context.Tests.Remove(t);
                            context.SaveChanges();
                        }
                    }
                    LoadData();
                }
            }
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            TestTitleBox.Clear();
            TestDescBox.Clear();
            if (AdminDepartmentCombo.Items.Count > 0) AdminDepartmentCombo.SelectedIndex = 0;
        }
    }
}