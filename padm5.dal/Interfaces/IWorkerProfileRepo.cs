using padm5.models;

namespace padm5.dal.Interfaces
{
    public interface IWorkerProfileRepo : IRepo<WorkerProfile>
    {
        public Task<WorkerProfile?> GetOneWithWorkerId(int workerId);
    }
}
