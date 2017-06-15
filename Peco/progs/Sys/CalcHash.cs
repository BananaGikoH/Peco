using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pecopeco.progs.Sys {
	class CalcHash {
		public string StringToHash(string str) {
			//MD5ハッシュ値を計算する文字列
			string s = str;
			//文字列をbyte型配列に変換する
			byte[] data = System.Text.Encoding.UTF8.GetBytes(s);

			//SHA512CryptoServiceProviderオブジェクトを作成
			System.Security.Cryptography.SHA512CryptoServiceProvider sha512 =
				new System.Security.Cryptography.SHA512CryptoServiceProvider();

			//ハッシュ値を計算する
			byte[] bs = sha512.ComputeHash(data);

			//リソースを解放する
			sha512.Clear();

			//byte型配列を16進数の文字列に変換
			System.Text.StringBuilder result = new System.Text.StringBuilder();
			foreach(byte b in bs) {
				result.Append(b.ToString("x2"));
			}
			//ここの部分は次のようにもできる
			//string result = BitConverter.ToString(bs).ToLower().Replace("-","");

			//結果を表示
			return result.ToString();
		}
	}
}
