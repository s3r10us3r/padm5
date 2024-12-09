using padm5.ViewModels;
using System.Windows.Controls;

namespace padm5.wpf
{
    /// <summary>
    /// Logika interakcji dla klasy NewWorkerPage.xaml
    /// </summary>
    public partial class NewWorkerPage : Page
    {
        public NewWorkerPage(ViewModelFactory factory)
        {
            DataContext = factory.CreateNewWorkerViewModel();
            InitializeComponent();
        }
    }
}
