namespace HCM.Api.Identity.Services.User;

using Features.Users.Requests;
using Infrastructure.Responses;
using Features.Users.Responses;
using Domain.Abstractions.Models;
using Infrastructure.Authentication;
using Domain.Abstractions.Repositories;

using MapsterMapper;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly JwtSettings _jwtSettings;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private static readonly string _pepper = "PasswordHashExamplePepper";
    private static readonly int _iteration = 3;

    public UserService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        JwtSettings jwtSettings,
        IMapper mapper)
    {
        _mapper = mapper;
        _jwtSettings = jwtSettings;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<IResult> Register(CreateUserRequest request)
    {
        var isRegistered = await _userRepository.GetUserByEmailAsync(request.Email);

        if (isRegistered is not null)
        {
            return Response.BadRequest("Email is already registered.");
        }

        var user = new User
        {
            Email = request.Email,
            PasswordSalt = PasswordHasher.GenerateSalt()
        };

        user.PasswordHash = PasswordHasher.ComputeHash(
            request.Password,
            user.PasswordSalt,
            _pepper,
            _iteration);

        var role = await _roleRepository.GetByIdAsync("afa1e622-d20b-4d88-8645-da0886dddd40");
        user.RoleId = role!.Id;

        await _userRepository.AddAsync(user);

        return Response.OkData(new CreateUserResponse 
            { Email = user.Email, Id = user.Id, Role = role.Name });
    }

    public async Task<IResult> Login(LoginUserRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user is null)
        {
            return Response.BadRequest("No registration existing with provided email.");
        }

        var passwordHash = PasswordHasher.ComputeHash(
            request.Password,
            user.PasswordSalt,
            _pepper,
            _iteration);

        if (user.PasswordHash != passwordHash)
        {
            return Response.BadRequest("Incorrect password provided.");
        }

        var role = await _roleRepository.GetByIdAsync(user.RoleId);

        JwtTokenGenerator tokenGenerator = new(
            _jwtSettings, _roleRepository);
        string token = await tokenGenerator.GenerateToken(user);

        return Response.OkData(new LoginUserResponse
            { Id = user.Id, Email = user.Email, Role = role!.Name, Token = token });
    }

    public async Task<IResult> GetUser(string id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
        {
            return Response.BadRequest("There is no user with provided Id.");
        }

        var userRole = await _roleRepository.GetByIdAsync(user.RoleId);
        var userToReturn = _mapper.Map<GetUserResponse>(user);
        userToReturn.Role = userRole!.Name;

        return Response.OkData(userToReturn);
    }

    public async Task<IResult> GetUsers()
    {
        var users = await _userRepository.GetAllAsync();

        var usersToReturn = new List<GetUserResponse>();

        foreach (var user in users)
        {
            var userRole = await _roleRepository.GetByIdAsync(user.RoleId);
            var currentUser = _mapper.Map<GetUserResponse>(user);
            currentUser.Role = userRole!.Name;

            usersToReturn.Add(currentUser);
        }

        return Response.OkData(usersToReturn);
    }

    public async Task<IResult> DeleteUser(string id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
        {
            return Response.BadRequest("There is no user with provided Id.");
        }

        await _userRepository.DeleteAsync(id);

        return Response.Ok();
    }

    public async Task<IResult> PromoteUser(string id)
    {
        var user = await _userRepository.GetByIdAsNoTracking(id);

        if (user is null)
        {
            return Response.BadRequest("There is no user with provided Id.");
        }

        user.RoleId = "506c5148-ffaa-425a-8e39-543a8a494176";
        await _userRepository.UpdateAsync(user);

        return Response.Ok();
    }
}