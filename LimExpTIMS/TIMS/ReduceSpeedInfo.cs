using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS.TIMS
{
	/// <summary>徐行情報</summary>
	public class ReduceSpeedInfo
	{
		/// <summary>制限速度</summary>
		public int LimitSPD { get; set; } = 0;

		/// <summary>開始距離程(整数部)</summary>
		public int StartDistanceINT { get; set; } = 0;
		/// <summary>開始距離程(小数部)</summary>
		public int StartDistanceDEC { get; set; } = 0;

		/// <summary>終了距離程(整数部)</summary>
		public int EndDistanceINT { get; set; } = 0;
		/// <summary>終了距離程(小数部)</summary>
		public int EndDistanceDEC { get; set; } = 0;
	}
}
