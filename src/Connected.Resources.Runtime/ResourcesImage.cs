using Connected.Runtime;

namespace Connected.Resources.Runtime;
internal sealed class ResourcesImage : RuntimeImage
{
	protected override void OnRegister()
	{
		Application.RegisterMicroService("Connected.Resources.dll");
		Application.RegisterMicroService("Connected.Resources.ContactTypes.dll");
		Application.RegisterMicroService("Connected.Resources.Effort.dll");
		Application.RegisterMicroService("Connected.Resources.JobPositions.dll");
		Application.RegisterMicroService("Connected.Resources.NamedResources.dll");
		Application.RegisterMicroService("Connected.Resources.TimeLogs.dll");
		Application.RegisterMicroService("Connected.Resources.TimeSheets.dll");
		Application.RegisterMicroService("Connected.Resources.Utilization.dll");
		Application.RegisterMicroService("Connected.Resources.Utilization.Agent.dll");
		Application.RegisterMicroService("Connected.Resources.WorkItems.dll");
		Application.RegisterMicroService("Connected.Resources.WorkItems.Agent.dll");
		Application.RegisterMicroService("Connected.Resources.WorkSheets.dll");
		Application.RegisterMicroService("Connected.Resources.Employees.dll");
		Application.RegisterMicroService("Connected.Resources.Persons.dll");

		Application.RegisterMicroService("Connected.Resources.Extensions.dll");
	}
}
