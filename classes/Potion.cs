public class Potion : IComparable<Potion>
{
	public string? Name { get; set; }
	public int Potency { get; set; }

public Potion (string name, int potency)
	{
		Name = name;
		Potency = potency;
	}

	public int CompareTo(Potion? other)
	{
		if (other == null) return 1;
		return Potency.CompareTo(other.Potency);
	}

	public override string ToString()
	{
		return $"{Name} (Potency: {Potency})";
	}
}