// Generic class definition
// <T> means the class can store any type (int, string, custom classes...)
// This class implements the interface IStorable<T>, meaning it must provide
// Add(T), Get(int), Count and Contains(T).
public class Container<T> : IStorable<T>
{
	// Internal list that holds the items of type T
	// This is the actual storage mechanism for the class
	private List<T> items = new List<T>();

	// Adds an item of type T to the internal list

	public void Add(T item)
	{
		items.Add(item);
	}

	// Returns the item at the given index from the internal list
	// Because T is generic, this method returns whatever type the container was created with

	public T Get(int index)
	{
		return items[index];
	}

	// Property that returns how many items are stored
	// This comes directly from items.Count

	public int Count => items.Count;

	// Checks whether the internal list contains the provided item

	public bool Contains(T item)
	{
		return items.Contains(item);
	}
}
