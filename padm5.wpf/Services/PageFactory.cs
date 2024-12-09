using Microsoft.Extensions.DependencyInjection;
using padm5.ViewModels;

namespace padm5.wpf.Services
{
    public static class PageFactory
    {
        public static DepartmentListPage CreateDepartmentListPage()
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new DepartmentListPage(factory);
        }

        public static NewDepartmentPage CreateNewDepartmentPage()
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new NewDepartmentPage(factory);
        }

        public static DepartmentDetailsPage CreateDepartmentDetailsPage(int id)
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new DepartmentDetailsPage(id, factory);
        }

        public static TeamDetailsPage CreateTeamDetailsPage(int id)
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new TeamDetailsPage(id, factory);
        }

        public static NewTeamPage CreateNewTeamPage(int id)
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new NewTeamPage(id, factory);
        }

        public static EditTeamPage EditTeamPage(int id)
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new EditTeamPage(id, factory);
        }

        public static WorkerListPage CreateWorkerListPage()
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new WorkerListPage(factory);
        }

        public static NewWorkerPage CreateNewWorkerPage()
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new NewWorkerPage(factory);
        }

        public static WorkerDetailsPage CreateWorkerDetailsPage(int id)
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new WorkerDetailsPage(id, factory);
        }

        public static EditWorkerPage CreateEditWorkerPage(int id)
        {
            var factory = App.ServiceProvider.GetRequiredService<ViewModelFactory>();
            return new EditWorkerPage(id, factory);
        }
    }
}
