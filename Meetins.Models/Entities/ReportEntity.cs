using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetins.Models.Entities
{
    /// <summary>
    /// Класс сопоставляется с таблицей dbo.Reports
    /// </summary>
    [Table("Reports", Schema = "dbo")]
    public class ReportEntity
    {
        /// <summary>
        /// Идентификатор обращения.
        /// </summary>
        [Key]
        [Column("ReportId", TypeName = "uuid")]
        public Guid ReportId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, который создал обращение.
        /// </summary>
        [Column("UserId", TypeName = "uuid")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Открыто или закрыто обращение.
        /// </summary>
        [Column("IsOpened", TypeName = "bool")]
        public bool IsOpened { get; set; }

        /// <summary>
        /// Тема обращения.
        /// </summary>
        [Column("Topic", TypeName = "varchar")]
        public string Topic { get; set; }

        /// <summary>
        /// Текст обращения.
        /// </summary>
        [Column("Text", TypeName = "varchar")]
        public string Text { get; set; }

        /// <summary>
        /// Дата создания обращения.
        /// </summary>
        [Column("Date", TypeName = "timestamp")]
        public DateTime Date { get; set; }

        public UserEntity User { get; set; }
    }
}
