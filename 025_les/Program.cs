//1
{
	GenericClass<int> list = new(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
	list.Print();
	Console.WriteLine(list.Exists(5));
	list.Find(x => x == 5);
}
