using Meetins.Models.User.Input;
using System.Threading.Tasks;

namespace Meetins.Frontend.Service
{
    public interface IUserService
    {
        public Task Login(LoginInput loginInput);
        public Task Register(RegisterUserInput registerUserInput);
    }
}
