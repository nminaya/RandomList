using System;
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

		[Fact(DisplayName = nameof(Enumerator_MoveNextThroughCollection))]
		public void Enumerator_MoveNextThroughCollection()
		{
			// Arrange
			var randList = new RandomList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var enumerator = randList.GetEnumerator();
			int count = 0;

			// Act
			while (enumerator.MoveNext())
			{
				// Assert
				int current = enumerator.Current;
				Assert.True(current == randList[count]);
				count++;
			}
		}

		[Fact(DisplayName = nameof(Randomizing))]
		public void Randomizing()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var randListBeforeReorder = randList.ToArray();
			var equalValues = new bool[10];

			// Act
			randList.Randomize();

			// Assert
			for (int i = 0; i < randList.Count; i++)
			{
				equalValues[i] = randList[i] == randListBeforeReorder[i];
			}

			// Ok if contains any false value
			Assert.Contains(equalValues, v => !v);
		}

		[Fact(DisplayName = nameof(Indexs_GettingValues_OutOfRange_NegativeIndex))]
		public void Indexs_GettingValues_OutOfRange_NegativeIndex()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			// Act
			Action action = () => 
			{
				var value = randList[-5];
			};

			// Assert
			Assert.Throws<IndexOutOfRangeException>(action);
		}

		[Fact(DisplayName = nameof(Indexs_GettingValues_OutOfRange_IndexBiggerThanLength))]
		public void Indexs_GettingValues_OutOfRange_IndexBiggerThanLength()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2 };

			// Act
			Action action = () =>
			{
				var value = randList[2];
			};

			// Assert
			Assert.Throws<IndexOutOfRangeException>(action);
		}

		[Fact(DisplayName = nameof(Indexs_SettingValues_OutOfRange_NegativeIndex))]
		public void Indexs_SettingValues_OutOfRange_NegativeIndex()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			// Act
			Action action = () =>
			{
				randList[-5] = 10;
			};

			// Assert
			Assert.Throws<IndexOutOfRangeException>(action);
		}

		[Fact(DisplayName = nameof(Indexs_SettingValues_OutOfRange_IndexBiggerThanLength))]
		public void Indexs_SettingValues_OutOfRange_IndexBiggerThanLength()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2 };

			// Act
			Action action = () =>
			{
				randList[2] = 100;
			};

			// Assert
			Assert.Throws<IndexOutOfRangeException>(action);
		}
	}
}
