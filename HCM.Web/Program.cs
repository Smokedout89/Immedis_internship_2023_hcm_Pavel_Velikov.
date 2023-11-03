using HCM.Web;
using HCM.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWeb(builder.Configuration);

var app = builder.Build();

app.UseCors(c => c.WithOrigins("https://localhost:7070")
    .AllowAnyMethod()
    .AllowAnyHeader());

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.UseMiddleware<ApplicationToken>();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Identity}/{controller=Home}/{action=Index}/{id?}");

app.Run();
