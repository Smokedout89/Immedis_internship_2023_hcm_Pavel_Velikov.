namespace HCM.API.Employees.Features.Employee.Requests;

using HCM.Domain.Abstractions.Models.Enums;

using Infrastructure.Requests;

public class CreateEmployeeRequest : BaseRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public DateOnly HireDate { get; set; }
    public GenderType Gender { get; set; }
    public ContractType ContractType { get; set; }
    public string DepartmentId { get; set; } = string.Empty;
    public string AddressId { get; set; } = string.Empty;
    public string SalaryId { get; set; } = string.Empty;
}