using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class Problem11 : IProblem {
		//Problem 11: Largest product in a grid
		//In the 20×20 grid below, four numbers along a diagonal line have been marked in red.

		//08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
		//49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
		//81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
		//52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
		//22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
		//24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
		//32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
		//67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
		//24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
		//21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
		//78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
		//16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
		//86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
		//19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
		//04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
		//88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
		//04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
		//20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
		//20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
		//01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48

		//The product of these numbers is 26 × 63 × 78 × 14 = 1788696.
		//What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?

		//Problem 11 Answer: 70600674
		//Elapsed Time (seconds): 0.010001

		public enum direction { up, down, left, right, upleft, upright, downleft, downright }
		
		public int totalDiags = 289;
		public int totalOrths = 340;

		public string GetAnswer() {//notes: need to figure out array overflow...means diagonals aren't calculating correctly
			var grid = getGrid();

			var diagonal_LR_Starts = getDiagonal_LR_Starts();
			if (diagonal_LR_Starts.Count() != totalDiags) {
				throw new Exception("There should be a total of " + totalDiags.ToString() + " diagonals in each set.");
			}
			var highestProductOfDiagonal_LR_Starts = getHighestProductOfDiagonal_LR_Starts(grid, diagonal_LR_Starts);

			var diagonal_RL_Starts = getDiagonal_RL_Starts();
			if (diagonal_RL_Starts.Count() != totalDiags) {
				throw new Exception("There should be a total of " + totalDiags.ToString() + " diagonals in each set.");
			}
			var highestProductOfDiagonal_RL_Starts = getHighestProductOfDiagonal_RL_Starts(grid, diagonal_RL_Starts);

			var orthogonal_LR_Starts = getOrthogonal_LR_Starts();
			if (orthogonal_LR_Starts.Count() != totalOrths) {
				throw new Exception("There should be a total of " + totalOrths.ToString() + " orthogonals in each set.");
			}
			var highestProductOfOrthogonal_LR_Starts = getHighestProductOfOrthogonal_LR_Starts(grid, orthogonal_LR_Starts);

			var orthogonal_UD_Starts = getOrthogonal_UD_Starts();
			if (orthogonal_UD_Starts.Count() != totalOrths) {
				throw new Exception("There should be a total of " + totalOrths.ToString() + " orthogonals in each set.");
			}
			var highestProductOfOrthogonal_UD_Starts = getHighestProductOfOrthogonal_UD_Starts(grid, orthogonal_UD_Starts);

			var answer = new List<int> { highestProductOfDiagonal_LR_Starts, highestProductOfDiagonal_RL_Starts, highestProductOfOrthogonal_LR_Starts, highestProductOfOrthogonal_UD_Starts }.Max();

			return "Problem 11 Answer: " + answer.ToString();
		}

		private int getHighestProductOfDiagonal_LR_Starts(int[] grid, int[] diagonal_LR_Starts) {
			var result = new List<int>();
			foreach (var d in diagonal_LR_Starts) {
				var t = getDiagonal_LR(d, grid);
				var p = multiplyTuple(t);
				result.Add(p);
			}
			return result.Max();
		}
		private Tuple<int, int, int, int> getDiagonal_LR(int d, int[] grid) {
			var d2 = getMoveNum(d, direction.upright);
			var d3 = getMoveNum(d2, direction.upright);
			var d4 = getMoveNum(d3, direction.upright);
			return Tuple.Create<int, int, int, int>(grid[d], grid[d2], grid[d3], grid[d4]);
		}
		private int getHighestProductOfDiagonal_RL_Starts(int[] grid, int[] diagonal_RL_Starts) {
			var result = new List<int>();
			foreach (var d in diagonal_RL_Starts) {
				var t = getDiagonal_RL(d, grid);
				var p = multiplyTuple(t);
				result.Add(p);
			}
			return result.Max();
		}
		private Tuple<int, int, int, int> getDiagonal_RL(int d, int[] grid) {
			var d2 = getMoveNum(d, direction.upleft);
			var d3 = getMoveNum(d2, direction.upleft);
			var d4 = getMoveNum(d3, direction.upleft);
			return Tuple.Create<int, int, int, int>(grid[d], grid[d2], grid[d3], grid[d4]);
		}
		private int getHighestProductOfOrthogonal_LR_Starts(int[] grid, int[] orthogonal_LR_Starts) {
			var result = new List<int>();
			foreach (var d in orthogonal_LR_Starts) {
				var t = getOrtogonal_LR(d, grid);
				var p = multiplyTuple(t);
				result.Add(p);
			}
			return result.Max();
		}
		private Tuple<int, int, int, int> getOrtogonal_LR(int o, int[] grid) {
			var o2 = getMoveNum(o, direction.right);
			var o3 = getMoveNum(o2, direction.right);
			var o4 = getMoveNum(o3, direction.right);
			return Tuple.Create<int, int, int, int>(grid[o], grid[o2], grid[o3], grid[o4]);
		}
		private int getHighestProductOfOrthogonal_UD_Starts(int[] grid, int[] orthogonal_UD_Starts) {
			var result = new List<int>();
			foreach (var d in orthogonal_UD_Starts) {
				var t = getOrtogonal_UD(d, grid);
				var p = multiplyTuple(t);
				result.Add(p);
			}
			return result.Max();
		}
		private Tuple<int, int, int, int> getOrtogonal_UD(int o, int[] grid) {
			var o2 = getMoveNum(o, direction.down);
			var o3 = getMoveNum(o2, direction.down);
			var o4 = getMoveNum(o3, direction.down);
			return Tuple.Create<int, int, int, int>(grid[o], grid[o2], grid[o3], grid[o4]);
		}
		
		private int[] getDiagonal_LR_Starts() {
			var diagonals = new int[totalDiags];
			var rowSize = 16;
			var index = 0;
			for (int i = 0; i <= rowSize; i++) {
				var rowStart = (i * 20) + 60;
				diagonals[index] = rowStart;
				index++;
				for (int j = 0; j < rowSize; j++) {
					var value = rowStart + 1 + j;
					diagonals[index] = value;
					index++;
				}
			}
			if (diagonals.Contains(0)) {
				throw new Exception("Zero should not occur in the list of diagonals.");
			}
			return diagonals;
		}
		private int[] getDiagonal_RL_Starts() {
			var diagonals = new int[totalDiags];
			var rowSize = 16;
			var index = 0;
			for (int i = 0; i <= rowSize; i++) {
				var rowStart = (i * 20) + 79;
				diagonals[index] = rowStart;
				index++;
				for (int j = 0; j < rowSize; j++) {
					var value = rowStart - 1 - j;
					diagonals[index] = value;
					index++;
				}
			}
			if (diagonals.Contains(0)) {
				throw new Exception("Zero should not occur in the list of diagonals.");
			}
			return diagonals;
		}
		private int[] getOrthogonal_LR_Starts() {
			var orthogonals = new int[totalOrths];
			var rowSize = 17;
			var index = 0;
			for (int i = 0; i < rowSize; i++) {
				var rowStart = i * 20;
				orthogonals[index] = rowStart;
				index++;
				for (int j = 0; j < rowSize; j++) {
					var value = rowStart + 1 + j;
					orthogonals[index] = value;
					index++;
				}
			}
			return orthogonals;
		}
		private int[] getOrthogonal_UD_Starts() {
			var orthogonals = new int[totalOrths];
			var rowSize = 20;
			var index = 0;
			for (int i = 0; i < 16; i++) {
				var rowStart = i * 20;
				orthogonals[index] = rowStart;
				index++;
				for (int j = 0; j < rowSize; j++) {
					var value = rowStart + 1 + j;
					orthogonals[index] = value;
					index++;
				}
			}
			return orthogonals;
		}

		private int multiplyTuple(Tuple<int, int, int, int> t) {
			return t.Item1 * t.Item2 * t.Item3 * t.Item4;
		}
		private int getMoveNum(int current, direction dir) {
			switch (dir) {
				case direction.up:
					return current - 20;
				case direction.down:
					return current + 20;
				case direction.left:
					return current - 1;
				case direction.right:
					return current + 1;
				case direction.upleft:
					return current - 21;
				case direction.upright:
					return current - 19;
				case direction.downleft:
					return current + 19;
				case direction.downright:
					return current + 21;
			}
			return 0;
		}
		private int[] getGrid() {
			var grid = new int[400] { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08, 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00, 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65, 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91, 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80, 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50, 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70, 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21, 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72, 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95, 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92, 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57, 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58, 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40, 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66, 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69, 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36, 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16, 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54, 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 };
			return grid;
		}
	}
}
