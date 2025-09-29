using Connected.Runtime;
using Microsoft.Extensions.Configuration;

namespace Connected.Resources;
internal sealed class Bootstrapper : Startup
{
	protected override async Task OnInitialize()
	{
		var section = Configuration.GetSection("resources:contacts:types");

		if (section.Exists())
			ResourcesConfiguration.EmailContactType = section.GetValue<string>("email", ResourcesConfiguration.EmailContactType);

		await Task.CompletedTask;
	}
}
