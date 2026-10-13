namespace ProtonTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int DepartmentId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }


        public Role? Role { get; set; }
        public Department? Department { get; set; }
        public List<TestResult> TestResults { get; set; } = new();

        public User() { }

        public User(int roleId, int departmentId, string username, string fullname, string passwordHash)
        {
            RoleId = roleId;
            DepartmentId = departmentId;
            Username = username;
            FullName = fullname;
            PasswordHash = passwordHash;
        }
    }
}
