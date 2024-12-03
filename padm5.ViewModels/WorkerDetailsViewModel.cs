using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.ViewModels.Interfaces;

namespace padm5.ViewModels
{
    public partial class WorkerDetailsViewModel : ObservableObject
    {
        private readonly IBaseWebService _webService;
        private readonly INavigationManager _navigationManager;
        private readonly int _id;

        public WorkerDetailsViewModel(int id, IBaseWebService webService, INavigationManager navigationManager)
        {
            _webService = webService;
            _navigationManager = navigationManager;
            _id = id;
            LoadData();
        }

        [ObservableProperty]
        private Worker workerModel;

        [ObservableProperty]
        private string workerModelFullName;

        [ObservableProperty]
        private WorkerProfile? workerProfileModel;

        private async Task LoadData()
        {
            WorkerModel = await _webService.GetOne<Worker>(_id);
            if (WorkerModel == null)
            {
                await _navigationManager.NavigateToNotFound();
            }
            WorkerProfileModel = WorkerModel.Profile;
            WorkerModelFullName = WorkerModel.FirstName + " " + WorkerModel.LastName;
        }

        [RelayCommand]
        private async Task Delete()
        {
            await _webService.DeleteOne<Worker>(_id);
            await _navigationManager.NavigateToWorkerList();
        }

        [RelayCommand]
        private async Task Edit()
        {
            await _navigationManager.NavigateToEditWorker(_id);
        }
    }
}
