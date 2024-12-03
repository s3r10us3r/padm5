using Microsoft.Extensions.Logging;
using padm5.frontend.webServices;
using padm5.frontend.webServices.Interfaces;
using padm5.maui.Services;
using padm5.ViewModels.Extensions;
using padm5.ViewModels.Interfaces;

namespace padm5.maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IBaseWebService, BaseWebService>();
            builder.Services.AddSingleton<INavigationManager, MauiNavigationManager>();
            builder.Services.AddSingleton<IAlertService, AlertService>();
            builder.Services.AddViewModelFactory();
            builder.Services.AddPages();
#if DEBUG
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }

        private static void AddPages(this IServiceCollection services)
        {
            services.AddTransient<MainPage>();
            services.AddTransient<DepartmentDetailsPage>();
            services.AddTransient<TeamDetailsPage>();
            services.AddTransient<WorkerListPage>();
            services.AddTransient<NewWorkerPage>();
            services.AddTransient<WorkerDetailsPage>();
            services.AddTransient<UpdateWorkerPage>();
            services.AddTransient<NewDepartmentPage>();
            services.AddTransient<NewTeamPage>();
            services.AddTransient<EditTeamPage>();
        }
    }
}
