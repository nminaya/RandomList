using RandomList.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RandomList.Tests
{
    public class EnumeratorTests
    {
        [Fact(DisplayName = nameof(GetEnumerator))]
        public void GetEnumerator()
        {
            // Arrange
            var randList = new RandomList<int>() { 1, 2, 3 };

            // Act
            var enumerator = randList.GetEnumerator();

            // Assert
            Assert.NotNull(enumerator);
        }

        [Fact(DisplayName = nameof(MoveNext_EmptyList))]
        public void MoveNext_EmptyList()
        {
            // Arrange
            var randList = new RandomList<int>();
            var enumerator = randList.GetEnumerator();

            // Act
            bool result = enumerator.MoveNext();

            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = nameof(MoveNext_NotEmptyList))]
        public void MoveNext_NotEmptyList()
        {
            // Arrange
            var randList = new RandomList<int> { 1, 2, 3 };
            var enumerator = randList.GetEnumerator();

            // Act
            bool result = enumerator.MoveNext();

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = nameof(MoveNextThroughCollection))]
        public void MoveNextThroughCollection()
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
