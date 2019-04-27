using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  class D01AA
  {
    //D01AA 運転情報

    static internal void Loaded()
    {

    }
    static internal void UnLoaded()
    {

    }
    static internal unsafe void Elapse(int* p)
    {
      //無線ch番号表示
      p[249] = Main.RadioCHNum + 1;
      if (!Main.IsTimeTableSet)
      {
        //自炊出力を上書き

      }
    }
  }
}
