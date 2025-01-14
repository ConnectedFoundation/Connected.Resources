using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Ops;
internal sealed class Update(IStorageProvider storage, IResourceService resources, IEventService events, IResourceCache cache)
	: ServiceAction<IUpdateResourceDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await resources.Select(Dto.CreatePrimaryKey(Dto.Id))) as Resource ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Resource>().Update(entity.Merge(Dto, State.Default), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);

			return SetState(await resources.Select(Dto.CreatePrimaryKey(Dto.Id))) as Resource;
		}, Caller);

		await cache.Refresh(entity.Id);
		await events.Updated(this, resources, entity.Id);
	}
}
