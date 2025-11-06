using System.Runtime.CompilerServices;

public class Container<T> : IStorable<T>
{
	private List<T> items = new List<T>();

	public void Add(T item)
	{
		items.Add(item);
	}

	public T Get(int index)
	{
		return items[index];
	}

	public int Count => items.Count;
}
