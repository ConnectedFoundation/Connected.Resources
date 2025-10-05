using Connected.Core.Mock;
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
		var id = await Insert<InsertPersonDtoMock, int>(new InsertPersonDtoMock
		{
			FirstName = "John",
			LastName = "Lennon",
			Code = "LEJ",
			Status = Status.Enabled
		});

		Assert.IsTrue(id > 0);

		var entities = await Query<PersonMock>();

		Assert.IsTrue(entities is not null && entities.Count > 0);

		entities = await Get<List<PersonMock>>(ResourcesUrls.LookupOperation,
		[
			new("Items", id)
		]);

		Assert.IsTrue(entities is not null && entities.Count > 0);

		await Update(new UpdatePersonDtoMock
		{
			Id = id,
			FirstName = "Ringo",
			LastName = "Starr",
			Code = "LEJ",
			Status = Status.Disabled,
		});

		var entity = await Select<PersonMock>(id);

		Assert.IsTrue(entity is not null
			&& string.Equals(entity.FirstName, "Ringo", StringComparison.OrdinalIgnoreCase)
			&& string.Equals(entity.LastName, "Starr", StringComparison.OrdinalIgnoreCase)
			&& entity.Status == Status.Disabled);

		entity = await Get<PersonMock>(ResourcesMetaData.SelectByCodeOperation, new Dictionary<string, object?>
		{
			{"Value", entity.Code }
		});

		Assert.IsTrue(entity is not null);

		await Delete(id);

		entity = await Select<PersonMock>(id);

		Assert.IsNull(entity);

	}
}
