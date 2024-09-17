using System;

namespace Meetins.Models.Reports
{
    /// <summary>
    /// Класс выходной модели обращения.
    /// </summary>
    public class ReportOutput
    {
        /// <summary>
        /// Идентификатор обращения.
        /// </summary>
        public Guid ReportId { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Закрыто или открыто обращение.
        /// </summary>
        public bool IsOpened { get; set; }

        /// <summary>
        /// Тема обращения.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Текст обращения.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата создания обращения.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
