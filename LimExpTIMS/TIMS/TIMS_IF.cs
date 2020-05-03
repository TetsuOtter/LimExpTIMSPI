using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS.TIMS
{
  public static class TIMS_IF
  {
    static TimeManager BlinkTimer = new TimeManager(cvs.TIMSFlushTime);
    static bool Blink_P = false;
    public static void Init()
    {
      BlinkTimer.TimerEvent += (s, e) => Blink_P = !Blink_P;
      BlinkTimer.TimerStart();

      Ats.KeyDownEv += Ats_KeyDownEv;
      Ats.KeyUpEv += Ats_KeyUpEv;
    }

    static private void Ats_KeyUpEv(object sender, IntValEvArgs e)
    {
      
    }

    static private void Ats_KeyDownEv(object sender, IntValEvArgs e)
    {
      
    }



    #region PanelStatuses
    #region Common
    static public Pnl_TIMSMon_TsukokuJoho_Char TsukokuJoho_Char { get; private set; }
    static public Pnl_TIMSMon_Emerg_Warning_WC Emerg_Warning_WC_Btn { get; private set; }

		#region 通告情報欄ボタン状態
		static public Pnl_TIMSMon_TsukokuJoho_BtnState Tsukoku_Btn { get; private set; }
    static public Pnl_TIMSMon_TsukokuJoho_BtnState Kisei_Btn { get; private set; }
    static public Pnl_TIMSMon_TsukokuJoho_BtnState Shirei_Btn { get; private set; }
    static public Pnl_TIMSMon_TsukokuJoho_BtnState Unkou_Btn { get; private set; }
		#endregion
		#endregion

		#region D01AA
		static public Pnl_Radio_CH Radio_CH { get; private set; }

    static public StaInfo FirstRow { get; private set; } = null;
    static public StaInfo SecondRow { get; private set; } = null;
    static public StaInfo ThirdRow { get; private set; } = null;
    static public StaInfo FourthRow { get; private set; } = null;
    static public StaInfo FifthRow { get; private set; } = null;
    static public StaInfo NextStop { get; private set; } = null;

    static public ReduceSpeedInfo ReduceSPD1 { get; private set; } = null;
    static public ReduceSpeedInfo ReduceSPD2 { get; private set; } = null;
    #endregion
    #endregion

  }

  /// <summary>時刻表表示部表示情報</summary>
  public class StaInfo
  {
    /// <summary>停車駅であるか否か</summary>
    public bool IsStopSta { get; set; } = true;

    /// <summary>駅位置</summary>
    public int StaLocation { get; set; } = 0;

    /// <summary>駅名</summary>
    public int StaIndex { get; set; } = 0;
    /// <summary>時分</summary>
    public TimeSetting TimeDst { get; set; } = new TimeSetting();

    /// <summary>着時刻設定</summary>
    public TimeSetting Arrive { get; set; } = new TimeSetting();
    
    public Pnl_TIMSMon_D01AA_TimeSep Arrive_Sep { get; set; } = Pnl_TIMSMon_D01AA_TimeSep.Blank;

    /// <summary>発時刻設定</summary>
    public TimeSetting Depart { get; set; } = new TimeSetting();
    public Pnl_TIMSMon_D01AA_TimeSep Depart_Sep { get; set; } = Pnl_TIMSMon_D01AA_TimeSep.Blank;

    /// <summary>番線</summary>
    public int TrackNum { get; set; } = 0;

    /// <summary>到着時制限</summary>
    public int? ArrLimitSPD { get; set; } = null;
    /// <summary>出発時制限</summary>
    public int? DepLimitSPD { get; set; } = null;
  }

  public class TimeSetting
  {
    public byte? HH { get; set; } = null;
    public byte? MM { get; set; } = null;
    public byte SS { get; set; } = 0;

    public void SetFromBeaconD(in int data)
    {
      HH = data == 0 ? null : (byte?)((data / cvs.TIMS_TT_HHPos) % cvs.TIMS_TimeSetting_Len);
      MM = data == 0 ? null : (byte?)((data / cvs.TIMS_TT_MMPos) % cvs.TIMS_TimeSetting_Len);
      SS = (byte)(data % cvs.TIMS_TimeSetting_Len);//0はBlank
    }

    public override string ToString()
      => string.Format("{0}:{1}:{2}", HH, MM, SS);
  }

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
