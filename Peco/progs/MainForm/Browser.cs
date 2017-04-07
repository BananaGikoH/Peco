using System;
using System.Windows.Forms;

namespace pecopeco.progs.MainForm {
	[System.Runtime.InteropServices.ComVisibleAttribute(true)]
	public partial class Browser : Form {
		//*******************************************************************************************************
		//http://crossframe.iiv.jp/20130408163/
		//*******************************************************************************************************

		public Browser() {
			InitializeComponent();

			webBrowser1.ObjectForScripting = this;
			webBrowser1.Navigate(
				new Uri("file:///C:/Users/pecopeco/Documents/workspace/Chush/Peco/Peco/bin/Debug/test/test.html"));

		}
		public void CSfunc1(string value) {
			MessageBox.Show(value);
		}
		private void button1_Click(object sender,EventArgs e) {
			object[] args = { "これはC#からブラウザのJSを呼び出して実行するC#動作" };
			webBrowser1.Document.InvokeScript("JSfunc1",args);
		}
		private void button2_Click(object sender,EventArgs e) {
			string js01 = "alert('Check!')";
			webBrowser1.Url = new Uri("javascript:" + js01 + ";");
		}
		//*******************************************************************************************************
	}
}
