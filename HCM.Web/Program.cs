using HCM.Web;
using HCM.Web.APIServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWeb();

builder.Services.AddScoped<APIAuthService>();

builder.Services.AddHttpClient("APIAuthService",
    client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiIdentityBaseUrl"]!);
});

builder.Services.AddHttpClient("ApiEmployeeService",
    client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiEmployeeBaseUrl"]!);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
