namespace Meetins.Models.User.Output
{
    /// <summary>
    /// Модель статуса блокировки пользователя
    /// </summary>
    public class LockoutStatusOutput
    {
        /// <summary>
        /// Заблокирован ли пользователь
        /// </summary>
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// Дата конца блокировки пользователя
        /// </summary>
        public string LockoutEnd { get; set; }
    }
}
