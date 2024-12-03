using padm5.ViewModels.Interfaces;

namespace padm5.maui.Services
{
    internal class AlertService : IAlertService
    {
        public async Task ShowAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
