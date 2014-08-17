using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem22 : IProblem {
		//Names scores
		//Problem 22
		//Using names.txt, a 46K text file containing over five-thousand first names, 
		//begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the 
		//list to obtain a name score.

		//For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
		//So, COLIN would obtain a score of 938 × 53 = 49714.

		//What is the total of all the name scores in the file?
		//Problem 22 Answer: 871198282
		//Elapsed Time (seconds): 0.0210021

		public string GetAnswer() {
			var answer = countAllNames();
			return Label.GetLabel(this.GetType(), answer.ToString());
		}

		private int countAllNames() {
			var names = readNamesFile().OrderBy(a => a).ToList();
			var count = 0;
			for (int i = 0; i < names.Count(); i++) {
				var name = names[i].Trim().ToLower().ToCharArray();
				var _count = 0;
				foreach (var c in name) {
					_count += ((int)c) - 96;
				}
				count += _count * (i + 1);
			}
			return count;
		}

		private List<string> readNamesFile() {
			var path = Directory.GetCurrentDirectory() + "\\Files\\Problem22.txt";
			var file = File.ReadAllText(path).Replace("\"", "");
			return file.Split(',').ToList();
		}
	}
}