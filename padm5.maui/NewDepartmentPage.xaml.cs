using padm5.maui.Extensions;
using padm5.ViewModels;

namespace padm5.maui;

public partial class NewDepartmentPage : ContentPage
{
	public NewDepartmentPage(ViewModelFactory factory)
	{
		InitializeComponent();
		BindingContext = factory.CreateNewDepartmentViewModel();
		this.SetBackButtonBehavior();
	}
}