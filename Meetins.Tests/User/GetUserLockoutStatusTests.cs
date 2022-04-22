using Meetins.Abstractions.Repositories;
using Meetins.Models.User.Output;
using Meetins.Services.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace Meetins.Tests.User
{
    [TestClass]
    public class GetUserLockoutStatusTests : BaseServiceTest
    {
        [TestMethod]
        public async Task GetUserLockoutStatusAsyncTest_ReturnsTrue()
        {
            var guid = Guid.NewGuid();

            //Arrange
            async Task<LockoutStatusOutput> GetMockedLockoutStatus(Guid guid)
            {
                return new LockoutStatusOutput
                {
                    LockoutEnabled = true,
                    LockoutEnd = DateTime.Parse("25.04.2022 9:00", System.Globalization.CultureInfo.CreateSpecificCulture("uk-UA")).ToString()
                };
            }

            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(a => a.GetUserLockoutStatusAsync(guid)).Returns(GetMockedLockoutStatus(guid));

            var service = new UserService(mockRepository.Object, RefreshTokenRepository, PostgreDbContext, MailingService, CommonService);

            //Act
            var result = service.GetUserLockoutStatusAsync(guid);

            //Assert
            Assert.IsTrue(result.Result.LockoutEnabled == true && result.Result.LockoutEnd == "25.04.2022 09:00:00");
        }

        [TestMethod]
        public async Task GetUserLockoutStatusAsyncTest_ReturnsFalse()
        {
            var guid = Guid.NewGuid();

            //Arrange
            async Task<LockoutStatusOutput> GetMockedLockoutStatus(Guid guid)
            {
                return new LockoutStatusOutput
                {
                    LockoutEnabled = false,
                    LockoutEnd = ""
                };
            }

            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(a => a.GetUserLockoutStatusAsync(guid)).Returns(GetMockedLockoutStatus(guid));

            var service = new UserService(mockRepository.Object, RefreshTokenRepository, PostgreDbContext, MailingService, CommonService);

            //Act
            var result = service.GetUserLockoutStatusAsync(guid);

            //Assert
            Assert.IsTrue(result.Result.LockoutEnabled == false && result.Result.LockoutEnd == "");
        }
    }
}



