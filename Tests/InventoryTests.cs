using Xunit;
using System.Linq;

public class InventoryTests
{
	[Fact]
	public void AddSinglePotion_IncreasesCount_AndIsRetrievable()
	{
		// Arrange
		var shelf = new Inventory<Potion>();
		var potion = new Potion("Healing Potion", 50);

		// Act
		shelf.Add(potion);

		// Assert
		Assert.Equal(1, shelf.Count);
		Assert.True(shelf.Contains(potion));
		Assert.Equal(potion, shelf.Get(0));
	}
}