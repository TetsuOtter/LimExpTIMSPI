﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS.TIMS
{
  public class TIMS_IF : IDisposable
  {
    TimeManager BlinkTimer = new TimeManager(cvs.TIMSFlushTime);
    bool Blink_P = false;
    public TIMS_IF()
    {
      BlinkTimer.TimerEvent += (s, e) => Blink_P = !Blink_P;
      BlinkTimer.TimerStart();

      Ats.KeyDownEv += Ats_KeyDownEv;
      Ats.KeyUpEv += Ats_KeyUpEv;
    }

    private void Ats_KeyUpEv(object sender, IntValEvArgs e)
    {
      
    }

    private void Ats_KeyDownEv(object sender, IntValEvArgs e)
    {
      
    }



    #region PanelStatuses
    #region Common
    public Pnl_TIMSMon_TsukokuJoho_Char TsukokuJoho_Char { get; private set; }
    public Pnl_TIMSMon_Emerg_Warning_WC Emerg_Warning_WC_Btn { get; private set; }
    #endregion

    #region D01AA
    public Pnl_Radio_CH Radio_CH { get; private set; }

    public StaInfo FirstRow { get; private set; } = null;
    public StaInfo SecondRow { get; private set; } = null;
    public StaInfo ThirdRow { get; private set; } = null;
    public StaInfo FourthRow { get; private set; } = null;
    public StaInfo FifthRow { get; private set; } = null;
    public StaInfo NextStop { get; private set; } = null;

    public ReduceSpeedInfo ReduceSPD1 { get; private set; } = null;
    public ReduceSpeedInfo ReduceSPD2 { get; private set; } = null;
    #endregion
    #endregion

    #region IDisposable Support
    private bool disposedValue = false; // 重複する呼び出しを検出するには

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          // TODO: マネージ状態を破棄します (マネージ オブジェクト)。
        }

        // TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
        // TODO: 大きなフィールドを null に設定します。

        Ats.KeyDownEv -= Ats_KeyDownEv;
        Ats.KeyUpEv -= Ats_KeyUpEv;

        disposedValue = true;
      }
    }

    // TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
    // ~TIMS_IF()
    // {
    //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
    //   Dispose(false);
    // }

    // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
    void IDisposable.Dispose()
    {
      // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
      Dispose(true);
      // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
      // GC.SuppressFinalize(this);
    }
    #endregion

  }

  /// <summary>時刻表表示部表示情報</summary>
  public class StaInfo
  {
    /// <summary>停車駅であるか否か</summary>
    public bool IsStopSta { get; set; } = true;

    /// <summary>駅名</summary>
    public int StaIndex { get; set; } = 0;
    /// <summary>時分</summary>
    public int? TimeDst { get; set; } = null;

    /// <summary>着(HH)</summary>
    public byte? Arrive_HH { get; set; } = null;
    /// <summary>着(MM)</summary>
    public byte? Arrive_MM { get; set; } = null;
    /// <summary>着(SS)</summary>
    public byte Arrive_SS { get; set; } = 0;
    public Pnl_TIMSMon_D01AA_TimeSep Arrive_Sep { get; set; } = Pnl_TIMSMon_D01AA_TimeSep.Blank;

    public byte? Depart_HH { get; set; } = null;
    public byte? Depart_MM { get; set; } = null;
    public byte Depart_SS { get; set; } = 0;
    public Pnl_TIMSMon_D01AA_TimeSep Depart_Sep { get; set; } = Pnl_TIMSMon_D01AA_TimeSep.Blank;

    /// <summary>番線</summary>
    public int TrackNum { get; set; } = 0;

    /// <summary>到着時制限</summary>
    public int? ArrLimitSPD { get; set; } = null;
    /// <summary>出発時制限</summary>
    public int? DepLimitSPD { get; set; } = null;
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
