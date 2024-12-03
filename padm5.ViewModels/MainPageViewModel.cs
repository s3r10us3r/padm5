using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.ViewModels.Interfaces;
using System.Collections.ObjectModel;

namespace padm5.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IBaseWebService baseWebService;
        private readonly INavigationManager navigationManager;
        private readonly IAlertService alertService;

        public MainPageViewModel(IBaseWebService baseWebService, INavigationManager navigationManager, IAlertService alertService)
        {
            this.baseWebService = baseWebService;
            this.navigationManager = navigationManager;
            this.alertService = alertService;
            LoadDepartments();
        }

        [ObservableProperty]
        private ObservableCollection<Department> departmentList = [];

        private async Task LoadDepartments()
        {
            var departments = await baseWebService.GetAll<Department>();
            if (departments == null)
            {
                await navigationManager.NavigateToError();
            }
            else
            {
                DepartmentList = new ObservableCollection<Department>(departments);
            }
        }

        [RelayCommand]
        public async Task ShowDetails(int id)
        {
            await navigationManager.NavigateToDepartmentDetails(id);
        }
        
        [RelayCommand]
        public async Task Delete(int id)
        {
            await baseWebService.DeleteOne<Department>(id);
            await LoadDepartments();
        }

        [RelayCommand]
        public async Task Edit(int id)
        {
            await navigationManager.NavigateEditDepartment(id);
        }

        [RelayCommand]
        public async Task NewDepartment()
        {
            await navigationManager.NavigateToNewDepartment();
        }

        [RelayCommand]
        public async Task ViewWorkerList()
        {
            await navigationManager.NavigateToWorkerList();
        }
    }
}
