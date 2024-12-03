using padm5.maui.Extensions;
using padm5.ViewModels;

namespace padm5.maui;

[QueryProperty(nameof(WorkerId), "id")]
public partial class UpdateWorkerPage : ContentPage
{
	private readonly ViewModelFactory _factory;

	private int id;
	public int WorkerId
	{
		get => id;
		set
		{
			id = value;
			BindingContext = _factory.CreateUpdateWorkerViewModel(id);
		}
	}

	public UpdateWorkerPage(ViewModelFactory factory)
	{
		_factory = factory;
		InitializeComponent();
		this.SetBackButtonBehavior();
	}
}