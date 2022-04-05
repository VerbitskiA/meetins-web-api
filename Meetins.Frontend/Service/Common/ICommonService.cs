using Meetins.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meetins.Frontend.Service
{
    public interface ICommonService
    {
        public Task<List<CityOutput>> GetAllCities();
    }
}
