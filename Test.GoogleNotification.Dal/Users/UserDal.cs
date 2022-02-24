using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.GoogleNotification.Dal.Entities;

namespace Test.GoogleNotification.Dal.Users
{
    public class UserDal : IUserDal
    {
        private GoogleNotificationContext _db;
        public UserDal(GoogleNotificationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(User model)
        {
            if (model == null) return false;
            if (string.IsNullOrEmpty(model.IpAddress)) return false;
            if (string.IsNullOrEmpty(model.SubscribeToken)) return false;
            if (!model.CreatedDate.HasValue) model.CreatedDate = DateTime.Now;
            await _db.AddAsync(model);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<User> GetById(int userId)
        {
            return _db.User.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public Task<User> GetByIP(string ipAddress)
        {
            return _db.User.FirstOrDefaultAsync(x => x.IpAddress.Equals(ipAddress));
        }

        public Task<User> GetByToken(string token)
        {
            return _db.User.FirstOrDefaultAsync(x => x.SubscribeToken.Equals(token));
        }

        public Task<List<User>> Gets(int top)
        {
            return _db.User.ToListAsync();
        }
    }
}
