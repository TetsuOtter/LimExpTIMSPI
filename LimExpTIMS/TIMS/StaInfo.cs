using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS.TIMS
{
  /// <summary>時刻表表示部表示情報</summary>
  public class StaInfo : ICloneable
  {
    /// <summary>停車駅であるか否か</summary>
    public bool IsStopSta { get => StopMode != Station_StopMode.Pass; }//通過駅でなければ停車

    /// <summary>停車種別</summary>
    public Station_StopMode StopMode { get; set; } = Station_StopMode.Stop;

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

    public object Clone()
    {
      StaInfo sinfo = (StaInfo)MemberwiseClone();
      sinfo.TimeDst = (TimeSetting)TimeDst.Clone();
      sinfo.Arrive = (TimeSetting)Arrive.Clone();
      sinfo.Depart = (TimeSetting)Depart.Clone();
      return sinfo;
    }

    public void CopyTo(StaInfo dst)
    {
      dst = (StaInfo)MemberwiseClone();
    }
  }


  public class TimeSetting : ICloneable
  {
    public byte? HH { get; set; } = null;
    public byte? MM { get; set; } = null;
    public byte SS { get; set; } = 0;

    public object Clone()
      => MemberwiseClone();

    public void SetFromBeaconD(in int data)
    {
      HH = data == 0 ? null : (byte?)((data / cvs.TIMS_TT_HHPos) % cvs.TIMS_TimeSetting_Len);
      MM = data == 0 ? null : (byte?)((data / cvs.TIMS_TT_MMPos) % cvs.TIMS_TimeSetting_Len);
      SS = (byte)(data % cvs.TIMS_TimeSetting_Len);//0はBlank
    }

    public override string ToString()
      => new StringBuilder().Append(HH).Append(':').Append(MM).Append(':').Append(SS).ToString();
  }
}
