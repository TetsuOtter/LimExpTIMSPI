using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  /// <summary>時刻表を管理します.</summary>
  static public class TimetableManager
  {
    static public Pnl_TIMSMon_TrainNum_Header TrNumHeader { get; private set; }
    static public int TrNum { get; private set; }
    static public Pnl_TIMSMon_TrainNum_Footer TrNumFooter { get; private set; }

    static public List<TIMS.StaInfo> StaList { get; private set; }

    /// <summary>TTMngerを初期化します.</summary>
    static public void Init()
    {
      //イベントの購読を行う
      Ats.SetBeaconEv += Ats_SetBeaconEv;
    }

    private static void Ats_SetBeaconEv(object sender, BeaconEvArgs e)
    {
      throw new NotImplementedException();
    }
  }
}
