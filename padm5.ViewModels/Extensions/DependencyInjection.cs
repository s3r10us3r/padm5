using Microsoft.Extensions.DependencyInjection;

namespace padm5.ViewModels.Extensions
{
    public static class DependencyInjection
    {
        public static void AddViewModelFactory(this IServiceCollection services)
        {
            services.AddScoped<ViewModelFactory>();
        }
    }
}
