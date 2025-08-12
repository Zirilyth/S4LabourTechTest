namespace S4LabourTest.Models;

public class Note {
	public required string Text { get; set; }
	public int EmployeeId { get; set; }
	public DateTime CreatedAt { get; set; }
}