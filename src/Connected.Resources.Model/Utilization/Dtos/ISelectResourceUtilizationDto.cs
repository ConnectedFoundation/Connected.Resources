using Connected.Services;

namespace Connected.Resources.Utilization.Dtos;

public interface ISelectResourceUtilizationDto : IDto
{
	int Resource { get; set; }
	DateTimeOffset Date { get; set; }
}
