using padm5.ViewModels;
namespace padm5.maui;

[QueryProperty("DepartmentId", "id")]
public partial class NewTeamPage : ContentPage
{
	private readonly ViewModelFactory _factory;

	private int id;

	public int DepartmentId
	{
		get => id;
		set
		{
			id = value;
			BindingContext = _factory.CreateNewTeamViewModel(id);
		}
	}


	public NewTeamPage(ViewModelFactory factory)
	{
		_factory = factory;
		InitializeComponent();
	}
}