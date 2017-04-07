using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pecopeco.progs.Property {
	class BaseProperty_Json {
		private static dynamic SetupJson;
		public dynamic SJ {
			set {
				SetupJson = value;
			}
			get {
				return SetupJson;
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
			bool CheckCURDIR = SetupJson.SJ.CurrentDirectory.change;
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
