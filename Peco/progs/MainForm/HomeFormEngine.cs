using pecopeco.progs.Property;
using System.IO;
using Codeplex.Data;
using System.Windows.Forms;

namespace pecopeco.progs.MainForm {
	class HomeFormEngine {

		//BaseProperty BP = new BaseProperty();
		BaseProperty_Json BPJ = new BaseProperty_Json();


		public string CurrentDirAdd() {
			return BPJ.CurrentDirectory();
		}

		public string[] textFricker(string s1,string s2,string s3,string s4,string s5,string s6) {
			string[] answer = {"","","",""};
			answer[0] = "出力:\n";
			answer[1] = s1 + " : " + s2;
			answer[2] = s3 + " : " + s4;
			answer[3] = s5 + " : " + s6;
			return answer;
		}

		public string jsonSave(string[] words) {

			string path = words[0];

			string content = "";

			content = "{"
					+ "\"" + words[1] + "\":" + "\"" + words[4] + "\"" + ","
					+ "\"" + words[2] + "\":" + "\"" + words[5] + "\"" + ","
					+ "\"" + words[3] + "\":" + "\"" + words[6] + "\""
					+ "}";

			var obj = DynamicJson.Parse(content);

			MessageBox.Show(obj.ToString());

			//実験
			//EditJson exp = new EditJson();
			//exp.ej(obj);

			if(File.Exists(path)) {
				//ファイルが存在する場合→上書きorキャンセル
				DialogResult result = MessageBox.Show("ファイルを上書きしますか？",
					"すでにファイルが存在しています。",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2);

				if(result == DialogResult.OK) {
					using(StreamWriter sw = new StreamWriter(path,false)) {
						sw.WriteLine(obj);
						return "書き込み完了しました";
					}
				} else {
					return "「キャンセル」が選択されました";
				}
			} else {
				//ファイルが存在しない場合→新規作成orキャンセル
				DialogResult result = MessageBox.Show("ファイルを新規作成しますか？",
					"ファイルは存在しません。",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2);

				if(result == DialogResult.OK) {
					using(StreamWriter sw = File.CreateText(path)) {
						sw.WriteLine(obj);
						return "書き込み完了しました";
					}
				} else {
					return "「キャンセル」が選択されました";
				}
			}
		}
		public void saveDiary(string DiaryTitle,string DiaryContents,object taglist) {
			string[] tags = null;
			tags = (string[])taglist;

			dynamic root = new DynamicJson();
			root.obj = new {
				Contents = new {
					No_1 = new {
						title = DiaryTitle,
						comment = DiaryContents
					}
				}
			};

			/*
			CardinalAct CA = new CardinalAct();
			var TimeDynamic = DynamicJson.Parse(CA.GetTimeNow().ToString());

			root.obj.Contents.No_1.tags = tags;
			root.obj.Contents.No_1.EditedDate = new {
				year = TimeDynamic.year,
				month = TimeDynamic.month,
				day = TimeDynamic.day,
				hour = TimeDynamic.hour,
				minute = TimeDynamic.minute,
				second = TimeDynamic.second
			};
			*/
			
			string jsonstr = DynamicJson.Serialize(root);
		}

	}
}
