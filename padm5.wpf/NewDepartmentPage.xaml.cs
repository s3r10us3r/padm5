using padm5.ViewModels;
using System.Windows.Controls;

namespace padm5.wpf
{
    /// <summary>
    /// Logika interakcji dla klasy NewDepartmentPage.xaml
    /// </summary>
    public partial class NewDepartmentPage : Page
    {
        public NewDepartmentPage(ViewModelFactory factory)
        {
            DataContext = factory.CreateNewDepartmentViewModel();
            InitializeComponent();
        }
    }
}
