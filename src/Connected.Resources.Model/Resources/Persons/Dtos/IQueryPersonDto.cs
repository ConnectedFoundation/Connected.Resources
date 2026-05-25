using Connected.Services;

namespace Connected.Resources.Resources.Persons.Dtos;
public interface IQueryPersonDto : IQueryDto
{
	List<long>? Users { get; set; }
}
