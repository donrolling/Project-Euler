using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem16 : IProblem {
		//Power digit sum
		//Problem 16
		//2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
		//What is the sum of the digits of the number 2^1000?
		public string GetAnswer() {
			var answer = BigInteger.Pow(2, 1000).ToString().ToCharArray().Aggregate(0, (current, item) => current + int.Parse(item.ToString()));
			return Label.GetLabel(this.GetType(), answer.ToString());
		}
	}
}
