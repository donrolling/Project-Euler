using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Problems {
	public class Problem4 : IProblem {
		//Problem 4: Largest palindrome product
		//A palindromic number reads the same both ways. The largest palindrome made from the product 
		//of two 2-digit numbers is 9009 = 91 × 99.
		//Find the largest palindrome made from the product of two 3-digit numbers.
		//Problem 4 Answer: 906609
		//First Elapsed Time (seconds): 0.1381436
		public string GetAnswer() { 
			var set1 = getNumbersOfLength(3);
			var set2 = getNumbersOfLength(3);
			var palindromes = getPalindromes(set1, set2);
			return "Problem 4: " + palindromes.Max().ToString();
		}

		private IEnumerable<long> getPalindromes(IEnumerable<long> set1, IEnumerable<long> set2) { 
			foreach (var s1 in set1) {
				foreach (var s2 in set2) {
					var product = s1 * s2;
					if (isPalindrome(product)) {
						//Console.WriteLine(s1.ToString() + " * " + s2.ToString() + " = " + product.ToString());
						yield return product;
					}
				}
			}
		}

		private IEnumerable<long> getNumbersOfLength(int length) {
			if (length <= 1) {
				for (long i = 0; i < 10; i++) {
					yield return i;
				}
			} else { 
				var startString = "1";
				for (int i = 1; i < length; i++) {
					startString += "0";
				}
				long startNum = 0;
				long.TryParse(startString, out startNum);
				
				var max = startNum * 10 - 1;
				for (long i = startNum - 1; i < max; i++) {
					yield return i + 1;
				}
			}
		} 

		private bool isPalindrome(long num) {
			if (num < 10) {
				return false;
			}
			var str = num.ToString();
			for (int i = 0; i < str.Length / 2; i++) {
				var front = str[i];
				var back = str[str.Length - (i + 1)];
				if (front != back) {
					return false;
				}
			}
			return true;
		}
	}
}
