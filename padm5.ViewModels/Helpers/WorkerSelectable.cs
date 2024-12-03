using CommunityToolkit.Mvvm.ComponentModel;
using padm5.models.Dtos;

namespace padm5.ViewModels.Helpers
{
    public partial class WorkerSelectable : ObservableObject
    {
        public WorkerDtoWithId Worker { get; }

        [ObservableProperty]
        private bool isSelected;

        public WorkerSelectable(WorkerDtoWithId worker)
        {
            Worker = worker;
        }
    }
}
