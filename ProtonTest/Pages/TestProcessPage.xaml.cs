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
    /// Логика взаимодействия для TestProcessPage.xaml
    /// </summary>
    public partial class TestProcessPage : Page
    {
        private readonly TestCategory _category;
        private int _currentIndex = 0;
        private int _correctCount = 0;
        private readonly List<int> _selectedAnswers = new List<int>();

        public TestProcessPage(TestCategory category)
        {
            InitializeComponent();
            _category = category;
            CategoryTitleText.Text = _category.Title;
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            var q = _category.Questions[_currentIndex];
            QuestionText.Text = q.QuestionText;
            ProgressText.Text = $"Вопрос {_currentIndex + 1} из {_category.Questions.Count}";
            TestProgressBar.Value = ((double)(_currentIndex + 1) / _category.Questions.Count) * 100;

            OptionsContainer.Children.Clear();

            for (int i = 0; i < q.Options.Count; i++)
            {
                var option = q.Options[i];
                var rb = new RadioButton
                {
                    Content = option.Text,
                    Tag = i,
                    Margin = new Thickness(0, 0, 0, 12),
                    FontSize = 14
                };

                // Подключаем динамическое отслеживание ресурса темы
                rb.SetResourceReference(Control.ForegroundProperty, "TextPrimaryBrush");

                OptionsContainer.Children.Add(rb);
            }

            NextBtn.Content = (_currentIndex == _category.Questions.Count - 1) ? "Завершить тест" : "Следующий вопрос";
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = -1;
            for (int i = 0; i < OptionsContainer.Children.Count; i++)
            {
                if (OptionsContainer.Children[i] is RadioButton rb && rb.IsChecked == true)
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите вариант ответа.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (_category.Questions[_currentIndex].Options[selectedIndex].IsCorrect)
            {
                _correctCount++;
            }

            _currentIndex++;

            if (_currentIndex < _category.Questions.Count)
            {
                DisplayQuestion();
            }
            else
            {
                FinishTest();
            }
        }

        private void FinishTest()
        {
            var result = new TestResult
            {
                TestTitle = _category.Title,
                TotalQuestions = _category.Questions.Count,
                CorrectAnswers = _correctCount,
                DatePassed = DateTime.Now.ToString("dd.MM.yyyy HH:mm")
            };

            UserSession.CurrentUser?.Results.Add(result);

            MessageBox.Show($"Тест завершен!\nПравильных ответов: {_correctCount} из {_category.Questions.Count} ({result.Percentage:F1}%)",
                            "Результат", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService?.Navigate(new ProfilePage());
        }
    }
}
