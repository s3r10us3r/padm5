using padm5.ViewModels;

namespace padm5.maui;

[QueryProperty(nameof(TeamId), "id")]
public partial class TeamDetailsPage : ContentPage
{
	private readonly ViewModelFactory _factory;

	private int id;
	public int TeamId
	{
		get => id;
		set
		{
			id = value;
			BindingContext = _factory.CreateTeamDetailsViewModel(id);
		}
	}

	public TeamDetailsPage(ViewModelFactory factory)
	{
		_factory = factory;
		InitializeComponent();
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