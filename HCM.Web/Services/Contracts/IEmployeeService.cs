namespace HCM.Web.Services.Contracts;

using Models;

public interface IEmployeeService
{
    // Employees
    Task<HttpResponseMessage> GetEmployees();
    Task<HttpResponseMessage> CreateEmployee(EmployeeCreateModel model);

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

    // Salaries
    Task<HttpResponseMessage> GetSalary(string id);
    Task<HttpResponseMessage> GetSalaries();
    Task<HttpResponseMessage> CreateSalary(SalaryCreateModel model);
    Task<HttpResponseMessage> EditSalary(SalaryModel model);
    Task<HttpResponseMessage> DeleteSalary(string id);
}