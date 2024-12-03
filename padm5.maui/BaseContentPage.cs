using Microsoft.Maui.Controls;

namespace padm5.maui
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            SetBackButtonBehavior();
        }

        private void SetBackButtonBehavior()
        {
            var backButtonBehavior = new BackButtonBehavior
            {
                Command = new Command(async () =>
                {
                    await Shell.Current.GoToAsync("//MainPage");
                })
            };
            Shell.SetBackButtonBehavior(this, backButtonBehavior);
        }
    }
}

