using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem19 : IProblem {
		//Counting Sundays
		//Problem 19
		//You are given the following information, but you may prefer to do some research for yourself.

		//1 Jan 1900 was a Monday.
		//Thirty days has September,
		//April, June and November.
		//All the rest have thirty-one,
		//Saving February alone,
		//Which has twenty-eight, rain or shine.
		//And on leap years, twenty-nine.
		//A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
		//How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

		//Problem 19 Answer: 171
		//Elapsed Time (seconds): 0.0010008
		
		public string GetAnswer() {
			var answer = countSundays();
			return Label.GetLabel(this.GetType(), answer.ToString());
		}

		private int countSundays() {
			var result = 0;
			
			var startDate = new DateTime(1901, 1, 1);
			var endDate = new DateTime(2000, 12, 31);

			var currentDate = startDate;
			do {
				if (currentDate.DayOfWeek == DayOfWeek.Sunday) {
					result++;
				}
				currentDate = currentDate.AddMonths(1);
				if (currentDate.Day != 1) {
					throw new Exception("adding months isn't working.");
				}
			} while (currentDate <= endDate);

			return result;
		}
	}
}
