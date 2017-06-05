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

			int num = 0;
			CatchArgs ca = new CatchArgs();
			num = ca.ArgsMenu(args);

			Start ma = new Start();
			ma.numcheck(num);
		}
		void numcheck(int num) {
			//通常起動のとき
			if(0 == num) {
				DiaryBrowserForm DBF = new DiaryBrowserForm();
				Application.Run(DBF);
			}
			//takeoffmode(見えないモード)
			if(1100 == num) {
				MessageBox.Show("take off mode Goes on ...","takeoff mode");
			}
			//debug mode
			if(9999 == num) {
				MessageBox.Show("debug mode Goes on ...","debug mode");
				DiaryBrowserForm DBF = new DiaryBrowserForm();
				Application.Run(DBF);
			}
		}
	}
}
	
