using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory<T> : IStorable<T>, IEnumerable<T> where T : IComparable<T>
{

	private List<T> itemsOnShelf = new List<T>();

	public void Add(T item)
	{
		itemsOnShelf.Add(item);
	}

	public void Add(params T[] newItems)
	{
		foreach (T item in newItems)
		{
			itemsOnShelf.Add(item);
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		foreach (T item in itemsOnShelf)
			yield return item;
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	public T Get(int index)
	{
		return itemsOnShelf[index];
	}

	public int Count => itemsOnShelf.Count;

	public bool Contains(T item)
	{
		return itemsOnShelf.Contains(item);
	}

	public T GetMax()
	{
		if (itemsOnShelf.Count == 0)
			throw new InvalidOperationException("The potion shop is out of stock.");

		T max = itemsOnShelf[0];

		foreach (T item in itemsOnShelf)
		{
			if (item.CompareTo(max) > 0)
			{
				max = item;
			}
		}
		return max;
	}

	public bool TryGet(int index, out T? value)
	{
		if (index < 0 || index >= itemsOnShelf.Count)
		{
			value = default;
			return false;
		}

		value = itemsOnShelf[index];
		return true;
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= itemsOnShelf.Count)
			throw new ArgumentOutOfRangeException(nameof(index));

		itemsOnShelf.RemoveAt(index);
	}

	public IReadOnlyList<T> Items => itemsOnShelf.AsReadOnly();
}
