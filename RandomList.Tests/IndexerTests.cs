﻿using System;
using RandomList.Core;
using Xunit;

namespace RandomList.Tests
{
	public class IndexerTests
	{
		[Fact(DisplayName = nameof(GettingValues_OutOfRange_NegativeIndex))]
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

		[Fact(DisplayName = nameof(GettingValues_OutOfRange_IndexBiggerThanLength))]
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

		[Fact(DisplayName = nameof(SettingValues_OutOfRange_NegativeIndex))]
		public void SettingValues_OutOfRange_NegativeIndex()
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

		[Fact(DisplayName = nameof(SettingValues_OutOfRange_IndexBiggerThanLength))]
		public void SettingValues_OutOfRange_IndexBiggerThanLength()
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