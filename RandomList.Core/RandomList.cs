using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RandomList.Core
{
	public class RandomList<T> : IList<T> where T : class
	{
		private readonly List<T> _list = new List<T>();

		private int[] _randomIndexs;

		public T this[int index]
		{
			get => _list[_randomIndexs[index]];
			set => _list[_randomIndexs[index]] = value;
		}

		public RandomList()
		{
			_randomIndexs = BuildRandomNumbers();
		}

		public int Count => _list.Count;

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			_list.Add(item);
			_randomIndexs = BuildRandomNumbers();
		}

		public void Clear()
		{
			_list.Clear();
			_randomIndexs = BuildRandomNumbers();
		}

		public bool Contains(T item) => _list.Contains(item);

		public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

		public int IndexOf(T item) => _list.IndexOf(item);

		public void Insert(int index, T item)
		{
			_list.Insert(index, item);
			_randomIndexs = BuildRandomNumbers();
		}

		public bool Remove(T item)
		{
			bool removedOk = _list.Remove(item);

			if (removedOk)
				_randomIndexs = BuildRandomNumbers();

			return removedOk;
		}

		public void RemoveAt(int index)
		{
			_list.RemoveAt(index);
			_randomIndexs = BuildRandomNumbers();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < _list.Count; i++)
			{
				yield return _list[_randomIndexs[i]];
			}
		}

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