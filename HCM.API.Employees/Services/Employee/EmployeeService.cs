namespace HCM.API.Employees.Services.Employee;

using Infrastructure.Responses;
using Features.Employee.Requests;
using Domain.Abstractions.Models;
using Features.Employee.Responses;
using Domain.Abstractions.Repositories;

using MapsterMapper;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ISalaryRepository _salaryRepository;

    public EmployeeService(
        IMapper mapper,
        IAddressRepository addressRepository,
        IDepartmentRepository departmentRepository,
        IEmployeeRepository employeeRepository,
        ISalaryRepository salaryRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
        _departmentRepository = departmentRepository;
        _employeeRepository = employeeRepository;
        _salaryRepository = salaryRepository;
    }

    public async Task<IResult> CreateEmployee(CreateEmployeeRequest request)
    {
        var isCreated = await _employeeRepository.GetEmployeeByNames(
            request.FirstName,
            request.LastName);

        if (isCreated is not null)
        {
            return Response.BadRequest("Employee is already created.");
        }

        var address = await _addressRepository.GetByIdAsync(request.AddressId);

        if (address is null)
        {
            return Response.BadRequest("There is no address with the provided id.");
        }

        var department = await _departmentRepository.GetByIdAsync(request.DepartmentId);

        if (department is null)
        {
            return Response.BadRequest("There is no department with the provided id.");
        }

        var salary = await _salaryRepository.GetByIdAsync(request.SalaryId);

        if (salary is null)
        {
            return Response.BadRequest("There is no salary with the provided id.");
        }

        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Age = request.Age,
            DateOfBirth = request.DateOfBirth,
            HireDate = request.HireDate,
            JobTitle = request.JobTitle,
            Gender = request.Gender,
            ContractType = request.ContractType,
            AddressId = request.AddressId,
            DepartmentId = request.DepartmentId,
            SalaryId = request.SalaryId
        };

        await _employeeRepository.AddAsync(employee);

        var response = _mapper.Map<EmployeeResponse>(employee);

        response.Address = await GetAddressAsString(employee.AddressId);
        response.Department = await GetDepartmentAsString(employee.DepartmentId);
        response.NetSalary = await GetSalaryAsDecimal(employee.SalaryId);

        return Response.OkData(response);
    }

    public async Task<IResult> GetEmployeeById(string id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee is null)
        {
            return Response.BadRequest("There is no employee with the provided Id.");
        }

        return Response.OkData(_mapper.Map<EmployeeResponse>(employee));
    }

    public async Task<IResult> GetEmployees()
    {
        var employees = await _employeeRepository.GetAllAsync();
        var employeesToReturn = employees.Select(
            employee => _mapper.Map<EmployeeResponse>(employee)).ToList();

        return Response.OkData(employeesToReturn);
    }

    public async Task<IResult> UpdateEmployee(UpdateEmployeeRequest request)
    {
        var employee = await _employeeRepository.GetByIdAsNoTracking(request.Id);

        if (employee is null)
        {
            return Response.BadRequest("There is no employee with the provided Id.");
        }

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Age = request.Age;
        employee.DateOfBirth = request.DateOfBirth;
        employee.HireDate = request.HireDate;
        employee.JobTitle = request.JobTitle;
        employee.Gender = request.Gender;
        employee.ContractType = request.ContractType;
        employee.AddressId = request.AddressId;
        employee.DepartmentId = request.DepartmentId;
        employee.SalaryId = request.SalaryId;

        await _employeeRepository.UpdateAsync(employee);

        var response = _mapper.Map<EmployeeResponse>(employee);

        response.Address = await GetAddressAsString(employee.AddressId);
        response.Department = await GetDepartmentAsString(employee.DepartmentId);
        response.NetSalary = await GetSalaryAsDecimal(employee.SalaryId);

        return Response.OkData(response);
    }

    public async Task<IResult> DeleteEmployee(string id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        if (employee is null)
        {
            return Response.BadRequest("There is no employee with the provided Id.");
        }

        await _employeeRepository.DeleteAsync(id);

        return Response.Ok();
    }

    private async Task<string> GetAddressAsString(string id)
    {
        var address = await _addressRepository.GetByIdAsync(id);

        return $"{address!.StreetName} {address.StreetNumber}";
    }

    private async Task<string> GetDepartmentAsString(string id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);

        return department!.Name;
    }

    private async Task<decimal> GetSalaryAsDecimal(string id)
    {
        var salary = await _salaryRepository.GetByIdAsync(id);

        return salary!.NetSalary;
    }
}