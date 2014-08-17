using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem7 : IProblem {
		//Problem 7: 10001st prime
		//By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
		//What is the 10 001st prime number?
		//Answer: 104743 
		//First Time: 18 seconds
		//Second Time: 0.003 seconds
		public string GetAnswer() {
			var primes = PrimeHelper.FindPrimes_ToCount(10001);
			var answer = primes.Last();
			return "Problem 7: " + answer.ToString();
		}
	}
}
