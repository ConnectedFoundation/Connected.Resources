using Connected.Entities;

namespace Connected.Resources.Resources.Utilization;
public interface IResourceUtilization : IEntity<long>
{
	int Resource { get; init; }
	DateTimeOffset Date { get; init; }
	double Capacity { get; init; }
	double Utilization { get; init; }
	double PlannedEffort { get; init; }
	double UnplannedEffort { get; init; }
}
