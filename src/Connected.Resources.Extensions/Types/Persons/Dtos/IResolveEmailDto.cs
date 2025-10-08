using Connected.Services;

namespace Connected.Resources.Persons.Dtos;
public interface IResolveEmailDto : IDto
{
	int Person { get; set; }
}
