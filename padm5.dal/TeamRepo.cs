using padm5.dal.Interfaces;
using padm5.models;

namespace padm5.dal
{
    public class TeamRepo : BaseRepo<Team>, ITeamRepo
    {
        public TeamRepo(CompanyDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Team> LoadProperties(Team entity)
        {
            await Table.Entry(entity)
                .Collection(t => t.Workers)
                .LoadAsync();

            await Table.Entry(entity)
                .Reference(t => t.Department)
                .LoadAsync();

            return entity;
        }
    }
}
