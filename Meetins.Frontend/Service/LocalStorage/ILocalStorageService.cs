using System.Threading.Tasks;

namespace Meetins.Frontend.Service
{
    public interface ILocalStorageService
    {
        public Task SetAsync<T>(string key, T item) where T : class;
        public Task SetStringAsync(string key, string value);
        public Task<T> GetAsync<T>(string key) where T : class;
        public Task<string> GetStringAsync(string key);
        public Task RemoveAsync(string key);
    }
}
