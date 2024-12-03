using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.models.Dtos;
using padm5.ViewModels.Interfaces;

namespace padm5.ViewModels
{
    public partial class NewWorkerViewModel : ObservableObject
    {
        private IBaseWebService _webService;
        private INavigationManager _navigationManager;

        public NewWorkerViewModel(IBaseWebService webService, INavigationManager navigationManager)
        {
            _webService = webService;
            _navigationManager = navigationManager;
            MyWorkerDto = new();
        }

        [ObservableProperty]
        private WorkerDto myWorkerDto;

        [RelayCommand]
        private async Task Submit()
        {
            var model = await _webService.AddOne<Worker>(MyWorkerDto);
            if (model == null)
            {
                await _navigationManager.NavigateToError();
                return;
            }
            await _navigationManager.NavigateToWorkerDetails(model.Id);
        }
    }
}
