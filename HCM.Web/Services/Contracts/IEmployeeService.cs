namespace HCM.Web.Services.Contracts;

public interface IEmployeeService
{
    Task<HttpResponseMessage> GetEmployees();
}