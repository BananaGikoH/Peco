using pecopeco.progs.Property;
using pecopeco.progs.MainForm;
using System.IO;
using System.Text;
using System.Windows.Forms;
using pecopeco.progs.archive;

namespace pecopeco.progs.Start {
	public class Bootstrap {
		BaseProperty BP = new BaseProperty();
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

			//リソースファイルを書き出す
			if(!(Directory.Exists(@"Diary"))) {
				Directory.CreateDirectory(@"Diary");
			}
			/**/
			if(!(File.Exists(@"Diary\DiaryBasic.html"))) {
				StreamWriter sw = new StreamWriter(@"Diary\DiaryBasic.html");
				//
				sw.Write(takeoutTxt.DiaryBasic_html);
				sw.Close();
			}
			/*
			if(!(File.Exists(@"Diary\base.html"))) {
				StreamWriter sw = new StreamWriter(@"Diary\base.html");
				//
				sw.Write(takeoutTxt.baseHTML);
				sw.Close();
			}
			if(!(File.Exists(@"Diary\makeHTML.js"))) {
				StreamWriter sw = new StreamWriter(@"Diary\makeHTML.js");
				//
				sw.Write(takeoutTxt.makeHTML_js);
				sw.Close();
			}
			*/
			if(!(File.Exists(@"Diary\Diary_JavaScript.js"))) {
				StreamWriter sw = new StreamWriter(@"Diary\Diary_JavaScript.js");
				sw.Write(takeoutTxt.Diary_JavaScript_js);
				sw.Close();
			}
			
			if(!(File.Exists(@"Diary\DiaryCSS.css"))) {
				StreamWriter sw = new StreamWriter(@"Diary\DiaryCSS.css");
				sw.Write(takeoutTxt.DiaryCSS_css);
				sw.Close();
			}
			
			if(!(File.Exists(@"Diary\ExampleDiaryQuestion.json"))) {
				StreamWriter sw = new StreamWriter(@"Diary\ExampleDiaryQuestion.json");
				sw.Write(takeoutTxt.ExampleDiaryQuestion_json);
				sw.Close();
			}
			
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

			//初期設定のためのHTMLを作成
			if(BP.SJ.JustGetStarted.firstLaunch) {
				//setupの中にHTML作成
				//

				SettingForm SF = new SettingForm();
				Application.Run(SF);

				//firstLaunchをfalseに
				BP.SJ.JustGetStarted.firstLaunch = false;
				BP.UpdateSJ();
			}
		}
	}
}

