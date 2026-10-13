namespace ProtonTest.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; } = new();

        public Department() { }

        public Department(string name)
        {
            Name = name;
        }
    }
}
