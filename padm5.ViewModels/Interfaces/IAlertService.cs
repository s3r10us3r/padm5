namespace padm5.ViewModels.Interfaces
{
    public interface IAlertService
    {
        Task ShowAlert(string title, string message, string cancel);
    }
}
