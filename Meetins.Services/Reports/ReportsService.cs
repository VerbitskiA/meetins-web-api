using Meetins.Abstractions.Repositories;
using Meetins.Abstractions.Services;
using Meetins.Models.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetins.Services.Reports
{
    /// <summary>
    /// В сервисе содержится функционал для обращений.
    /// </summary>
    public class ReportsService : IReportsService
    {
        private IReportsRepository _reportRepository;

        public ReportsService(IReportsRepository reportsRepository)
        {
            _reportRepository = reportsRepository;
        }

        /// <summary>
        /// Получение списка всех обращений.
        /// </summary>
        /// <returns> Список всех обращений. </returns>
        public async Task<IEnumerable<ReportOutput>> GetAllReportsAsync()
        {
            var result = await _reportRepository.GetAllReportsAsync();

            return result;
        }

        /// <summary>
        /// Получение обращения по Id.
        /// </summary>
        /// <param name="reportId"> Идентификатор обращения. </param>
        /// <returns> Обращение. </returns>
        public async Task<IEnumerable<ReportOutput>> GetReportByReportId(Guid reportId)
        {
            try
            {
                var result = await _reportRepository.GetReportByReportId(reportId);

                return result;
            }
            catch(Exception)
            {
                throw;
            } 
        }
    }
}
