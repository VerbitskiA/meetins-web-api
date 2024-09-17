namespace Meetins.Models.Reports
{
    /// <summary>
    /// Класс входной модели обращения для создания обращения.
    /// </summary>
    public class CreateReportInput
    {
        /// <summary>
        /// Тема обращения.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Текст обращения.
        /// </summary>
        public string Text { get; set; }
    }
}
