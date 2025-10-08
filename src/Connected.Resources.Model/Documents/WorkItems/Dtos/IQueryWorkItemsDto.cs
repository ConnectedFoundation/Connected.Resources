using Connected.Services;

namespace Connected.Resources.Documents.WorkItems.Dtos;
public interface IQueryWorkItemsDto : IDto
{
	string? Entity { get; set; }
	string? EntityId { get; set; }
	DateTimeOffset? Start { get; set; }
	DateTimeOffset? End { get; set; }
	int? Resource { get; set; }
	int TimeSheet { get; set; }
	long? Parent { get; set; }
}
