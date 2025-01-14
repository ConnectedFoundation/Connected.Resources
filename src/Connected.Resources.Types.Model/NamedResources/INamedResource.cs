using Connected.Entities;

namespace Connected.Resources.NamedResources;

public interface INamedResource : IEntity<int>
{
	string Name { get; init; }
}