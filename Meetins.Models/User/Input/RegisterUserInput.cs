using System;

namespace Meetins.Models.User.Input
{
    /// <summary>
    /// Входная модель регистрации пользователя.
    /// </summary>
    public class RegisterUserInput
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Почта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Идентификатор города.
        /// </summary>
        public string CityId { get; set; }
    }
}
