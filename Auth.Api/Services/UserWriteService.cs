#region snippet_UserServiceClass
using Auth.Api.Infrastructure.Helpers;
using Auth.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Auth.Api.Services
{
    public class UserWriteService : IUserWriteService
    {
        private readonly IMongoCollection<User> _users;
        private readonly AppSettings _appSettings;

        #region UserService Constructor
        public UserWriteService(IUserstoreDatabaseSettings settings, IOptions<AppSettings> appSettings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);

            _appSettings = appSettings.Value;
        }

        #endregion

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}
#endregion
