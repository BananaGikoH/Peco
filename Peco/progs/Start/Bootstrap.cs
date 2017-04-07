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
using Newtonsoft.Json;

namespace pecopeco.progs.Start {
	public class Bootstrap {

		BaseProperty bp = new BaseProperty();
		BaseProperty_Json BPJ = new BaseProperty_Json();
		Sys.EditSetup ES = new Sys.EditSetup();

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
		 * 設定項目が保存してあるjsonファイルを読み出す
		 * 完全に初期起動だった場合、設定ファイルを作成
		 * 過去に起動している場合は、起動時の設定書き込みメゾッドを読み出す
		 */
		void setProperty() {

			if(!(Directory.Exists(@"setup"))) {
				Directory.CreateDirectory(@"setup");
			}
			
			//将来はJsonの中身で検索、指定をかけても良いかもしれない
			if(!(File.Exists(@"setup\peco_wholeSetup.json"))) {
				Encoding enc = new UTF8Encoding(false);
				StreamWriter sw = new StreamWriter(@"setup\peco_wholeSetup.json",false,enc);
				sw.Write(ES.createFirstRuleJson());
				sw.Close();
			}

			ES.startStep();
			bootMethod(BPJ.SJ);

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
