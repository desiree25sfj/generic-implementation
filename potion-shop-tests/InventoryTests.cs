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

	// Test to verify that adding multiple potions via params works correctly
	[Fact]
	public void AddParams_AddsMultiplePotionsInOrder()
	{
		// Arrange
		var inventory = new Inventory<Potion>();
		var p1 = new Potion("Swiftness Potion", 10);
		var p2 = new Potion("Invisibility Draught", 25);
		var p3 = new Potion("Giant Strength Brew", 50);

		// Act
		inventory.Add(p1, p2, p3);

		// Assert
		Assert.Equal(3, inventory.Count);
		Assert.Equal(p1, inventory.Get(0));
		Assert.Equal(p2, inventory.Get(1));
		Assert.Equal(p3, inventory.Get(2));
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

// Test to verify that getting a potion by invalid index throws an exception
	[Fact]
	public void Get_InvalidIndex_ThrowsArgumentOutOfRange()
	{
		// Arrange
		var inventory = new Inventory<Potion>();
		inventory.Add(new Potion("Dragon's Breath Elixir", 40));

		// Act + Assert
		Assert.Throws<ArgumentOutOfRangeException>(() => inventory.Get(-1));
		Assert.Throws<ArgumentOutOfRangeException>(() => inventory.Get(10));
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

	// Test to verify that Contains only returns true for the same instance
	[Fact]
	public void Contains_ReturnsTrueOnlyForSameInstance()
	{
		// Arrange
		var inventory = new Inventory<Potion>();
		var p1 = new Potion("Healing Potion", 10);
		var p2 = new Potion("Healing Potion", 10); // Different instance but same properties

		// Act
		inventory.Add(p1);

		// Assert
		Assert.True(inventory.Contains(p1));
		Assert.False(inventory.Contains(p2));
	}

	// Test to verify that enumerator iterates through all items in order
	[Fact]
	public void Enumerator_IteratesThroughAllItemsInOrder()
	{
		// Arrange
		var inventory = new Inventory<Potion>();
		var p1 = new Potion("A", 1);
		var p2 = new Potion("B", 2);

		inventory.Add(p1);
		inventory.Add(p2);

		// Act
		var names = new List<string>();
		foreach (var p in inventory)
			names.Add(p.Name!);

		// Assert
		Assert.Equal(new[] { "A", "B" }, names);
	}

	// Test to verify that Items property returns a read-only collection
	[Fact]
	public void ItemsIsReadOnly_AndCannotBeModified()
	{
		// Arrange
		var inventory = new Inventory<Potion>();
		inventory.Add(new Potion("Lockpicking Elixir", 5));

		var view = inventory.Items; // read-only view

		// Act + Assert
		Assert.Throws<NotSupportedException>(() => { view.RemoveAt(0); });
		Assert.Equal(1, inventory.Count);
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