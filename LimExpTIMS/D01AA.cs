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

    static internal unsafe void Elapse(int* p)
    {
      //無線ch番号表示
      p[Panel.TIMS.RadioChannelNum] = Main.RadioCHNum + 1;
      if (!Main.IsTimeTableSet)
      {
        //自炊出力を上書き
        for (int i = 98; i <= 101; i++) p[i] = 0;//Location
        if (!Main.IsTrainNumSet) for (int i = 111; i <= 119; i++) p[i] = 0;//列番など 上の帯?
        for (int i = 130; i <= 207; i++) p[i] = 0;//時刻表表示など
      }

      if(Main.CabSeSLoc!= Main.CabSeSLocationENum.F)//CabSeS"後"のときはP列番が表示されない。Setされない。
      {
        for (int i = 91; i <= 97; i++) p[i] = 0;//P列番
        p[Panel.TIMS.D01AA.SettingCompleteLamp] = 0;
      }
      else
      {
        for (int i = 91; i <= 96; i++)p[i] = p[i + 20];
        p[Panel.TIMS.D01AA.PTrainNum.NumSuffix2] = p[Panel.TIMS.D01AA.TrainNum.NumSuffix2];
      }
    }
  }
}
