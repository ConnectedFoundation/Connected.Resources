using Connected.Services;

namespace Connected.Resources.Documents.WorkItems.Dtos;

public interface IQueryWorkItemsInDateDto : IDto
{
	int TimeSheet { get; set; }
	int Resource { get; set; }
	DateTimeOffset Date { get; set; }
}
