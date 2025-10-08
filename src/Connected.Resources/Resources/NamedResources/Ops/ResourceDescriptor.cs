using Connected.Resources.NamedResources.Dtos;

namespace Connected.Resources.Resources.NamedResources.Ops;
internal sealed class ResourceDescriptor : IResourceDescriptor
{
	public required string Token { get; set; }
	public int Id { get; set; }
	public string? Type { get; set; }
}
