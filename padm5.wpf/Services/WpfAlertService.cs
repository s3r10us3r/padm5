using padm5.ViewModels.Interfaces;
using System.Windows;

namespace padm5.wpf.Services
{
    public class WpfAlertService : IAlertService
    {
        public async Task ShowAlert(string title, string message, string cancel)
        {
            MessageBox.Show(title, message, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
