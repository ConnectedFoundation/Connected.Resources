using Connected.Services;

namespace Connected.Resources.Resources.Persons.Dtos;
internal sealed class QueryPersonDto : QueryDto, IQueryPersonDto
{
	public List<long>? Users { get; set; }
}
