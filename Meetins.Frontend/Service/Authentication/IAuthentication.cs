using Meetins.Models.User.Input;
using Meetins.Models.User.Output;
using System.Threading.Tasks;

namespace Meetins.Frontend.Service
{
    public interface IAuthentication
    {
        public Task<LoginOutput> GetLoginOutput(LoginInput loginInput);
    }
}
