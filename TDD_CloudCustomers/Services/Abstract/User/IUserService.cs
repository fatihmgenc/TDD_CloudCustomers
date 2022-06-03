using TDD_CloudCustomers.API.Models.UserRelated;
namespace TDD_CloudCustomers.API.Services.Abstract.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
    }
}
