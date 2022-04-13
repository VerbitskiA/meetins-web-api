using Meetins.Abstractions.Repositories;
using Meetins.Core.Data;
using Meetins.Core.Logger;
using Meetins.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetins.Services.Common
{
    /// <summary>
    /// В реппозитории содержится общий функционал.
    /// </summary>
    public class CommonRepository : ICommonRepository
    {
        private PostgreDbContext _postgreDbContext;

        public CommonRepository(PostgreDbContext postgreDbContext)
        {
            _postgreDbContext = postgreDbContext;
        }

        /// <summary>
        /// Получение списка всех городов.
        /// </summary>
        /// <returns> Список всех городов. </returns>
        public async Task<IEnumerable<CityOutput>> GetAllCitiesAsync()
        {
            try
            {
                var result = await _postgreDbContext.Cities
                .Select(city => new CityOutput
                {
                    CityId = city.CityId,
                    CityName = city.CityName,
                    HasKudagoEvents = city.HasKudagoEvents
                })
                .ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_postgreDbContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
                throw;
            }
        }

        /// <summary>
        /// Метод получает число зарегистрированных пользователей за последние сутки
        /// </summary>
        /// <returns>Число зарегистрированных пользователей</returns>
        public async Task<int> GetRegistrationsForLast24HoursAsync()
        {
            try
            {
                var result = _postgreDbContext.Users
                    .Where(user => user.DateRegister.Day == DateTime.Now.Day && user.DateRegister.Month == DateTime.Now.Month && user.DateRegister.Year == DateTime.Now.Year).Count();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_postgreDbContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
                throw;
            }
        }
    }
}
