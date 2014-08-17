using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem23 : IProblem {
		//Non-abundant sums
		//Problem 23
		//A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
		//For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

		//A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

		//As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
		//By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. 
		//However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of 
		//two abundant numbers is less than this limit.

		//Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
		//Problem 23 Answer: 4179871
		//Elapsed Time (seconds): 34.4127028

		public string GetAnswer() {
			var answer = solve(28123);
			return Label.GetLabel(this.GetType(), answer.ToString());
		}

		private string solve(int limit) {
			var abundantNumbers = getAbundantNumbers(limit).ToList();
			var nonAbundantSumNumbers = getNonAbundantSumNumbers(abundantNumbers, limit).Distinct().ToList();
			BigInteger result = 0;
			for (int i = 1; i < limit; i++){
				if (!nonAbundantSumNumbers.Contains(i)) {
					result += i;					
				}
			}
			return result.ToString();
		}

		private IEnumerable<int> getNonAbundantSumNumbers(List<int> abundantNumbers, int limit) {
			var half = (int)limit / 2;

			for (int i = 0; i < abundantNumbers.Count(); i++) {
				for (int j = 0; j < abundantNumbers.Count(); j++) {
					var a = abundantNumbers[i];
					var b = abundantNumbers[j];
					if (a > half && b > half) {
						continue;
					}
					var sum = a + b;
					if (sum < limit) {
						yield return sum;
					}
				}
			}
		}

		private IEnumerable<int> getAbundantNumbers(int limit) {
			for (int i = 1; i < limit; i++) {
				var divisors = getProperDivisors(i);
				var sum = divisors.Sum();
				var isAbundant = sum > i ? true : false;
				if (isAbundant) {
					yield return i;
				}
			}
		}

		private IEnumerable<int> getNumbersToLimit(int limit) {
			for (int i = 1; i < limit; i++) {
				yield return i;
			}
		}

		private IEnumerable<int> getProperDivisors(int n) {
			for (int i = 1; i <= n / 2; i++) {
				if (n % i == 0) {
					yield return i;
				}
			}
		}

	}
}