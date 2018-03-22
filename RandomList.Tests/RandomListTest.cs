using System.Collections.Generic;
using System.Linq;
using RandomList.Core;
using Xunit;

namespace RandomList.Tests
{
	public class RandomListTest
	{
		[Fact]
		public void CreatingInstance()
		{
			// Act
			var randList = new RandomList<int>();

			// Assert
			Assert.NotNull(randList);
		}

		[Fact]
		public void Adding_OneItem()
		{
			// Arrange
			var randList = new RandomList<int>();

			// Act
			randList.Add(5);

			// Assert
			Assert.True(1 == randList.Count);
		}

		[Fact]
		public void Adding_100Items()
		{
			// Arrange
			var randList = new RandomList<int>();

			// Act
			for (int i = 0; i < 100; i++)
			{
				randList.Add(i);
			}

			// Assert
			Assert.True(100 == randList.Count);
		}

		[Fact]
		public void Adding_1000Items()
		{
			// Arrange
			var randList = new RandomList<int>();

			// Act
			for (int i = 0; i < 1000; i++)
			{
				randList.Add(i);
			}

			// Assert
			Assert.True(1000 == randList.Count);
		}

		[Fact]
		public void Removing_OneItem()
		{
			// Arrange
			var randList = new RandomList<int> { 1 };

			// Act
			randList.Remove(1);

			// Assert
			Assert.True(0 == randList.Count);
		}

		[Fact]
		public void Removing_10Items()
		{
			// Arrange
			var randList = new RandomList<int>();

			for (int i = 0; i < 10; i++)
			{
				randList.Add(i);
			}

			// Act
			for (int i = 0; i < 10; i++)
			{
				randList.Remove(i);
			}

			// Assert
			Assert.True(0 == randList.Count);
		}

		[Fact]
		public void ClearList()
		{
			// Arrange
			var randList = new RandomList<int>();

			for (int i = 0; i < 10; i++)
			{
				randList.Add(i);
			}

			// Act
			randList.Clear();

			// Assert
			Assert.True(0 == randList.Count);
		}

		[Fact]
		public void Contains_TrulyContains()
		{
			// Arrange
			var randList = new RandomList<int>() { 5 };

			// Act
			bool result = randList.Contains(5);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void Contains_NotContains()
		{
			// Arrange
			var randList = new RandomList<int>() { 5 };

			// Act
			bool result = randList.Contains(100);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void Casting_List_To_RandomList()
		{
			// Act
			var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

			// Act
			RandomList<int> randList = list;

			// Assert
			Assert.True(list.Count == randList.Count);
		}
	}
}
