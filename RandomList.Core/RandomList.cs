using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RandomList.Core
{
	/// <summary>
	/// Represents a Collection of objects that can be interated randomly
	/// </summary>
	/// <typeparam name="T">The type of elements in the collection</typeparam>
	public class RandomList<T> : ICollection<T>
	{
		private readonly List<T> _list = new List<T>();

		/// <summary>
		/// Array of random numbers for indexs
		/// </summary>
		private int[] _randomIndexs;

		/// <summary>
		/// Gets or sets the element at the specified index
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set</param>
		/// <returns>The element at the specified index</returns>
		public T this[int index]
		{
			get => (index > _list.Count || index < 0) ? throw new IndexOutOfRangeException() : _list[_randomIndexs[index]];
			set
			{
				if (index > _list.Count || index < 0)
					throw new IndexOutOfRangeException();

				_list[_randomIndexs[index]] = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of RandomList class that
		/// is empty and has the default 
		/// initial capacity
		/// </summary>
		public RandomList() => _randomIndexs = BuildRandomIndexs();

		/// <summary>
		/// Initializes a new instance of RandomList class with the given Collection
		/// </summary>
		/// <param name="list">List</param>
		public RandomList(IEnumerable<T> list)
		{
			if (list == null)
				throw new ArgumentNullException(nameof(list));

			_list = list.ToList();
			_randomIndexs = BuildRandomIndexs();
		}

		/// <summary>
		/// Gets the number of elements contained in the Collection
		/// </summary>
		public int Count => _list.Count;

		/// <summary>
		/// Collection is not a ReadOnly List
		/// </summary>
		public bool IsReadOnly => false;

		/// <summary>
		/// Adds an object and reorganize the RandonList
		/// </summary>
		/// <param name="item">The object to be added</param>
		public void Add(T item)
		{
			_list.Add(item);
			_randomIndexs = BuildRandomIndexs(); // Reorganize indexs
		}

		/// <summary>
		/// Removes all elements
		/// </summary>
		public void Clear()
		{
			_list.Clear();
			_randomIndexs = BuildRandomIndexs();
		}

		/// <summary>
		/// Determines whether an element is in the Collection
		/// </summary>
		/// <param name="item">The object to locate in the Collection</param>
		/// <returns>true if item is found in the Collection</returns>
		public bool Contains(T item) => _list.Contains(item);

		/// <summary>
		/// Copies the entire Collection to a compatible one-dimensional
		/// array, starting at the specified index 
		/// of the target array.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional System.Array that is the destination of the elements copied
		/// from Collection. The System.Array 
		/// must have zero-basedindexing
		/// </param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			for (int i = arrayIndex, j = 0; i < _list.Count; i++, j++)
			{
				array[i] = _list[_randomIndexs[j]];
			}
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the Collection
		/// </summary>
		/// <param name="item">
		/// The object to remove from the Collection. The value can
		/// be null for reference types
		/// </param>
		/// <returns>true if item is successfully removed</returns>
		public bool Remove(T item)
		{
			bool removedOk = _list.Remove(item);

			if (removedOk)
				_randomIndexs = BuildRandomIndexs();

			return removedOk;
		}

		/// <summary>
		/// Randomize the collection again
		/// </summary>
		public void Randomize() => _randomIndexs = BuildRandomIndexs();

		/// <summary>
		/// Returns an enumerator that iterates through the collection
		/// </summary>
		/// <returns>
		/// An System.Collections.IEnumerator object that can be 
		/// used to iterate through the collection
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator() => new Enumerator(_list, _randomIndexs);

		/// <summary>
		/// Returns an enumerator that iterates through the collection
		/// </summary>
		/// <returns> An enumerator that can be used to iterate through the collection</returns>
		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < _list.Count; i++)
			{
				yield return _list[_randomIndexs[i]];
			}
		}

		/// <summary>
		/// Generate an int array of random numbers
		/// </summary>
		/// <returns>array of random numbers</returns>
		private int[] BuildRandomIndexs()
		{
			var nums = Enumerable.Range(0, _list.Count).ToArray();
			var rnd = new Random();

			for (int i = 0; i < nums.Length; ++i)
			{
				int randomIndex = rnd.Next(nums.Length);
				int temp = nums[randomIndex];
				nums[randomIndex] = nums[i];
				nums[i] = temp;
			}

			return nums;
		}

		/// <summary>
		/// Implicit cast
		/// </summary>
		/// <param name="list">List</param>
		public static implicit operator RandomList<T>(List<T> list) => new RandomList<T>(list);

		public struct Enumerator : IEnumerator<T>
		{
			private readonly List<T> _list;

			/// <summary>
			/// Array of random numbers for indexs
			/// </summary>
			private readonly int[] _randomIndexs;

			/// <summary>
			/// Current index
			/// </summary>
			private int _cursor;

			public Enumerator(List<T> list, int[] randomIndexs)
			{
				_list = list;
				_randomIndexs = randomIndexs;
				_cursor = -1;
			}

			/// <summary>
			/// Gets the element in the collection at the current position of the enumerator
			/// </summary>
			public T Current
			{
				get
				{
					if ((_cursor < 0) || (_cursor == _list.Count))
						throw new InvalidOperationException();

					return _list[_randomIndexs[_cursor]];
				}
			}

			/// <summary>
			/// Gets the element in the collection at the current position of the enumerator
			/// </summary>
			object IEnumerator.Current => this.Current;

			public void Dispose()
			{
				_list.GetEnumerator().Dispose();
			}

			/// <summary>
			/// Advances the enumerator to the next element of the collection
			/// </summary>
			/// <returns>true if the enumerator was successfully advanced to the next element</returns>
			public bool MoveNext()
			{
				if (_cursor < _list.Count)
					_cursor++;

				return _cursor != _list.Count;
			}

			/// <summary>
			/// Sets the enumerator to its initial position
			/// </summary>
			public void Reset()
			{
				_cursor = -1;
			}
		}
	}
}