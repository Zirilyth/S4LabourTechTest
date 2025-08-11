using System.Text.Json;
using S4LabourTest.DTOs;
using S4LabourTest.Models;

namespace S4LabourTest.Services;

public class EmployeeService : IEmployeeService
{
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        using var client = new HttpClient();

        //todo:This could pass these variables in, including pagination info if we wanted
        var response = await client.GetAsync("https://randomuser.me/api/?results=20&inc=gender,name,phone,email,picture");
        response.EnsureSuccessStatusCode();

        var randomUserResponse = await response.Content.ReadFromJsonAsync<RandomUserResponse>();
        var employees = randomUserResponse?.Results;

        return employees ?? [];
    }
}