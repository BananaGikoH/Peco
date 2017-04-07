using System;
using Codeplex.Data;
using Newtonsoft.Json;
using System.IO;
using pecopeco.progs.Property;

namespace pecopeco.progs.Sys {
	public class EditSetup {

		BaseProperty BPJ = new BaseProperty();

		public String createFirstRuleJson() {
			var obj = new {
				JustGetStarted = new {
					firstLaunch = true
				},
				EnvironmentName = new {
					Initial = "peco",
					change = false,
					userSet = ""
				},
				CurrentDirectory = new {
					change = false,
					userSet = ""
				}
			};
			string firstRule = "";
			firstRule = DynamicJson.Serialize(obj);
			dynamic parsedJson = JsonConvert.DeserializeObject(firstRule);
			return JsonConvert.SerializeObject(parsedJson,Formatting.Indented);
		}

		public void startStep() {
			string line = String.Empty;
			string str = String.Empty;

			using(StreamReader r = new StreamReader(@"setup\peco_wholeSetup.json")) {
				while((str = r.ReadLine()) != null) { // 1行ずつ読み出し。
					line = line + str;
				}
			}

			if(line != String.Empty) {
				BPJ.SJ = DynamicJson.Parse(line);
			} else {
				//警告、うまくファイルを開けませんでした。
			}
		}

	}
}

