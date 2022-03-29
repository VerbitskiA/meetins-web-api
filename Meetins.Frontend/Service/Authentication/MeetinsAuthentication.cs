using Meetins.Models.User.Input;
using Meetins.Models.User.Output;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Meetins.Frontend.Service
{
    public class MeetinsAuthentication : IAuthentication
    {
        private readonly HttpClient _httpClient;

        public MeetinsAuthentication(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginOutput> GetLoginOutput(LoginInput loginInput)
        {
            return await _httpClient.PostAsJsonAsync("/user/login",loginInput).Result.Content.ReadFromJsonAsync<LoginOutput>();
        }
    }
}
