using System;

// Creating a Container<int> means we are using the generic class "Container"
// with the type parameter T set to int. This instance can only store integers.
Container<int> intContainer = new Container<int>();

// Adding integer values to the container
intContainer.Add(10);
intContainer.Add(20);
intContainer.Add(30);

// Count comes from the Container<T> class and returns how many items it stores
Console.WriteLine($"The container has {intContainer.Count} numbers.");
Console.WriteLine($"The max value is: {intContainer.GetMax()}");
// Expected output: "The max value is: 30"

// Get(index) retrieves an item from the internal list
// Since this container stores ints, the returned value is an int
Console.WriteLine($"The first number is: {intContainer.Get(0)}");
Console.WriteLine($"The second number is: {intContainer.Get(1)}");

// Creating a new container that stores strings instead of ints
// Same class, different type parameter - this is why generics exist
Container<string> stringContainer = new Container<string>();

// Adding some strings to the container
stringContainer.Add("Hello");
stringContainer.Add("World");

Console.WriteLine($"The container has {stringContainer.Count} words.");
Console.WriteLine($"The first word is: {stringContainer.Get(0)}");

// Here we create a Container<int>, but store it in a variable typed as IStorable<int>
// This shows that Container<int> *implements* the interface.
// We can only access members defines in the interface (Add, Get, Count, Contains)
IStorable<int> store = new Container<int>();
store.Add(10);
store.Add(20);

// Get(index) works because the interface requires it
Console.WriteLine(store.Get(0));

// Same pattern, but now with strings
// Again; the variable type is the interface, but the object type is Container<string>
IStorable<string> words = new Container<string>();
words.Add("Interface");
words.Add("Magic");

// Accessing the stored items through the interface
Console.WriteLine($"Stored via interface: {words.Get(1)}");

// Contains(item) checks if the value exists in the container
Console.WriteLine(words.Contains("Magic")); // should be true
Console.WriteLine(words.Contains("Chaos")); // should be false, because it was never added

// Adding several integers in one call
intContainer.Add(40, 50, 60);
Console.WriteLine($"Container now has {intContainer.Count} numbers.");

// Adding multiple strings at once
stringContainer.Add("Lunch", "Dinner", "Breakfast");
Console.WriteLine($"Container now has {stringContainer.Count} words.");

Console.WriteLine("Looping through intContainer with foreach:");
foreach (var num in intContainer)
{
	Console.WriteLine(num);
}

Console.WriteLine("Looping through stringContainer with foreach:");
foreach (var word in stringContainer)
{
	Console.WriteLine(word);
}