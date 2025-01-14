using Connected.Services;

namespace Connected.Resources.NamedResources.Dtos;
public interface INamedResourceProviderDto : IDto
{
	List<IResourceDescriptor> Items { get; set; }
}
