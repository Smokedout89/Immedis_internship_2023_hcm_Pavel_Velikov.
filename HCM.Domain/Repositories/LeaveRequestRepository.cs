namespace HCM.Domain.Repositories;

using Abstractions.Models;
using Abstractions.Repositories;

using MapsterMapper;
using PostgresModels;

public class LeaveRequestRepository 
    : Repository<LeaveRequest, LeaveRequestDb>, ILeaveRequestRepository
{
    public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
    }
}