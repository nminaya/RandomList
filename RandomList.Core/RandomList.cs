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
		/// <summary>
		/// Internal list for backing data
		/// </summary>
		private readonly List<T> _list;

		/// <summary>
		/// Random instance
		/// </summary>
		private readonly Random _random = new Random();

		/// <summary>
		/// Array of random numbers for indexes
		/// </summary>
		private int[] _randomIndexes;

		/// <summary>
		/// Flag for when collection has changed (item added or removed)
		/// </summary>
		private bool _collectionHasChanged;

		/// <summary>
		/// Gets or sets the element at the specified index
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set</param>
		/// <returns>The element at the specified index</returns>
		public T this[int index]
		{
			get
			{
				if (index >= _list.Count || index < 0)
					throw new IndexOutOfRangeException();

				if (_collectionHasChanged)
					ShuffleRandomIndexes();

				return _list[_randomIndexes[index]];
			}
			set
			{
				if (index >= _list.Count || index < 0)
					throw new IndexOutOfRangeException();

				if (_collectionHasChanged)
					ShuffleRandomIndexes();

				_list[_randomIndexes[index]] = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of RandomList class that
		/// is empty and has the default 
		/// initial capacity
		/// </summary>
		public RandomList()
		{
			_list = new List<T>();
			ShuffleRandomIndexes();
		}

		/// <summary>
		/// Initializes a new instance of RandomList class with the given Collection
		/// </summary>
		/// <param name="list">List</param>
		public RandomList(IEnumerable<T> list)
		{
			if (list == null)
				throw new ArgumentNullException(nameof(list));

			_list = new List<T>(list);
			ShuffleRandomIndexes();
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
			_collectionHasChanged = true;
		}

		/// <summary>
		/// Removes all elements
		/// </summary>
		public void Clear()
		{
			_list.Clear();
			_collectionHasChanged = true;
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
			if (_collectionHasChanged)
				ShuffleRandomIndexes();

			for (int i = arrayIndex, j = 0; i < _list.Count; i++, j++)
			{
				array[i] = _list[_randomIndexes[j]];
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
				_collectionHasChanged = true;

			return removedOk;
		}

		/// <summary>
		/// Randomize the collection again
		/// </summary>
		public void Randomize() => ShuffleRandomIndexes();

		/// <summary>
		/// Get an item randomly from the collection
		/// </summary>
		/// <returns>An item from the collection</returns>
		public T GetItemRandomly()
		{
			int randomIndex = _random.Next(_list.Count);

			return _list[randomIndex];
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection
		/// </summary>
		/// <returns>
		/// An System.Collections.IEnumerator object that can be 
		/// used to iterate through the collection
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>
		/// Returns an enumerator that iterates through the collection
		/// </summary>
		/// <returns> An enumerator that can be used to iterate through the collection</returns>
		public IEnumerator<T> GetEnumerator()
		{
			if (_collectionHasChanged)
				ShuffleRandomIndexes();

			for (int i = 0; i < _list.Count; i++)
			{
				yield return _list[_randomIndexes[i]];
			}
		}

		/// <summary>
		/// Generate an int array of random numbers
		/// </summary>
		/// <returns>array of random numbers</returns>
		private void ShuffleRandomIndexes()
		{
			var nums = Enumerable.Range(0, _list.Count).ToArray();

			for (int i = 0; i < nums.Length; ++i)
			{
				// Fisher-Yates shuffle algorithm
				int randomIndex = i + _random.Next(nums.Length - i);

				if(i != randomIndex)
					Swap(ref nums[i], ref nums[randomIndex]);
			}

			_randomIndexes = nums;
			_collectionHasChanged = false;

			void Swap(ref int a, ref int b)
			{
				int temp = a;
				a = b;
				b = temp;
			}
		}

		/// <summary>
		/// Implicit cast
		/// </summary>
		/// <param name="list">List</param>
		public static implicit operator RandomList<T>(List<T> list) => new RandomList<T>(list);
	}
}