using System;
using Microsoft.SqlServer.Server;
using TR.LimExpTIMS.TIMS;

namespace TR.LimExpTIMS
{
  /// <summary>状態を管理する.  ウィンドウ表示クラスで扱いやすいような形を用いる.</summary>
  static public class Status
  {
    /// <summary>自車のCabSeS状態</summary>
    static public direct CabSeS_kore { get; set; }
    /// <summary>他車1(最後尾車両)のCabSeS状態</summary>
    static public direct CabSeS_hoka1 { get; set; }
    /// <summary>他車2(中間先頭車1)のCabSeS状態</summary>
    static public direct CabSeS_hoka2 { get; set; }
    /// <summary>他車3(中間先頭車2)のCabSeS状態</summary>
    static public direct CabSeS_hoka3 { get; set; }

    /// <summary>Panel表示モード状態</summary>
    static public DisplayingModeENum DispMode { get; set; }
    /// <summary>マスコンキーの状態</summary>
    static public MCKeyStateENum MCKey { get; set; }
    /// <summary>架線電圧種類</summary>
    static public WireVolType WireType { get; set; }

    /// <summary>No1表示器のバックライト状態</summary>
    static public DispBL No1DispBL { get; set; }
    /// <summary>No2表示器のバックライト状態</summary>
    static public DispBL No2DispBL { get; set; }
    /// <summary>TIMS表示器のバックライト状態</summary>
    static public DispBL TIMSDispBL { get; set; }

    /// <summary>各NFBの状態</summary>
    static public bool[] NFB { get; set; } = new bool[Enum.GetNames(typeof(NFBs)).Length];
    /// <summary>車両ボタンの押下状態</summary>
    static public bool[] Btn { get; set; } = new bool[Enum.GetNames(typeof(Btns)).Length];

    static public TIMSPageENum TIMSMon_PageNum { get; set; }

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

    static public bool ShokiSentakuBtn { get; set; } = false;

    static public direct TIMS_DirectArrow { get; set; } = direct.F;

    /// <summary>0:なし 1~20:n号車, 21~25:便所</summary>
    static public int TIMS_EmergencyCaller { get; set; } = 0;
    #endregion

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
    static public bool D04AA_PassSettingBtn { get; set; } = false;

    static public Pnl_TIMSMon_TrainNum_Header D04AA_PrefixBtn { get; set; } = Pnl_TIMSMon_TrainNum_Header.Blank;
    static public Pnl_TIMSMon_D04AA_10KeyMode D04AA_10KeyMode { get; set; } = Pnl_TIMSMon_D04AA_10KeyMode.Blank;

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
    static public bool Keiki_MRPres_Unusual { get; set; } = false;
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
}
