using Connected.Annotations;
using Connected.Resources.Resources.TimeSheets.Dtos;
using Connected.Services;

namespace Connected.Resources.Resources.TimeSheets.Middlewares;

[Middleware<ITimeSheetService>(nameof(ITimeSheetService.Insert))]
internal sealed class InsertTimeSheetMiddleware(ITimeSheetService timeSheets)
	: ServiceFunctionMiddleware<IInsertTimeSheetDto, int>
{

	protected override async Task OnInvoke()
	{
		await TimeSheetsUtils.EnsureSingleDefault(timeSheets, Result);
	}
}
