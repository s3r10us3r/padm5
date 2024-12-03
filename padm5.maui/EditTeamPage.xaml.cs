using padm5.maui.Extensions;
using padm5.ViewModels;

namespace padm5.maui;

[QueryProperty(nameof(TeamId), "id")]
public partial class EditTeamPage : ContentPage
{
	private int id;
	public int TeamId
	{
		get => id;
		set
		{
			id = value;
			BindingContext = _factory.CreateEditTeamViewModel(TeamId);
		}
	}

	private readonly ViewModelFactory _factory;

	public EditTeamPage(ViewModelFactory factory)
	{
		_factory = factory;
		InitializeComponent();
		this.SetBackButtonBehavior();
	}
}