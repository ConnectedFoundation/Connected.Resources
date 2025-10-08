using Connected.Entities;
using Connected.Resources.Types.NamedResources;

namespace Connected.Resources.Resources.NamedResources;
internal sealed record NamedResource : Entity<int>, INamedResource
{
	public required string Name { get; init; }
}
