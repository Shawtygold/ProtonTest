namespace ProtonTest.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string QuestionText { get; set; }

        public Test? Test { get; set; }
        public List<Option> Options { get; set; } = new();

        public Question() { }

        public Question(int testId, string questionText)
        {
            TestId = testId;
            QuestionText = questionText;
        }
    }
}
