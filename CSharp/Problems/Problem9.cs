using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Problems {
	public class Problem9 : IProblem {
		//Problem 9: Special Pythagorean triplet
		//A Pythagorean triplet is a set of three natural numbers, a < b < c, for which, a^2 + b^2 = c^2
		//For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
		//There exists exactly one Pythagorean triplet for which a + b + c = 1000.
		//Find the product abc.
		public string GetAnswer() {
			var tries = 100;
			var attempts = 0;
			Tuple<int, int, int, int> answer;
			for (int i = 0; i < tries; i++) {
				for (int j = 0; j < tries; j++) {
					attempts++;
					try {
						answer = getPythagoreanTripletAndSum(i, j);
						var format = "{0}, {1}, {2} summed = {3} proof of triplet: {4} + {5} = {6} product = {7} attempts = {8}";
						if (answer.Item4 == 1000) {
							return "Problem 9: " + string.Format(format, answer.Item1.ToString(), answer.Item2.ToString(), answer.Item3.ToString(), answer.Item4.ToString(), (answer.Item1 * answer.Item1).ToString(), (answer.Item2 * answer.Item2).ToString(), (answer.Item3 * answer.Item3).ToString(), (answer.Item1 * answer.Item2 * answer.Item3).ToString(), attempts.ToString());
						}
					} catch { }
				}
			}
			return "Problem 9: unanswered";
		}

		private Tuple<int, int, int, int> getPythagoreanTripletAndSum(int m, int n) {
			var q = 0;
			if (m < n) {
				q = m;
				m = n;
				n = q;
			}
			if (m < 0 || n < 0) {
				throw new Exception("Euclid is mad! All inputs must be greater than 0.");
			}
			if ((m - n) % 2 == 0) {
				throw new Exception("Euclid is mad! m - n must be odd.");
			}
			if (!areCoprime(m, n)) {
				throw new Exception("Euclid is mad! m and n must be coprime (their greatest common divisor being 1).");
			}
			var k = 0;
			var a = 0;
			var b = 0;
			var c = 0;

			do {
				k++;
				a = k * ((m * m) - (n * n));
				b = k * (2 * m * n);
				c = k * ((m * m) + (n * n));
			} while ((c * c) != (a * a) + (b * b));

			var s = a + b + c;
			return Tuple.Create<int, int, int, int>(a, b, c, s);
		}

		private bool areCoprime(int m, int n) {
			var nd = getDivisors(n);
			var md = getDivisors(m);
			var s = nd.Intersect(md);
			if (s.Any()) {
				return false;
			}
			return true;
		}
		private IEnumerable<int> getDivisors(int n) {
			var sequence = getSequenceToLimit(n);
			foreach (var s in sequence) {
				if (n % s == 0) {
					yield return s;
				}
			}
		}
		public IEnumerable<int> getSequenceToLimit(int limit) {
			for (int i = 2; i <= getSqrt(limit); i++) {
				yield return i;
			}
		}
		private int getSqrt(int num) {
			var sqrt = (int)Math.Round(Math.Sqrt((double)num));
			return sqrt;
		}
	}
}
