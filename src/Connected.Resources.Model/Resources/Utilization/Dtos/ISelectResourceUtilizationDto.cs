using Connected.Services;

namespace Connected.Resources.Resources.Utilization.Dtos;

public interface ISelectResourceUtilizationDto : IDto
{
	int Resource { get; set; }
	DateTimeOffset Date { get; set; }
}
