using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Helpers {
	public static class StringExtensions {
		public static string UnCamelCase(this string value) {
			var lastCharWasNumber = false;
			if (!string.IsNullOrEmpty(value)) {
				var sb = new StringBuilder();
				foreach (char c in value) {
					if (char.IsLower(c) || (char.IsNumber(c) && !lastCharWasNumber)) {
						lastCharWasNumber = true;
						sb.Append(c);
					} else {
						if (char.IsNumber(c)) {
							lastCharWasNumber = false;
						}
						sb.Append(" " + c);
					}
				}

				return sb.ToString().Trim();
			}

			return value;
		}
	}
}
