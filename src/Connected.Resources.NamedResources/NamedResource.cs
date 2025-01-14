using Connected.Entities;

namespace Connected.Resources.NamedResources;
internal sealed record NamedResource : Entity<int>, INamedResource
{
	public required string Name { get; init; }
}
