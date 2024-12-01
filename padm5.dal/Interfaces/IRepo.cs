using padm5.models;

namespace padm5.dal.Interfaces
{
    public interface IRepo<T> where T : Entity
    {
        Task<T?> GetOneAsync(int id);
        public Task<List<T>> GetRangeAsync(IEnumerable<int> ids);
        Task<List<T>> GetAllAsync();
        Task<int> AddRangeAsync(IEnumerable<T> entitites);
        Task<int> AddAsync(T entity);
        Task<int> UpdateOneAsync(T entity);
        Task<int> DeleteOneAsync(T entity);
        Task<int> DeleteOneAsync(int id);
        Task<int> DeleteRangeAsync(IEnumerable<T> entities);
        Task<T> LoadProperties(T entity);
    }
}
