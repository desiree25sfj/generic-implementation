public interface IStorable<T>
{
	void Add(T item);
	T Get(int index);
	int Count { get;  }
}