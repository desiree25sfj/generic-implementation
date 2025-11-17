using System;
using System.Collections;
using System.Collections.Generic;

public class Container<T> : IStorable<T>, IEnumerable<T> where T : IComparable<T>
{

	private List<T> items = new List<T>();

	public void Add(T item)
	{
		items.Add(item);
	}

	public void Add(params T[] newItems)
	{
		foreach (T item in newItems)
		{
			items.Add(item);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		foreach (T item in items)
			yield return item;
	}

	IEnumerator IEnumerable.GetEnumerator () => GetEnumerator();

	public T Get(int index)
	{
		return items[index];
	}

	public int Count => items.Count;

	public bool Contains(T item)
	{
		return items.Contains(item);
	}

	public T GetMax()
	{
		if (items.Count == 0)
			throw new InvalidOperationException("Container is empty.");

		T max = items[0];

		foreach (T item in items)
		{
			if (item.CompareTo(max) > 0)
			{
				max = item;
			}
		}
		return max;
	}
}
