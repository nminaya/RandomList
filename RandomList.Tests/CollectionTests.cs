﻿using RandomList.Core;
using Xunit;

namespace RandomList.Tests
{
	public class CollectionTests
	{
		[Theory(DisplayName = nameof(AddingItems))]
		[InlineData(1)]
		[InlineData(100)]
		[InlineData(1000)]
		public void AddingItems(int itemsCount)
		{
			// Arrange
			var randList = new RandomList<int>();

			// Act
			for (int i = 0; i < itemsCount; i++)
			{
				randList.Add(i);
			}

			// Assert
			Assert.True(itemsCount == randList.Count);
		}

		[Theory]
		[InlineData(1)]
		[InlineData(100)]
		[InlineData(1000)]
		public void RemovingItems(int itemsCount)
		{
			// Arrange
			var randList = new RandomList<int>();

			for (int i = 0; i < itemsCount; i++)
			{
				randList.Add(i);
			}

			// Act
			for (int i = 0; i < itemsCount; i++)
			{
				randList.Remove(i);
			}

			// Assert
			Assert.True(0 == randList.Count);
		}

		[Fact]
		public void Removing_NonExistentItem()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2, 3 };

			// Act
			bool resutl = randList.Remove(5);

			// Assert
			Assert.False(resutl);
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
				// Comparing each element in randList with the array
				Assert.True(randList[i] == array[i]);
			}
		}
	}
}