namespace ProtonTest.Services
{
    //public class Option
    //{
    //    public string Text { get; set; }
    //    public bool IsCorrect { get; set; }
    //    public string Rationale { get; set; }
    //}

    //public class Question
    //{
    //    public string QuestionText { get; set; }
    //    public List<Option> Options { get; set; } = new List<Option>();
    //    public string Hint { get; set; }
    //}

    //public class TestCategory
    //{
    //    public string Id { get; set; }
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public List<Question> Questions { get; set; } = new List<Question>();
    //}

    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string QuestionText { get; set; }
    }

    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class TestResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TestTitle { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public double Percentage => TotalQuestions == 0 ? 0 : (double)CorrectAnswers / TotalQuestions * 100;
        public string DatePassed { get; set; }
    }
}