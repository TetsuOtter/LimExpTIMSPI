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
    private static bool IsBeforeNotFADC = false;
    private static bool IsBeforeR = false;
    private static bool IsBeforeB = false;
    private static int TimeCounter = 0;
    private static int No1BLNum = 0;
    private static int No2BLNum = 0;
    private static bool IsADCChangeChacking = false;
    private static int? ADCCheckStartTime = null;
    //private static int MRDispNum = 0;
    private const int ADCChangeCheckLength = 30 * 1000;
    private const int ControlVoltageDecSPD = 8000;
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
          Pa[Panel.GCP.BrakeLocationDisplay] = 0;
          Pa[Panel.GCP.EmergencyBrakeLamp] = 0;

          //ATS Wrapper
          for (int i = 0; i <= 21; i++) Pa[i] = 0;
          Pa[Panel.Ats.PsPatternSpeed] = 140;//Ps Pattern Bar

        }
        else if (IsBeforeNotF)//R=>B=>NULL
        {
          if (Ats.StateD.T - TimeCounter > 35)
          {
            if (IsBeforeB)
            {
              No1BLNum = Pa[Panel.GCP.No1BrightAdjust];//No1
              No2BLNum = Pa[Panel.GCP.No2BrightAdjust];//No2
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
          Pa[Panel.GCP.No1BrightAdjust] = No1BLNum;
          Pa[Panel.GCP.No2BrightAdjust] = No2BLNum;

        }
      }

      if (IsADCChangeChacking)
      {
        int TimeDifference = Ats.StateD.T - (int)ADCCheckStartTime;
        if (ADCCheckStartTime == null) ADCCheckStartTime = Ats.StateD.T;
        if (TimeDifference > ADCChangeCheckLength || TimeDifference < 0)
        {
          ADCCheckStartTime = null;
          IsADCChangeChacking = false;
          //常時自炊から「通常」として送られてきてるはず...
        }
        else
        {
          //VCB全入切表示後1~2sで事故
          //架線電圧復帰後3~4sで事故消灯
          //事故消灯後5sくらいで三相消灯 100Vへ
          //AC区間であれば即0 事故表示
          //事故表示0.5s後くらいに96V?87V? 三相
          //VCB表示消灯は5sくらい VCB入ると事故消灯
          //要調査
          if (Pa[Panel.GCP.ACDCLamp] == 1)//DC区間の場合
          {
            Pa[Panel.GCP.AccidentLamp] = 1;//事故

            Pa[Panel.GCP.DCVolNeedle] = 0;//直流電圧系の針
            Pa[Panel.GCP.DCVolUnusual] = 1;//DC電圧異常

            Pa[Panel.Cab.VCBState] = 3;//VCB状態(両点灯)

            Pa[Panel.GCP.ControlVolNeedle] = 87 - (TimeDifference / ControlVoltageDecSPD);//制御電圧計の針
            Pa[Panel.GCP.ControlVolUnusual] = 0;//制御電圧異常
            Pa[Panel.GCP.ControlVol10] = Pa[Panel.GCP.ControlVolNeedle] / 10;//制御電圧10の位
            Pa[Panel.GCP.ControlVol1] = Pa[Panel.GCP.ControlVolNeedle] % 10;//制御電圧1の位

          }
          else if (Pa[Panel.GCP.ACDCLamp] == 2)//AC区間の場合
          {
            Pa[Panel.GCP.AccidentLamp] = 1;//事故

            Pa[Panel.GCP.ACVolNeedle] = 0;//交流電圧系の針
            Pa[Panel.GCP.ACVolUnusual] = 1;//AC電圧異常

            Pa[Panel.Cab.VCBState] = 3;//VCB状態(両点灯)

            Pa[Panel.GCP.ControlVolNeedle] = 87 - (TimeDifference / ControlVoltageDecSPD);//制御電圧計の針
            Pa[Panel.GCP.ControlVolUnusual] = 0;//制御電圧異常
            Pa[Panel.GCP.ControlVol10] = Pa[Panel.GCP.ControlVolNeedle] / 10;//制御電圧10の位
            Pa[Panel.GCP.ControlVol1] = Pa[Panel.GCP.ControlVolNeedle] % 10;//制御電圧1の位
          }
          else//ACでもDCでもないなら転換試験をしない。
          {
            ADCCheckStartTime = null;
            IsADCChangeChacking = false;
          }
        }
      }

      if (IsBeforeNotFADC && !IsADCChangeChacking && Main.CabSeSLoc == Main.CabSeSLocationENum.F) 
      {
        IsBeforeNotFADC = false;
        IsADCChangeChacking = true;
      }
      if (Main.CabSeSLoc != Main.CabSeSLocationENum.F) IsBeforeNotFADC = true;

      //耐雪ブレーキ表示
      Pa[Panel.GCP.SnowResistantBrake] = Main.NFBConfig.SnoBrake ? 1 : 0;

      //MR針位置の設定
      //自炊を変換するのみ
      Pa[Panel.GCP.MRNeedle] = 750 + (5 * (Pa[127] + Pa[128] + Pa[129]));//MR針

      Pa[Panel.GCP.MRUnusualBand] = 0;//MR異常時用帯 非表示(v100)
      Pa[Panel.GCP.MRUnusualScale] = 0;//MR異常時用目盛 非表示(v100)


    }
  }
}
