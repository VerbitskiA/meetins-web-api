﻿using Meetins.Abstractions.Repositories;
using Meetins.Abstractions.Services;
using Meetins.Core.Data;
using Meetins.Core.Logger;
using Meetins.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetins.Services.Common
{
    /// <summary>
    /// Сервис общего функционала.
    /// </summary>
    public class CommonService : ICommonService
    {
        private ICommonRepository _commonRepository;
        private PostgreDbContext _postgreDbContext;

        public CommonService(ICommonRepository commonRepository, PostgreDbContext postgreDbContext)
        {
            _commonRepository = commonRepository;
            _postgreDbContext = postgreDbContext;
        }

        /// <summary>
        /// Метод генерирует 6-значный цифробуквенный код.
        /// </summary>
        /// <returns>6-значный цифробуквенный код.</returns>
        public async Task<string> GenerateCodeAsync()
        {
            Random random = new Random();

            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var chars = Enumerable.Range(0, 6)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        /// <summary>
        /// Получение списка всех городов пользователей из БД.
        /// </summary>
        /// <returns> Список всех городов пользователей из БД. </returns>
        public async Task<IEnumerable<CityOutput>> GetAllCitiesAsync()
        {
            try
            {
                var result = await _commonRepository.GetAllCitiesAsync();

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
