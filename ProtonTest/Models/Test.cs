namespace ProtonTest.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Department? Department { get; set; }
        public List<Question> Questions { get; set; } = new();
        public List<TestResult> TestResults { get; set; } = new();

        public Test() { }

        public Test(int departmentId, string title, string description)
        {
            DepartmentId = departmentId;
            Title = title;
            Description = description;
        }
    }
}
