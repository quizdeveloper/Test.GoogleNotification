using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.GoogleNotification.Dal.Entities;

namespace Test.GoogleNotification.Dal.Users
{
    public interface IUserDal
    {
        Task<User> GetById(int userId);
        Task<User> GetByIP(string ipAddress);
        Task<User> GetByToken(string token);
        Task<List<User>> Gets(int top);
        Task<bool> Create(User model);
    }
}
