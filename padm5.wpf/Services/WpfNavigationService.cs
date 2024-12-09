using padm5.ViewModels.Interfaces;

namespace padm5.wpf.Services
{
    public class WpfNavigationManager : INavigationManager
    {
        public Task NavigateEditDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToDepartmentDetails(int id)
        {
            var page = PageFactory.CreateDepartmentDetailsPage(id);
            MainWindow.NavigationFrame.Navigate(page);
        }

        public async Task NavigateToDepartmentList()
        {
            var page = PageFactory.CreateDepartmentListPage();
            MainWindow.NavigationFrame.Navigate(page);
        }

        public async Task NavigateToEditTeam(int id)
        {
            var page = PageFactory.EditTeamPage(id);
            MainWindow.NavigationFrame.Navigate(page);
        }

        public async Task NavigateToEditWorker(int id)
        {
            var page = PageFactory.CreateEditWorkerPage(id);
            MainWindow.NavigationFrame.Navigate(page);
        }

        public Task NavigateToError()
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToNewDepartment()
        {
            var page = PageFactory.CreateNewDepartmentPage();
            MainWindow.NavigationFrame.Navigate(page);
        }

        public async Task NavigateToNewTeam(int departmentId)
        {
            var page = PageFactory.CreateNewTeamPage(departmentId);
            MainWindow.NavigationFrame.Navigate(page);  
        }

        public async Task NavigateToNewWorker()
        {
            var page = PageFactory.CreateNewWorkerPage();
            MainWindow.NavigationFrame.Navigate(page);
        }

        public Task NavigateToNotFound()
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToTeamDetails(int id)
        {
            var page = PageFactory.CreateTeamDetailsPage(id);
            MainWindow.NavigationFrame.Navigate(page);
        }

        public async Task NavigateToWorkerDetails(int id)
        {
            var page = PageFactory.CreateWorkerDetailsPage(id);
            MainWindow.NavigationFrame.Navigate(page);
        }

        public async Task NavigateToWorkerList()
        {
            var page = PageFactory.CreateWorkerListPage();
            MainWindow.NavigationFrame.Navigate(page);
        }
    }
}
