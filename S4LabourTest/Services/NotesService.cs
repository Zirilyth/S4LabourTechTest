using S4LabourTest.DTOs;
using S4LabourTest.Models;

namespace S4LabourTest.Services;

public class NotesService(InMemoryDataStore dataStore) : INotesService {
	public Note[] GetNotesByUserId(int userId) {
		dataStore.Notes.TryGetValue(userId, out var notes);
		return notes ?? [];
	}

	public void AddNoteToUser(int id, AddNoteRequest note) {
		var newNote = new Note {
			Text = note.Text,
			EmployeeId = id,
			CreatedAt = DateTime.Now
		};
		dataStore.Notes.AddOrUpdate(id, [newNote], (key, value) => value.Concat([newNote]).ToArray());
	}
}