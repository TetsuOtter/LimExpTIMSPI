using System;
using System.Runtime.CompilerServices;

using Microsoft.SqlServer.Server;
using TR.LimExpTIMS.TIMS;

namespace TR.LimExpTIMS
{
	/// <summary>状態を管理する.  ウィンドウ表示クラスで扱いやすいような形を用いる.</summary>
	static public class Status
	{

		/// <summary>自車のCabSeS状態</summary>
		static public direct CabSeS_kore { get; set; }= direct.N;
		/// <summary>他車1(最後尾車両)のCabSeS状態</summary>
		static public direct CabSeS_hoka1 { get; set; }= direct.N;
		/// <summary>他車2(中間先頭車1)のCabSeS状態</summary>
		static public direct CabSeS_hoka2 { get; set; }= direct.N;
		/// <summary>他車3(中間先頭車2)のCabSeS状態</summary>
		static public direct CabSeS_hoka3 { get; set; }= direct.N;

		/// <summary>Panel表示モード状態</summary>
		static public DisplayingModeENum DispMode { get; set; }= DisplayingModeENum.Driving;
		/// <summary>マスコンキーの状態</summary>
		static public MCKeyStateENum MCKey { get; set; }= MCKeyStateENum.Removed;
		/// <summary>架線電圧種類</summary>
		static public WireVolType WireType { get; set; }= WireVolType.DC1500V;

		/// <summary>No1表示器のバックライト状態</summary>
		static public DispBL No1DispBL { get; set; }= DispBL.Max;
		/// <summary>No2表示器のバックライト状態</summary>
		static public DispBL No2DispBL { get; set; }= DispBL.Max;
		/// <summary>TIMS表示器のバックライト状態</summary>
		static public DispBL TIMSDispBL { get; set; }= DispBL.Max;

		/// <summary>各NFBの状態</summary>
		static public bool[] NFB { get; set; } = new bool[Enum.GetNames(typeof(NFBs)).Length];
		/// <summary>車両ボタンの押下状態</summary>
		static public bool[] Btn { get; set; } = new bool[Enum.GetNames(typeof(Btns)).Length];

		static public TIMSPageENum TIMSMon_PageNum { get; set; } = TIMSPageENum.D01AA;

		#region TIMS Disp PanelStatuses
		#region Common
		static public Pnl_TIMSMon_TsukokuJoho_Char TsukokuJoho_Char { get; internal set; }
		static public Pnl_TIMSMon_Emerg_Warning_WC Emerg_Warning_WC_Btn { get; internal set; }

		#region 通告情報欄ボタン状態
		static public Pnl_TIMSMon_TsukokuJoho_BtnState Tsukoku_Btn { get; internal set; }
		static public Pnl_TIMSMon_TsukokuJoho_BtnState Kisei_Btn { get; internal set; }
		static public Pnl_TIMSMon_TsukokuJoho_BtnState Shirei_Btn { get; internal set; }
		static public Pnl_TIMSMon_TsukokuJoho_BtnState Unkou_Btn { get; internal set; }
		#endregion

		static public TimeSpan TIMS_DispTime { get; set; } = new TimeSpan(0);
		static public int TIMS_DispSpeed { get; set; } = 0;
		static public bool TIMS_LocationEnabled { get; set; } = false;
		static public int TIMS_LocationINT { get; set; } = 0;
		static public int TIMS_LocationDEC { get; set; } = 0;

		static public bool ShokiSentakuBtnPushed { get; set; } = false;

		static public direct TIMS_DirectArrow { get; set; } = direct.F;

		/// <summary>0:なし 1~20:n号車, 21~25:便所</summary>
		static public int TIMS_EmergencyCaller { get; set; } = 0;

		/// <summary>運行情報が存在するかどうか</summary>
		static public bool IsThereOpInfo { get; set; } = false;
		#endregion

		static public bool S00AB_UteshiBtnPushed { get; set; } = false;

		#region D00AA
		public static Pnl_TIMSMon_D00AA_Btn D00AA_Btn { get; set; } = Pnl_TIMSMon_D00AA_Btn.Blank;
		#endregion


