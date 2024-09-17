using Meetins.Abstractions.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using Meetins.Services.Reports;

namespace Meetins.Tests.Reports
{
    [TestClass]
    public class IsOpenedReportTests
    {
        [TestMethod]
        public async Task CloseReportAsyncTest()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.CloseReportAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            var service = new ReportsService(mockRepository.Object);

            //Act
            var result = await service.CloseReportAsync(new Guid("5a2d47a8-8916-4ad0-a7c8-df7c69585978"));

            //Assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public async Task OpenReportAsyncTest()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.OpenReportAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            var service = new ReportsService(mockRepository.Object);

            //Act
            var result = await service.OpenReportAsync(new Guid("5a2d47a8-8916-4ad0-a7c8-df7c69585978"));

            //Assert
            Assert.AreEqual(result, true);
        }
    }
}
