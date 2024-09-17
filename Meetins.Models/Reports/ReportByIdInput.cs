using System;

namespace Meetins.Models.Reports
{
    /// <summary>
    /// Класс входной модели обращения по идентификатору обращения.
    /// </summary>
    public class ReportByIdInput
    {
        /// <summary>
        /// Идентификатор обращения.
        /// </summary>
        public Guid ReportId { get; set; }
    }
}
