using System;

namespace Meetins.Models.Reports
{
    /// <summary>
    /// Класс входной модели обращения за период времени.
    /// </summary>
    public class GetReportsForPeriodInput
    {
        /// <summary>
        /// Начало периода.
        /// </summary>
        public DateTime StartOfPeriod { get; set; }

        /// <summary>
        /// Конец периода.
        /// </summary>
        public DateTime EndOfPeriod { get; set; }
    }
}
