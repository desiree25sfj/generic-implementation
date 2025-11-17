using System;

Container<int> intContainer = new Container<int>();

intContainer.Add(10);
intContainer.Add(20);
intContainer.Add(30);

Console.WriteLine($"The container has {intContainer.Count} numbers.");
Console.WriteLine($"The max value is: {intContainer.GetMax()}");

Console.WriteLine($"The first number is: {intContainer.Get(0)}");
Console.WriteLine($"The second number is: {intContainer.Get(1)}");

Container<string> stringContainer = new Container<string>();

stringContainer.Add("Hello");
stringContainer.Add("World");

Console.WriteLine($"The container has {stringContainer.Count} words.");
Console.WriteLine($"The first word is: {stringContainer.Get(0)}");

IStorable<int> store = new Container<int>();
store.Add(10);
store.Add(20);

Console.WriteLine(store.Get(0));

IStorable<string> words = new Container<string>();
words.Add("Interface");
words.Add("Magic");

Console.WriteLine($"Stored via interface: {words.Get(1)}");

Console.WriteLine(words.Contains("Magic"));
Console.WriteLine(words.Contains("Chaos"));

intContainer.Add(40, 50, 60);
Console.WriteLine($"Container now has {intContainer.Count} numbers.");

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