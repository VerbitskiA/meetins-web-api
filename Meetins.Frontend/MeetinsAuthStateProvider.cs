using Meetins.Frontend.Model;
using Meetins.Frontend.Service;
using Meetins.Models.User.Input;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
namespace Meetins.Frontend
{
    public class MeetinsAuthStateProvider : AuthenticationStateProvider
    {
        private ILocalStorageService _localStorageService;
        private HttpClient _httpClient;
        public MeetinsAuthStateProvider( HttpClient httpClient,
            ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        private AuthenticationState CreateAnonymus()
        {
            var anonymusIdentity = new ClaimsIdentity();
            var anonymusPrincipal = new ClaimsPrincipal(anonymusIdentity);
            return new AuthenticationState(anonymusPrincipal);
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var token = await _localStorageService.GetAsync<SecurityToken>(nameof(SecurityToken));

            if (token ==null)
            {
                var anonymus = CreateAnonymus();
                NotifyAuthenticationStateChanged(Task.FromResult(anonymus));
                return anonymus;
            }

            if (String.IsNullOrEmpty(token.AccessToken))
            {
                var anonymus = CreateAnonymus();
                NotifyAuthenticationStateChanged(Task.FromResult(anonymus));
                return anonymus;
            }
            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token.AccessToken),"jwt");
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);
        }


        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
