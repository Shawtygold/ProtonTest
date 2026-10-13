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
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isCorrect && isCorrect) return "[Правильный]";
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

    public partial class AdminTestsPage : Page
    {
        private Test? _selectedTest = null;
        private Question? _selectedQuestion = null;

        public AdminTestsPage()
        {
            InitializeComponent();
            LoadDepartmentsAndTests();
        }

        private void LoadDepartmentsAndTests()
        {
            using (ApplicationContext context = new())
            {
                AdminDepartmentCombo.ItemsSource = context.Departments.ToList();
                if (AdminDepartmentCombo.Items.Count > 0)
                    AdminDepartmentCombo.SelectedIndex = 0;

                TestsListBox.ItemsSource = context.Tests.Include(t => t.Department).ToList();
            }
        }

        // --- УПРАВЛЕНИЕ ТЕСТАМИ ---

        private void TestsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TestsListBox.SelectedItem is Test test)
            {
                _selectedTest = test;
                TestTitleBox.Text = test.Title;
                TestDescBox.Text = test.Description;
                AdminDepartmentCombo.SelectedValue = test.DepartmentId;
                TestFormTitle.Text = $"Редактировать тест (ID: {test.Id})";

                LoadQuestionsForTest(test.Id);
                QuestionsSection.IsEnabled = true;
                QuestionsSection.Opacity = 1.0;
            }
        }

        private void LoadQuestionsForTest(int testId)
        {
            try
            {
                using (ApplicationContext context = new())
                {
                    QuestionsListBox.ItemsSource = context.Questions.Where(q => q.TestId == testId).ToList();
                    QuestionsListBox.SelectedItem = null;
                    OptionsListBox.ItemsSource = null;
                    _selectedQuestion = null;
                    QuestionTextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void SaveTest_Click(object sender, RoutedEventArgs e)
        {
            if (AdminDepartmentCombo.SelectedValue == null || string.IsNullOrWhiteSpace(TestTitleBox.Text))
            {
                MessageBox.Show("Заполните название теста и выберите департамент.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int deptId = (int)AdminDepartmentCombo.SelectedValue;
            string title = TestTitleBox.Text;
            string desc = TestDescBox.Text;

            using (ApplicationContext context = new())
            {
                if (_selectedTest == null)
                {
                    Test newTest = new(deptId, title, desc);
                    context.Tests.Add(newTest);
                }
                else
                {
                    var testInDb = context.Tests.Find(_selectedTest.Id);
                    if (testInDb != null)
                    {
                        testInDb.DepartmentId = deptId;
                        testInDb.Title = title;
                        testInDb.Description = desc;
                    }
                }
                context.SaveChanges();
            }

            ClearTestForm();
            LoadDepartmentsAndTests();
            MessageBox.Show("Тест успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteTest_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTest == null) return;

            if (MessageBox.Show($"Удалить тест \"{_selectedTest.Title}\" со всеми вопросами?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (ApplicationContext context = new())
                {
                    var testInDb = context.Tests.Find(_selectedTest.Id);
                    if (testInDb != null)
                    {
                        context.Tests.Remove(testInDb);
                        context.SaveChanges();
                    }
                }
                ClearTestForm();
                LoadDepartmentsAndTests();
            }
        }

        private void ClearTestForm_Click(object sender, RoutedEventArgs e) => ClearTestForm();

        private void ClearTestForm()
        {
            _selectedTest = null;
            _selectedQuestion = null;
            TestTitleBox.Clear();
            TestDescBox.Clear();
            TestFormTitle.Text = "Добавить новый тест";
            TestsListBox.SelectedItem = null;
            QuestionsSection.IsEnabled = false;
            QuestionsSection.Opacity = 0.5;
            QuestionsListBox.ItemsSource = null;
            OptionsListBox.ItemsSource = null;
        }

        // --- УПРАВЛЕНИЕ ВОПРОСАМИ ---

        private void QuestionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuestionsListBox.SelectedItem is Question q)
            {
                _selectedQuestion = q;
                QuestionTextBox.Text = q.QuestionText;
                LoadOptionsForQuestion(q.Id);
            }
        }

        private void LoadOptionsForQuestion(int questionId)
        {
            using (ApplicationContext context = new())
            {
                OptionsListBox.ItemsSource = context.Options.Where(o => o.QuestionId == questionId).ToList();
            }
        }

        private void NewQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTest == null) return;

            using (ApplicationContext context = new())
            {
                Question newQ = new(_selectedTest.Id, "Новый вопрос");
                context.Questions.Add(newQ);
                context.SaveChanges();

                LoadQuestionsForTest(_selectedTest.Id);
                QuestionsListBox.SelectedItem = QuestionsListBox.Items[^1];
            }
        }

        private void SaveQuestionText_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuestion == null || string.IsNullOrWhiteSpace(QuestionTextBox.Text)) return;

            using (ApplicationContext context = new())
            {
                var qInDb = context.Questions.Find(_selectedQuestion.Id);
                if (qInDb != null)
                {
                    qInDb.QuestionText = QuestionTextBox.Text;
                    context.SaveChanges();
                }
            }
            LoadQuestionsForTest(_selectedTest.Id);
            MessageBox.Show("Текст вопроса сохранен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuestion == null) return;

            using (ApplicationContext context = new())
            {
                var qInDb = context.Questions.Find(_selectedQuestion.Id);
                if (qInDb != null)
                {
                    context.Questions.Remove(qInDb);
                    context.SaveChanges();
                }
            }
            LoadQuestionsForTest(_selectedTest.Id);
        }

        // --- УПРАВЛЕНИЕ ВАРИАНТАМИ ОТВЕТОВ ---

        private void AddOption_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuestion == null || string.IsNullOrWhiteSpace(NewOptionTextBox.Text))
            {
                MessageBox.Show("Выберите вопрос и введите текст варианта ответа.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool isCorrect = IsCorrectCheckBox.IsChecked ?? false;

            using (ApplicationContext context = new())
            {
                if (isCorrect)
                {
                    var existingOptions = context.Options.Where(o => o.QuestionId == _selectedQuestion.Id).ToList();
                    foreach (var opt in existingOptions)
                    {
                        opt.IsCorrect = false;
                    }
                }

                Option newOpt = new(_selectedQuestion.Id, NewOptionTextBox.Text, isCorrect);
                context.Options.Add(newOpt);
                context.SaveChanges();
            }

            NewOptionTextBox.Clear();
            IsCorrectCheckBox.IsChecked = false;
            LoadOptionsForQuestion(_selectedQuestion.Id);
        }

        private void DeleteOption_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Option option)
            {
                using (ApplicationContext context = new())
                {
                    var optInDb = context.Options.Find(option.Id);
                    if (optInDb != null)
                    {
                        context.Options.Remove(optInDb);
                        context.SaveChanges();
                    }
                }
                if (_selectedQuestion != null)
                {
                    LoadOptionsForQuestion(_selectedQuestion.Id);
                }
            }
        }

        private void BackToggleBtn_Click(object sender, RoutedEventArgs e)
        {


            NavigationService?.Navigate(new DashboardPage());
        }
    }
}
