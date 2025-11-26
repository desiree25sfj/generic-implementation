using Xunit;
using System.Linq;

public class InventoryTests
{
	// Test to verify that adding a single potion increases the count and allows retrieval
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

	// Test to verify that removing a potion by index works correctly
	[Fact]
	public void RemoveAt_RemovesCorrectPotion_AndShiftsIndexes()
	{
		// Arrange
		var inventory = new Inventory<Potion>();
		var p1 = new Potion("Healing Draught", 10);
		var p2 = new Potion("Mana Brew", 20);
		var p3 = new Potion("Stamina Tonic", 30);

		inventory.Add(p1);
		inventory.Add(p2);
		inventory.Add(p3);

		// Act
		inventory.RemoveAt(1); // Remove "Mana Brew"

		// Assert
		Assert.Equal(2, inventory.Count);
		Assert.True(inventory.TryGet(1, out var potion));
		Assert.Equal("Stamina Tonic", potion.Name);
	}

	// Test generic constraint and CompareTo implementation indirectly via GetMax
	[Fact]
	public void GetMax_ReturnsPotionWithHighestPotency()
	{
		// Arrange
		var inventory = new Inventory<Potion>();
		var weak = new Potion("Weak Healing Tincture", 5);
		var medium = new Potion("Greater Healing Potion", 25);
		var strong = new Potion("Elixir of Titan Strength", 50);

		inventory.Add(weak);
		inventory.Add(medium);
		inventory.Add(strong);

		// Act
		var maxPotion = inventory.GetMax();

		// Assert
		Assert.Equal("Elixir of Titan Strength", maxPotion.Name);
		Assert.Equal(50, maxPotion.Potency);
	}

	// Parameterized test to check TryGet with various indexes
	[Theory]
	[InlineData(-1, false)]
	[InlineData(0, true)]
	[InlineData(1, true)]
	[InlineData(5, false)]
	public void TryGet_VariousIndexes_ReturnsExpectedResults(int index, bool expected)
	{
		// Arrange
		var inventory = new Inventory<Potion>();
		inventory.Add(new Potion("Fire Resistance Philter", 15));
		inventory.Add(new Potion("Frost Resistance Philter", 20));

		// Act
		var result = inventory.TryGet(index, out var _);

		// Assert
		Assert.Equal(expected, result);
	}
}