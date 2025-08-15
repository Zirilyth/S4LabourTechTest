using System.Collections.Concurrent;
using S4LabourTest.Models;

namespace S4LabourTest.Services;

public class InMemoryDataStore {
	//Key is the EmployeeId
	public ConcurrentDictionary<int, Note[]> Notes { get; } = new();
}