		#region D01AA
		static public Pnl_Radio_CH Radio_CH { get; internal set; }

		static public bool IsPTrNumEnabled { get; set; } = false;
		static public bool IsPassSettingEnabled { get; set; } = false;
		static public Pnl_TIMSMon_TrainNum_Header PTrNum_Header { get; set; } = Pnl_TIMSMon_TrainNum_Header.Blank;
		static public int PTrNum_Number { get; set; } = 0;
		static public Pnl_TIMSMon_TrainNum_Footer PTrNum_Footer1 { get; set; } = Pnl_TIMSMon_TrainNum_Footer.Blank;
		static public Pnl_TIMSMon_TrainNum_Footer PTrNum_Footer2 { get; set; } = Pnl_TIMSMon_TrainNum_Footer.Blank;

		static public bool IsTrNumEnabled { get; set; } = false;
		static public Pnl_TIMSMon_TrainNum_Header TrNum_Header { get; set; } = Pnl_TIMSMon_TrainNum_Header.Blank;
		static public int TrNum_Number { get; set; } = 0;
		static public Pnl_TIMSMon_TrainNum_Footer TrNum_Footer1 { get; set; } = Pnl_TIMSMon_TrainNum_Footer.Blank;
		static public Pnl_TIMSMon_TrainNum_Footer TrNum_Footer2 { get; set; } = Pnl_TIMSMon_TrainNum_Footer.Blank;


		static public StaInfo FirstRow { get; internal set; } = null;
		static public StaInfo SecondRow { get; internal set; } = null;
		static public StaInfo ThirdRow { get; internal set; } = null;
		static public StaInfo FourthRow { get; internal set; } = null;
		static public StaInfo FifthRow { get; internal set; } = null;
		static public StaInfo NextStop { get; internal set; } = null;

		static public ReduceSpeedInfo ReduceSPD1 { get; internal set; } = null;
		static public ReduceSpeedInfo ReduceSPD2 { get; internal set; } = null;

		static public Pnl_TIMSMon_D01AA_UnitState UnitState1 { get; set; } = Pnl_TIMSMon_D01AA_UnitState._VNNN;
		static public Pnl_TIMSMon_D01AA_UnitState UnitState2 { get; set; } = Pnl_TIMSMon_D01AA_UnitState._VNNN;
		static public Pnl_TIMSMon_D01AA_UnitState UnitState3 { get; set; } = Pnl_TIMSMon_D01AA_UnitState._VNNN;
		static public Pnl_TIMSMon_D01AA_UnitState UnitState4 { get; set; } = Pnl_TIMSMon_D01AA_UnitState._VNNN;
		#endregion

		#region D04AA
		static public bool D04AA_PassSettingBtnPushed { get; set; } = false;

		static public Pnl_TIMSMon_TrainNum_Header D04AA_SelectedPrefixBtn { get; set; } = Pnl_TIMSMon_TrainNum_Header.Blank;
		static public Pnl_TIMSMon_D04AA_10KeyMode D04AA_Selected10KeyMode { get; set; } = Pnl_TIMSMon_D04AA_10KeyMode.Blank;

		/// <summary>0:Blank, 1:D1...10:D0, 11:訂正</summary>
		static public int D04AA_10KeyPressedNum { get; set; } = 0;
		static public Pnl_TIMSMon_D04AA_KeyState D04AA_OtherKey { get; set; } = Pnl_TIMSMon_D04AA_KeyState.Blank;
		#endregion
		#endregion

		#region No.1計器モニタ PanelStatus
		static public int Keiki_DispSpeed { get; set; } = 0;
		static public int SourceVoltage_DC { get; set; } = 0;
		static public int SourceVoltage_AC { get; set; } = 0;
		static public int Voltage_DC100V { get; set; } = 0;

		static public bool Keiki_PL_DC { get; set; } = false;
		static public bool Keiki_PL_AC { get; set; } = false;

