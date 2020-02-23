using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  static public class Status
  {
    static public direct CabSeS_kore { get; set; }
    static public direct CabSeS_hoka1 { get; set; }
    static public direct CabSeS_hoka2 { get; set; }
    static public direct CabSeS_hoka3 { get; set; }
    static public direct CabSeS_hoka4 { get; set; }
    static public direct CabSeS_hoka5 { get; set; }
    static public DisplayingModeENum DispMode { get; set; }
    static public MCKeyStateENum MCKey { get; set; }
    static public WireVolType WireType { get; set; }

    static public bool[] NFB { get; set; } = new bool[Enum.GetNames(typeof(NFBs)).Length];
    static public bool[] Btn { get; set; } = new bool[Enum.GetNames(typeof(Btns)).Length];

  }
}
