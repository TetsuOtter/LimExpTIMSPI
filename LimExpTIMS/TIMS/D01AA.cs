using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TR.LimExpTIMS.TIMS
{
	//D01AA 運転情報
	static public class D01AA
	{
		static int DisplayingStaIndexOfList = 0;
		
		
		//内部的には常に実行.  表示させるときにはIF側に値を渡す.
		static public void Init()
		{
			Ats.ElapseEv += Ats_ElapseEv;
			Ats.DoorOpenEv += Ats_DoorOpenEv;
			TimetableManager.NextStaPassed += TimetableManager_NextStaPassed;
		}

		private static void Ats_DoorOpenEv(object sender, EventArgs e)
		{
			//駅更新
			if (Status.NextStop.StaLocation - (Ats.SpecD.C * cvs.OneCarLength) <= Ats.StateD.Z)//停止位置の編成長分だけ手前より奥に止まればOK
			{
				new TimeManager(cvs.Time_ToRefreshTT_WithDoor, StaRefresh).TimerStart();
			}
		}

		private static void TimetableManager_NextStaPassed(object sender, EventArgs e)
		{
			//LETsPIモードでは動作しないことが期待される.
			StaRefresh();
		}

		private static void Ats_ElapseEv(object sender, TickEvArgs e)
		{
			//駅更新
			if (Ats.IsLETsPIMode)
			{
				//両数x20m手前から停車場位置までの間でドアが開けられた場合, 1s待って停車場更新を行う.
				//停車場位置を通過した場合, 即時停車場更新を行う.
				//F7?ｼﾗﾈ

			}
		}

		
		//距離によるコマ送り=>1行目Blank=>1行目更新=>2行目Blank=>2行目更新=>3行目...=>次停車駅Blank=>次停車駅更新=>次停車駅点滅終了 <<==60fps(実際はもっと速い)
		//ドア開によるコマ送り=>PL滅=>(1sec前後)=>モニタドア開(概ね先頭車から順に)=>(1sec)=>距離によるコマ送りと同様
		/// <summary>表示する駅名の更新を実施する.  即時に更新が行われる.</summary>
		private static void StaRefresh()
		{
			Task.Run(() =>
			{
				for (int i = 0; i < 5; i++)//6は次停車駅
					StaInfoUpdate(i, TimetableManager.StaList?.ElementAt(DisplayingStaIndexOfList + i));
				StaInfoUpdate(5, GetNextStop());
			}).Start();
		}

		private static async void StaInfoUpdate(int Index, StaInfo dst, int sleepLen = cvs.Time_ToRefreshTT)
		{
			TIMS_IF.SetStaInfo(Index, null);
			await Task.Delay(sleepLen);
			TIMS_IF.SetStaInfo(Index, (StaInfo)dst?.Clone());
			await Task.Delay(sleepLen);
		}

		/// <summary>次の停車駅を取得する</summary>
		/// <returns>次の停車駅</returns>
		private static StaInfo GetNextStop()
		{
			if (Ats.IsLETsPIMode)
			{
				if (TimetableManager.StaList.Count <= DisplayingStaIndexOfList + 1) return null;//次駅が存在しない

				for (int i = DisplayingStaIndexOfList + 1; i < TimetableManager.StaList.Count; i++)
					if (TimetableManager.StaList.ElementAt(i)?.IsStopSta == true)
						return TimetableManager.StaList.ElementAt(i);
				
			}
			else
				return TimetableManager.NextStopInfo;
			
			return null;
		}
	}
}
