using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pecopeco.progs.Property {
	/**
	 * 
	 * 参考:http://neue.cc/2010/04/30_256.html
	 * http://yuuxxxx.hatenablog.com/entry/2014/01/13/231500
	 * http://dynamicjson.codeplex.com/
	 * 
	 * http://ufcpp.net/study/csharp/sp4_dynamic.html
	 */
	public class BaseProperty {

		/*
		private static dynamic BaseProperty_json;

		public dynamic BaseProperty_entry {
			get {
				return BaseProperty_json;
			}

			set {
				BaseProperty_json = value;
			}
		}
		*/

		private static String EnvironmentName;
		private static String CurrentDirectory = "";

		public String EN {
			set {
				EnvironmentName = value;
			}
			get {
				return EnvironmentName;
			}
		}

		public String CURDIR {
			set {
				CurrentDirectory = value;
			}
			get {
				return CurrentDirectory;
			}
		}

	}
}