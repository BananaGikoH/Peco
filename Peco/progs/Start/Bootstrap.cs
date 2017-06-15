using pecopeco.progs.Property;
using pecopeco.progs.MainForm;
using System.IO;
using System.Text;
using System.Windows.Forms;
using pecopeco.progs.archive;
using Codeplex.Data;

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
			//読み出してBasePropertyに保存
			ES.startStep();

			//全体の基礎になるHTMLを生成
			if(!(File.Exists(@"setup\Base.html"))) {
				StreamWriter sw = new StreamWriter(@"setup\Base.html");
				sw.Write(takeoutTxt.BaseHTML);
				sw.Close();
			}
			if(!(File.Exists(@"setup\BaseJS.js"))) {
				StreamWriter sw = new StreamWriter(@"setup\BaseJS.js");
				sw.Write(takeoutTxt.BaseJS_js);
				sw.Close();
			}
			if(!(File.Exists(@"setup\BaseCSS.cs"))) {
				StreamWriter sw = new StreamWriter(@"setup\BaseCSS.css");
				sw.Write(takeoutTxt.BaseCSS_css);
				sw.Close();
			}

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

			string[] temprateName = new string[0];
			//初期設定で使用するテンプレートを読み込む
			int ch = 1;
			int i = 0;
			while(ch==1) {
				//MessageBox.Show(BP.SJ.DefaultTemplate.IsDefined("n_" + i).ToString());
				if(BP.SJ.DefaultTemplate.IsDefined("n_" + i)) {
					System.Array.Resize(ref temprateName,i+1);
					temprateName[i] = "";
					temprateName[i] = BP.SJ.DefaultTemplate["n_" + i]["name"];
					i = i + 1;
				} else {
					ch = 0;
				}
			}

			for(i = 0; i < temprateName.Length; i++) {
				//各テンプレートごとの処理
				//リソースファイルを書き出す
				//temprateName[i] 各テンプレートの名称
				if(!(Directory.Exists(@"Template\" + temprateName[i]))) {
					Directory.CreateDirectory(@"Template\" + temprateName[i]);
				}
			}
			/*
			if(!(File.Exists(@"Diary\DiaryBasic.html"))) {
				StreamWriter sw = new StreamWriter(@"Diary\DiaryBasic.html");
				//
				sw.Write(takeoutTxt.DiaryBasic_html);
				sw.Close();
			}
			*/
			/**/
			if(!(File.Exists(@"Template\Diary\makeHTML.js"))) {
				StreamWriter sw = new StreamWriter(@"Template\Diary\makeHTML.js");
				//
				sw.Write(takeoutTxt.BaseJS_js);
				sw.Close();
			}
			/**/
			if(!(File.Exists(@"Template\Diary\Diary_JavaScript.js"))) {
				StreamWriter sw = new StreamWriter(@"Template\Diary\Diary_JavaScript.js");
				sw.Write(takeoutTxt.Diary_JavaScript_js);
				sw.Close();
			}
			
			if(!(File.Exists(@"Template\Diary\DiaryCSS.css"))) {
				StreamWriter sw = new StreamWriter(@"Template\Diary\DiaryCSS.css");
				sw.Write(takeoutTxt.DiaryCSS_css);
				sw.Close();
			}
			
			if(!(File.Exists(@"Template\Diary\ExampleDiaryQuestion.json"))) {
				StreamWriter sw = new StreamWriter(@"Template\Diary\ExampleDiaryQuestion.json");
				sw.Write(takeoutTxt.ExampleDiaryQuestion_json);
				sw.Close();
			}
		}
	}
}

