using HCM.API.Employees;
using HCM.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddApiEmployees();
    builder.Services.AddInfrastructure(
        connectionString!,
        builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthentication();
    app.UseAuthorization();

    app.RegisterEndpoints();

    app.Run();
}