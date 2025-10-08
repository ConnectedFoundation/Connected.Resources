using Connected.Annotations;
using Connected.Resources.Resources.TimeSheets.Dtos;
using Connected.Services;

namespace Connected.Resources.Resources.TimeSheets.Middlewares;

[Middleware<ITimeSheetService>(nameof(ITimeSheetService.Update))]
internal sealed class UpdateTimeSheetMiddleware(ITimeSheetService timeSheets)
	: ServiceActionMiddleware<IUpdateTimeSheetDto>
{
	protected override async Task OnInvoke()
	{
		await TimeSheetsUtils.EnsureSingleDefault(timeSheets, Operation.Dto.Id);
	}
}
