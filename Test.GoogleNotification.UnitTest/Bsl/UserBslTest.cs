using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Test.GoogleNotification.Bsl.User;
using Test.GoogleNotification.Dal.Entities;
using Test.GoogleNotification.Dal.Users;

namespace Test.GoogleNotification.UnitTest.Bsl
{
    public class UserBslTest
    {
        private IServiceCollection services;
        private ServiceProvider provider;
        [SetUp]
        public void Setup()
        {
            services = new ServiceCollection();

            services.AddScoped<IUserBsl, UserBsl>();
            services.AddTransient<IUserDal, UserDal>();
            services.AddTransient<GoogleNotificationContext>();
            provider = services.BuildServiceProvider();

            services.AddDbContextPool<GoogleNotificationContext>(x => {
                x.UseSqlServer("Server=DESKTOP-9HHLK4D;Database=GoogleNotification;user id=sa;password=sa@12345;Trusted_Connection=True;");
                x.UseInternalServiceProvider(provider);
            });
        }

        [TestCase(0)] // Not Existed
        [TestCase(1)] // Existed
        [TestCase(10000)] // Not Existed
        public async Task Get_User_By_Id(int userId)
        {
            var userObj = await provider.GetService<IUserBsl>().GetById(userId);
            Assert.Greater(userObj.UserId, 0);
        }

        [Test]
        public async Task Get_All_User()
        {
            var userObj = await provider.GetService<IUserBsl>().Gets(1000);
            Assert.Greater(userObj.Count, 0);
        }

        [Test]
        public async Task Test_Create_User()
        {
            var userModel = new Dal.Entities.User() {
                IpAddress = "123.33.44.4",
                SubscribeToken = "lqkdwndbwhdiwdwdwqdwh232hj32hj3gv2v3g2v3g232",
                CreatedDate = DateTime.Now
            };

            var result = await provider.GetService<IUserBsl>().Create(userModel);
            Assert.IsTrue(result);
        }
    }
}