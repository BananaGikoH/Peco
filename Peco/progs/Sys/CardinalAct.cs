using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pecopeco.progs.Sys {
	class CardinalAct {
		public DynamicJson GetTimeNow() {
			DateTime dt = System.DateTime.Now;
			int yr = 0;
			int mo = 0;
			int da = 0;
			int ho = 0;
			int mi = 0;
			int se = 0;
			yr = int.Parse(dt.ToString("yyyyy"));
			mo = int.Parse(dt.ToString("MM"));
			da = int.Parse(dt.ToString("dd"));
			ho = int.Parse(dt.ToString("HH"));
			mi = int.Parse(dt.ToString("mm"));
			se = int.Parse(dt.ToString("ss"));

			dynamic root = new DynamicJson();
			root.year = yr;
			root.month = mo;
			root.day = da;
			root.hour = ho;
			root.minute = mi;
			root.second = se;

			return root;
		}
	}
}
