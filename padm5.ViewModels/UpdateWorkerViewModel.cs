using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.models.Dtos;
using padm5.ViewModels.Interfaces;

namespace padm5.ViewModels
{
    public partial class UpdateWorkerViewModel : ObservableObject
    {
        private readonly IBaseWebService _webService;
        private readonly INavigationManager _navigationManager;
        private readonly int _id;

        public UpdateWorkerViewModel(int id, IBaseWebService webService, INavigationManager navigationManager)
        {
            _webService = webService;
            _navigationManager = navigationManager;
            _id = id;
            LoadData();
        }

        [ObservableProperty]
        private WorkerDto workerDto;

        [ObservableProperty]
        private WorkerProfileDto workerProfileDto;

        private async Task LoadData()
        {
            var workerModel = await _webService.GetOne<Worker>(_id);
            if (workerModel == null)
            {
                await _navigationManager.NavigateToNotFound();
                return;
            }
            WorkerDto = new WorkerDto() { FirstName = workerModel.FirstName, LastName = workerModel.LastName, Position = workerModel.Position, Salary = workerModel.Salary };
            WorkerProfileDto = workerModel.Profile == null ?
                new WorkerProfileDto() :
                new WorkerProfileDto() { Address = workerModel.Profile.Address, Mail = workerModel.Profile.Mail, PhoneNumber = workerModel.Profile.PhoneNumber };
        }

        [RelayCommand]
        private async Task SubmitWorker()
        {
            await _webService.UpdateOne<Worker>(_id, workerDto);
            await _navigationManager.NavigateToWorkerDetails(_id);
        }

        [RelayCommand]
        private async Task SubmitProfile()
        {
            await _webService.UpdateOne<WorkerProfile>(_id, workerProfileDto);
            await _navigationManager.NavigateToWorkerDetails(_id);
        }
    }
}
