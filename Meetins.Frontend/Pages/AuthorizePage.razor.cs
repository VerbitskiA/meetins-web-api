using Meetins.Models.Common;
using Meetins.Models.User.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Meetins.Frontend.Pages
{
    public partial class AuthorizePage:ComponentBase
    {
        private LoginInput _loginData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _loginData = new LoginInput();
            _cities = await CommonService.GetAllCities();
            StateHasChanged();
        }
        private async Task LoginAsync()
        {
            await UserService.Login(_loginData); _registerData = new RegisterUserInput();
            StateHasChanged();
            NavigationManager.NavigateTo("/", true);
        }
        private RegisterUserInput _registerData { get; set; } = new RegisterUserInput();
        private List<CityOutput> _cities { get; set; } = new List<CityOutput>();

        private async Task RegisterAsync()
        {
            await UserService.Register(_registerData);
            NavigationManager.NavigateTo("/", true);
        }
    }
}
