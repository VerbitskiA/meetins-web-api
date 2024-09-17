using Meetins.Abstractions.Repositories;
using Meetins.Core.Data;
using Meetins.Models.MainPage.Output;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Meetins.Core.Logger;
using System;

namespace Meetins.Services.MainPage
{
    //TODO: переименовать в MainPageRepository
    public class AboutRepository : IAboutRepository
    {
        private IDataContext _dataContext;

        public AboutRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<AboutsOutput>> GetAboutsAsync()
        {
            try
            {
                var result = await (from a in _dataContext.Abouts
                                    select new AboutsOutput
                                    {
                                        MainText = a.MainText,
                                        Description = a.Description
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
    }
}
