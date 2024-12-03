using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.models.Dtos;
using padm5.ViewModels.Helpers;
using padm5.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace padm5.ViewModels
{
    public partial class NewTeamViewModel : ObservableObject
    {
        private readonly IBaseWebService _webService;
        private readonly INavigationManager _navigationManager;

        public NewTeamViewModel(int departmentId, IBaseWebService webService, INavigationManager navigationManager)
        {
            _webService = webService;
            _navigationManager = navigationManager;
            TeamDto = new TeamDto { DepartmentId = departmentId, Workers = new List<WorkerDtoWithId>() };
            LoadWorkers();
        }

        [ObservableProperty]
        private TeamDto teamDto;

        [ObservableProperty]
        private ObservableCollection<WorkerSelectable> allWorkers;


        private async Task LoadWorkers()
        {
            var workerModels = await _webService.GetAll<Worker>();
            var dtos = workerModels.Select(w => w.ToDto()).ToList();

            var workerSelectables = dtos.Select(dto => new WorkerSelectable(dto)).ToList();

            foreach (var workerSelectable in workerSelectables)
            {
                workerSelectable.PropertyChanged += WorkerSelectable_PropertyChanged;
            }

            AllWorkers = new ObservableCollection<WorkerSelectable>(workerSelectables);
        }

        private void WorkerSelectable_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(WorkerSelectable.IsSelected))
            {
                var workerSelectable = sender as WorkerSelectable;
                if (workerSelectable != null)
                {
                    if (workerSelectable.IsSelected)
                    {
                        if (!TeamDto.Workers.Any(w => w.Id == workerSelectable.Worker.Id))
                        {
                            TeamDto.Workers.Add(workerSelectable.Worker);
                        }
                    }
                    else
                    {
                        var existingWorker = TeamDto.Workers.FirstOrDefault(w => w.Id == workerSelectable.Worker.Id);
                        if (existingWorker != null)
                        {
                            TeamDto.Workers.Remove(existingWorker);
                        }
                    }
                }
            }
        }

        [RelayCommand]
        private async Task Submit()
        {
            var model = await _webService.AddOne<Team>(TeamDto);
            await _navigationManager.NavigateToTeamDetails(model.Id);
        }
    }
}

