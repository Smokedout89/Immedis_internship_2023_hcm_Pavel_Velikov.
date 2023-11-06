namespace HCM.Web.Models;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

public class EmployeeWithAllData
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string HireDate { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    [JsonRequired]
    public string ContractType { get; set; } = string.Empty;
    [JsonRequired]
    public string Department { get; set; } = string.Empty;
    [JsonRequired]
    public string Salary { get; set; } = string.Empty;
    [JsonRequired]
    public string Address { get; set; } = string.Empty;

    [ValidateNever]
    public List<SelectListItem> Departments { get; set; } = null!;
    [ValidateNever]
    public List<SelectListItem> Salaries { get; set; } = null!;
    [ValidateNever]
    public List<SelectListItem> Towns { get; set; } = null!;
}