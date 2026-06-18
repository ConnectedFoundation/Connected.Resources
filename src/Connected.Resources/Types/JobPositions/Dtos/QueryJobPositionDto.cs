using Connected.Services;

namespace Connected.Resources.Types.JobPositions.Dtos;

internal sealed class QueryJobPositionDto : QueryDto, IQueryJobPositionDto
{
    public string? Code { get; set; }
}
