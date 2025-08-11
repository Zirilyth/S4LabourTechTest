using Microsoft.AspNetCore.Mvc;
using S4LabourTest.DTOs;
using S4LabourTest.Services;

namespace S4LabourTest.Controllers;

[ApiController]
[Route("employees")]
public class EmployeesController(IEmployeeService employeeService) : Controller
{
    [HttpGet]
    public IActionResult GetEmployees()
    {
        try
        {
            var employees = employeeService.GetEmployees().Result;
            return new OkObjectResult(employees);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex);
        }
    }

    [HttpGet("{id:int}/notes")]
    public IActionResult GetNotesForEmployee(int id)
    {
        throw new NotImplementedException(nameof(GetNotesForEmployee));
    }

    [HttpPost("{id:int}/notes")]
    public IActionResult AddNoteForEmployee(int id, AddNoteRequest note)
    {
        throw new NotImplementedException(nameof(AddNoteForEmployee));
    }

}

