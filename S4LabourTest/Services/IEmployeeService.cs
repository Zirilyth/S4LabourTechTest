using S4LabourTest.Models;

namespace S4LabourTest.Services;

public interface IEmployeeService
{
    public Task<IEnumerable<Employee>> GetEmployees();
}