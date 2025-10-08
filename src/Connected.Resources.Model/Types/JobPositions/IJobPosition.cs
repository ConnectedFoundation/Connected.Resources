using Connected.Entities;

namespace Connected.Resources.Types.JobPositions;

public interface IJobPosition : IEntity<int>
{
	string Code { get; init; }
	string Name { get; init; }
	Status Status { get; init; }
	float? HourlyRate { get; init; }
}