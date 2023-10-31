namespace HCM.API.Employees.Services.Employee;

using Features.Employee.Requests;

public interface IEmployeeService
{
    Task<IResult> CreateEmployee(CreateEmployeeRequest request);
    Task<IResult> GetEmployeeById(string id);
    Task<IResult> GetEmployees();
    Task<IResult> UpdateEmployee(UpdateEmployeeRequest request);
    Task<IResult> DeleteEmployee(string id);
}