using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem3 : IProblem {
		//Problem 3: Largest prime factor
		//The prime factors of 13195 are 5, 7, 13 and 29.
		//What is the largest prime factor of the number 600851475143 ?
		//Problem 3 Answer: 6857
		//First Elapsed Time (seconds): 0.0670802
		public string GetAnswer() { 
			var num = 600851475143;
			var limit = getSqrt(num);
			var odds = getOdds(limit, num);
			var primes = getPrimeFactors(odds, num);
			return "Problem 3: " + primes.Max().ToString();
		}

		private long getSqrt(long num) { 
			var sqrt = (long)Math.Round(Math.Sqrt((double)num));
			return sqrt;
		}

		public IEnumerable<long> getPrimeFactors(IEnumerable<long> odds, long num) {
			foreach (var odd in odds) {
				var potentialDivisors = odds.Where(a => a <= getSqrt(odd));
				if (potentialDivisors.Any()) {
					var hasDivisor = false;
					foreach (var potentialDivisor in potentialDivisors) {
						if (odd % potentialDivisor == 0) {
							hasDivisor = true;
							break;
						}
					}
					if (!hasDivisor && num % odd == 0) {
 						yield return odd;
					}
				}
			}
		}
		public IEnumerable<long> getOdds(long limit, long num) { 
			for(long i = 3; i <= limit; i++){
				if (i % 2 != 0 && num % i == 0) {
					yield return i;
				}
			}
		}
	}
}
