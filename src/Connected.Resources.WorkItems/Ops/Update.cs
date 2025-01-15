using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.WorkItems.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.WorkItems.Ops;
internal sealed class Update(IStorageProvider storage, IWorkItemService workItems, IEventService events, IWorkItemCache cache)
	: ServiceAction<IUpdateWorkItemDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await workItems.Select(Dto.CreatePrimaryKey(Dto.Id))) as WorkItem ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<WorkItem>().Update(entity.Merge(Dto, State.Default), Dto, async () =>
		{
			await cache.Remove(Dto.Id);

			return SetState(await workItems.Select(Dto.CreatePrimaryKey(Dto.Id))) as WorkItem;
		}, Caller);

		await cache.Remove(entity.Id);
		await events.Updated(this, workItems, entity.Id);
	}
}
