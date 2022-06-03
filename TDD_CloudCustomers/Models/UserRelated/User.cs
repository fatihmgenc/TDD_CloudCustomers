using TDD_CloudCustomers.API.Models.AccomadationRelated;

namespace TDD_CloudCustomers.API.Models.UserRelated
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public Address? Address { get; set; }
    }
}
