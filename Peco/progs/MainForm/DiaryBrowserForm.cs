using Codeplex.Data;
using pecopeco.progs.Property;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pecopeco.progs.MainForm {
	public partial class DiaryBrowserForm : Form {

		BaseProperty BPJ = new BaseProperty();

		DiaryBrowserFormEngine dbfe = new DiaryBrowserFormEngine();

		public DiaryBrowserForm() {



			InitializeComponent();

			webBrowser1.ObjectForScripting = this;
			webBrowser1.Navigate(
			new Uri(dbfe.SendURI()));
		}

		public string ThrowSavePath() {
			return BPJ.CurrentDirectory() + @"\Diary\Diary_2017-01-01.json";
		}
		public string ThrowTemplatePath() {
			return BPJ.CurrentDirectory() + @"\Diary\ExampleDiaryQuestion.json";
		}

		public string OpenDirDialog() {
			string loadPath = string.Empty;

			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.Description = "開くフォルダを選択してください";
			fbd.SelectedPath = BPJ.CurrentDirectory();
			fbd.ShowNewFolderButton = true;
			if(fbd.ShowDialog() == DialogResult.OK) {
				//OKボタンがクリックされたとき、選択されたファイル名を表示する
				loadPath = fbd.SelectedPath;
			}
			loadPath = loadPath + @"\Diary_2017-01-01.json";
			return loadPath;
		}

		public void Save(String path,String json) {
			var obj = DynamicJson.Parse(json);
			dbfe.save(obj,path);
		}

		public new string Load(String path) {
			string info = string.Empty;
			info = dbfe.load(path);
			return info;
		}
	}
}
