using Connected.Notifications;
using Connected.Resources.Utilization.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Utilization.Ops;

internal sealed class UpdateResource(IStorageProvider storage, IEventService events, IResourceUtilizationService resources, IResourceUtilizationCache cache)
	: ServiceAction<IUpdateResourceUtilizationDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await resources.Select(Dto)) as ResourceUtilization ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<ResourceUtilization>().Update(entity.Merge(Dto, Entities.State.Default), Dto, async () =>
		{
			await cache.Remove(Dto.Id);

			return SetState(await resources.Select(Dto)) as ResourceUtilization ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}, Caller);

		await cache.Remove(Dto.Id);
		await events.Updated(this, resources, Dto.Id);
	}
}
