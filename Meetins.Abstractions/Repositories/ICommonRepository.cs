using Meetins.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetins.Abstractions.Repositories
{
    /// <summary>
    /// Абстракция для общего репозитория.
    /// </summary>
    public interface ICommonRepository
    {
        /// <summary>
        /// Получение списка всех городов пользователей.
        /// </summary>
        /// <returns> Список всех городов пользователей. </returns>
        Task<IEnumerable<CityOutput>> GetAllCitiesAsync();

        /// <summary>
        /// Метод получает число зарегистрированных пользователей за последние сутки
        /// </summary>
        /// <returns>Число зарегистрированных пользователей</returns>
        Task<int> GetRegistrationsForLast24HoursAsync();
    }
}
