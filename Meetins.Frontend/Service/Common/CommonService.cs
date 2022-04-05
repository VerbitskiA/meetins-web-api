using Meetins.Models.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Meetins.Frontend.Service
{
    public class CommonService : ICommonService
    {
        private readonly HttpClient _httClient;
        public CommonService(HttpClient httClient)
        {
            _httClient = httClient;
        }
        public async Task<List<CityOutput>> GetAllCities()
        {
            var cities = await _httClient.GetFromJsonAsync<List<CityOutput>>("/common/cities");
            return cities;
        }
    }
}
