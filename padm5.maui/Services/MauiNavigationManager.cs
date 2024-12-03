using padm5.ViewModels.Interfaces;

namespace padm5.maui.Services
{
    public class MauiNavigationManager : INavigationManager
    {
        public Task NavigateEditDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToDepartmentDetails(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(DepartmentDetailsPage)}?id={id}");
        }

        public async Task NavigateToDepartmentList()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }

        public async Task NavigateToEditTeam(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(EditTeamPage)}?id={id}");
        }

        public async Task NavigateToEditWorker(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(UpdateWorkerPage)}?id={id}");
        }

        public Task NavigateToError()
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToNewDepartment()
        {
            await Shell.Current.GoToAsync(nameof(NewDepartmentPage));
        }

        public async Task NavigateToNewTeam(int departmentId)
        {
            await Shell.Current.GoToAsync($"{nameof(NewTeamPage)}?id={departmentId}");
        }

        public async Task NavigateToNewWorker()
        {
            await Shell.Current.GoToAsync(nameof(NewWorkerPage));
        }

        public Task NavigateToNotFound()
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToTeamDetails(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(TeamDetailsPage)}?id={id}");
        }

        public async Task NavigateToWorkerDetails(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(WorkerDetailsPage)}?id={id}");
        }

        public async Task NavigateToWorkerList()
        {
            await Shell.Current.GoToAsync(nameof(WorkerListPage));
        }
    }
}
