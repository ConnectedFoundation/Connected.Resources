using Connected.Annotations;
using Connected.Resources.TimeSheets.Dtos;
using Connected.Services.Middleware;

namespace Connected.Resources.TimeSheets.Middlewares;

[Middleware<ITimeSheetService>(nameof(ITimeSheetService.Update))]
internal sealed class UpdateTimeSheetMiddleware(ITimeSheetService timeSheets)
	: ServiceActionMiddleware<IUpdateTimeSheetDto>
{
	protected override async Task OnInvoke()
	{
		await TimeSheetsUtils.EnsureSingleDefault(timeSheets, Dto.Id);
	}
}
