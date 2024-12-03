using padm5.maui.Extensions;
using padm5.ViewModels;

namespace padm5.maui;

[QueryProperty(nameof(WorkerId), "id")]
public partial class WorkerDetailsPage : ContentPage
{
	private int id;
	public int WorkerId
	{
		get => id;
		set
		{
			id = value;
			BindingContext = _factory.CreateWorkerDetailsViewModel(id);
		}
	}

	private readonly ViewModelFactory _factory;

	public WorkerDetailsPage(ViewModelFactory factory)
	{
		_factory = factory;
		InitializeComponent();
		this.SetBackButtonBehavior();
	}


}