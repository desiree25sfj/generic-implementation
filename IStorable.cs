// This is a generic interface
// <T> means any class implementing this interface must
// use the same type parameter for all its methods
public interface IStorable<T>
{
	// Method for adding an item of type T.
	void Add(T item);

	// Method for retrieving an item based on its index
	T Get(int index);

	// Property that returns the total number of stored items
	int Count { get; }

	// Method that checks whether a gived item exists
	bool Contains(T item);
}