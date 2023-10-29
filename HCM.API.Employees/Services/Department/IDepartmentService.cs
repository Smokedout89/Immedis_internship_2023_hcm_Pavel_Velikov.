namespace HCM.API.Employees.Services.Department;

using Features.Department.Requests;

public interface IDepartmentService
{
    Task<IResult> CreateDepartment(CreateDepartmentRequest request);
    Task<IResult> GetDepartmentById(string id);
    Task<IResult> GetDepartments();
    Task<IResult> UpdateDepartment(UpdateDepartmentRequest request);
    Task<IResult> DeleteDepartment(string id);
}