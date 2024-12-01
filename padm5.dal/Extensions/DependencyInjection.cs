using Microsoft.Extensions.DependencyInjection;
using padm5.dal.Interfaces;

namespace padm5.dal.Extensions
{
    public static class DependencyInjection
    {
        public static void AddCompanyDbContext(this IServiceCollection services)
        {
            services.AddDbContext<CompanyDbContext>();
        }

        public static void AddRepos(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<ITeamRepo, TeamRepo>();
            services.AddScoped<IWorkerProfileRepo, WorkerProfileRepo>();
            services.AddScoped<IWorkerRepo, WorkerRepo>();
            services.AddScoped<IQueryExecutor, QueryExecutor>();
        }
    }
}
