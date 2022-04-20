using Meetins.Models.Common;
using Meetins.Models.User.Input;
using Microsoft.AspNetCore.Components;


namespace Meetins.Frontend.Pages
{
    public partial class AuthorizePage : ComponentBase
    {
        private int _daysInMonth { get; set; }
        private int _birthDay { 
            get 
            {
                return _registerData.BirthDate.Day;
            }
            set
            {
                UpdateBirthDay(value, _birthMonth, _birthYear);
            }
        } 
        private int _birthMonth
        {
            get
            {
                return _registerData.BirthDate.Month;
            }
            set
            {
                UpdateBirthDay(_birthDay, value, _birthYear);
            }
        }
        private int _birthYear
        {
            get
            {
                return _registerData.BirthDate.Year;
            }
            set
            {
                UpdateBirthDay(_birthDay, _birthMonth, value);
            }
        }
        private void UpdateBirthDay(int day,int month, int year)
        {
            try
            {
                _registerData.BirthDate = new DateTime(year, month, day);
            }
            catch
            {

                _registerData.BirthDate = new DateTime(year, month, 1);
            }
            _daysInMonth = DateTime.DaysInMonth(_registerData.BirthDate.Year, _registerData.BirthDate.Month);
            StateHasChanged();
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
            _registerData.BirthDate = DateTime.Now;
            _daysInMonth = DateTime.DaysInMonth(_registerData.BirthDate.Year, _registerData.BirthDate.Month);
            _birthDay= _registerData.BirthDate.Day;
            _birthMonth= _registerData.BirthDate.Month;
            _birthYear= _registerData.BirthDate.Year;
            _loginData = new LoginInput();
            _cities = await CommonService.GetAllCities();
            _cities = _cities.OrderBy(x => x.CityName).ToList();
            StateHasChanged();
        }

        private bool _isFocusManButton { get; set; } = false;
        private bool _isFocusWomanButton { get; set; } = false;
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
            //Console.WriteLine("Регистрация");
            await UserService.Register(_registerData);
            NavigationManager.NavigateTo("/", true);
        }


    }
}
