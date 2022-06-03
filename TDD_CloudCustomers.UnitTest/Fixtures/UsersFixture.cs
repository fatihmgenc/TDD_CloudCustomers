using TDD_CloudCustomers.API.Models.AccomadationRelated;
using TDD_CloudCustomers.API.Models.UserRelated;

namespace TDD_CloudCustomers.UnitTest.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers()
        {
            return new List<User>
            {
                new User
                {
                    id=1,
                    username = "testUser1",
                    address = new Address
                    {
                        City = "usersCity",
                        StreetNumber = 13,
                    },
                    email = "test@test.tdd",
                    name = "User"
                },
                new User
                {
                    id=2,
                    username = "testUser1",
                    address = new Address
                    {
                        City = "usersCity",
                        StreetNumber = 13,
                    },
                    email = "test@test.tdd",
                    name = "User"
                },
                new User
                {
                    id=3,
                    username = "testUser1",
                    address = new Address
                    {
                        City = "usersCity",
                        StreetNumber = 13,
                    },
                    email = "test@test.tdd",
                    name = "User"
                },
                new User
                {
                    id=4,
                    username = "testUser1",
                    address = new Address
                    {
                        City = "usersCity",
                        StreetNumber = 13,
                    },
                    email = "test@test.tdd",
                    name = "User"
                },
                new User
                {
                    id=5,
                    username = "testUser1",
                    address = new Address
                    {
                        City = "usersCity",
                        StreetNumber = 13,
                    },
                    email = "test@test.tdd",
                    name = "User"
                },
            };
        }
    }
}
