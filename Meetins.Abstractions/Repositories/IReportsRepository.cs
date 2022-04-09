using Meetins.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
