namespace Connected.Resources.Resources.Utilization.Dtos;

public interface IInsertResourceUtilizationDto : IResourceUtilizationDto
{
	DateTimeOffset Date { get; set; }
	int Resource { get; set; }
}
