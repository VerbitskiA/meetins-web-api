using System;

namespace Meetins.Models.Reports
{
    /// <summary>
    /// Класс входной модели обращения по идентификатору пользователя.
    /// </summary>
    public class GetReportsByUserIdInput
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
