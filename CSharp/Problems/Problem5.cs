using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Problems {
	public class Problem5 : IProblem {
		//Problem 5: Smallest multiple
		//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
		//What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
		//Problem 5 Answer: 232792560
		//First Elapsed Time (seconds): 8.1818591
		public string GetAnswer() { 
			var set = getSet(20);
			var smallestMultiple = findSmallestMultipleOfSet(set);
			return "Problem 5: " + smallestMultiple.ToString();
		}

		private long findSmallestMultipleOfSet(IEnumerable<int> set) {
			long num = 0;
			bool test = false;
			do {
				num = num + set.Last();
				test = isDivisibleByAll(num, set);
			} while (!test);
			return num;
		}

		private IEnumerable<int> getSet(int limit) {
			for (int i = 1; i <= limit; i++) {
				yield return i;
			}
		}

		private bool isDivisibleByAll(long num, IEnumerable<int> set) {
			foreach (var s in set) {
				if (num % s != 0) {
					return false;
				}
			}
			return true;
		}
	}
}
