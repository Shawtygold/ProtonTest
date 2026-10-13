namespace ProtonTest.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime DatePassed { get; set; }

        public User? User { get; set; }
        public Test? Test { get; set; }

        public TestResult() { }

        public TestResult(int userId, int testId, int totalQuestions, int correctAnswers, DateTime datePassed)
        {
            UserId = userId;
            TestId = testId;
            TotalQuestions = totalQuestions;
            CorrectAnswers = correctAnswers;
            DatePassed = datePassed;
        }
    }
}
