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
    private static bool IsBeforeNotF = false;
    private static bool IsBeforeR = false;
    private static bool IsBeforeB = false;
    private static int TimeCounter = 0;
    private static int No1BLNum = 0;
    private static int No2BLNum = 0;
    static internal unsafe void Elapse(int* Pa)
    {
      //CabSeS前でなければ、ATS出力を上書き
      if (Main.AskATSPsPLoaded)//そもそもPIが読まれてなかったら実行しない。
      {
        if (Main.CabSeSLoc != Main.CabSeSLocationENum.F)
        {
          IsBeforeNotF = true;
          IsBeforeB = false;
          IsBeforeR = false;
          TimeCounter = Ats.StateD.T;

          //B段数表示Wrapper
          Pa[30] = 0;
          Pa[31] = 0;

          //ATS Wrapper
          for (int i = 0; i <= 21; i++) Pa[i] = 0;
          

        }
        else if (IsBeforeNotF)//R=>B=>NULL
        {
          if (Ats.StateD.T - TimeCounter > 35)
          {
            if (IsBeforeB)
            {
              No1BLNum = Pa[241];//No1
              No2BLNum = Pa[242];//No2
            }else if (IsBeforeR)
            {
              No1BLNum = No2BLNum = Main.BLBlack;//R=>B
              IsBeforeB = true;
            }
            else//=>R
            {
              No1BLNum = No2BLNum = Main.BLRed;//=>R
              IsBeforeR = true;
            }


            TimeCounter = Ats.StateD.T;
          }
          Pa[241] = No1BLNum;
          Pa[242] = No1BLNum;

        }
      }
      
    }
  }
}
