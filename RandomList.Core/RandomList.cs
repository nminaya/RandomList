using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RandomList.Core
{
	/// <summary>
	/// RandomList
	/// </summary>
	/// <typeparam name="T">Generic Type</typeparam>
	public class RandomList<T> : IList<T>
	{
		private readonly List<T> _list = new List<T>();

		/// <summary>
		/// Array of random number for list indexs
		/// </summary>
		private int[] _randomIndexs;

		/// <summary>
		/// Gets or sets the element at the specified index
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set</param>
		/// <returns>The element at the specified index</returns>
		public T this[int index]
		{
			//TODO: throw ArgumentOutOfRangeException if index is out of range
			get => _list[_randomIndexs[index]];
			set => _list[_randomIndexs[index]] = value;
		}

		/// <summary>
		/// Initializes a new instance of RandomList class that
		/// is empty and has the default 
		/// initial capacity
		/// </summary>
		public RandomList()
		{
			_randomIndexs = BuildRandomNumbers();
		}

		/// <summary>
		/// Gets the number of elements contained in the RandomList
		/// </summary>
		public int Count => _list.Count;

		/// <summary>
		/// RandomList is not a ReadOnly List
		/// </summary>
		public bool IsReadOnly => false;

		/// <summary>
		/// Adds an object and reorganize the RandonList
		/// </summary>
		/// <param name="item">The object to be added</param>
		public void Add(T item)
		{
			_list.Add(item);
			_randomIndexs = BuildRandomNumbers();
		}

		/// <summary>
		/// Removes all elements
		/// </summary>
		public void Clear()
		{
			_list.Clear();
			_randomIndexs = BuildRandomNumbers();
		}

		/// <summary>
		/// Determines whether an element is in the RandomList
		/// </summary>
		/// <param name="item">The object to locate in the RandomList</param>
		/// <returns>true if item is found in the RandomList</returns>
		public bool Contains(T item) => _list.Contains(item);

		/// <summary>
		/// Copies the entire RandomList to a compatible one-dimensional
		/// array, starting at the specified index 
		/// of the target array.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional System.Array that is the destination of the elements copied
		/// from RandomList. The System.Array 
		/// must have zero-basedindexing
		/// </param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
		public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the first
		/// occurrence within the entire RandomList
		/// </summary>
		/// <param name="item">The object to locate in the RandomList</param>
		/// <returns>
		/// The zero-based index of the first occurrence 
		/// of item within the entire RandomList,
		/// if not found; –1
		/// </returns>
		public int IndexOf(T item) => _list.IndexOf(item);

		public void Insert(int index, T item)
		{
			//TODO: Handle insert element correctly
			_list.Insert(index, item);
			_randomIndexs = BuildRandomNumbers();
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the RandomList
		/// </summary>
		/// <param name="item">
		/// The object to remove from the RandomList. The value can
		/// be null for reference types
		/// </param>
		/// <returns>true if item is successfully removed</returns>
		public bool Remove(T item)
		{
			bool removedOk = _list.Remove(item);

			if (removedOk)
				_randomIndexs = BuildRandomNumbers();

			return removedOk;
		}

		/// <summary>
		/// Removes the element at the specified index of the RandomList.
		/// </summary>
		/// <param name="index">The zero-based index of the element to remove</param>
		public void RemoveAt(int index)
		{
			_list.RemoveAt(_randomIndexs[index]);
			_randomIndexs = BuildRandomNumbers();
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection
		/// </summary>
		/// <returns>
		/// An System.Collections.IEnumerator object that can be 
		/// used to iterate through the collection
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

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
		private int[] BuildRandomNumbers()
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
	}
}