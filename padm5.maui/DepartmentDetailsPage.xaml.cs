using padm5.maui.Extensions;
using padm5.ViewModels;

namespace padm5.maui;

[QueryProperty(nameof(DepartmentId), "id")]
public partial class DepartmentDetailsPage : ContentPage
{
	private readonly ViewModelFactory _viewModelFactory;
	private int departmentId;
	public int DepartmentId {
		get => departmentId; 
		set
		{
			departmentId = value;
            BindingContext = _viewModelFactory.CreateDepartmentDetailsViewModel(DepartmentId);
		}
	}


	public DepartmentDetailsPage(ViewModelFactory factory)
	{
		_viewModelFactory = factory;
        InitializeComponent();
		this.SetBackButtonBehavior();
	}
}