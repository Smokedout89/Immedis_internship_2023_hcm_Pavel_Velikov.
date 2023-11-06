namespace HCM.Web.Services.Contracts;

using Models;

public interface IEmployeeService
{
    Task<HttpResponseMessage> GetEmployees();

    // Departments
    Task<HttpResponseMessage> GetDepartment(string id);
    Task<HttpResponseMessage> GetDepartments();
    Task<HttpResponseMessage> CreateDepartment(DepartmentCreateModel model);
    Task<HttpResponseMessage> EditDepartment(DepartmentModel model);
    Task<HttpResponseMessage> DeleteDepartment(string id);

    // Towns
    Task<HttpResponseMessage> GetTown(string id);
    Task<HttpResponseMessage> GetTowns();
    Task<HttpResponseMessage> CreateTown(TownCreateModel model);
    Task<HttpResponseMessage> EditTown(TownModel model);
    Task<HttpResponseMessage> DeleteTown(string id);
}