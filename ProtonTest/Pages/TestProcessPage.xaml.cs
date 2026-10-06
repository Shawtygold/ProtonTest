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
        private readonly Test _test;
        private readonly List<Question> _testQuestions;
        private int _currentIndex = 0;
        private int _correctCount = 0;
        private int _questionIndex = 0;
        private int _questionCount = 0;
        private readonly List<int> _selectedAnswers = new List<int>();

        public TestProcessPage(Test test)
        {
            InitializeComponent();
            _test = test;
            _testQuestions = TestRepository.GetQuestions(_test.Id);
            _questionCount = _testQuestions.Count;
            CategoryTitleText.Text = _test.Title;
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            _currentIndex = Random.Shared.Next(_testQuestions.Count - 1);

            var q = _testQuestions[_currentIndex];
            var options = TestRepository.GetOptions(_testQuestions[_currentIndex].Id);
            QuestionText.Text = q.QuestionText;
            ProgressText.Text = $"Вопрос {_questionIndex + 1} из {_questionCount}";
            TestProgressBar.Value = ((double)(_questionIndex + 1) / _questionCount) * 100;

            OptionsContainer.Children.Clear();

            for (int i = 0; i < options.Count; i++)
            {
                var option = options[i];
                var rb = new RadioButton
                {
                    Content = option.OptionText,
                    Tag = i,
                    Margin = new Thickness(0, 0, 0, 12),
                    FontSize = 14
                };

                rb.SetResourceReference(Control.ForegroundProperty, "TextPrimaryBrush");

                OptionsContainer.Children.Add(rb);
            }

            _testQuestions.RemoveAt(_currentIndex);

            NextBtn.Content = (_testQuestions.Count == 0) ? "Завершить тест" : "Следующий вопрос";
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (_testQuestions.Count == 0)
            {
                FinishTest();
                return;
            }

            var options = TestRepository.GetOptions(_testQuestions[_currentIndex].Id);
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

            if (options[selectedIndex].IsCorrect)
            {
                _correctCount++;
            }

            //_currentIndex++;
            _questionIndex++;

            if (_testQuestions.Count != 0)
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
                UserId = UserSession.CurrentUser.Id,
                TestTitle = _test.Title,
                TotalQuestions = _questionCount,
                CorrectAnswers = _correctCount,
                DatePassed = DateTime.Now.ToString("dd.MM.yyyy HH:mm")
            };

            using (ApplicationContext context = new())
            {
                try
                {
                    context.TestResults.Add(result);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            MessageBox.Show($"Тест завершен!\nПравильных ответов: {_correctCount} из {_questionCount} ({result.Percentage:F1}%)",
                            "Результат", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService?.Navigate(new ProfilePage());
        }
    }
}
