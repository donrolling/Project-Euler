using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem24 : IProblem {
		//Lexicographic permutations
		//Problem 24
		//A permutation is an ordered arrangement of obiects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
		//If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

		//012   021   102   120   201   210

		//What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8, 9?

		public string GetAnswer() {
			var answer = solve(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1000000);
			return Label.GetLabel(this.GetType(), answer.ToString());
		}
		
		private string solve(int[] perm, int limit) {
			var count = 1;
			var n = perm.Length;

			while (count < limit) {
				var i = n - 1;
				while (perm[i - 1] >= perm[i]) {
					i = i - 1;
				}

				var j = n;
				while (perm[j - 1] <= perm[i - 1]) {
					j = j - 1;
				}

				// swap values at position i-1 and j-1
				perm = swap(perm, i - 1, j - 1);

				i++;
				j = n;
				while (i < j) {
					perm = swap(perm, i - 1, j - 1);
					i++;
					j--;
				}
				count++;
			}

			var permNum = string.Join("", perm);
			return permNum;
		}

		private int[] swap(int[] perm, int i, int j) {
			int k = perm[i];
			perm[i] = perm[j];
			perm[j] = k;
			return perm;
		}
	}
}