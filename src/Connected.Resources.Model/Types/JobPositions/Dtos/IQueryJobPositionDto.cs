using Connected.Services;

namespace Connected.Resources.Types.JobPositions.Dtos;
public interface IQueryJobPositionDto : IQueryDto
{
    public string? Code { get; set; }
}
