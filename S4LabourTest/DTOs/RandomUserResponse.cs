using S4LabourTest.Models;

namespace S4LabourTest.DTOs;

public class RandomUserResponse
{
    public IEnumerable<Employee> Results { get; set; }
}