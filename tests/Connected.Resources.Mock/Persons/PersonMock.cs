using Connected.Core.Entities.Mock;
using Connected.Entities;
using Connected.Resources.Persons;

namespace Connected.Resources.Mock.Persons;

public class PersonMock : EntityMock<int>, IPerson
{
	public string? Code { get; init; }
	public string? FirstName { get; init; }
	public string? LastName { get; init; }
	public Status Status { get; init; }
	public required string Token { get; init; }
}
