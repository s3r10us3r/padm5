namespace padm5.dal.Interfaces
{
    public interface IQueryExecutor
    {
        public Task ExecuteQueryRaw(FormattableString query);
        public Task<T> ExecuteQuery<T>(FormattableString query);
    }
}
