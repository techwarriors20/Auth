using Auth.Api.Models;
using System.Collections.Generic;

namespace Auth.Api.Services
{
    public interface IUserReadService
    {
        User Authenticate(string username, string password);
        List<User> Get();
    }
}