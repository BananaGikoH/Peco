using pecopeco.progs.Property;
using System;
using System.Windows.Forms;

namespace pecopeco.progs.Start {

	class CatchArgs {
		static class check {
			public static string[] args;
			public static bool MissTheWriteArgs = false;
		}
		public int ArgsMenu(string[] args) {
			int judge = 0;

			//args写し
			check.args = (string[])args.Clone();
			argumentManage();
			judge = judgeNumber();
			return judge;
		}
		BaseProperty BPJ = new BaseProperty();

		/**
		 * 引数処理
		 */
		void argumentManage() {
			string str = "";
			if(0 < check.args.Length) {
				str = check.args[0];
			}

			if(0 < str.Length) {
				string stTarget = "";

				//最初の指定の引数を検知
				if(0 < check.args.Length) {
					stTarget = check.args[0];
				}

				//-で始まってなければ間違い
				if(stTarget.StartsWith("-")) {
					//引数処理
					MessageBox.Show("オプション操作です：" + check.args[0],BPJ.EnvironmentName()+ " option");

					//--modeか
					if("--mode" == check.args[0]) {
						mode();
					}

				} else {
					//間違ってコマンド入力した場合
					check.MissTheWriteArgs = true;
				}
			}

			if(check.MissTheWriteArgs == true) {
				//TODO:Bottunに変えること

				MessageBox.Show("適切なオプション指示ではありません",BPJ.EnvironmentName() + " error");
				MessageBox.Show("プログラムを終了します。",BPJ.EnvironmentName() + " error");
				Environment.Exit(0);
			}
		}
		static class modetakeoff {
			public static bool check = false;
			public static int num = 1100;
		}
		static class debug {
			public static bool check = false;
			public static int num = 9999;
		}
		void mode() {
			string str = "";
			str = check.args[1];
			if("takeoff" == str) {
				modetakeoff.check = true;
			}
			if("debug" == str) {
				debug.check = true;
			}
		}
		int judgeNumber() {
			int mag = 0;
			if(modetakeoff.check == true) {
				mag = modetakeoff.num;
			}
			if(debug.check == true) {
				mag = debug.num;
			}
			return mag;
		}
	}
}
