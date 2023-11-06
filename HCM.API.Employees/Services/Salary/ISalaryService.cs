namespace HCM.API.Employees.Services.Salary;

using Features.Salary.Requests;

public interface ISalaryService
{
    Task<IResult> CreateSalary(CreateSalaryRequest request);
    Task<IResult> GetSalaries();
    Task<IResult> GetSalaryById(string id);
    Task<IResult> UpdateSalary(UpdateSalaryRequest request);
    Task<IResult> DeleteSalary(string id);
}