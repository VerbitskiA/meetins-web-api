using Meetins.Frontend.Service;
using Meetins.Models.Profile.Output;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Meetins.Frontend.Pages
{
    public partial class UserEditingProfile : ComponentBase
    {
        private ProfileOutput _profile { get; set; }
        private string _name { get; set; }
        private string _age { get; set; }
        private string _avatar { get; set; }
        private string _city { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _profile = await ProfileService.GetMyProfile();
            GetInfoFromProfile();
        }
        private void GetInfoFromProfile()
        {
            _name = _profile.Name;
            var age = _profile.BirthDate.Year-DateTime.Now.Year;
        }
    }
}
