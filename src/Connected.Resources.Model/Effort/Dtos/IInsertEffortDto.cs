namespace Connected.Resources.Effort.Dtos;

public interface IInsertEffortDto : IEffortDto
{
	int Resource { get; set; }
	long? WorkItem { get; set; }
	int TimeSheet { get; set; }
}
