namespace HCM.API.Employees.Features.Salary.Requests;

using Infrastructure.Requests;

public class CreateSalaryRequest : BaseRequest
{
    public decimal GrossSalary { get; set; }
}