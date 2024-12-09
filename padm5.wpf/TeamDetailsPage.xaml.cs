using padm5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace padm5.wpf
{
    /// <summary>
    /// Logika interakcji dla klasy TeamDetailsPage.xaml
    /// </summary>
    public partial class TeamDetailsPage : Page
    {
        public TeamDetailsPage(int id, ViewModelFactory factory)
        {
            DataContext = factory.CreateTeamDetailsViewModel(id);
            InitializeComponent();
        }
    }
}
