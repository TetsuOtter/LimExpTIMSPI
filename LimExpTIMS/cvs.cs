using System;

namespace TR.LimExpTIMS
{
	//定数値核種を格納

	/// <summary>レバーサー位置</summary>
	public static class Reverser
	{
		/// <summary>後進</summary>
		public const int B = -1;
		/// <summary>中立</summary>
		public const int N = 0;
		/// <summary>前進</summary>
		public const int F = 1;
	}
	/// <summary>定速制御の状態</summary>
	public static class ConstSP
	{
		/// <summary>前回の状態を継続する</summary>
		public const int Continue = 0;
		/// <summary>有効化する</summary>
		public const int Enable = 1;
		/// <summary>無効化する</summary>
		public const int Disable = 2;
	}
	/// <summary>警笛の種類</summary>
	public static class Horn
	{
		/// <summary>Primary Horn</summary>
		public const int Primary = 0;
		/// <summary>Secondary Horn</summary>
		public const int Secondary = 1;
		/// <summary>Music Horn</summary>
		public const int Music = 2;
	}
	/// <summary>サウンド再生に関する操作の情報</summary>
	public static class Sound
	{
		/// <summary>繰り返し再生する</summary>
		public const int Loop = 0;
		/// <summary>一度だけ再生する</summary>
		public const int Once = 1;
		/// <summary>前回の状態を継続する</summary>
		public const int Continue = 2;
		/// <summary>再生を停止する</summary>
		public const int Stop = -10000;
	}
	/// <summary>ハンドルの初期位置設定</summary>
	public static class InitialPos
	{
		/// <summary>常用ブレーキ(B67?)</summary>
		public const int Service = 0;
		/// <summary>非常ブレーキ位置</summary>
		public const int Emergency = 1;
		/// <summary>抜き取り位置</summary>
		public const int Removed = 2;
	}
	/// <summary>ATS Keys</summary>
	public static class ATSKeys
	{
		/// <summary>ATSKey_S (Default : Space)</summary>
		public const int S = 0;
		/// <summary>ATSKey_A1 (Default : Insert)</summary>
		public const int A1 = 1;
		/// <summary>ATSKey_A2 (Default : Delete)</summary>
		public const int A2 = 2;
		/// <summary>ATSKey_B1 (Default : Home)</summary>
		public const int B1 = 3;
		/// <summary>ATSKey_B2 (Default : End)</summary>
		public const int B2 = 4;
		/// <summary>ATSKey_C1 (Default : PageUp)</summary>
		public const int C1 = 5;
		/// <summary>ATSKey_C2 (Default : PageDown)</summary>
		public const int C2 = 6;
		/// <summary>ATSKey_D (Default : D2)</summary>
		public const int D = 7;
		/// <summary>ATSKey_E (Default : D3)</summary>
		public const int E = 8;
		/// <summary>ATSKey_F (Default : D4)</summary>
		public const int F = 9;
		/// <summary>ATSKey_G (Default : D5)</summary>
		public const int G = 10;
		/// <summary>ATSKey_H (Default : D6)</summary>
		public const int H = 11;
		/// <summary>ATSKey_I (Default : D7)</summary>
		public const int I = 12;
		/// <summary>ATSKey_J (Default : D8)</summary>
		public const int J = 13;
		/// <summary>ATSKey_K (Default : D9)</summary>
		public const int K = 14;
		/// <summary>ATSKey_L (Default : D0)</summary>
		public const int L = 15;
	}

	/// <summary>const values</summary>
	public static class cvs
	{
		public const double SPDThreshold = 5;//空転/滑走表示の閾値。

		public const int DCKeyNum = ATSKeys.K;
		public const int ACKeyNum = ATSKeys.L;

		/// <summary>TIMSモニタのBlink間隔</summary>
		public const int TIMSFlushTime = 400;
		public const byte ICRWFlushCountMAX = 10;
		/// <summary>IC R/Wの読込間隔</summary>
		public const int ICRWBusyCycle = 250;

		/// <summary>Panel / Soundの配列長</summary>
		public const int PSArrayLength = 256;

		/// <summary>徐行案内をどれくらい前から出すかの設定[m]</summary>
		public const int ReduceSpeed_ShowDistance = 400;

		/// <summary>徐行区間予告Msgを鳴らす頻度[ms]</summary>
		public const int ReduceSpeed_ComingMsgCycle = 10 * 1000;
		/// <summary>徐行区間内Msgを鳴らす頻度[ms]</summary>
		public const int ReduceSpeed_RunningMsgCycle = 10 * 1000;

		public static readonly int DisplayingModeENum_Count = Enum.GetNames(typeof(DisplayingModeENum)).Length;

		/// <summary>エアセク警報を出し始める距離[ms]</summary>
		public const int AirSec_Warning_ShowDistance = 400;
		/// <summary>エアセク警報メッセージの再生間隔[ms]</summary>
		public const int AirSec_Warning_MsgCycle = 10 * 1000;
		/// <summary>エアセク警報を流すスピードの上限</summary>
		public const int AirSec_Warning_ShowSpeed = 25;

