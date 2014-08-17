using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Problems {
	public class Problem6 : IProblem {
		//Problem 6: Sum square difference
		//The sum of the squares of the first ten natural numbers is 1^2 + 2^2 + ... + 10^2 = 385

		//The square of the sum of the first ten natural numbers is (1 + 2 + ... + 10)^2 = 55^2 = 3025

		//Hence the difference between the sum of the squares of the first ten natural numbers 
		//and the square of the sum is 3025 − 385 = 2640.

		//Find the difference between the sum of the squares of the first one hundred natural numbers 
		//and the square of the sum.
		public string GetAnswer() {
			var set = getSet(100);
			var sumOfSquares = getSumOfSquares(set);
			var squareOfSum = getSquareOfSum(set);
			return "Problem 6: " + (squareOfSum - sumOfSquares);
		}

		private double getSquareOfSum(IEnumerable<double> set) {
			var result = Math.Pow(set.Aggregate((a, b) => a + b), 2);
			return result;
		}

		private double getSumOfSquares(IEnumerable<double> set) {
			double result = 0;
			foreach (var s in set) {
				result += s * s;
			}
			return result;
		}

		private IEnumerable<double> getSet(int limit) {
			for (int i = 1; i <= limit; i++) {
				yield return i;
			}
		}

	}
}
