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
    public class GetUserLockoutStatusTest : BaseServiceTest
    {
        [TestMethod]
        public async Task GetUserLockoutStatusAsyncTest()
        {
            var guid = Guid.NewGuid();

            //Arrange
            async Task<LockoutStatusOutput> GetMockedLockoutStatus(Guid guid)
            {
                return new LockoutStatusOutput
                {
                    LockoutEnabled = true,
                    LockoutEnd = "4/25/2022 9:00"
                };
            }

            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(a => a.GetUserLockoutStatusAsync(guid)).Returns(GetMockedLockoutStatus(guid));

            var service = new UserService(mockRepository.Object, RefreshTokenRepository, PostgreDbContext, MailingService, CommonService);

            //Act
            var result = service.GetUserLockoutStatusAsync(guid);

            //Assert
            Assert.IsTrue(result.Result.LockoutEnabled == true && result.Result.LockoutEnd == "4/25/2022 9:00");
        }

        [TestMethod]
        public async Task GetUserLockoutStatusAsyncTest2()
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

        [TestMethod]
        public async Task GetUserLockoutStatusAsyncTest3()
        {
            var guid = Guid.NewGuid();

            //Arrange
            async Task<LockoutStatusOutput> GetMockedLockoutStatus(Guid guid)
            {
                return new LockoutStatusOutput
                {
                    // 25.04.2022 9:00:00 - uk-UA
                    // 04/25/2022 9:00:00 - ?(en-US)
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
            Assert.IsTrue(result.Result.LockoutEnabled == true);
            Assert.IsTrue(result.Result.LockoutEnd.Equals("25.04.2022 09:00:00"));
        }
    }
}

/*
GetUserLockoutStatusAsyncTest3
  Source: GetUserLockoutStatusTest.cs line 69
   Duration: 4,3 sec

  Message: 
Test method Meetins.Tests.User.GetUserLockoutStatusTest.GetUserLockoutStatusAsyncTest3 threw exception: 
System.AggregateException: One or more errors occurred. (String '4/25/2022 9:00:00' was not recognized as a valid DateTime.) --->System.FormatException: String '4/25/2022 9:00:00' was not recognized as a valid DateTime.

  Stack Trace: 
DateTimeParse.Parse(ReadOnlySpan`1 s, DateTimeFormatInfo dtfi, DateTimeStyles styles)
DateTime.Parse(String s)
GetUserLockoutStatusTest.< GetUserLockoutStatusAsyncTest3 > g__GetMockedLockoutStatus | 2_0(Guid guid) line 76
UserService.GetUserLockoutStatusAsync(Guid userId) line 558
UserService.GetUserLockoutStatusAsync(Guid userId) line 567
-- - End of inner exception stack trace ---
Task`1.GetResultCore(Boolean waitCompletionNotification)
Task`1.get_Result()
GetUserLockoutStatusTest.GetUserLockoutStatusAsyncTest3() line 92
ThreadOperations.ExecuteWithAbortSafety(Action action)

  Standard Output: 
System.FormatException: String '4/25/2022 9:00:00' was not recognized as a valid DateTime.
   at System.DateTimeParse.Parse(ReadOnlySpan`1 s, DateTimeFormatInfo dtfi, DateTimeStyles styles)
   at System.DateTime.Parse(String s)
   at Meetins.Tests.User.GetUserLockoutStatusTest.<GetUserLockoutStatusAsyncTest3>g__GetMockedLockoutStatus|2_0(Guid guid) in D:\Programming\C#\meetins-web-api\Meetins.Tests\User\GetUserLockoutStatusTest.cs:line 76
   at Meetins.Services.User.UserService.GetUserLockoutStatusAsync(Guid userId) in D:\Programming\C#\meetins-web-api\Meetins.Services\User\UserService.cs:line 558
*/

