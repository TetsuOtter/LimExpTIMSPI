using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS.ATSPsP
{
	public static class ATSIF
	{
		public static void Init()
		{
			AskATSPsP.LoadPI();
		}

		/// <summary>システム初期化の模擬を実行する</summary>
		static public void SysInit()
		{

		}

		/// <summary>保安装置プラグインからの出力</summary>
		static public int BrakeOutput { get; private set; }

		/// <summary>ats0 ATS電源(白色灯)</summary>
		static public bool ATS_Power_Lamp { get; private set; }

		/// <summary>ats1 ATS動作(赤色灯)</summary>
		static public bool ATS_Trip_Lamp { get; private set; }

		/// <summary>ats2 P電源</summary>
		static public bool P_Power_Lamp { get; private set; }

		static public bool P_Pattern_Coming_Lamp { get; private set; }
		static public bool P_Brake_Release_Lamp { get; private set; }    
	}
}
