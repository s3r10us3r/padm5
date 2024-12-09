using padm5.ViewModels;
using padm5.wpf.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace padm5.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame NavigationFrame { get; set; }

        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            NavigationFrame = MainFrame;
            DataContext = viewModel;
        }
    }
}