using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomList.Core
{
	public class RandomList<T> : IEnumerable<T> where T : class
	{
		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}