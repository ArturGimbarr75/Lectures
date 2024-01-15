class CarComparer : IComparer<Car>
{
	public int Compare(Car? x, Car? y)
	{
		if (x is null)
			return y is null ? 0 : -1;

		if (y is null)
			return 1;

		if (x.FuelUssage > y.FuelUssage)
			return 1;

		if (x.FuelUssage < y.FuelUssage)
			return -1;

		return 0;
	}
}
