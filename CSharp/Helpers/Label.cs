using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Helpers;

namespace CSharp.Helpers {
	public static class Label {
		public static string GetLabel(Type type, string answer) {
			var template = "{0} Answer: {1}";
			var typeName = type.Name.UnCamelCase();
			var label = string.Format(template, typeName, answer);
			return label;
		}
	}
}
