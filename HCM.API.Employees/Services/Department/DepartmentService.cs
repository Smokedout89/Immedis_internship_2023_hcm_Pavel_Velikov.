namespace HCM.API.Employees.Services.Department;

using Infrastructure.Responses;
using Domain.Abstractions.Models;
using Features.Department.Requests;
using Features.Department.Responses;
using Domain.Abstractions.Repositories;

using MapsterMapper;

public class DepartmentService : IDepartmentService
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IMapper mapper, IDepartmentRepository departmentRepository)
    {
        _mapper = mapper;
        _departmentRepository = departmentRepository;
    }

    public async Task<IResult> CreateDepartment(CreateDepartmentRequest request)
    {
        var isCreated = await _departmentRepository.GetDepartmentByName(request.Name);

        if (isCreated is not null)
        {
            return Response.BadRequest("Department is already created.");
        }

        var department = new Department { Name = request.Name };
        await _departmentRepository.AddAsync(department);

        return Response.OkData(_mapper.Map<DepartmentResponse>(department));
    }

    public async Task<IResult> GetDepartmentById(string id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);

        if (department is null)
        {
            return Response.BadRequest("There is no Department with the provided Id.");
        }

        return Response.OkData(_mapper.Map<DepartmentResponse>(department));
    }

    public async Task<IResult> GetDepartments()
    {
        var departments = await _departmentRepository.GetAllAsync();
        var departmentsToReturn = departments.Select(
            department => _mapper.Map<DepartmentResponse>(department)).ToList();

        return Response.OkData(departmentsToReturn);
    }

    public async Task<IResult> UpdateDepartment(UpdateDepartmentRequest request)
    {
        var department = await _departmentRepository.GetByIdAsNoTracking(request.Id);

        if (department is null)
        {
            return Response.BadRequest("There is no Department with the provided Id.");
        }

        department.Name = request.Name;
        await _departmentRepository.UpdateAsync(department);

        return Response.OkData(_mapper.Map<DepartmentResponse>(department));
    }

    public async Task<IResult> DeleteDepartment(string id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);

        if (department is null)
        {
            return Response.BadRequest("There is no Department with the provided Id.");
        }

        await _departmentRepository.DeleteAsync(id);

        return Response.Ok();
    }
}