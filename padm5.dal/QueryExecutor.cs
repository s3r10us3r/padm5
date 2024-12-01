using Microsoft.EntityFrameworkCore;
using padm5.dal.Interfaces;

namespace padm5.dal
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly CompanyDbContext _dbContext;
        public QueryExecutor(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<T> ExecuteQuery<T>(FormattableString query)
        {
            throw new NotImplementedException();
        }

        public async Task ExecuteQueryRaw(FormattableString query)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync(query);
        }
    }
}
