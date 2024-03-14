using CCG = CustomCollections.Generic;

namespace _038_Les_Tests;

public class UnitTestCustomList
{
	[Fact]
	public void EmptyList()
	{
		CCG.List<int> list = new();
		Assert.Empty(list);
		Assert.Equal(4, list.Capacity);
		Assert.False(list.IsReadOnly);
	}

	[Fact]
	public void ListWithCapacity()
	{
		CCG.List<int> list = new(10);
		Assert.Empty(list);
		Assert.Equal(10, list.Capacity);
		Assert.False(list.IsReadOnly);
	}

	[Fact]
	public void ListWithCollection()
	{
		List<int> collection = new() { 1, 2, 3, 4, 5 };
		CCG.List<int> list = new(collection);
		Assert.Equal(5, list.Count);
		Assert.Equal(5, list.Capacity);
		Assert.False(list.IsReadOnly);
		Assert.Equal(1, list[0]);
		Assert.Equal(2, list[1]);
		Assert.Equal(3, list[2]);
		Assert.Equal(4, list[3]);
		Assert.Equal(5, list[4]);
	}

	[Fact]
	public void ListWithNullCollection()
	{
		Assert.Throws<ArgumentNullException>(() => new CCG.List<int>(null));
	}

	[Fact]
	public void ListWithNegativeCapacity()
	{
		Assert.Throws<ArgumentOutOfRangeException>(() => new CCG.List<int>(-1));
	}

	[Fact]
	public void Indexer()
	{
		CCG.List<int> list = new() { 1, 2, 3, 4, 5 };
		Assert.Equal(1, list[0]);
		Assert.Equal(2, list[1]);
		Assert.Equal(3, list[2]);
		Assert.Equal(4, list[3]);
		Assert.Equal(5, list[4]);
	}

	[Fact]
	public void IndexerOutOfRange()
	{
		CCG.List<int> list = new() { 1, 2, 3, 4, 5 };
		Assert.Throws<IndexOutOfRangeException>(() => list[-1]);
		Assert.Throws<IndexOutOfRangeException>(() => list[5]);
	}

	[Fact]
	public void IndexerSet()
	{
		CCG.List<int> list = new() { 1, 2, 3, 4, 5 };
		list[0] = 10;
		Assert.Equal(10, list[0]);
	}

	[Fact]
	public void IndexerSetOutOfRange()
	{
		CCG.List<int> list = new() { 1, 2, 3, 4, 5 };
		Assert.Throws<IndexOutOfRangeException>(() => list[-1] = 10);
		Assert.Throws<IndexOutOfRangeException>(() => list[5] = 10);
	}

	[Fact]
	public void Add()
	{
		CCG.List<int> list = new();
		list.Add(1);
		Assert.Equal(1, list.Count);
		Assert.Equal(4, list.Capacity);
		Assert.Equal(1, list[0]);
	}

	[Fact]
	public void AddWithResize()
	{
		CCG.List<int> list = new(4);
		list.Add(1);
		list.Add(2);
		list.Add(3);
		list.Add(4);
		list.Add(5);
		Assert.Equal(5, list.Count);
		Assert.Equal(8, list.Capacity);
		Assert.Equal(1, list[0]);
		Assert.Equal(2, list[1]);
		Assert.Equal(3, list[2]);
		Assert.Equal(4, list[3]);
		Assert.Equal(5, list[4]);
	}

	[Fact]
	public void AddRange()
	{
		CCG.List<int> list = new();
		list.AddRange(new int[] { 1, 2, 3, 4, 5 });
		Assert.Equal(5, list.Count);
		Assert.Equal(5, list.Capacity);
		Assert.Equal(1, list[0]);
		Assert.Equal(2, list[1]);
		Assert.Equal(3, list[2]);
		Assert.Equal(4, list[3]);
		Assert.Equal(5, list[4]);
	}
}