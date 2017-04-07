using System;
using System.Windows.Forms;
using pecopeco.progs.Property;

namespace pecopeco.progs.MainForm {
	public partial class HomeForm : Form {

		BaseProperty_Json BPJ = new BaseProperty_Json();
		HomeFormEngine HFE = new HomeFormEngine();

		public HomeForm() {
			//コンストラクタは必ず実行される
			InitializeComponent();
			BootingSet();
		}
		void BootingSet() {
			Text = BPJ.EnvironmentName();
		}
		private void ToolStripMenuItem_Click(object sender,EventArgs e) {
			Environment.Exit(0);
		}

		//-------------------

		private void textBox_brank0_TextChanged(object sender,EventArgs e) {

		}
		private void button3_Click(object sender,EventArgs e) {
			//Json出力
			string[] answer = { "","","","" };
			answer = (string[])HFE.textFricker(textBox1.Text,textBox2.Text,textBox3.Text,
				textBox4.Text,textBox5.Text,textBox6.Text).Clone();
			label4.Text = answer[0];
			label5.Text = answer[1];
			label6.Text = answer[2];
			label7.Text = answer[3];
			label5.Visible = true;
			label6.Visible = true;
			label7.Visible = true;
		}

		private void button1_Click(object sender,EventArgs e) {
			//textBox_brank1.Text = BP.CURDIR;
			test_CurrentDirectoryNow.Text = HFE.CurrentDirAdd();
		}

		private void button4_Click(object sender,EventArgs e) {
			//Json保存
			string[] throwWords = { "","","","","","","" };
			throwWords[0] = BPJ.CurrentDirectory() + @"\test\jsonData.json";
			throwWords[1] = textBox1.Text; throwWords[2] = textBox2.Text;
			throwWords[3] = textBox3.Text; throwWords[4] = textBox4.Text;
			throwWords[5] = textBox5.Text; throwWords[6] = textBox6.Text;
			label13.Text = HFE.jsonSave(throwWords);
		}

		private void nikki_No1_1_tagAddB_Click(object sender,EventArgs e) {
			nikki_No1_1_TagList.Items.Add(nikki_No1_1_TagInput.Text);
		}

		private void nikki_No1_1_tagEditB_Click(object sender,EventArgs e) {
			//初めから空のリストを作り裏で管理すれば良い？
			String str = "";
			if(!(null == nikki_No1_1_TagList.SelectedItem)) {
				str = nikki_No1_1_TagList.SelectedItem.ToString();
				nikki_No1_1_TagList.Items.Remove(nikki_No1_1_TagList.SelectedItem);
				nikki_No1_1_TagInput.Text = str;
			}
		}

		private void nikki_No1_1_tagDeleteB_Click(object sender,EventArgs e) {
			if(!(null == nikki_No1_1_TagList.SelectedItem)) {
				nikki_No1_1_TagList.Items.Remove(nikki_No1_1_TagList.SelectedItem);
			}
		}

		private void nikki_No1_1_save_Click(object sender,EventArgs e) {
			HFE.saveDiary(nikki_No1_1_title.Text,nikki_No1_1_contents.Text
				,nikki_No1_1_TagList.Items);
		}
	}
}

