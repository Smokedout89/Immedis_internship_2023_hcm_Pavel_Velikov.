namespace HCM.API.Identity.Abstractions;

public interface IEndpoint
{
    void RegisterEndpoints(WebApplication app);
}