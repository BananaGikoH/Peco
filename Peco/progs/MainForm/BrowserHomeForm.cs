using Codeplex.Data;
using pecopeco.progs.Property;
using System;
using System.Windows.Forms;

namespace pecopeco.progs.MainForm {
	[System.Runtime.InteropServices.ComVisible(true)]
	public partial class BrowserHomeForm : Form {
		public BrowserHomeForm() {
			InitializeComponent();

			webBrowser1.ObjectForScripting = this;
			webBrowser1.Navigate(
				new Uri("file:///C:/Users/pecopeco/Documents/workspace/Chush/Peco/Peco/bin/Debug/test/preDiary/DiaryBase.html"));
			
		}
		//BaseProperty bp = new BaseProperty();
		BaseProperty BPJ = new BaseProperty();

		public string ThrowSavePath() {
			webBrowser1.ObjectForScripting = new BrowserHomeForm();
			return BPJ.CurrentDirectory()+ @"\test\QandA.json";
		}
		BrowserHomeFormEngine bhfe = new BrowserHomeFormEngine();

		public void Save(String path,String json) {
			var obj = DynamicJson.Parse(json);
			bhfe.save(obj,path);
		}

		public string OpenFileDialog() {
			string loadPath = string.Empty;

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "開くファイルを選択してください";
			ofd.InitialDirectory = BPJ.CurrentDirectory();
			ofd.RestoreDirectory = true;
			if(ofd.ShowDialog() == DialogResult.OK) {
				//OKボタンがクリックされたとき、選択されたファイル名を表示する
				loadPath = ofd.FileName;
			}
			return loadPath;
		}
		public string Road(String path) {
			string info = string.Empty;
			info = bhfe.load(path);
			return info;
		}
	}
}
