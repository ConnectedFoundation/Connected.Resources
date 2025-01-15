using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.WorkItems.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.WorkItems.Ops;
internal sealed class Insert(IStorageProvider storage, IWorkItemService workItems, IEventService events, IWorkItemCache cache)
	: ServiceFunction<IInsertWorkItemDto, long>
{
	protected override async Task<long> OnInvoke()
	{
		var entity = await storage.Open<WorkItem>().Update(Dto.AsEntity<WorkItem>(State.New)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await events.Inserted(this, workItems, entity.Id);

		return entity.Id;
	}
}
