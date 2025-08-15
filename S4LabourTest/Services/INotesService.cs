using S4LabourTest.DTOs;
using S4LabourTest.Models;

namespace S4LabourTest.Services;

public interface INotesService {
	public Note[] GetNotesByUserId(int userId);
	public void AddNoteToUser(int employeeId,AddNoteRequest note);
}