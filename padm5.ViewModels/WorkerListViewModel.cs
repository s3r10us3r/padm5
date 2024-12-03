using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.ViewModels.Interfaces;
using System.Collections.ObjectModel;

namespace padm5.ViewModels
{
    public partial class WorkerListViewModel : ObservableObject
    {
        private readonly IBaseWebService _webService;
        private readonly INavigationManager _navigationManager;

        public WorkerListViewModel(IBaseWebService webService, INavigationManager navigationManager)
        {
            _webService = webService;
            _navigationManager = navigationManager;
            LoadData();
        }

        [ObservableProperty]
        ObservableCollection<Worker> workers = [];

        private async Task LoadData()
        {
            var allWorkers = await _webService.GetAll<Worker>();
            Workers = new ObservableCollection<Worker>(allWorkers);
        }

        [RelayCommand]
        private async Task ViewDetails(int workerId)
        {
            await _navigationManager.NavigateToWorkerDetails(workerId);
        }

        [RelayCommand]
        private async Task Update(int workerId)
        {
            await _navigationManager.NavigateToEditWorker(workerId);
        }

        [RelayCommand]
        private async Task Delete(int workerId)
        {
            await _webService.DeleteOne<Worker>(workerId);
            await LoadData();
        }

        [RelayCommand]
        private async Task Add()
        {
            await _navigationManager.NavigateToNewWorker();
        }
    }
}
