using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem10 : IProblem {
		//Problem 10: Summation of primes
		//The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
		//Find the sum of all the primes below two million.
		//Problem 10 Answer: 142913828922
		//First Elapsed Time (seconds): 4 hours something - forgot to sieve
		//Second Elapsed Time (seconds): 0.0190295
		public string GetAnswer() {
			var primes = PrimeHelper.FindPrimes_ToLimit(2000000);
			var sum = primes.Sum();
			return "Problem 10: " + sum.ToString();
		}
	}
}
