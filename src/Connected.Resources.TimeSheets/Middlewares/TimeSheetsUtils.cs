using Connected.Resources.TimeSheets.Dtos;
using Connected.Services;

namespace Connected.Resources.TimeSheets.Middlewares;
internal static class TimeSheetsUtils
{
	public static async Task EnsureSingleDefault(ITimeSheetService timeSheets, int id)
	{
		var items = await timeSheets.Query(null);
		var defaults = items.Count(f => f.IsDefault);

		switch (defaults)
		{
			case 0:
				await UpdateDefault(timeSheets, items[0], true);
				break;
			case > 1:
				foreach (var item in items)
				{
					if (item.Id == id)
						continue;

					if (item.IsDefault)
						await UpdateDefault(timeSheets, item, false);
				}

				break;
		}
	}

	private static async Task UpdateDefault(ITimeSheetService timeSheets, ITimeSheet timeSheet, bool isDefault)
	{
		var dto = Dto.Factory.Create<IUpdateTimeSheetDto>();

		dto.Id = timeSheet.Id;
		dto.IsDefault = isDefault;
		dto.Name = timeSheet.Name;

		await timeSheets.Update(dto);
	}
}
