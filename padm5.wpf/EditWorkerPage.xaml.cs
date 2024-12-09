using padm5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace padm5.wpf
{
    /// <summary>
    /// Logika interakcji dla klasy EditWorkerPage.xaml
    /// </summary>
    public partial class EditWorkerPage : Page
    {
        public EditWorkerPage(int id, ViewModelFactory factory)
        {
            DataContext = factory.CreateUpdateWorkerViewModel(id);
            InitializeComponent();
        }
    }
}
