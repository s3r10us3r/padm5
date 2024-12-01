using padm5.frontend.webServices.Interfaces;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace padm5.frontend.webServices
{
    public class BaseWebService : IBaseWebService
    {
        private readonly HttpClient _client;
        protected HttpClient Client => _client;
        private const string ApiAddress = @"https://localhost:7299/api";
        public BaseWebService(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> AddOne<T>(object entity) where T : class
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(GetUri<T>() + "/add", entity);
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            var result = await response.Content.ReadFromJsonAsync<T>();
            return result!;
        }

        public async Task<HttpStatusCode> DeleteOne<T>(int id) where T : class
        {
            HttpResponseMessage response = await Client.DeleteAsync(GetUri<T>() + $"/delete/{id}");
            return response.StatusCode;
        }

        public async Task<List<T>?> GetAll<T>() where T : class
        {
            HttpResponseMessage response = await Client.GetAsync(GetUri<T>() + "/getAll");
            Console.WriteLine(GetUri<T>() + "/getAll");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<T>>();
                return result;
            }
            return null;
        }

        public async Task<T?> GetOne<T>(int id) where T : class
        {
            var response = await Client.GetAsync(GetUri<T>() + $"/getOne/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result;
            }
            return null;
        }

        public async Task UpdateOne<T>(int id, object entity) where T : class
        {
            var response = await Client.PutAsJsonAsync(GetUri<T>() + $"/update/{id}", entity);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();
        }

        private string GetUri<T>() => ApiAddress + "/" + typeof(T).Name + "s";
    }
}
