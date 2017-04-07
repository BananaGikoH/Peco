using pecopeco.progs.Property;
using System.IO;
using System.Text;

namespace pecopeco.progs.Start {
	public class Bootstrap {

		BaseProperty bp = new BaseProperty();
		BaseProperty BPJ = new BaseProperty();
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
		}
	}
}
