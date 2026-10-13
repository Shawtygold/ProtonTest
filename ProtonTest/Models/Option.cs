namespace ProtonTest.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }

        public Question? Question { get; set; }

        public Option() { }

        public Option(int questionId, string optionText, bool isCorrect)
        {
            QuestionId = questionId;
            OptionText = optionText;
            IsCorrect = isCorrect;
        }
    }
}
