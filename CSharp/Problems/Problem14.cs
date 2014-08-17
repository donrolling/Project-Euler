using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;
using System.Numerics;

namespace CSharp.Problems {
	public class Problem14 : IProblem {
		//Problem 14: Longest Collatz sequence
		//The following iterative sequence is defined for the set of positive integers:

		//n → n/2 (n is even)
		//n → 3n + 1 (n is odd)

		//Using the rule above and starting with 13, we generate the following sequence:
		//13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
		//It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. 
		//Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
		//Which starting number, under one million, produces the longest chain?
		//NOTE: Once the chain starts the terms are allowed to go above one million.

		//Problem 14 Answer: 837799 with a count of: 525
		//Elapsed Time (seconds): 2.2831306

		public string GetAnswer() {
			var n = 1000000;//1000000
			var answer = findStartingNumForLongestChain(n);
			//var r = findCollatzSequenceLength(n);
			return "Problem 14 Answer: " + answer.Item1.ToString() + " with a count of: " + answer.Item2.ToString();
		}

		private Tuple<int, int> findStartingNumForLongestChain(int n) {
			var val = 0;
			var count = 0;

			for (int i = 1; i < n; i++) {
				var s = findCollatzSequenceLength(i);
				if (s > count) {
					val = i;
					count = s;
				}
			}

			return Tuple.Create<int, int>(val, count);
		}
		private void printCollatzSequence(List<int> ns) {
			foreach (var n in ns) {
				Console.Write(n + ", ");
			}
		}
		private int findCollatzSequenceLength(long n) {
			var i = n;
			var length = 1;
			do {
				if (i % 2 == 0) {
					i = i / 2;
				} else {
					i = (3 * i) + 1;
				}
				length++;
			} while (i != 1);

			return length;
		}
		private List<int> runCollatzSequence(int n) {
			var r = new List<int>();

			var i = n;
			do {
				if (i % 2 == 0) {
					r.Add(i / 2);
				} else {
					r.Add((3 * i) + 1);
				}
				i = r.Last();
			} while (i > 1);

			return r;
		}
	}
}
