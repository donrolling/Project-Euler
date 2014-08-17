using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Helpers {
    public static class PrimeHelper {
		//the BitArray can be maxxed out by a very high limit. 
		public static IList<long> FindPrimes_ToLimit(int limit) {
			var resultArrayInitializer = (int)(limit / (Math.Log(limit) - 1.08366));
			var result = new List<long>(resultArrayInitializer);
			var maxSquareRoot = Math.Sqrt(limit);
			var eliminatedArrayInitializer = (int)limit + 1;
			var eliminated = new System.Collections.BitArray(eliminatedArrayInitializer);

			result.Add(2);

			for (int i = 3; i <= limit; i += 2) {
				if (!eliminated[i]) {
					if (i < maxSquareRoot) {
						for (int j = i * i; j <= limit; j += 2 * i)
							eliminated[j] = true;
					}
					result.Add(i);
				}
			}
			return result;
		}
		public static IList<long> FindPrimes_ToCount(long count) {
			var maxNumEstimate = (int)count * 20;
			var arrayInitializer = (int)(count / (Math.Log(count) - 1.08366));
			var result = new List<long>(arrayInitializer);
			var maxSquareRoot = Math.Sqrt(maxNumEstimate);
			var eliminated = new System.Collections.BitArray(maxNumEstimate);

			result.Add(2);

			int i = 3;
			do{
				if (!eliminated[i]) {
					if (i < maxSquareRoot) {
						for (int j = i * i; j <= maxNumEstimate; j += 2 * i) {
							eliminated[j] = true;
						}
					}
					result.Add(i);
				}
				i += 2;
			} while (result.Count < count);

			return result;
		}
    }
}
