using TDD_CloudCustomers.API.Models.AccomadationRelated;

namespace TDD_CloudCustomers.API.Models.UserRelated
{
    public class User
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }

        public Address? address { get; set; }
    }
}
