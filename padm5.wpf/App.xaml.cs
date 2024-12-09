using Microsoft.Extensions.DependencyInjection;
using padm5.frontend.webServices;
using padm5.frontend.webServices.Interfaces;
using padm5.ViewModels;
using padm5.ViewModels.Extensions;
using padm5.ViewModels.Interfaces;
using padm5.wpf.Services;
using padm5.wpf.ViewModel;
using System.Windows;

namespace padm5.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INavigationManager, WpfNavigationManager>();
            services.AddViewModelFactory();
            services.AddSingleton<IBaseWebService, BaseWebService>();
            services.AddSingleton<MainWindow>();
            services.AddTransient<MainWindowViewModel>();
            services.AddSingleton<IAlertService, WpfAlertService>();
            services.AddHttpClient();
        }
    }

}
