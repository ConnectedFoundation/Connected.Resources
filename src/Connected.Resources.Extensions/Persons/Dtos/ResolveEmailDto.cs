using Connected.Annotations;
using Connected.Services;

namespace Connected.Resources.Persons.Dtos;
internal sealed class ResolveEmailDto : Dto, IResolveEmailDto
{
	[MinValue(1)]
	public int Person { get; set; }
}
