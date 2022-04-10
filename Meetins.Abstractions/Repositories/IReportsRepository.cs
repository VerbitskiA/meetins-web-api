using Meetins.Models.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetins.Abstractions.Repositories
{
    /// <summary>
    /// Абстракция репозитория обращений.
    /// </summary>
    public interface IReportsRepository
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
