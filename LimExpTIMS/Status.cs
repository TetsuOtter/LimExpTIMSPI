using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
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
  }
}
