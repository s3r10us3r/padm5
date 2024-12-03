using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.models.Dtos;
using padm5.ViewModels.Interfaces;

namespace padm5.ViewModels
{
    public partial class NewDepartmentViewModel : ObservableObject
    {
        private IBaseWebService _webService;
        private INavigationManager _navigationManager;
        public NewDepartmentViewModel(IBaseWebService webService, INavigationManager navigationManager)
        {
            _webService = webService;
            _navigationManager = navigationManager;
        }

        [ObservableProperty]
        private DepartmentDto _department = new();

        [RelayCommand]
        public async Task Submit()
        {
            var model = await _webService.AddOne<Department>(Department);
            await _navigationManager.NavigateToDepartmentDetails(model.Id);
        }
    }
}
