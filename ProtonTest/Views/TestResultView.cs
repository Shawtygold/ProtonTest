namespace ProtonTest.Views
{
    public class TestResultView
    {
        public string TestTitle { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public double Percentage => TotalQuestions == 0 ? 0 : (double)CorrectAnswers / TotalQuestions * 100;
        public string DatePassed { get; set; }

        public TestResultView(string testTitle, int totalQuestions, int correctAnswers, string datePassed)
        {
            TestTitle = testTitle;
            TotalQuestions = totalQuestions;
            CorrectAnswers = correctAnswers;
            DatePassed = datePassed;
        }
    }
}
