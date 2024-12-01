using padm5.dal.Interfaces;
using padm5.models;

namespace padm5.dal
{
    public class WorkerRepo : BaseRepo<Worker>, IWorkerRepo
    {
        public WorkerRepo(CompanyDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Worker> LoadProperties(Worker entity)
        {
            var entry = Table.Entry(entity);
            await entry.Collection(e => e.Teams).LoadAsync();
            await entry.Reference(e => e.Profile).LoadAsync();

            return entity;
        }
    }
}
