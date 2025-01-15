using Connected.Annotations;
using Connected.Resources.TimeSheets.Dtos;
using Connected.Services.Middleware;

namespace Connected.Resources.TimeSheets.Middlewares;

[Middleware<ITimeSheetService>(nameof(ITimeSheetService.Insert))]
internal sealed class InsertTimeSheetMiddleware(ITimeSheetService timeSheets)
	: ServiceFunctionMiddleware<IInsertTimeSheetDto, int>
{

	protected override async Task<int> OnInvoke(int result)
	{
		await TimeSheetsUtils.EnsureSingleDefault(timeSheets, result);

		return result;
	}
}
