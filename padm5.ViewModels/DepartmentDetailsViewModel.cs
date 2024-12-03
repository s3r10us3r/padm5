using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.ViewModels.Interfaces;

namespace padm5.ViewModels
{
    public partial class DepartmentDetailsViewModel : ObservableObject
    {
        private readonly IBaseWebService baseWebService;
        private readonly INavigationManager navigationManager;

        public DepartmentDetailsViewModel(int id, IBaseWebService baseWebService, INavigationManager navigationManager)
        {
            this.baseWebService = baseWebService;
            this.navigationManager = navigationManager;
            LoadDepartment(id);
        }

        [ObservableProperty]
        private Department viewDepartment;

        private async void LoadDepartment(int id)
        {
            var department = await baseWebService.GetOne<Department>(id);
            if (department == null)
            {
                await navigationManager.NavigateToNotFound();
            }
            else
            {
                ViewDepartment = department;
            }
        }

        [RelayCommand]
        public async Task EditDepartment()
        {
            await navigationManager.NavigateEditDepartment(ViewDepartment.Id);
        }

        [RelayCommand]
        public async Task DeleteDepartment()
        {
            await baseWebService.DeleteOne<Department>(ViewDepartment.Id);
            await navigationManager.NavigateToDepartmentList();
        }

        [RelayCommand]
        public async Task AddTeam()
        {
            await navigationManager.NavigateToNewTeam(ViewDepartment.Id);
        }

        [RelayCommand]
        public async Task TeamDetails(int id)
        {
            await navigationManager.NavigateToTeamDetails(id);
        }
    }
}
