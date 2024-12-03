using padm5.ViewModels;

namespace padm5.maui;

public partial class NewWorkerPage : ContentPage
{
	public NewWorkerPage(ViewModelFactory factory)
	{
		InitializeComponent();
		BindingContext = factory.CreateNewWorkerViewModel();
        SetBackButtonBehavior();
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