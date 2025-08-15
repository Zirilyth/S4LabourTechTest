using Microsoft.AspNetCore.Mvc;
using S4LabourTest.DTOs;
using S4LabourTest.Models;
using S4LabourTest.Services;

namespace S4LabourTest.Controllers;

[ApiController]
[ProducesResponseType<IEnumerable<Employee>>(statusCode: 200)]
[ProducesResponseType<BadRequestResult>(statusCode: 400)]
[Route("employees")]
public class EmployeesController(IEmployeeService employeeService, INotesService notesService) : Controller {
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
		try {
			var notes = notesService.GetNotesByUserId(id);
			return new OkObjectResult(notes);
		}
		catch (Exception ex) {
			return new BadRequestObjectResult(ex.Message);
		}
	}

	[ProducesResponseType<IEnumerable<Note>>(statusCode: 200)]
	[ProducesResponseType<BadRequestResult>(statusCode: 400)]
	[HttpPost("{id:int}/notes")]
	public IActionResult AddNoteForEmployee(int id, AddNoteRequest note) {
		try {
			notesService.AddNoteToUser(id, note);
			return new OkResult();
		}
		catch (Exception ex) {
			return new BadRequestObjectResult(ex.Message);
		}
	}
}