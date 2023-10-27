using HCM.Api.Identity;
using HCM.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
    builder.Services.AddApiIdentity();
    builder.Services.AddInfrastructure(
        connectionString!,
        builder.Configuration);
}

var app = builder.Build();
{
    app.Services.ApplicationSeeder();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.RegisterEndpoints();

    app.Run();
}