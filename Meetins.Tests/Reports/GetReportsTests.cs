using Meetins.Abstractions.Repositories;
using Meetins.Models.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using Meetins.Services.Reports;
using Meetins.Models.Reports;
using System.Collections.Generic;

namespace Meetins.Tests.Reports
{
    [TestClass]
    public class GetReportsTests : BaseServiceTest
    {
        [TestMethod]
        public async Task GetReportByReportIdAsyncTest_ThrowsNotFoundException()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetReportByReportIdAsync(It.IsAny<Guid>())).Throws(new NotFoundException("Обращение с таким идентификатором не найдено."));

            var service = new ReportsService(mockRepository.Object);

            //Act
            try
            {
                var reisult = await service.GetReportByReportIdAsync(new Guid("5a2d47a8-8916-4ad0-a7c8-df7c69585978"));
                Assert.Fail("Исключение NotFoundException в тестируемом сервисе не выбросилось.");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is NotFoundException);
            }
        }

        [TestMethod]
        public async Task GetReportByReportIdAsyncTest_ReturnsProfile()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetReportByReportIdAsync(It.IsAny<Guid>())).ReturnsAsync(new ReportOutput());

            var service = new ReportsService(mockRepository.Object);

            //Act
            var result = await service.GetReportByReportIdAsync(new Guid("5a2d47a8-8916-4ad0-a7c8-df7c69585978"));

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllReportsAsyncTest_ThrowsNotFoundException()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetAllReportsAsync()).Throws(new NotFoundException("Обращений не найдено."));

            var service = new ReportsService(mockRepository.Object);

            //Act
            try
            {
                var reisult = await service.GetAllReportsAsync();
                Assert.Fail("Исключение NotFoundException в тестируемом сервисе не выбросилось.");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is NotFoundException);
            }
        }

        [TestMethod]
        public async Task GetAllReportsAsyncTest_ReturnsProfile()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetAllReportsAsync()).ReturnsAsync(new List<ReportOutput>());

            var service = new ReportsService(mockRepository.Object);

            //Act
            var result = await service.GetAllReportsAsync();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetReportsByUserIdAsyncTest_ThrowsNotFoundException()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetReportsByUserIdAsync(It.IsAny<Guid>())).Throws(new NotFoundException("Обращений от пользователя с данным id не найдено."));

            var service = new ReportsService(mockRepository.Object);

            //Act
            try
            {
                var reisult = await service.GetReportsByUserIdAsync(Guid.NewGuid());
                Assert.Fail("Исключение NotFoundException в тестируемом сервисе не выбросилось.");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is NotFoundException);
            }
        }

        [TestMethod]
        public async Task GetReportsByUserIdAsyncTest_ReturnsProfile()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetReportsByUserIdAsync(It.IsAny<Guid>())).ReturnsAsync(new List<ReportOutput>());

            var service = new ReportsService(mockRepository.Object);

            //Act
            var result = await service.GetReportsByUserIdAsync(new Guid("22247892-12EB-4382-4598-FA5F097E60B0"));

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetOpenReportsAsyncTest_ThrowsNotFoundException()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetOpenReportsAsync()).Throws(new NotFoundException("Открытых oбращений не найдено."));

            var service = new ReportsService(mockRepository.Object);

            //Act
            try
            {
                var reisult = await service.GetOpenReportsAsync();
                Assert.Fail("Исключение NotFoundException в тестируемом сервисе не выбросилось.");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is NotFoundException);
            }
        }

        [TestMethod]
        public async Task GetOpenReportsAsyncTest_ReturnsProfile()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetOpenReportsAsync()).ReturnsAsync(new List<ReportOutput>());

            var service = new ReportsService(mockRepository.Object);

            //Act
            var result = await service.GetOpenReportsAsync();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetClosedReportsAsyncTest_ThrowsNotFoundException()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetClosedReportsAsync()).Throws(new NotFoundException("Закрытых oбращений не найдено."));

            var service = new ReportsService(mockRepository.Object);

            //Act
            try
            {
                var reisult = await service.GetClosedReportsAsync();
                Assert.Fail("Исключение NotFoundException в тестируемом сервисе не выбросилось.");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is NotFoundException);
            }
        }

        [TestMethod]
        public async Task GetClosedReportsAsyncTest_ReturnsProfile()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetClosedReportsAsync()).ReturnsAsync(new List<ReportOutput>());

            var service = new ReportsService(mockRepository.Object);

            //Act
            var result = await service.GetClosedReportsAsync();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetReportsForPeriodAsyncTest_ThrowsNotFoundException()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetReportsForPeriodAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Throws(new NotFoundException("Обращений от пользователя с данным id не найдено."));

            var service = new ReportsService(mockRepository.Object);

            //Act
            try
            {
                var reisult = await service.GetReportsForPeriodAsync(DateTime.Now, DateTime.Now);
                Assert.Fail("Исключение NotFoundException в тестируемом сервисе не выбросилось.");
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is NotFoundException);
            }
        }

        [TestMethod]
        public async Task GetReportsForPeriodAsyncTest_ReturnsProfile()
        {
            //Arrange
            var mockRepository = new Mock<IReportsRepository>();
            mockRepository.Setup(a => a.GetReportsForPeriodAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(new List<ReportOutput>());

            var service = new ReportsService(mockRepository.Object);

            //Act
            var result = await service.GetReportsForPeriodAsync(DateTime.Now, DateTime.Now);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
