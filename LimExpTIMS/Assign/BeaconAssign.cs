namespace TR.LimExpTIMS.Assign
{
	public enum BeaconAssign
	{
		TIMS_Accidental_Passage_Preventer = 30,

		TIMS_TrNum = 100,
		TIMS_TrNum_Header,
		TIMS_Direction,
		TIMS_Location,
		//運行パターンは略
		TIMS_NextStopComming = 105,
		TIMS_NextStopStaNum,
		TIMS_NextStopArrTime,
		TIMS_NextStopTrack,
		//TIMS行先設定は略
		TIMS_Timetable_StaName = 110,
		TIMS_Timetable_ArrTime,
		TIMS_Timetable_DepTime,
		TIMS_Timetable_Track,
		TIMS_Timetable_LimSPD_IN,
		TIMS_Timetable_LimSPD_OUT,
		TIMS_Timetable_RunTime,
		//行路表矢印は略
		TIMS_Section_Notice = 120,//ACDC. ACAC, AirSec
		TIMS_Section_Voltage = 121,


		//以下, LimExpTIMSPI独自の機能用Assign

		/// <summary>LETsPIを使用できる路線であることを示すフラグ(路線IDも同時設定)</summary>
		LETsPI_Usable_Flag = 1501,//車両側に設定されたIDと異なる場合, No.2Monでのみ駅名表示が可能

		/// <summary>LETsPIにBeaconの通過情報を流すかどうかを設定するフラグ</summary>
		LETsPI_Beacon_Suspend_Flag,

		/// <summary>各駅の位置を設定する.</summary>
		LETsPI_TIMS_Timetable_StaLoc,

		/// <summary>各駅の停車種類を設定する.</summary>
		LETsPI_TIMS_Timetable_StopMode,//0:停車, 1:通過, 2:運転停車, 3:終着 etc

		LETsPI_TIMS_TimeTable_TimeSep_Arr,//時刻表示区切り文字を設定
		LETsPI_TIMS_TimeTable_TimeSep_Dep,//設定可能な値はPnl_TIMSMon_D01AA_TimeSepで定義される

		/// <summary>架線電源の周波数を設定する(DC電源や非電化区間は0)</summary>
		LETsPI_TIMS_Frequency,

		/// <summary>防護無線を作動させる.</summary>
		LETsPI_Bougo,

		/// <summary>徐行区間設定 開始位置を設定する</summary>
		LETsPI_Joko_StartLocation,
		/// <summary>徐行区間設定 終了位置を設定する</summary>
		LETsPI_Joko_EndLocation,
		/// <summary>徐行区間設定 速度を設定する</summary>
		LETsPI_Joko_LimSPD,

		/// <summary>運行情報の更新通知を流す</summary>
		LETsPI_OPInfo_Chime,

		/// <summary>エアコンの動作を設定する</summary>
		LETsPI_AirCond,

		/// <summary>車掌弁が扱われる長さを設定する</summary>
		LETsPI_Conductor_EB,

		/// <summary>列番の記号部を設定する</summary>
		LETsPI_TrNum_CharPart,

		/// <summary>無線chを変更させる.</summary>
		LETsPI_RadioCH_Change = 139,

		/// <summary>無線情報設定</summary>
		LETsPI_Radio_DataState,

		/// <summary>左カーブのために車体傾斜を開始</summary>
		LETsPI_Curve_L = 141,
		/// <summary>右カーブのために車体傾斜を開始</summary>
		LETsPI_Curve_R,
		/// <summary>車体傾斜を終了する</summary>
		LETsPI_Curve_End,

		/// <summary>非常通報を作動させる</summary>
		LETsPI_Passenger_Emerg = 146,

		/// <summary>初期状態を設定する</summary>
		LETsPI_Startup_State = 150,
	}

	public static class AssignEnumConv
	{
		public static int ToInt(this BeaconAssign b) => (int)b;
	}
}
