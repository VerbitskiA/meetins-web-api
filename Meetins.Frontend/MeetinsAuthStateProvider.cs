using Meetins.Frontend.Service;
using Meetins.Models.User.Input;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Meetins.Frontend
{
    public class MeetinsAuthStateProvider : AuthenticationStateProvider
    {
        private IAuthentication _authentication;

        public MeetinsAuthStateProvider(IAuthentication authentication)
        {
            _authentication=authentication;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var loginIn = new LoginInput()
            {
                Email = @"Alex8257@rambler.ru",
                Password = "159875321"
            };
            var con = await _authentication.GetLoginOutput(loginIn);

            var token = con.auth.AccessToken;
            var identity = new ClaimsIdentity(token);
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
    }
}
