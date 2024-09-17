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
    /// В репозитории содержится общий функционал.
    /// </summary>
    public class CommonRepository : ICommonRepository
    {
        private IDataContext _dataContext;

        public CommonRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Получение списка всех городов.
        /// </summary>
        /// <returns> Список всех городов. </returns>
        public async Task<IEnumerable<CityOutput>> GetAllCitiesAsync()
        {
            try
            {
                var result = await _dataContext.Cities
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
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
                throw;
            }
        }

        /// <summary>
        /// Получение названия города по идентификатору города
        /// </summary>
        /// <param name="cityId">Идентификатор города</param>
        /// <returns>Название города</returns>
        public async Task<string> GetCityNameAsync(Guid cityId)
        {
            try
            {
                var result = await _dataContext.Cities.FirstOrDefaultAsync(city => city.CityId.Equals(cityId));

                return result.CityName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var logger = new Logger(_dataContext, e.GetType().FullName, e.Message, e.StackTrace);
                await logger.LogError();
                throw;
            }
        }
    }
}
