Container<int> intContainer = new Container<int>();
intContainer.Add(10);
intContainer.Add(20);
intContainer.Add(30);

Console.WriteLine($"The container has {intContainer.Count} numbers.");
Console.WriteLine($"The first number is: {intContainer.Get(0)}");
Console.WriteLine($"The second number is: {intContainer.Get(1)}");

Container<string> stringContainer = new Container<string>();
stringContainer.Add("Hello");
stringContainer.Add("World");

Console.WriteLine($"The container has {stringContainer.Count} words.");
Console.WriteLine($"The first word is: {stringContainer.Get(0)}");
