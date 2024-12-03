namespace padm5.maui.Extensions
{
    internal static class Helpers
    {
        public static void SetBackButtonBehavior(this ContentPage page)
        {
            var backButtonBehavior = new BackButtonBehavior
            {
                Command = new Command(async () =>
                {
                    // Navigate to MainPage
                    await Shell.Current.Navigation.PopToRootAsync();
                })
            };
            Shell.SetBackButtonBehavior(page, backButtonBehavior);
        }
    }
}
