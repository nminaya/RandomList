using System.Collections;
using RandomList.Core;
using Xunit;

namespace RandomList.Tests
{
	public class EnumeratorTests
	{
		[Fact]
		public void GetEnumerator()
		{
			// Arrange
			var randList = new RandomList<int>() { 1, 2, 3 };

			// Act
			var enumerator = randList.GetEnumerator();

			// Assert
			Assert.NotNull(enumerator);
		}

		[Fact]
		public void MoveNext_On_EmptyList()
		{
			// Arrange
			var randList = new RandomList<int>();
			var enumerator = randList.GetEnumerator();

			// Act
			bool result = enumerator.MoveNext();

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void MoveNext__On_NotEmptyList()
		{
			// Arrange
			var randList = new RandomList<int> { 1, 2, 3 };
			var enumerator = randList.GetEnumerator();

			// Act
			bool result = enumerator.MoveNext();

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void MoveNext_ThroughCollection()
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
	}
}