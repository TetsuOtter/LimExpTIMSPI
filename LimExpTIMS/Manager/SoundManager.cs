using System;
using System.Runtime.InteropServices;

namespace TR.LimExpTIMS
{
	public class SoundManager
	{
		public SoundManager(PlayType ptyp, int index, int? loopInterval = null)
		{
			PTyp = ptyp;
			Index = index;
			OffsetToWrite = index * sizeof(int);
		}
		

		/// <summary>LOOP再生かONCE再生かの種類(間欠再生をPI側で行う場合はONCEになります。)</summary>
		public enum PlayType
		{
			/// <summary>繰り返し再生</summary>
			PlayLoop,
			/// <summary>一度きり再生</summary>
			PlayOnce
		}

		/// <summary>再生タイプの記録</summary>
		public PlayType PTyp { get; }
		/// <summary>サウンドのインデックス</summary>
		public int Index { get; }
		private int OffsetToWrite { get; }
		/// <summary>再生ボリュームの設定(設定なし=>null)</summary>
		public int? PlayVolume { get; set; } = null;
		/// <summary>PI側で間欠の制御を行う場合の間隔[ms]</summary>
		public int? LoopInterval { get; }
		private int NextPlayTime = -1;

		/// <summary>再生状態の設定</summary>
		public bool IsPlaying { get; private set; } = false;

		private int outputRec = 0;

		/// <summary>出力すべき値を取得できるメソッド</summary>
		/// <returns>出力すべき値</returns>
		public int GetOutput()
		{
			//間欠再生制御用
			if (IsPlaying && LoopInterval != null && Ats.StateD.T >= NextPlayTime)
			{
				NextPlayTime = Ats.StateD.T + LoopInterval ?? 0;
				Play();
			}
			outputRec = getOutput();
			return outputRec;
		}
		/// <summary>出力すべき値を取得できるメソッド</summary>
		/// <param name="ArrInd0">サウンド再生状態を格納する配列の開始位置のアドレス</param>
		public void GetOutput(in IntPtr ArrInd0) => Marshal.WriteInt32(ArrInd0, OffsetToWrite, GetOutput());
		
		private int getOutput()
		{
			if (IsPlaying) return Sound.Stop;

			switch (outputRec)
			{
				case Sound.Stop://New Playing
					return PTyp == PlayType.PlayLoop ? Sound.Loop : Sound.Once;

				case Sound.Loop://Loop playing
					return PlayVolume ?? Sound.Continue;

				case Sound.Once://OneTime Playing
					return PlayVolume ?? Sound.Continue;

				default:
					return Sound.Continue;
			}
		}

		public void Play()
		{
			outputRec = Sound.Stop;
			IsPlaying = true;
		}
		public void Stop()
		{
			IsPlaying = false;
		}
	}
}
