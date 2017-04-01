using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pecopeco.progs.MainForm;

namespace pecopeco.progs.Start {
	//開始
	class Start {

		/**
		 * 開始
		 * argsに文字を入れれば何かできるように
		 * Bootstrap.booting(string)に
		 */
		//TODO:argsに文字を入れるときの体系について
		[STAThread]
		static void Main(string[] args) {
			Bootstrap start = new Bootstrap();
			start.booting();

			CatchArgs ca = new CatchArgs();
			ca.ArgsMenu(args);

			//Browser B = new Browser();
			//Application.Run(B);

			//BrowserHomeForm BHF = new BrowserHomeForm();
			//Application.Run(BHF);

			DiaryBrowserForm DBF = new DiaryBrowserForm();
			Application.Run(DBF);

			//HomeForm h = new HomeForm();
			//Application.Run(h);

		}
	}
}
	
