using System;
using System.Linq;
using RandomList.Core;
using Xunit;

namespace RandomList.Tests
{
	public class IndexerTests
	{
		[Fact]
		public void Setting_And_Getting_Value()
		{
			// Arrange
			var randList = new RandomList<int>(Enumerable.Range(0, 10));

			// Act
			randList[5] = 20;
			int value = randList[5];

			// Assert
			Assert.True(value == 20);
		}

		[Fact]
		public void GettingValues_OutOfRange_NegativeIndex()
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

		[Fact]
		public void GettingValues_OutOfRange_IndexBiggerThanLength()
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

		[Fact]
		public void SettingValues_OutOfRange_NegativeIndex()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			// Act
			Action action = () => randList[-5] = 10;

			// Assert
			Assert.Throws<IndexOutOfRangeException>(action);
		}

		[Fact]
		public void SettingValues_OutOfRange_IndexBiggerThanLength()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2 };

			// Act
			Action action = () => randList[2] = 100;

			// Assert
			Assert.Throws<IndexOutOfRangeException>(action);
		}

		[Fact]
		public void GettingValue_Index_Equals_Count()
		{
			// Arrange
			var randList = new RandomList<int> { 1 };

			// Act 
			Action action = () =>
			{
				var value = randList[1];
			};

			// Assert
			Assert.Throws<IndexOutOfRangeException>(action);
		}

		[Fact]
		public void SettingValue_Index_Equals_Count()
		{
			// Arrange
			var randList = new RandomList<int> { 1 };

			// Act 
			Action action = () => randList[1] = 10;

			// Assert
			Assert.Throws<IndexOutOfRangeException>(action);
		}
	}
}