using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using padm5.ViewModels.Interfaces;

namespace padm5.wpf.ViewModel
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly INavigationManager _navigationManager;

        public MainWindowViewModel(INavigationManager navigationManager) 
        {
            _navigationManager = navigationManager;
            
        }

        [RelayCommand]
        public async Task NavigateToDepartments()
        {
            await _navigationManager.NavigateToDepartmentList();
        }

        [RelayCommand]
        public async Task NavigateToWorkers()
        {
            await _navigationManager.NavigateToWorkerList();
        }
    }
}
