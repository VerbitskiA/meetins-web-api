using Meetins.Abstractions.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using Meetins.Services.Reports;

namespace Meetins.Tests.Reports
{
    [TestClass]
    public class CreateReportTest
    {
        [TestMethod]
        public async Task CreateReportAsyncTest()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.CreateReportAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);

            var service = new ReportsService(mockRepository.Object);

            //Act
            var result = await service.CreateReportAsync(new Guid("5a2d47a8-8916-4ad0-a7c8-df7c69585971"), "do", "something");

            //Assert
            Assert.AreEqual(result, true);
        }
    }
}
