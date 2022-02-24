using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.GoogleNotification.Bsl.Models;

namespace Test.GoogleNotification.Bsl.User
{
    public interface IUserBsl
    {
        Task<UserModel> GetById(int userId);
        Task<UserModel> GetByIP(string fullname);
        Task<UserModel> GetByToken(string token);
        Task<List<UserModel>> Gets(int top);
        Task<bool> Create(Dal.Entities.User model);
    }
}
