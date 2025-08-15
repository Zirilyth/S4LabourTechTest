using System.Net;
using System.Text;
using S4LabourTest.Services;

namespace UnitTesting.Services {
	internal sealed class FakeHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responder)
		: HttpMessageHandler {
		private readonly Func<HttpRequestMessage, HttpResponseMessage> _responder =
			responder ?? throw new ArgumentNullException(nameof(responder));

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
			CancellationToken cancellationToken)
			=> Task.FromResult(_responder(request));
	}

	[TestFixture]
	public class EmployeeServiceTests {
		[Test]
		public async Task GetEmployees_ReadsMockValue_AssignsSequentialIds() {
			const string json = """
			                    {
			                      "results": [
			                        {
			                          "gender": "male",
			                          "name": { "title": "Mr", "first": "John", "last": "Doe" },
			                          "email": "john.doe@example.com",
			                          "phone": "0123456789",
			                          "picture": { "thumbnail": "https://example.com/t.jpg", "medium": "https://example.com/m.jpg", "large": "https://example.com/l.jpg" }
			                        },
			                        {
			                          "gender": "female",
			                          "name": { "title": "Ms", "first": "Jane", "last": "Roe" },
			                          "email": "jane.roe@example.com",
			                          "phone": "0987654321",
			                          "picture": { "thumbnail": "https://example.com/t2.jpg", "medium": "https://example.com/m2.jpg", "large": "https://example.com/l2.jpg" }
			                        },
			                        {
			                          "gender": "male",
			                          "name": { "title": "Mr", "first": "Bob", "last": "Smith" },
			                          "email": "bob.smith@example.com",
			                          "phone": "0111222333",
			                          "picture": { "thumbnail": "https://example.com/t3.jpg", "medium": "https://example.com/m3.jpg", "large": "https://example.com/l3.jpg" }
			                        }
			                      ]
			                    }
			                    """;

			var handler = new FakeHttpMessageHandler(_ =>
				new HttpResponseMessage(HttpStatusCode.OK) {
					Content = new StringContent(json, Encoding.UTF8, "application/json")
				});

			var httpClient = new HttpClient(handler);
			var service = new EmployeeService(httpClient, "http://any-host/ignored-by-fake");

			var employees = (await service.GetEmployees()).ToList();

			Assert.That(employees, Is.Not.Null);
			Assert.That(employees, Has.Count.EqualTo(3));
			Assert.That(employees.Select(e => e.Id), Is.EqualTo(new[] { 0, 1, 2 }));
		}

		[Test]
		public async Task GetEmployees_EmptyResults_ReturnsEmptyCollection() {
			const string json = """{ "results": [] }""";

			var handler = new FakeHttpMessageHandler(_ =>
				new HttpResponseMessage(HttpStatusCode.OK) {
					Content = new StringContent(json, Encoding.UTF8, "application/json")
				});

			var httpClient = new HttpClient(handler);
			var service = new EmployeeService(httpClient, "http://any-host/ignored-by-fake");

			var employees = (await service.GetEmployees()).ToList();

			Assert.That(employees, Is.Empty);
		}
	}
}