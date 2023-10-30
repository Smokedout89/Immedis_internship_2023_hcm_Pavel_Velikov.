namespace HCM.API.Employees.Features.Salary.Requests;

using System.ComponentModel;
using Infrastructure.Requests;

public class UpdateSalaryRequest : BaseIdRequest
{
    public decimal GrossSalary { get; set; }

    [DefaultValue(false)]
    public bool BonusAvailable { get; set; }
}