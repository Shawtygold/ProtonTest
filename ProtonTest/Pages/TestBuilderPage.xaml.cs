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

namespace ProtonTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestBuilderPage.xaml
    /// </summary>
    /// 

    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isCorrect && isCorrect) return "[Правильный]";
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
    public partial class TestBuilderPage : Page
    {
        private readonly Test _currentTest;
        private Question? _selectedQuestion;

        public TestBuilderPage(Test test)
        {
            InitializeComponent();
            _currentTest = test;
            TestTitleHeader.Text = $"Настройка теста: {_currentTest.Title}";
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            using (ApplicationContext context = new())
            {
                QuestionsListBox.ItemsSource = context.Questions.Where(q => q.TestId == _currentTest.Id).ToList();
                QuestionsListBox.SelectedItem = null;
                _selectedQuestion = null;
                QuestionEditorPanel.IsEnabled = false;
                QuestionEditorPanel.Opacity = 0.4;
            }
        }

        private void QuestionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuestionsListBox.SelectedItem is Question q)
            {
                _selectedQuestion = q;
                QuestionTextBox.Text = q.QuestionText;
                LoadOptions(q.Id);
                QuestionEditorPanel.IsEnabled = true;
                QuestionEditorPanel.Opacity = 1.0;
            }
        }

        private void LoadOptions(int questionId)
        {
            using (ApplicationContext context = new())
            {
                OptionsListBox.ItemsSource = context.Options.Where(o => o.QuestionId == questionId).ToList();
            }
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new())
            {
                Question newQ = new(_currentTest.Id, "Новый вопрос");
                context.Questions.Add(newQ);
                context.SaveChanges();

                LoadQuestions();
                QuestionsListBox.SelectedItem = QuestionsListBox.Items[QuestionsListBox.Items.Count - 1];
            }
        }

        private void SaveQuestionText_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuestion == null || string.IsNullOrWhiteSpace(QuestionTextBox.Text)) return;

            using (ApplicationContext context = new())
            {
                var q = context.Questions.Find(_selectedQuestion.Id);
                if (q != null)
                {
                    q.QuestionText = QuestionTextBox.Text;
                    context.SaveChanges();
                }
            }
            LoadQuestions();
            MessageBox.Show("Текст вопроса сохранен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuestion == null) return;

            using (ApplicationContext context = new())
            {
                var q = context.Questions.Find(_selectedQuestion.Id);
                if (q != null)
                {
                    context.Questions.Remove(q);
                    context.SaveChanges();
                }
            }
            LoadQuestions();
        }

        private void AddOption_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuestion == null || string.IsNullOrWhiteSpace(NewOptionTextBox.Text))
            {
                MessageBox.Show("Введите текст варианта ответа.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool isCorrect = IsCorrectCheckBox.IsChecked ?? false;

            using (ApplicationContext context = new())
            {
                if (isCorrect)
                {
                    var existing = context.Options.Where(o => o.QuestionId == _selectedQuestion.Id).ToList();
                    foreach (var opt in existing) opt.IsCorrect = false;
                }

                Option newOpt = new(_selectedQuestion.Id, NewOptionTextBox.Text, isCorrect);
                context.Options.Add(newOpt);
                context.SaveChanges();
            }

            NewOptionTextBox.Clear();
            IsCorrectCheckBox.IsChecked = false;
            LoadOptions(_selectedQuestion.Id);
        }

        private void DeleteOption_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Option option)
            {
                using (ApplicationContext context = new())
                {
                    var opt = context.Options.Find(option.Id);
                    if (opt != null)
                    {
                        context.Options.Remove(opt);
                        context.SaveChanges();
                    }
                }
                if (_selectedQuestion != null) LoadOptions(_selectedQuestion.Id);
            }
        }

        private void FinishAndSave_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new())
            {
                var questions = context.Questions.Where(q => q.TestId == _currentTest.Id).ToList();

                if (questions.Count == 0)
                {
                    MessageBox.Show("Невозможно сохранить тест: в нем нет ни одного вопроса!", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                foreach (var q in questions)
                {
                    var options = context.Options.Where(o => o.QuestionId == q.Id).ToList();

                    if (options.Count == 0)
                    {
                        MessageBox.Show($"Невозможно сохранить тест: у вопроса \"{q.QuestionText}\" отсутствуют варианты ответов!", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    bool hasCorrectOption = options.Any(o => o.IsCorrect);
                    if (!hasCorrectOption)
                    {
                        MessageBox.Show($"Невозможно сохранить тест: у вопроса \"{q.QuestionText}\" не отмечен правильный вариант ответа!", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }

            MessageBox.Show("Тест полностью укомплектован, проверен и успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService?.Navigate(new AdminTestsPage());
        }
    }
}
