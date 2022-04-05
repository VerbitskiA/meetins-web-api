using Meetins.Frontend.Model;
using Meetins.Models.User.Input;
using Meetins.Models.User.Output;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Meetins.Frontend.Service
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httClient;
        private readonly ILocalStorageService _localStorageService;
        public UserService(HttpClient httClient,
            ILocalStorageService localStorageService)
        {
            _httClient = httClient;
            _localStorageService = localStorageService;
        }
        public async Task Login(LoginInput loginInput)
        {
            var respone = await _httClient.PostAsJsonAsync("/user/login", loginInput);
            var loginOutput = await respone.Content.ReadFromJsonAsync<LoginOutput>();
            var securityToken = new SecurityToken()
            {
                UserName = loginOutput.profile.Name,
                AccessToken = loginOutput.auth.AccessToken,
                RefreshToken = loginOutput.auth.RefreshToken,
                ExpiredAt = DateTime.Now.AddDays(10),
            };
            await _localStorageService.SetAsync(nameof(SecurityToken), securityToken);
        }

        public async Task Register(RegisterUserInput registerUserInput)
        {
            await _httClient.PostAsJsonAsync("/user/register-user", registerUserInput);
        }


    }
}
