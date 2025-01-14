namespace Connected.Resources.NamedResources;

public interface INamedResource : IResource
{
	string Name { get; init; }
}