using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.frontend.webServices.Interfaces;
using padm5.models;
using padm5.ViewModels.Interfaces;

namespace padm5.ViewModels
{
    public partial class TeamDetailsViewModel : ObservableObject
    {
        private readonly IBaseWebService _webService;
        private readonly INavigationManager _navigationManager;
        private readonly int _id;

        public TeamDetailsViewModel(int id, IBaseWebService webService, INavigationManager navigationManager) 
        {
            _id = id;
            _webService = webService;
            _navigationManager = navigationManager;
            LoadData();
        }

        [ObservableProperty]
        private Team _teamModel;

        private async Task LoadData()
        {
            TeamModel = await _webService.GetOne<Team>(_id);
        }

        [RelayCommand]
        private async Task EditTeam()
        {
            await _navigationManager.NavigateToEditTeam(_id);
        }

        [RelayCommand]
        private async Task DeleteTeam()
        {
            await _webService.DeleteOne<Team>(_id);
            await _navigationManager.NavigateToDepartmentDetails(_teamModel.DepartmentId);
        }
    }
}
