using pecopeco.progs.Property;
using System;
using System.Windows.Forms;

namespace pecopeco.progs.Start {

	class CatchArgs {

		static class check {
			public static string[] args;
			public static bool MissTheWriteArgs = false;
		}

		public void ArgsMenu(string[] args) {

			//args写し
			check.args = (string[])args.Clone();
			argumentManage();

			//argsから取った文字列で制御
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
	}
}
