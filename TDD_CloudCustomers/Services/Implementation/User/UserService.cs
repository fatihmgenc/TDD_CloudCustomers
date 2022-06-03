
using TDD_CloudCustomers.API.Models.UserRelated;
using TDD_CloudCustomers.API.Services.Abstract.UserServices;

namespace TDD_CloudCustomers.API.Services.Implementation.UserServices
{
    public class UserService : IUserService
    {


        Task<List<User>> IUserService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
