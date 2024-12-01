using Microsoft.EntityFrameworkCore;
using padm5.models;

namespace padm5.dal
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerProfile> WorkerProfiles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Server=DESKTOP-867RC1J;Database=Company;Trusted_Connection=true;TrustServerCertificate=true")
            .UseSeeding((context, _) =>
            {
                var testDepartment = context.Set<Department>().FirstOrDefault(d => d.Name == "Test");
                if (testDepartment == null)
                {
                    Seed(context);
                    context.SaveChanges();
                }

            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                var testDepartment = context.Set<Department>().FirstOrDefault(d => d.Name == "Test");
                if (testDepartment == null)
                {
                    Seed(context);
                    await context.SaveChangesAsync();
                }
            });

        private void Seed(DbContext context)
        {
            var emptyDepartment = new Department() { Name = "Test" };
            var department1 = new Department() { Name = "Mobile app" };
            var department2 = new Department() { Name = "Desktop app" };

            var team1 = new Team() { Name = "Backend", Department = department1 };
            var team2 = new Team() { Name = "DevOps", Department = department1 };
            var team3 = new Team() { Name = "UI/UX", Department = department2 };
            var team4 = new Team() { Name = "Frontend", Department = department2 };

            var worker1 = new Worker() { FirstName = "Mikołaj", LastName = "Tradecki", Position = "Junior developer", Salary = 500, Teams = [team1] };
            var worker2 = new Worker() { FirstName = "Jon", LastName = "Doe", Position = "Mid developer", Salary = 2000, Teams = [team1] };
            var worker3 = new Worker() { FirstName = "Bob", LastName = "Ross", Position = "Senior developer", Salary = 10000, Teams = [team1, team2] };

            var worker4 = new Worker() { FirstName = "Julia", LastName = "Nowak", Position = "Graphic designer", Salary = 1000, Teams = [team3] };
            var worker5 = new Worker() { FirstName = "Marcin", LastName = "Krystian", Position = "UX designer", Salary = 3000, Teams = [team3] };
            var worker6 = new Worker() { FirstName = "George", LastName = "Michael", Position = "Senior button designer", Salary = 10000, Teams = [team4] };
            var worker7 = new Worker() { FirstName = "Karol", LastName = "Wojtyła", Position = "Senior pope", Salary = 0, Teams = [team4] };

            var worker8 = new Worker() { FirstName ="J", LastName = "Star", Position = "Seniot", Salary = 1_000_000, Teams = [team1, team2, team3, team4] };

            context.AddRange([emptyDepartment, department1, department2]);

            context.AddRange([team1, team2, team3, team4]);
            context.AddRange([worker1, worker2, worker3, worker4, worker5, worker6, worker7, worker8]);
        }
    }
}
