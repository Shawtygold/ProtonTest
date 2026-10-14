using ProtonTest.Models;
using ProtonTest.Services;
using ProtonTest.Views;
using System.Windows;
using System.Windows.Controls;

namespace ProtonTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestProcessPage.xaml
    /// </summary>
    public partial class TestProcessPage : Page
    {
        private readonly Test _test;
        private readonly List<Question> _testQuestions;
        private Question? _currentQuestion;
        private int _correctCount = 0;
        private int _questionIndex = 0;
        private int _questionCount = 0;

        public TestProcessPage(Test test)
        {
            InitializeComponent();
            _test = test;
            _testQuestions = TestRepository.GetQuestions(_test.Id);
            _questionCount = _testQuestions.Count;
            CategoryTitleText.Text = _test.Title;

            if (_questionCount == 0)
            {
                MessageBox.Show("В этом тесте еще нет вопросов.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            if (_testQuestions.Count == 0) return;

            int index = Random.Shared.Next(_testQuestions.Count);
            _currentQuestion = _testQuestions[index];

            _testQuestions.RemoveAt(index);

            var options = TestRepository.GetOptions(_currentQuestion.Id);
            QuestionText.Text = _currentQuestion.QuestionText;
            ProgressText.Text = $"Вопрос {_questionIndex + 1} из {_questionCount}";
            TestProgressBar.Value = ((double)(_questionIndex + 1) / _questionCount) * 100;

            OptionsContainer.Children.Clear();

            foreach (var option in options)
            {
                var rb = new RadioButton
                {
                    Content = option.OptionText,
                    Tag = option,
                    Margin = new Thickness(0, 0, 0, 12),
                    FontSize = 14
                };

                rb.SetResourceReference(Control.ForegroundProperty, "TextPrimaryBrush");
                OptionsContainer.Children.Add(rb);
            }

            NextBtn.Content = (_testQuestions.Count == 0) ? "Завершить тест" : "Следующий вопрос";
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            RadioButton? selectedRb = null;
            foreach (var child in OptionsContainer.Children)
            {
                if (child is RadioButton rb && rb.IsChecked == true)
                {
                    selectedRb = rb;
                    break;
                }
            }

            if (selectedRb == null)
            {
                MessageBox.Show("Пожалуйста, выберите вариант ответа.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (selectedRb.Tag is Option selectedOption && selectedOption.IsCorrect)
            {
                _correctCount++;
            }

            _questionIndex++;

            if (_testQuestions.Count > 0)
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
            var result = new TestResult(UserSession.CurrentUser.Id, _test.Id, _questionCount, _correctCount, DateTime.Now);

            using (ApplicationContext context = new())
            {
                try
                {
                    context.TestResults.Add(result);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            var testResultView = new TestResultView(_test.Title, result.TotalQuestions, result.CorrectAnswers, result.DatePassed.ToString("dd.MM.yyyy HH:mm"));

            MessageBox.Show($"Тест завершен!\nПравильных ответов: {_correctCount} из {_questionCount} ({testResultView.Percentage:F1}%)",
                            "Результат", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService?.Navigate(new ProfilePage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DashboardPage());
        }
    }
}