		static public int Keiki_BCPres { get; set; } = 0;
		static public int Keiki_MRPres { get; set; } = 0;
		static public int Keiki_BPos { get; set; } = 0;

		static public bool Keiki_Yokusoku { get; set; } = false;
		static public bool Keiki_EmergB { get; set; } = false;

		static public bool Keiki_Jiko { get; set; } = false;
		static public bool Keiki_3Phase { get; set; } = false;
		static public bool Keiki_EmergShort { get; set; } = false;
		static public bool Keiki_SnowResist { get; set; } = false;
		static public bool Keiki_BackupStraightB { get; set; } = false;
		static public bool Keiki_ConstSPD { get; set; } = false;
		static public bool Keiki_ParkB { get; set; } = false;

		static public int Keiki_ATSPsP_RunSPD { get; set; } = 0;
		static public int Keiki_ATSPsP_LimSPD { get; set; } = 0;
		#endregion

		#region No.2計器モニタ(No1+2を含む) PanelStatus
		static public bool ATSP_PW { get; set; } = false;
		static public bool ATSP_PatternComing { get; set; } = false;
		static public bool ATSP_Brake_Working { get; set; } = false;
		static public bool ATSP_EmergB { get; set; } = false;
		static public bool ATSP_Brake_Open { get; set; } = false;
		static public bool ATSP_PL { get; set; } = false;
		static public bool ATSP_Broken { get; set; } = false;

		static public bool ATS_PW { get; set; } = false;
		static public bool ATS_Trip { get; set; } = false;

		static public bool ATSPs_PatternCreated { get; set; } = false;
		static public bool ATSPs_PatternComing { get; set; } = false;
		static public bool ATSPs_Brake_Working { get; set; } = false;
		static public bool ATSPs_Brake_Open { get; set; } = false;
		static public bool ATSPs_Broken { get; set; } = false;
		#endregion

		#region Cab States
		static public bool EBAlermLamp { get; set; } = false;

		/// <summary>マスコン位置 (B < 0 < P)</summary>
		static public int MasCtrlPos { get; set; } = -9;
		static public direct ReverserPos { get; set; } = direct.N;

		static public Pnl_IC_RW_Display IC_RW { get; set; } = Pnl_IC_RW_Display.Blank;
		static public bool IC_Readable { get; set; } = false;
		#endregion
	}

