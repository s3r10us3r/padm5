using padm5.frontend.webServices.Interfaces;
using padm5.ViewModels.Interfaces;

namespace padm5.ViewModels
{
    public class ViewModelFactory(IBaseWebService webService, INavigationManager navigationManager, IAlertService alertService)
    {
        public DepartmentDetailsViewModel CreateDepartmentDetailsViewModel(int id) => new(id, webService, navigationManager);
        public EditTeamViewModel CreateEditTeamViewModel(int id) => new(id, webService, navigationManager);
        public MainPageViewModel CreateMainPageViewModel() => new(webService, navigationManager, alertService);
        public NewDepartmentViewModel CreateNewDepartmentViewModel() => new(webService, navigationManager);
        public NewTeamViewModel CreateNewTeamViewModel(int departmentId) => new(departmentId, webService, navigationManager);
        public NewWorkerViewModel CreateNewWorkerViewModel() => new(webService, navigationManager);
        public TeamDetailsViewModel CreateTeamDetailsViewModel(int id) => new(id, webService, navigationManager);
        public UpdateWorkerViewModel CreateUpdateWorkerViewModel(int id) => new(id, webService, navigationManager);
        public WorkerDetailsViewModel CreateWorkerDetailsViewModel(int id) => new(id, webService, navigationManager);
        public WorkerListViewModel CreateWorkerListViewModel() => new(webService, navigationManager);
    }
}
