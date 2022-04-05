using Meetins.Models.Profile.Output;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Meetins.Frontend.Pages
{
    public partial class UserConfirmProfile:ComponentBase
    {
        private ProfileOutput _profile { get; set; } = new ProfileOutput();
        protected override async Task OnInitializedAsync()
        {
            _profile = await ProfileService.GetMyProfile();
            StateHasChanged();
        }
    }
}
