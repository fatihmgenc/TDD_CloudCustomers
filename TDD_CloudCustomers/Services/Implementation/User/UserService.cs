
using Microsoft.Extensions.Options;
using TDD_CloudCustomers.API.Models.Config;
using TDD_CloudCustomers.API.Models.UserRelated;
using TDD_CloudCustomers.API.Services.Abstract.UserServices;

namespace TDD_CloudCustomers.API.Services.Implementation.UserServices
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly UserApiOptions _options;

        public UserService(HttpClient httpClient, IOptions<UserApiOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<List<User>> GetAll()
        {
            var resp = await _httpClient.GetAsync(_options.EndPoint);

            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<User>();

            }

            var responseContent = resp.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
            return allUsers?.ToList();

        }

    }
}
