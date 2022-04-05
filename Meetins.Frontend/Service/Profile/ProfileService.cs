using Meetins.Models.Profile.Output;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Meetins.Frontend.Service
{
    public class ProfileService:IProfileService
    {
        private readonly HttpClient _httClient;
        public ProfileService(HttpClient httClient)
        {
            _httClient = httClient;
        }

        public async Task<ProfileOutput> GetMyProfile()
        {
            var profile = await _httClient.GetFromJsonAsync<ProfileOutput>("/profile/my-profile");
            return profile;
        }
    }
}
