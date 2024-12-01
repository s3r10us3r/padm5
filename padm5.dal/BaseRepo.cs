using Microsoft.EntityFrameworkCore;
using padm5.dal.Interfaces;
using padm5.models;

namespace padm5.dal
{
    public abstract class BaseRepo<T> : IRepo<T> where T : Entity
    {
        private readonly CompanyDbContext _db;
        private readonly DbSet<T> _table;

        protected CompanyDbContext Db => _db;
        protected DbSet<T> Table => _table;

        public BaseRepo(CompanyDbContext dbContext)
        {
            _db = dbContext;
            _table = dbContext.Set<T>();
        }

        public async Task<int> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            return await SaveChangesAsync(); 
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entitites)
        {
            await _table.AddRangeAsync(entitites);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteOneAsync(T entity)
        {
            _table.Remove(entity);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteOneAsync(int id)
        {
            var entity = await GetOneAsync(id);
            if (entity is null)
                return 0;
            return await DeleteOneAsync(entity);
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<T> entities)
        {
            _table.RemoveRange(entities);
            return await SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetOneAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<List<T>> GetRangeAsync(IEnumerable<int> ids)
        {
            var idSet = ids.ToHashSet();
            return await _table.Where(e => idSet.Contains(e.Id)).ToListAsync();
        }

        public async Task<int> UpdateOneAsync(T entity)
        {
            _table.Update(entity);
            return await SaveChangesAsync();
        }

        protected async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public abstract Task<T> LoadProperties(T entity);
    }
}
