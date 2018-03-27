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
			Assert.True(randList.Count == 0);
		}

		[Fact(DisplayName = nameof(CreatingInstance_Passing_IEnumerable))]
		public void CreatingInstance_Passing_IEnumerable()
		{
			// Arrange
			var list = Enumerable.Range(0, 10);

			// Act
			var randList = new RandomList<int>(list);

			// Assert
			Assert.True(randList.Count == list.Count());
		}

		[Fact(DisplayName = nameof(CreatingInstance_Passing_Null_IEnumerable))]
		public void CreatingInstance_Passing_Null_IEnumerable()
		{
			// Arrange
			IEnumerable<int> list = null;

			// Act
			Action action = () =>
			{
				var randList = new RandomList<int>(list);
			};

			// Assert
			Assert.Throws<ArgumentNullException>(action);
		}

		[Fact(DisplayName = nameof(Casting_List_To_RandomList))]
		public void Casting_List_To_RandomList()
		{
			// Act
			var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

			// Act
			RandomList<int> randList = list; //Implicit cast

			// Assert
			Assert.True(list.Count == randList.Count);
		}

		[Fact(DisplayName = nameof(Randomizing))]
		public void Randomizing()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var randListBeforeRandomize = randList.ToArray();
			var equalValues = new bool[10];

			// Act
			randList.Randomize();

			// Assert
			for (int i = 0; i < randList.Count; i++)
			{
				equalValues[i] = randList[i] == randListBeforeRandomize[i];
			}

			// Ok if contains any false value
			Assert.Contains(equalValues, v => !v);
		}

		[Fact(DisplayName = nameof(GetItemRandomly))]
		public void GetItemRandomly()
		{
			// Arrange
			var randList = new RandomList<int>(Enumerable.Range(0, 10));

			// Act
			int item = randList.GetItemRandomly();

			// Assert
			Assert.Contains(item, randList);
		}
	}
}
