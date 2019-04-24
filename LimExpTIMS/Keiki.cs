using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  static class Keiki
  {
    //No.1(実装準備) / No.1+2 / No.2計器モニタ表示
    static class No1
    {

    }
    static internal class No12
    {
      internal static unsafe void Panel(int* Pa)
      {
        Pa[21] = Main.NFBConfig.SnoBrake ? 1 : 0;
      }
    }
    static class No2
    {
      //特に独自処理はない。
    }
  }
}
