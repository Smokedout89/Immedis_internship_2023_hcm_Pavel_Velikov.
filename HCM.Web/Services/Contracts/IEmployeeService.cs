namespace HCM.Web.Services.Contracts;

using Models;

public interface IEmployeeService
{
    Task<HttpResponseMessage> GetEmployees();
    Task<HttpResponseMessage> GetDepartment(string id);
    Task<HttpResponseMessage> GetDepartments();
    Task<HttpResponseMessage> CreateDepartment(DepartmentCreateModel model);
    Task<HttpResponseMessage> EditDepartment(DepartmentModel model);
    Task<HttpResponseMessage> DeleteDepartment(string id);
}