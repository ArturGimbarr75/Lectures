class VarKeeper
{
	public int Value { get; private set; }

	public void IncrementWithoutLock()
	{
		var locker = this;
		++locker;
		Console.WriteLine(Value);
    }

	public void IncrementWithLock()
	{
		var locker = this;
		lock (locker)
		{
			++locker;
            Console.WriteLine(this);
        }
	}

	public static VarKeeper operator ++(VarKeeper varKeeper)
	{
		return new VarKeeper { Value = varKeeper.Value + 1 };
	}

	override public string ToString() => Value.ToString();
}