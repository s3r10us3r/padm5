using padm5.maui.Services;
using padm5.maui.ViewModels;

namespace padm5.maui
{
    public partial class AppShell : Shell
    {
        public AppShell(MainPage view)
        {
            InitializeComponent();
            var mainPage = new ShellContent
            {
                Title = "Home",
                Content = view,
                Route = "Home"
            };
            Items.Add(mainPage);

            Routing.RegisterRoute(nameof(DepartmentDetailsPage), typeof(DepartmentDetailsPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(TeamDetailsPage), typeof(TeamDetailsPage));
            Routing.RegisterRoute(nameof(WorkerListPage), typeof(WorkerListPage));
            Routing.RegisterRoute(nameof(NewWorkerPage), typeof(NewWorkerPage));
            Routing.RegisterRoute(nameof(WorkerDetailsPage), typeof(WorkerDetailsPage));
            Routing.RegisterRoute(nameof(UpdateWorkerPage), typeof(UpdateWorkerPage));
            Routing.RegisterRoute(nameof(NewDepartmentPage), typeof(NewDepartmentPage));
            Routing.RegisterRoute(nameof(NewTeamPage), typeof(NewTeamPage));
            Routing.RegisterRoute(nameof(EditTeamPage), typeof(EditTeamPage));
        }
    }
}
