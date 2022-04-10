using Meetins.Models.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetins.Abstractions.Services
{
    /// <summary>
    /// Абстракция сервиса всех обращений.
    /// </summary>
    public interface IReportsService
    {
        /// <summary>
        /// Получение списка всех обращений.
        /// </summary>
        /// <returns> Список всех обращений. </returns>
        Task<IEnumerable<ReportOutput>> GetAllReportsAsync();

        /// <summary>
        /// Получение обращения по Id.
        /// </summary>
        /// <param name="reportId"> Идентификатор обращения. </param>
        /// <returns> Обращение. </returns>
        Task<IEnumerable<ReportOutput>> GetReportByReportId(Guid reportId);
    }
}
