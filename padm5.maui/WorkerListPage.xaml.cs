using padm5.ViewModels;

namespace padm5.maui;

public partial class WorkerListPage : ContentPage
{
	public WorkerListPage(ViewModelFactory factory)
	{
		InitializeComponent();
        SetBackButtonBehavior();
		BindingContext = factory.CreateWorkerListViewModel();
	}
    private void SetBackButtonBehavior()
    {
        var backButtonBehavior = new BackButtonBehavior
        {
            Command = new Command(async () =>
            {
                // Navigate to MainPage
                await Shell.Current.Navigation.PopToRootAsync();
            })
        };
        Shell.SetBackButtonBehavior(this, backButtonBehavior);
    }
}