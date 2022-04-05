using Meetins.Models.Profile.Output;
using System.Threading.Tasks;

namespace Meetins.Frontend.Service
{
    public interface IProfileService
    {
        public Task<ProfileOutput> GetMyProfile();
    }
}
