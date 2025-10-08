using Connected.Runtime;

namespace Connected.Resources;
internal sealed class ResourcesImage : RuntimeImage
{
	protected override void OnRegister()
	{
		RegisterDependency("Connected.Resources.Extensions.dll");
	}
}
