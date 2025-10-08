using Connected.Entities;

namespace Connected.Resources.Types.NamedResources;

public interface INamedResource : IEntity<int>
{
	string Name { get; init; }
}