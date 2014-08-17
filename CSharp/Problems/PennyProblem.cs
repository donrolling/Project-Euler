using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Problems {
	public class PennyProblem : IProblem {
		public string GetAnswer() {
			int amount = 1;
			for (int i = 0; i < 30; i++) {
				amount = amount * 2;
			}
			return Label.GetLabel(this.GetType(), (amount/100).ToString());
		}
	}
}
