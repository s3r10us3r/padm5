using Microsoft.AspNetCore.Components;
using padm5.frontend.webServices.Interfaces;
using padm5.models;

namespace padm5.blazor.Components.Pages
{
    public partial class Home()
    {
        [Inject]
        public IBaseWebService WebService { get; set; }

        private async Task<List<Department>> GetDepartments()
        {
            var result = await WebService.GetAll<Department>();
            return result ?? [];
        }
    }
}
