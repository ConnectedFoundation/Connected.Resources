using Connected.Core.Mock;
using Connected.Core.Services.Mock;
using Connected.Entities;
using Connected.Resources.Mock.Persons;
using Connected.Resources.Mock.Persons.Dtos;

namespace Connected.Resources.Test;

[TestClass]
public class Persons()
	: RestTest(ResourcesUrls.Persons)
{
	[TestMethod]
	public async Task OnInvoke()
	{
		var id = await Insert<InsertPersonDtoMock, int>(new()
		{
			FirstName = ValueGenerator.Generate(8),
			LastName = ValueGenerator.Generate(16),
			Code = ValueGenerator.Generate(4),
			Status = Status.Enabled
		});

		Assert.IsTrue(id > 0);

		var entities = await Query<DtoMock, PersonMock>(null);

		Assert.IsNotNull(entities);
		Assert.IsTrue(entities.Count > 0);

		entities = await GetList<PrimaryKeyListDtoMock<int>, PersonMock>(ResourcesUrls.LookupOperation, new(id));

		Assert.IsNotNull(entities);
		Assert.IsTrue(entities.Count > 0);

		var updateDto = new UpdatePersonDtoMock
		{
			Id = id,
			FirstName = ValueGenerator.Generate(8),
			LastName = ValueGenerator.Generate(16),
			Code = ValueGenerator.Generate(4),
			Status = Status.Disabled,
		};

		await Update(updateDto);

		var entity = await Select<PrimaryKeyDtoMock<int>, PersonMock>(id);

		Assert.IsNotNull(entity);

		Assert.AreEqual(entity.FirstName, updateDto.FirstName);
		Assert.AreEqual(entity.LastName, updateDto.LastName);
		Assert.AreEqual(entity.Status, updateDto.Status);

		entity = await Get<ValueDtoMock<string>, PersonMock>(ResourcesMetaData.SelectByCodeOperation, entity.Code ?? string.Empty);

		Assert.IsNotNull(entity);

		await Delete<PrimaryKeyDtoMock<int>>(id);

		entity = await Select<PrimaryKeyDtoMock<int>, PersonMock>(id);

		Assert.IsNull(entity);
	}
}
