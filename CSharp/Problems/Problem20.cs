using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem20 : IProblem {
		//Factorial digit sum
		//Problem 20
		//n! means n × (n − 1) × ... × 3 × 2 × 1

		//For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
		//and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

		//Find the sum of the digits in the number 100!

		//Problem 20 Answer: 648
		//Elapsed Time (seconds): 0.0009866

		public string GetAnswer() {
			var answer = getFactorialDigitSum(100);
			return Label.GetLabel(this.GetType(), answer.ToString());
		}
		
		private int getFactorialDigitSum(int n) {
			var digits = getFactorialDigits(n).ToString();
			var result = 0;
			foreach (var c in digits) {
				int d = Int32.Parse(c.ToString());
				result += d;
			}
			return result;
		}
		
		private BigInteger getFactorialDigits(int n) {
			BigInteger result = n;
			do {
				result = result * (n - 1);
				n--;
			} while (n > 1);
			return result;
		}
	}
}
