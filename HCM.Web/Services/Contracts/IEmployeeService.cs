namespace HCM.Web.Services.Contracts;

using Models;

public interface IEmployeeService
{
    Task<HttpResponseMessage> GetEmployees();
    Task<HttpResponseMessage> GetDepartments();
    Task<HttpResponseMessage> CreateDepartment(DepartmentModel model);
}