using System;
using System.Windows.Forms;

using pecopeco.progs.Property;
using System.IO;
using Codeplex.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pecopeco.progs.Start {
	public class Bootstrap{

		BaseProperty bp = new BaseProperty();

		/**
		 * 最初の起動のためにやることを設定し、アプリを起動する
		 * 
		 */
		public void booting() {
			//全体の設定項目のセット
			setProperty();
		}



		/**-----------------------------------------------------------------------------------
		 * 全体の設定項目のセットを行う
		 * 設定項目が保存してあるjsonファイルを読み出し、起動時の設定書き込みメゾッドを読み出す
		 */
		void setProperty() {
			string line = String.Empty;
			string str = String.Empty;
			using(StreamReader r = new StreamReader(@"setup\peco_wholeSetup.json")) {
				while((str = r.ReadLine()) != null) { // 1行ずつ読み出し。
					line = line + str;
				}
			}

			if(line != String.Empty) {
				//jsonファイル書き込まれている場合
				var setupjson = DynamicJson.Parse(line);
				bootMethod(setupjson);
			} else {
				//jsonファイル書き込まれてない・見つからない場合
				//jsonファイル新規作成→初期内容書き込み
			}
		}

		/**------------------------------------------------------------------------------------
		 * 起動時の設定を入力するメソッド
		 */
		void bootMethod(dynamic setupjson) {

			//EnvironmentName
			bool CheckEN = setupjson.EnvironmentName.change;
			if(CheckEN) {
				//変更有->ユーザー独自設定
				bp.EN = setupjson.EnvironmentName.userSet;
			} else {
				//変更無->初期設定
				bp.EN = setupjson.EnvironmentName.Initial;
			}

			//CurrentDirectory
			bool CheckCURDIR = setupjson.CurrentDirectory.change;
			if(CheckCURDIR) {
				//変更有->ユーザー独自設定
				bp.CURDIR = setupjson.EnvironmentName.userSet;
			} else {
				//変更無->初期設定
				bp.CURDIR = Environment.CurrentDirectory;
			}
		}
	}
}