		/// <summary>"真"を意味する値</summary>
		public const int TRUE_VALUE = 1;
		/// <summary>"偽"を意味する値</summary>
		public const int FALSE_VALUE = 0;

		/// <summary>一桁目までを取得する場合</summary>
		public const int ColX1 = 10;
		/// <summary>二桁目までを取得する場合</summary>
		public const int ColX2 = 100;
		/// <summary>三桁目までを取得する場合</summary>
		public const int ColX3 = 1000;
		/// <summary>四桁目までを取得する場合</summary>
		public const int ColX4 = 10000;
		/// <summary>五桁目までを取得する場合</summary>
		public const int ColX5 = 100000;
		/// <summary>六桁目までを取得する場合</summary>
		public const int ColX6 = 1000000;
		/// <summary>七桁目までを取得する場合</summary>
		public const int ColX7 = 10000000;
		/// <summary>八桁目までを取得する場合</summary>
		public const int ColX8 = 100000000;

		/// <summary>自炊TIMSにおける距離加算設定で距離を減算する場合</summary>
		public const int Jisui_LocSetting_MinusSetBias = ColX6;

		/// <summary>駅番号の桁長</summary>
		public const int TIMS_StaName_IDLength = ColX3;

		/// <summary>Beaconで時刻情報を設定する際の「時刻表桁番号」情報の開始位置</summary>
		public const int TIMS_TT_Time_StaIDPos = TIMS_TimeSetting_Len * TIMS_TimeSetting_Len * TIMS_TimeSetting_Len;
		/// <summary>Beaconで設定する時刻情報の「時」情報の開始位置</summary>
		public const int TIMS_TT_HHPos = TIMS_TimeSetting_Len * TIMS_TimeSetting_Len;
		/// <summary>Beaconで設定する時刻情報の「分」情報の開始位置</summary>
		public const int TIMS_TT_MMPos = TIMS_TimeSetting_Len;
		/// <summary>Beaconで設定する時刻情報の各情報の長さ</summary>
		public const int TIMS_TimeSetting_Len = ColX2;

		/// <summary>Beaconで設定する各駅位置情報の長さ</summary>
		public const int LETsPI_TT_StaPos_PosLen = ColX7;
		/// <summary>Beaconで設定する各駅時刻表表示のセパレータの種類設定の長さ</summary>
		public const int LETsPI_TT_TimeSep_SepSetLen = ColX2;

		/// <summary>60fpsの場合の1frameにかかる時間を提供する</summary>
		public const int fps_60 = 1000 / 60;

		/// <summary>時刻表表示で1行更新するのにかかる時間[ms]</summary>
		public const int Time_ToRefreshTT = fps_60;

		/// <summary>ドアと連動して時刻表を更新させる場合に, PL滅から更新までにかける時間</summary>
		public const int Time_ToRefreshTT_WithDoor = 2000;

		/// <summary>SimTimeSpeedProviderで時間経過確認を行う間隔</summary>
		public const int SimTimeSleepProvider_CheckInterval = 5;

		/// <summary>1両の長さ[m]</summary>
		public const int OneCarLength = 20;

		/// <summary>TIMS表示器の現在位置表示が無効化されていた際に表示する文字の位置</summary>
		public const int PElem_LocationDEC_DisabledChar = 10;
		/// <summary>数値画像の空白表示位置</summary>
		public const int PElem_Num_BlankPos = 10;

		/// <summary>MR異常表示の閾値[kPa] これ以下で異常</summary>
		public const int MR_Unusual_ThresholdPres = 720;
		/// <summary>通常時のMR圧力表示の針のステップ[kPa]</summary>
		public const int MR_PresDisp_PresStep_Usual = 5;
		/// <summary>異常時のMR圧力表示の針のステップ[kPa]</summary>
		public const int MR_PresDisp_PresStep_Unusual = 25;
		/// <summary>MR圧力表示の通常時の表示下限(表示として.  異常表示は関係ない)</summary>
		public const int MR_PresDisp_ULimit_Usual = 700;
		/// <summary>MR圧力表示の通常時の表示範囲[kPa]</summary>
		public const int MR_PresDisp_Range_Usual = 300;
		/// <summary>MR圧力表示の異常時の表示範囲[kPa]</summary>
		public const int MR_PresDisp_Range_Unusual = 1000;
		/// <summary>通常時のステップ(60)と, 異常時のフルスケール(1000)の最小公倍数</summary>
		public const int MR_PresDisp_DispRange = 3000;
		/// <summary>通常時のMR圧表示の表示ステップ[段]</summary>
		public const int MR_PresDisp_DispStep_Usual = MR_PresDisp_DispRange / (MR_PresDisp_Range_Usual / MR_PresDisp_PresStep_Usual);
		/// <summary>異常時のMR圧表示の表示ステップ[段]</summary>
		public const int MR_PresDisp_DispStep_Unusual = MR_PresDisp_DispRange / (MR_PresDisp_Range_Unusual / MR_PresDisp_PresStep_Unusual);

		public const int BC_PresDisp_PresStep = 20;

		public const int TIMS_D01AA_TimeHH_Blank = 24;
		public const int TIMS_D01AA_TimeMM_Blank = 60;
		public const int TIMS_D01AA_TimeSS_Blank = 0;
	}
}
