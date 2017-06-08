using pecopeco.progs.Property;
using System;
using System.IO;
using System.Windows.Forms;

namespace pecopeco.progs.MainForm {
	class DiaryBrowserFormEngine {
		//*************************************************************************
		BaseProperty BPJ = new BaseProperty();
		public string SendURI() {

			Uri u1 = new Uri(BPJ.CurrentDirectory() + @"\");
			Uri u2 = new Uri(u1,@"Diary\DiaryBasic.html");
			//Uri u2 = new Uri(u1,@"Diary\base.html");

			return u2.AbsoluteUri;
		}
		//*************************************************************************
		public void save(dynamic obj,string path) {

			MessageBox.Show(obj.ToString());

			if(File.Exists(path)) {
				//ファイルが存在する場合→上書きorキャンセル
				DialogResult result = MessageBox.Show("ファイルを上書きしますか？",
					"すでにファイルが存在しています。",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2);

				if(result == DialogResult.OK) {
					//上書き
					using(StreamWriter sw = new StreamWriter(path,false)) {
						sw.WriteLine(obj);
						MessageBox.Show("書き込み完了しました");
					}
				} else {
					//キャンセル
					MessageBox.Show("「キャンセル」が選択されました");
				}
			} else {
				//ファイルが存在しない場合→新規作成orキャンセル
				DialogResult result = MessageBox.Show("ファイルを新規作成しますか？",
					"ファイルは存在しません。",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button2);

				if(result == DialogResult.OK) {
					//新規作成
					using(StreamWriter sw = File.CreateText(path)) {
						sw.WriteLine(obj);
						MessageBox.Show("書き込み完了しました");
					}
				} else {
					MessageBox.Show("「キャンセル」が選択されました");
				}
			}
		}
		//*************************************************************************
		//http://d.hatena.ne.jp/mftech/20101109/1289293236
		//*************************************************************************
		public string load(String path) {
			// 結果格納変数
			string result = string.Empty;

			// ファイルの存在チェック
			if(System.IO.File.Exists(path)) {

				// StreamReaderでファイルを読み込む
				System.IO.StreamReader reader = (new StreamReader(path,System.Text.Encoding.GetEncoding("utf-8")));

				// ファイルの最後まで読み込む
				result = reader.ReadToEnd();

				// 閉じる (オブジェクトの破棄)
				reader.Close();
			}

			// 結果を表示する
			return result;
		}
	}
}
