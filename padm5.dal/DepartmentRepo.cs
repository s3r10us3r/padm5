using Microsoft.EntityFrameworkCore.Internal;
using padm5.dal.Interfaces;
using padm5.models;

namespace padm5.dal
{
    public class DepartmentRepo : BaseRepo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(CompanyDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Department> LoadProperties(Department entity)
        {
            await Table.Entry(entity)
                .Collection(entity => entity.Teams)
                .LoadAsync();

            entity.Teams.ForEach(t => t.Department = null);
            return entity;
        }
    }
}
