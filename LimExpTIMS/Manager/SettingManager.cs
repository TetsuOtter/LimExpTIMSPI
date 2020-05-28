using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
	/// <summary>Settingを管理するクラス.  一部未実装</summary>
	static public class SettingManager
	{
		static public bool IsEnabled { get; private set; } = false;
		static public Dictionary<string, string> Settings { get; private set; }
		//データ形式;csv風。最初の行でkeyを指定し、最初のコロンから改行まではすべてデータとする。

		/// <summary>ファイルを読み込む</summary>
		static public void Init()
		{
#if DEBUG
			LogManager.WriteLine("SettingManager", LogManager.LogLevel.Debug, LogManager.LogCategory.Execute_Information, string.Format("Init()\tIsEnabled:{0}\tSettings?.Count{1}", IsEnabled, Settings?.Count));
#endif
			if (IsEnabled || Settings != null) return;

			//Setting Load from file

			throw new NotImplementedException();
		}

		/// <summary>指定のキーに結びつけられた設定を読み込む</summary>
		/// <param name="key">設定の識別のための任意のキー</param>
		/// <param name="data">文字列形式の任意のデータ</param>
		/// <returns>ロードに成功したかどうか</returns>
		static public bool GetData(string key, out string data)
		{
#if DEBUG
			LogManager.WriteLine("SettingManager", LogManager.LogLevel.Debug, LogManager.LogCategory.Execute_Information, string.Format("GetData(key{2})\tIsEnabled:{0}\tSettings?.Count{1}", IsEnabled, Settings?.Count, key));
#endif

			if (!IsEnabled || Settings != null) Init();

			return Settings.TryGetValue(key, out data);
		}

		/// <summary>設定をセットする</summary>
		/// <param name="key">設定の識別のための任意のキー</param>
		/// <param name="data">文字列形式の任意のデータ</param>
		/// <returns>セットに成功したかどうか</returns>
		static public bool SetData(string key, string data)
		{
#if DEBUG
			LogManager.WriteLine("SettingManager", LogManager.LogLevel.Debug, LogManager.LogCategory.Execute_Information, string.Format("SetData({0}, {1})", key, data));
#endif
			if (string.IsNullOrWhiteSpace(key))//必ず文字を含む必要があります.
			{
				LogManager.WriteLine("SettingManager", LogManager.LogLevel.Warning, LogManager.LogCategory.Minor_Error, "KEY IS NULL or EMPTY or WHITESPACE!\tdata:" + data);
#if DEBUG
				throw new ArgumentException("argument \'key\' is Null or Empty or WhiteSpace.  (Not accesptable)");
#else
				return false;
#endif
			}
			if (!IsEnabled || Settings != null) Init();

			if (Settings.ContainsKey(key))
			{
				//keyが存在する場合
#if DEBUG
				LogManager.WriteLine("SettingManager", LogManager.LogLevel.Debug, LogManager.LogCategory.Execute_Information, string.Format("SetData\tkey:{0}\tOldValue:{1}\tNewValue:{2}", key, Settings[key], data));
#endif
				Settings[key] = data;
				return true;
			}
			else
			{
				//keyが存在しない場合
#if DEBUG
				LogManager.WriteLine("SettingManager", LogManager.LogLevel.Debug, LogManager.LogCategory.Execute_Information, string.Format("SetData(New Key)\tkey:{0}\tNewValue:{2}", key, Settings[key], data));
#endif
				Settings.Add(key, data);
				return true;
			}
		}

		/// <summary>設定を書き出す</summary>
		static public void Save()
		{
#if DEBUG
			LogManager.WriteLine("SettingManager", LogManager.LogLevel.Debug, LogManager.LogCategory.Execute_Information, string.Format("Save()\tIsEnabled:{0}\tSettings?.Count{1}", IsEnabled, Settings?.Count));
#endif
			if (!IsEnabled || Settings == null) return;//有効でないか, 設定が存在しないなら実行しない

			//write to file
			throw new NotImplementedException();
		}
	}
}
