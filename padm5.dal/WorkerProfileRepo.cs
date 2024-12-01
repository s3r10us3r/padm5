using Microsoft.EntityFrameworkCore;
using padm5.dal.Interfaces;
using padm5.models;

namespace padm5.dal
{
    public class WorkerProfileRepo : BaseRepo<WorkerProfile>, IWorkerProfileRepo
    {
        public WorkerProfileRepo(CompanyDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<WorkerProfile?> GetOneWithWorkerId(int workerId)
        {
            var profile = await Table.FirstOrDefaultAsync(p => p.WorkerId == workerId);
            return profile;
        }

        public override async Task<WorkerProfile> LoadProperties(WorkerProfile entity)
        {
            return entity;
        }
    }
}
