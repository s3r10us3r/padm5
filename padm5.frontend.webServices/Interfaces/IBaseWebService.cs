using System.Net;

namespace padm5.frontend.webServices.Interfaces
{
    public interface IBaseWebService
    {
        public Task<List<T>?> GetAll<T>() where T : class;
        public Task<T?> GetOne<T>(int ID) where T : class;
        public Task<T> AddOne<T>(object entity) where T : class;
        public Task UpdateOne<T>(int id, object entity) where T : class;

        //here the generic type is needed for uri generation
        public Task<HttpStatusCode> DeleteOne<T>(int id) where T : class;
    }
}
