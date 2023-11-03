namespace HCM.Web.Responses;

public class EmployeeResponse : BaseResponse<List<EmployeePayload>>
{
}

public class EmployeePayload
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }
    public DateOnly HireDate { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string ContractType { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal NetSalary { get; set; }
}