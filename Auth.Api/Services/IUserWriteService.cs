using Auth.Api.Models;

namespace Auth.Api.Services
{
    public interface IUserWriteService
    {
        User Create(User user);
    }
}