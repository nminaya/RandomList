using System;
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
	}
}
