using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem15 : IProblem {
		//Lattice paths
		//Problem 15
		//Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
		//http://projecteuler.net/problem=15
		//How many such routes are there through a 20×20 grid?
		//Problem 15 Answer: 137846528820
		//Elapsed Time (seconds): 0.1110333

		public string GetAnswer() {
			var answer = routesToBottomRight(20);
			return Label.GetLabel(this.GetType(), answer.ToString());
		}

		private BigInteger routesToBottomRight(int gridSize) {
			var arr = new BigInteger[gridSize * gridSize];
			for (int i = 0; i < gridSize; i++) {
				for (int j = 0; j < gridSize; j++) {
					var index = (i * gridSize) + j;
					arr[index] = index == 0 ? 2 
									: i == 0 ? arr[index-1] + 1 
										: j == 0 ? arr[index-gridSize] + 1 
											: arr[index - 1] + arr[index - gridSize];
					//Console.WriteLine(index + " " + arr[index]);
				}
			}

			return arr[(gridSize * gridSize) - 1];
		}
	}
}
