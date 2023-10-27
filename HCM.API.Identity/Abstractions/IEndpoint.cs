namespace HCM.Api.Identity.Abstractions;

public interface IEndpoint
{
    void RegisterEndpoints(WebApplication app);
}