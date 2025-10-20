using Connected.Services;

namespace Connected.Resources.Resources;
internal sealed class EmployeeExtensions(IServiceProvider services)
		: Service(services), IEmployeeExtensions
{
}
