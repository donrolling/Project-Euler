using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp {
	internal class Program {

		private static void Main(string[] args) {
			var startTime = DateTime.Now;
			var message = "{0}\nElapsed Time (seconds): {1}";
			var answer = new Problems.Problem26().GetAnswer();
			var endTime = DateTime.Now;
			var diff = (endTime - startTime).TotalSeconds;
			Console.WriteLine(string.Format(message, answer, diff.ToString()));
			Console.ReadLine();
		}
	}
}