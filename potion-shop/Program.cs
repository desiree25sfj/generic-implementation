using System;

var shelf = new Inventory<Potion>();

shelf.Add(
    new Potion("Healing Potion", 25),
    new Potion("Mana Elixir", 40),
    new Potion("Dragonfire Tonic", 80)
);

Console.WriteLine($"The shop inventory contains {shelf.Count} potions.");

Console.WriteLine("\nAll potions on the shelf:");
foreach (var potion in shelf)
{
    Console.WriteLine(potion);
}

Console.WriteLine($"\nThe strongest potion is: {shelf.GetMax()}");

if (shelf.TryGet(1, out var secondPotion))
{
    Console.WriteLine($"\nPotion at shelf index 1: {secondPotion}");
}

Console.WriteLine("\nRemoving the first potion from the shelf...");
shelf.RemoveAt(0);

Console.WriteLine($"Potions left: {shelf.Count}");

Console.WriteLine("\nSnapshot of current shelf (read-only view):");
foreach (var item in shelf.Items)
{
    Console.WriteLine(item);
}
