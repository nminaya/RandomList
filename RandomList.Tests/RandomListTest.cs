using System.Collections.Generic;
using System.Linq;
using RandomList.Core;
using Xunit;

namespace RandomList.Tests
{
	public class RandomListTest
	{
		[Fact(DisplayName = nameof(CreatingInstance))]
		public void CreatingInstance()
		{
			// Act
			var randList = new RandomList<int>();

			// Assert
			Assert.NotNull(randList);
		}

		[Fact(DisplayName = nameof(Adding_OneItem))]
		public void Adding_OneItem()
		{
			// Arrange
			var randList = new RandomList<int>();

			// Act
			randList.Add(5);

			// Assert
			Assert.True(1 == randList.Count);
		}

        [Fact(DisplayName = nameof(Adding_100Items))]
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

        [Fact(DisplayName = nameof(Adding_1000Items))]
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

        [Fact(DisplayName = nameof(Removing_OneItem))]
        public void Removing_OneItem()
		{
			// Arrange
			var randList = new RandomList<int> { 1 };

			// Act
			randList.Remove(1);

			// Assert
			Assert.True(0 == randList.Count);
		}

        [Fact(DisplayName = nameof(Removing_10Items))]
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

        [Fact(DisplayName = nameof(ClearList))]
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

        [Fact(DisplayName = nameof(Contains_TrulyContains))]
        public void Contains_TrulyContains()
		{
			// Arrange
			var randList = new RandomList<int>() { 5 };

			// Act
			bool result = randList.Contains(5);

			// Assert
			Assert.True(result);
		}

        [Fact(DisplayName = nameof(Contains_NotContains))]
        public void Contains_NotContains()
		{
			// Arrange
			var randList = new RandomList<int>() { 5 };

			// Act
			bool result = randList.Contains(100);

			// Assert
			Assert.False(result);
		}

        [Fact(DisplayName = nameof(Casting_List_To_RandomList))]
        public void Casting_List_To_RandomList()
		{
			// Act
			var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

			// Act
			RandomList<int> randList = list;

			// Assert
			Assert.True(list.Count == randList.Count);
		}

        [Fact(DisplayName = nameof(Array_CopyTo))]
        public void Array_CopyTo()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var array = new int[10];

			// Act
			randList.CopyTo(array, 0);

			// Assert
			for (int i = 0; i < array.Length; i++)
			{
				Assert.True(randList[i] == array[i]);
			}
		}
	}
}
