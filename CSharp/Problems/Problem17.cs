using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem17 : IProblem {
		//Number letter counts
		//Problem 17
		//If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
		//If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
		//NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) 
		//contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
		//Problem 17 Answer: 21124
		//Elapsed Time (seconds): 0.0030039

		public string GetAnswer() {
			var nums = new StringBuilder(3000);
			for (int i = 1; i <= 1000; i++) {
				var s = numbersToWords(i);
				nums.Append(s.Replace(" ", ""));
			}
			var answer = nums.ToString().Length;
			return Label.GetLabel(this.GetType(), answer.ToString());
		}

		private string numbersToWords(int n) {
			var f = int.Parse(n.ToString()[0].ToString());

			if (n < 10) {
				return ones(n);
			}

			if (n >= 10 && n < 100) {
				return tens(n);
			}else {
				var place = "";
				var h = movePlace(n, 10);
				if (n >= 100 && n < 1000) {
					if (n % 100 == 0) {
						place =" hundred ";
					}else{
						place =" hundred and ";
					}
				} else if (n >= 1000 && n < 10000) {
					place =" thousand ";
				}
				return ones(f) + place + numbersToWords(h);
			}
		}

		private int movePlace(int number, int divisor) {
			var s = number.ToString();
			var _n = int.Parse(s.Substring(1, s.Length - 1));
			return _n;
		}

		private string ones(int n) {
			switch ((int)n) {
				case 1:
					return "one";
				case 2:
					return "two";
				case 3:
					return "three";
				case 4:
					return "four";
				case 5:
					return "five";
				case 6:
					return "six";
				case 7:
					return "seven";
				case 8:
					return "eight";
				case 9:
					return "nine";
			}
			return "";
		}

		private string tens(int n) {
			if (n >= 100) {
				throw new Exception();
			}
			var s = 0;
			if (n >= 10) {
				s = int.Parse(n.ToString()[1].ToString());
			}
			if (n < 10) {
				return ones(n);
			} else if (n < 20 && n > 9) {
				switch ((int)n) {
					case 10:
						return "ten";
					case 11:
						return "eleven";
					case 12:
						return "twelve";
					case 13:
						return "thirteen";
					case 14:
						return "fourteen";
					case 15:
						return "fifteen";
					case 16:
						return "sixteen";
					case 17:
						return "seventeen";
					case 18:
						return "eighteen";
					case 19:
						return "nineteen";
				}
			} else if (n >= 20 && n < 30) {
				return "twenty " + ones(s);
			} else if (n >= 30 && n < 40) {
				return "thirty " + ones(s);
			} else if (n >= 40 && n < 50) {
				return "forty " + ones(s);
			} else if (n >= 50 && n < 60) {
				return "fifty " + ones(s);
			} else if (n >= 60 && n < 70) {
				return "sixty " + ones(s);
			} else if (n >= 70 && n < 80) {
				return "seventy " + ones(s);
			} else if (n >= 80 && n < 90) {
				return "eighty " + ones(s);
			} else if (n >= 90 && n < 100) {
				return "ninety " + ones(s);
			}
			return "";
		}
	}
}
