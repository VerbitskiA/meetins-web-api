using Meetins.Abstractions.Repositories;
using Meetins.Models.Entities;
using Meetins.Services.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetins.Tests.Common
{
    [TestClass]
    public class GetRegistrationsForLastDayTest : BaseServiceTest
    {
        [TestMethod]
        public async Task GetRegistrationsForLastDayAsyncTest_ReturnsThree()
        {
            //Arrange 
            async Task<int> GetMockedRegistrationsForLastDay()
            {
                var users = new List<UserEntity>();

                users.Add(new UserEntity { DateRegister = System.DateTime.Now });
                users.Add(new UserEntity { DateRegister = System.DateTime.Today });
                users.Add(new UserEntity { DateRegister = System.DateTime.Now.AddHours(-4) });
                users.Add(new UserEntity { DateRegister = System.DateTime.Now.AddHours(-25) });

                return users.Where(user => user.DateRegister >= System.DateTime.Now.AddHours(-24)).Count();
            }

            var mockRepository = new Mock<ICommonRepository>();
            mockRepository.Setup(a => a.GetRegistrationsForLastDayAsync()).Returns(GetMockedRegistrationsForLastDay());

            var service = new CommonService(mockRepository.Object, PostgreDbContext);

            //Act
            var result = await service.GetRegistrationsForLastDayAsync();

            //Assert
            Assert.IsTrue(result == 3);
        }
    }
}
