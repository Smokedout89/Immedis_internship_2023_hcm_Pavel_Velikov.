namespace HCM.API.Identity.Features.Roles.Handlers;

using HCM.Domain.Abstractions.Models;
using HCM.Domain.Abstractions.Repositories;
using HCM.Infrastructure.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Requests;
using Responses;

public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, IResult>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Role> _roleRepository;

    public CreateRoleHandler(IRepository<Role> roleRepository, IMapper mapper)
    {
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    public async Task<IResult> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var role = new Role { Name = request.Name };

        await _roleRepository.AddAsync(role);

        var model = _mapper.Map<CreateRoleResponse>(role);

        return Response.OkData(model);
    }
}