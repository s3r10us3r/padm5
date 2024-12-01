using padm5.blazor.Components;
using padm5.frontend.webServices;
using padm5.frontend.webServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(@"https://localhost:7299");
});
builder.Services.AddSingleton<IBaseWebService, BaseWebService>()
    .AddHttpClient<BaseWebService>("ApiClient");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