	public static class PanelElemShowStates
	{
		static public void Check()
		{
			__CabSeSLocation = Status.DispMode == DisplayingModeENum.CabSeSShowing;
			__TIMS_UpperBar = !(Status.TIMSMon_PageNum == TIMSPageENum.None || Status.TIMSMon_PageNum == TIMSPageENum.S00AA || Status.TIMSMon_PageNum == TIMSPageENum.S00AB || Status.TIMSMon_PageNum == TIMSPageENum.A06AA);
			__TIMS_LowerBar = !(Status.TIMSMon_PageNum == TIMSPageENum.None || Status.TIMSMon_PageNum == TIMSPageENum.S00AA || Status.TIMSMon_PageNum == TIMSPageENum.S00AB);
			__GCP_Speed100 = Status.Keiki_DispSpeed >= 100;
			__GCP_Speed10 = __GCP_Speed100 && Status.Keiki_DispSpeed >= 10;//3桁なら確実にVisible
			__S00AxPage = Status.TIMSMon_PageNum == TIMSPageENum.S00AA || Status.TIMSMon_PageNum == TIMSPageENum.S00AB;
			__A06AAPage = Status.TIMSMon_PageNum == TIMSPageENum.A06AA;
			__IsD00AA = Status.TIMSMon_PageNum == TIMSPageENum.D00AA;
			__IsD01AA = Status.TIMSMon_PageNum == TIMSPageENum.D01AA;
			__IsD04AA = Status.TIMSMon_PageNum == TIMSPageENum.D04AA;
			__IsD05AA = Status.TIMSMon_PageNum == TIMSPageENum.D05AA;
			__CabNFB = Status.DispMode == DisplayingModeENum.CabNFBShowing;
			__TIMS_Location = __TIMS_UpperBar && Status.TIMS_LocationEnabled;

			__ATS_Enabled = __IsD01AA && Status.CabSeS_kore == direct.F && Status.ATSP_PW;

			__MR_Unusual = Status.Keiki_MRPres <= cvs.MR_Unusual_ThresholdPres;
			__MRPres_DispNum = __MR_Unusual ? (Status.Keiki_MRPres / cvs.MR_PresDisp_PresStep_Unusual) * cvs.MR_PresDisp_DispStep_Unusual :
			 ((Status.Keiki_MRPres - cvs.MR_PresDisp_ULimit_Usual) / cvs.MR_PresDisp_PresStep_Usual) * cvs.MR_PresDisp_DispStep_Usual;

			__TIMS_Notification = !(Status.TIMSMon_PageNum == TIMSPageENum.None || Status.TIMSMon_PageNum == TIMSPageENum.S00AA);

			//__CtrlVUnusual = false;
			//__SourceACUnusual = false;
			//__SourceDCUnusual = false;

			__OutOfCar = Status.DispMode == DisplayingModeENum.OutOfCar;
			__IsA01AA = Status.TIMSMon_PageNum == TIMSPageENum.A01AA;

			__BC200 = Status.Keiki_BCPres >= 200;
			__BC400 = __BC200 && Status.Keiki_BCPres >= 400;//boolの比較の方が速いと信じて
			__BC600 = __BC400 && Status.Keiki_BCPres >= 600;//boolの比較の方が速いと信じて
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool CabSeSLocation() => __CabSeSLocation;
		static private bool __CabSeSLocation = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool TIMS_UpperBar() => __TIMS_UpperBar;
		static private bool __TIMS_UpperBar = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool TIMS_LowerBar() => __TIMS_LowerBar;
		static private bool __TIMS_LowerBar = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool GCP_Speed100() => __GCP_Speed100;
		static private bool __GCP_Speed100 = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool GCP_Speed10() => __GCP_Speed10;
		static private bool __GCP_Speed10 = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool S00AxPage() => __S00AxPage;
		static private bool __S00AxPage = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool A06AAPage() => __A06AAPage;
		static private bool __A06AAPage = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool IsD00AA() => __IsD00AA;
		static private bool __IsD00AA = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool IsD01AA() => __IsD01AA;
		static private bool __IsD01AA = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool IsD04AA() => __IsD04AA;
		static private bool __IsD04AA = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool IsD05AA() => __IsD05AA;
		static private bool __IsD05AA = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool CabNFB() => __CabNFB;
		static private bool __CabNFB = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool TIMS_Location() => __TIMS_Location;
		static private bool __TIMS_Location = false;

		/// <summary>D01AAかつATSにアクセスできるかどうかを返す.</summary>
		/// <returns>D01AAかつATSにアクセスできるかどうか</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool ATS_Enabled() => __ATS_Enabled;
		static private bool __ATS_Enabled = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool MR_Unusual() => __MR_Unusual;
		static private bool __MR_Unusual = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public object MRPres_DispNum(object _) => __MRPres_DispNum;
		static private int __MRPres_DispNum = 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool TIMS_Notification() => __TIMS_Notification;
		static private bool __TIMS_Notification = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool CtrlVUnusual() => __CtrlVUnusual;
		static private bool __CtrlVUnusual = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool SourceACUnusual() => __SourceACUnusual;
		static private bool __SourceACUnusual = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool SourceDCUnusual() => __SourceDCUnusual;
		static private bool __SourceDCUnusual = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool OutOfCar() => __OutOfCar;
		static private bool __OutOfCar = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool IsA01AA() => __IsA01AA;
		static private bool __IsA01AA = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool BC200() => __BC200;
		static private bool __BC200 = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool BC400() => __BC400;
		static private bool __BC400 = false;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		static public bool BC600() => __BC600;
		static private bool __BC600 = false;
	}
}
