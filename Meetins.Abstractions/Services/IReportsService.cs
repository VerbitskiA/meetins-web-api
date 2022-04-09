using Meetins.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
