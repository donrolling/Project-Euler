using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem21 : IProblem {
		//Amicable numbers
		//Problem 21
		//Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
		//If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

		//For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

		//Evaluate the sum of all the amicable numbers under 10000.
		
		//Problem 21 Answer: 31626
		//Elapsed Time (seconds): 0.3072902

		public string GetAnswer() {
			var answer = findAmicableNumbers(10000);
			return Label.GetLabel(this.GetType(), answer.ToString());
		}

		private int findAmicableNumbers(int limit) {
			var amicableNumbers = new List<int>();
			var n = 2;
			do {
				var a = findAmicableNumber(n);
				if (a > 0 && a < limit) {
					if (!amicableNumbers.Contains(a)) {
						amicableNumbers.Add(a);
					}
					if (!amicableNumbers.Contains(n)) {
						amicableNumbers.Add(n);
					}
				}
				n++;
			} while (n <= limit);
			return amicableNumbers.Sum();
		}

		private int findAmicableNumber(int n) {
			var d = getDivisors(n).Sum();
			if (n == d) {
				return 0;
			}
			var a = getDivisors(d).Sum();
			return a == n ? d : 0;
		}

		private List<int> getDivisors(int n) {
			var divisors = new List<int>();
			var d = 1;
			do {
				if (n % d == 0) {
					divisors.Add(d);
				}
				d++;
			} while (d < n);
			return divisors;
		}
	}
}