using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Test.GoogleNotification.Bsl.NotifyHistory;
using Test.GoogleNotification.Bsl.User;
using Test.GoogleNotification.Dal.Entities;
using Test.GoogleNotification.Dal.NotifyHistory;
using Test.GoogleNotification.Dal.Users;

namespace Test.GoogleNotification.UnitTest.Bsl
{
    public class NotifyHistoryBslTest
    {
        private IServiceCollection services;
        private ServiceProvider provider;

        [SetUp]
        public void Setup()
        {
            services = new ServiceCollection();
            services.AddTransient<GoogleNotificationContext>();
            services.AddScoped<INotifyHistoryBsl, NotifyHistoryBsl>();
            services.AddTransient<INotifyHistoryDal, NotifyHistoryDal>();

            provider = services.BuildServiceProvider();

            services.AddDbContextPool<GoogleNotificationContext>(x => {
                x.UseSqlServer("Server=DESKTOP-9HHLK4D;Database=GoogleNotification;user id=sa;password=sa@12345;Trusted_Connection=True;");
                x.UseInternalServiceProvider(provider);
            });
        }

        [Test]
        public async Task Test_Create_Push_History()
        {
            var pushModel = new Dal.Entities.NotifyHistory()
            {
                PushDate = DateTime.Now,
                Status = true,
                UserId = 1
            };

            var result = await provider.GetService<INotifyHistoryBsl>().Create(pushModel);
            Assert.IsTrue(result);
        }
    }
}