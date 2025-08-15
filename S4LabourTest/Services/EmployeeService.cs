using System.Net.Http.Json;
using S4LabourTest.DTOs;
using S4LabourTest.Models;

namespace S4LabourTest.Services;

public class EmployeeService(
	HttpClient httpClient,
	string endpoint = "https://randomuser.me/api/?results=20&inc=gender,name,phone,email,picture") : IEmployeeService {
	private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	private readonly string _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));

	public EmployeeService() : this(new HttpClient()) { }

	public async Task<IEnumerable<Employee>> GetEmployees() {
		var response = await _httpClient.GetAsync(_endpoint);
		response.EnsureSuccessStatusCode();

		var randomUserResponse = await response.Content.ReadFromJsonAsync<RandomUserResponse>();
		if (randomUserResponse == null) {
			throw new Exception("Could not deserialize response");
		}

		var employees = randomUserResponse.Results;
		var array = employees as Employee[] ?? employees.ToArray();
		if (array.Length == 0) return [];

		employees = array.Select((employee, i) => {
			employee.Id = i;
			return employee;
		});
		return employees;
	}
}