using HCM.Domain.Abstractions.Models;

namespace HCM.Infrastructure.Authentication;

public interface IJwtTokenGenerator
{
    Task<string> GenerateToken(User user);
}