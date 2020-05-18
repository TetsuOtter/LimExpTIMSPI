using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
	/// <summary>仮想空間内時刻に基づいた処理待機機能を提供します.</summary>
	public static class SimTimeSleepProvider
	{
		/// <summary>指定されたゲーム内時間が経過するまで, 関数は処理を返しません.  時間経過はcvs.SimTimeSleepProvider_CheckInterval[ms]ごとに確認されます.</summary>
		/// <param name="time">待機時間[ms]</param>
		public static async Task Sleep(int time)
		{
			if (time <= 0) return;//待機時間が0以下なら待機しない.
			int startTime = Ats.StateD.T;//待機開始時刻
			int dstTime = startTime + time;//待機終了予定時刻
			
			/* 終了予定時刻より現在時刻の方が小さい(==まだ終了予定時刻を過ぎてない)
			 * &&
			 * 現在時刻より開始時刻の方が同じか小さい(==開始直後であるor時が戻されていない)
			 */
			while (dstTime > Ats.StateD.T && Ats.StateD.T >= startTime) await Task.Delay(cvs.SimTimeSleepProvider_CheckInterval);//callerからもawaitable
		}
	}
}
