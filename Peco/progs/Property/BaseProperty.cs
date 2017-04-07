using Codeplex.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pecopeco.progs.Property {
	class BaseProperty {
		private static dynamic SetupJson;
		public dynamic SJ {
			set {
				SetupJson = value;
			}
			get {
				return SetupJson;
			}
		}
		public void UpdateSJ() {
			//保存
			if(File.Exists(@"setup\peco_wholeSetup.json")) {
				string updated = "";
				updated = SetupJson.ToString();
				dynamic parsedJson = JsonConvert.DeserializeObject(updated);
				updated = JsonConvert.SerializeObject(parsedJson,Formatting.Indented);

				Encoding enc = new UTF8Encoding(false);
				StreamWriter sw = new StreamWriter(@"setup\peco_wholeSetup.json",false,enc);
				sw.Write(updated);
				sw.Close();
			} else {
				//警告：実際の設定ファイルの更新が出来ませんでした
			}
		}
		public string EnvironmentName() {
			bool CheckEN = SetupJson.EnvironmentName.change;
			if(CheckEN) {
				//変更有->ユーザー独自設定
				return SetupJson.EnvironmentName.userSet;
			} else {
				//変更無->初期設定
				return SetupJson.EnvironmentName.Initial;
			}
		}
		public string CurrentDirectory() {
			//CurrentDirectory
			bool CheckCURDIR = SetupJson.CurrentDirectory.change;
			if(CheckCURDIR) {
				//変更有->ユーザー独自設定
				return SetupJson.EnvironmentName.userSet;
			} else {
				//変更無->初期設定
				return Environment.CurrentDirectory;
			}
		}
	}
}
