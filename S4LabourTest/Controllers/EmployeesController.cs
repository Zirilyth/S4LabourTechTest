using Microsoft.AspNetCore.Mvc;
using S4LabourTest.DTOs;
using S4LabourTest.Models;
using S4LabourTest.Services;

namespace S4LabourTest.Controllers;

[ApiController]
[ProducesResponseType<IEnumerable<Employee>>(statusCode: 200)]
[ProducesResponseType<BadRequestResult>(statusCode: 400)]
[Route("employees")]
public class EmployeesController(IEmployeeService employeeService) : Controller {
	[HttpGet]
	public IActionResult GetEmployees() {
		try {
			var employees = employeeService.GetEmployees().Result;
			return new OkObjectResult(employees);
		}
		catch (Exception ex) {
			return new BadRequestObjectResult(ex.Message);
		}
	}

	[ProducesResponseType<IEnumerable<Note>>(statusCode: 200)]
	[ProducesResponseType<BadRequestResult>(statusCode: 400)]
	[HttpGet("{id:int}/notes")]
	public IActionResult GetNotesForEmployee(int id) {
		return new OkObjectResult(new List<Note> {
			new Note {
				Text = "This is a note",
				EmployeeId = id,
				CreatedAt = DateTime.Now
			},
			new Note {
				Text = "This is another note",
				EmployeeId = id,
				CreatedAt = DateTime.Now

			}
		});
	}

	[ProducesResponseType<IEnumerable<Note>>(statusCode: 200)]
	[ProducesResponseType<BadRequestResult>(statusCode: 400)]
	[HttpPost("{id:int}/notes")]
	public IActionResult AddNoteForEmployee(int id, AddNoteRequest note) {
		throw new NotImplementedException(nameof(AddNoteForEmployee));
	}
}

