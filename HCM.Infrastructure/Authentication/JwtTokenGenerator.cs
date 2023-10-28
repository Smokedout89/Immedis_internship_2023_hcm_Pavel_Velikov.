namespace HCM.Infrastructure.Authentication;

using System.Text;
using System.Security.Claims;
using Domain.Abstractions.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Domain.Abstractions.Repositories;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IRoleRepository _roleRepository;

    public JwtTokenGenerator(JwtSettings jwtSettings, IRoleRepository roleRepository)
    {
        _jwtSettings = jwtSettings;
        _roleRepository = roleRepository;
    }

    public async Task<string> GenerateToken(User user)
    {
        var role = await _roleRepository.GetByIdAsync(user.RoleId);

        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);


        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, role!.Name)
        };

        JwtSecurityToken securityToken = new(
            claims: claims,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}