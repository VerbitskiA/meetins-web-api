using Meetins.Models.Common;
using Meetins.Models.User.Input;
using Microsoft.AspNetCore.Components;


namespace Meetins.Frontend.Pages
{
    public partial class AuthorizePage : ComponentBase
    {
        private DateTime _birthDay { get; set; }
        private int _daysInMonth { get;set; } 


        private Task UpdateBirthDayDay(int day)
        {
            DateTime newBirthDay=DateTime.Now;
            try
            {
                newBirthDay = new DateTime(_birthDay.Year, _birthDay.Month, day);
            }
            catch
            {
                newBirthDay = new DateTime(_birthDay.Year, _birthDay.Month, 1);    
            }
            _birthDay = newBirthDay;
            _daysInMonth = DateTime.DaysInMonth(_birthDay.Year, _birthDay.Month);
            StateHasChanged();
            return Task.CompletedTask;
        }
        private Task UpdateBirthDayMonth(int month)
        {
            DateTime newBirthDay = DateTime.Now;
            try
            {
                newBirthDay = new DateTime(_birthDay.Year, month, _birthDay.Day);
            }
            catch
            {
                newBirthDay = new DateTime(_birthDay.Year, 1, _birthDay.Day);
            }
            _birthDay = newBirthDay;
            _daysInMonth = DateTime.DaysInMonth(_birthDay.Year, _birthDay.Month);
            StateHasChanged();
            return Task.CompletedTask;
        }
        private Task UpdateBirthDayYear(int year)
        {
            DateTime newBirthDay = DateTime.Now;
            try
            {
                newBirthDay = new DateTime(year, _birthDay.Month, _birthDay.Day);
            }
            catch
            {
                newBirthDay = new DateTime(DateTime.Now.Year, _birthDay.Month, _birthDay.Day);
            }
            _birthDay = newBirthDay;
            _daysInMonth = DateTime.DaysInMonth(_birthDay.Year, _birthDay.Month);
            StateHasChanged();
            return Task.CompletedTask;
        }
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
            _birthDay=DateTime.Now;
            _daysInMonth = DateTime.DaysInMonth(_birthDay.Year,_birthDay.Month);
            _loginData = new LoginInput();
            _cities = await CommonService.GetAllCities();
            StateHasChanged();
        }
        private bool _isFocusManButton { get; set; } = false;
        private bool _isFocusWomanButton { get; set; } = false;
        private string _cssFocusManButton => _isFocusManButton ? "form-input-radio-focus" : "form-input-radio";
        private string _cssFocusWomanButton => _isFocusWomanButton ? "form-input-radio-focus" : "form-input-radio";
        private string IsChecedRadioButton(string check)
        {
            if (string.IsNullOrEmpty(_registerData.Gender)) return "form-input-radio";
            if (_registerData.Gender.Equals(check)) return "form-input-radio-checked";
            return "form-input-radio";
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
