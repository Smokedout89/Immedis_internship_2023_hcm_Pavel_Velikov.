namespace HCM.API.Employees.Services.Salary;

using Infrastructure.Responses;
using Features.Salary.Requests;
using Features.Salary.Responses;
using Domain.Abstractions.Models;
using Domain.Abstractions.Repositories;

using MapsterMapper;

public class SalaryService : ISalaryService
{
    private readonly IMapper _mapper;
    private readonly ISalaryRepository _salaryRepository;

    public SalaryService(IMapper mapper, ISalaryRepository salaryRepository)
    {
        _mapper = mapper;
        _salaryRepository = salaryRepository;
    }

    public async Task<IResult> CreateSalary(CreateSalaryRequest request)
    {
        var salary = new Salary { GrossSalary = request.GrossSalary };

        await _salaryRepository.AddAsync(salary);

        return Response.OkData(_mapper.Map<SalaryResponse>(salary));
    }

    public async Task<IResult> GetSalaries()
    {
        var salaries = await _salaryRepository.GetAllAsync();
        var salariesToReturn = salaries.Select(
            salary => _mapper.Map<SalaryResponse>(salary)).ToList();

        return Response.OkData(salariesToReturn);
    }

    public async Task<IResult> GetSalaryById(string id)
    {
        var salary = await _salaryRepository.GetByIdAsync(id);

        if (salary is null)
        {
            return Response.BadRequest("There is no salary with the provided Id.");
        }

        return Response.OkData(_mapper.Map<SalaryResponse>(salary));
    }

    public async Task<IResult> UpdateSalary(UpdateSalaryRequest request)
    {
        var salary = await _salaryRepository.GetByIdAsNoTracking(request.Id);

        if (salary is null)
        {
            return Response.BadRequest("There is no salary with the provided Id.");
        }

        salary.GrossSalary = request.GrossSalary;
        salary.BonusAvailable = request.BonusAvailable;

        await _salaryRepository.UpdateAsync(salary);

        return Response.OkData(_mapper.Map<SalaryResponse>(salary));
    }

    public async Task<IResult> DeleteSalary(string id)
    {
        var salary = await _salaryRepository.GetByIdAsync(id);

        if (salary is null)
        {
            return Response.BadRequest("There is no salary with the provided Id.");
        }

        await _salaryRepository.DeleteAsync(id);

        return Response.Ok();
    }
}