using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.models.Dtos;
using padm5.ViewModels.Helpers;
using padm5.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace padm5.ViewModels
{
    public partial class EditTeamViewModel : ObservableObject
    {
        private readonly IBaseWebService _webService;
        private readonly INavigationManager _navigationManager;
        private readonly int _id;

        public EditTeamViewModel(int id, IBaseWebService webService, INavigationManager navigationManager)
        {
            _webService = webService;
            _navigationManager = navigationManager;
            _id = id;
            TeamDto = new TeamDto { Workers = new List<WorkerDtoWithId>() };
            LoadData();
        }

        [ObservableProperty]
        private TeamDto teamDto;

        [ObservableProperty]
        private ObservableCollection<WorkerSelectable> allWorkers;

        private async Task LoadData()
        {
            var team = await _webService.GetOne<Team>(_id);
            if (team == null)
            {
                await _navigationManager.NavigateToNotFound();
                return;
            }

            TeamDto = new TeamDto
            {
                Name = team.Name,
                DepartmentId = team.DepartmentId,
                Workers = team.Workers.Select(w => w.ToDto()).ToList()
            };

            var workerModels = await _webService.GetAll<Worker>();
            var dtos = workerModels.Select(w => w.ToDto()).ToList();

            var workerSelectables = dtos.Select(dto => new WorkerSelectable(dto)).ToList();

            // Set IsSelected based on whether worker is in TeamDto.Workers
            foreach (var workerSelectable in workerSelectables)
            {
                if (TeamDto.Workers.Any(w => w.Id == workerSelectable.Worker.Id))
                {
                    workerSelectable.IsSelected = true;
                }

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
            await _webService.UpdateOne<Team>(_id, TeamDto);
            await _navigationManager.NavigateToTeamDetails(_id);
        }
    }
}
