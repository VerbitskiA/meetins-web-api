using Meetins.Models.Common;
using Meetins.Models.User.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Meetins.Frontend.Pages
{
    public partial class AuthorizeCopyPage:ComponentBase
    {

        private bool _isMainPage { get; set; } = true;
        private bool _isPasswordPage { get; set; } = false;
        private bool _isCreatedProfileStart { get; set; } = false;
        private bool _isCreatedProfileEnd { get; set; } = false;

        private string _cssMainPage => _isMainPage ? "" : "collapse";
        private string _cssPasswordPage => _isPasswordPage ? "" : "collapse";
        private string _cssCreatedProfileStart => _isCreatedProfileStart ? "" : "collapse";
        private string _cssCreatedProfileEnd => _isCreatedProfileEnd ? "" : "collapse";

        protected override async Task OnInitializedAsync()
        {
            _loginData = new LoginInput();
            _cities = await CommonService.GetAllCities();
            StateHasChanged();
        }

        private void OnPagePassword()
        {
            _isMainPage = false;
            _isPasswordPage = true;
            _isCreatedProfileStart = false;
            _isCreatedProfileEnd = false;

            StateHasChanged();

        }
        private void OnMainPage()
        {
            _isMainPage = true;
            _isPasswordPage = false;
            _isCreatedProfileStart = false;
            _isCreatedProfileEnd = false;

        }
        private void OnCreatedProfileStart()
        {
            _isMainPage = false;
            _isPasswordPage = false;
            _isCreatedProfileStart = true;
            _isCreatedProfileEnd = false;

        }
        private void OnCreatedProfileEnd()
        {
            _isMainPage = false;
            _isPasswordPage = false;
            _isCreatedProfileStart = false;
            _isCreatedProfileEnd = true;

        }
        private LoginInput _loginData { get; set; }
        private async Task LoginAsync()
        {
            await UserService.Login(_loginData);
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
