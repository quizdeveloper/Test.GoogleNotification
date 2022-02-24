using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.GoogleNotification.Bsl.Models;
using Test.GoogleNotification.Dal.Entities;
using Test.GoogleNotification.Dal.Users;

namespace Test.GoogleNotification.Bsl.User
{
    public class UserBsl : IUserBsl
    {
        private readonly IUserDal _userDal;

        public UserBsl(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<bool> Create(Dal.Entities.User model)
        {
            return await _userDal.Create(model);
        }

        public async Task<UserModel> GetById(int userId)
        {
            return new UserModel(await _userDal.GetById(userId));
        }

        public async Task<UserModel> GetByIP(string ipAddress)
        {
            return new UserModel(await _userDal.GetByIP(ipAddress));
        }

        public async Task<UserModel> GetByToken(string token)
        {
            return new UserModel(await _userDal.GetByToken(token));
        }

        public async Task<List<UserModel>> Gets(int top)
        {
            return (await _userDal.Gets(top)).Select(x => new UserModel(x)).ToList();
        }
    }
}
