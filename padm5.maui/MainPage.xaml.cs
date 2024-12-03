using padm5.ViewModels;

namespace padm5.maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            BindingContext = viewModelFactory.CreateMainPageViewModel();
        }
    }
}
