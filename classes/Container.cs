// Generic class definition
// <T> means the class can store any type (int, string, custom classes...)
// This class implements the interface IStorable<T>, meaning it must provide
// Add(T), Get(int), Count and Contains(T).
using System.Reflection.PortableExecutable;

public class Container<T> : IStorable<T> where T : IComparable<T>
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

	// This method finds the larget item in the container
	// It works because we know T implements IComparable<T>
	// If the container is empty, it throws an exception to avoid returning an invald value
	public T GetMax()
	{
		if (items.Count == 0)
			throw new InvalidOperationException("Container is empty.");

		// Start by assuming the first item is the largest
		T max = items[0];

		// Loop through each item in the list
		foreach (T item in items)
		{
			// Compare the current item to the current max
			// If item is greater than max, update max
			if (item.CompareTo(max) > 0)
			{
				max = item;
			}
		}
		// Return the largest item after checking all elements.
		return max;
	}
}
