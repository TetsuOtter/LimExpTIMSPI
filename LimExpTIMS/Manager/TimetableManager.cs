using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.LimExpTIMS.TIMS;
namespace TR.LimExpTIMS
{
  /// <summary>時刻表を管理します.</summary>
  static public class TimetableManager
  {
    static public bool IsPassMode { get; private set; }

    /// <summary>接頭辞(列番側)</summary>
    static public Pnl_TIMSMon_TrainNum_Header TrNumHeader { get; private set; } = Pnl_TIMSMon_TrainNum_Header.Blank;

    /// <summary>接頭辞(先頭側)</summary>
    static public Pnl_TIMSMon_TrainNum_Header TrNumHeaderP { get; private set; } = Pnl_TIMSMon_TrainNum_Header.Blank;

    static public int TrNum { get; private set; } = 0;

    static public Pnl_TIMSMon_TrainNum_Footer TrNumFooter { get; private set; } = Pnl_TIMSMon_TrainNum_Footer.Blank;

    static public Pnl_TIMSMon_TrainNum_Footer TrNumFooter2 { get; private set; } = Pnl_TIMSMon_TrainNum_Footer.Blank;

    static public Jisui_TIMS_TrNum_Footer JMode_TrNumChar { get; private set; } = Jisui_TIMS_TrNum_Footer.Blank; //自炊TIMS互換出力用

    /// <summary>距離が負の方向に向かうものであるかどうか</summary>
    static public bool IsLocToMinusMode { get; private set; } = false;
    
    /// <summary>バイアスを設定</summary>
    static public double Dst_BIAS { get; private set; } = 0;

    /// <summary>入力された駅一覧</summary>
    static public List<StaInfo> StaList { get; private set; } = new List<StaInfo>();

    

    /// <summary>次駅の位置を設定(LETsPIモード時は無効) 表示更新を掛けた際にnullにする</summary>
    static public double? NextStaLocation { get; set; } = null;

    /// <summary>次駅更新がかかった際に発火するイベント(LETsPIモードでは無効)</summary>
    static public event EventHandler NextStaPassed;

    /// <summary>次の停車駅情報(LETsPIモードでは無効)</summary>
    static public StaInfo NextStopInfo { get; private set; } = new StaInfo();//=>更新はNextStaPassedで同時に行う


    /// <summary>TTMngerを初期化します.</summary>
    static public void Init()
    {
#if DEBUG
      LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Debug, LogManager.LogCategory.Step_Log, "TimetableManager.Init()");
#endif
      //イベントの購読を行う
      Ats.SetBeaconEv += Ats_SetBeaconEv;
    }

    private static void Ats_SetBeaconEv(object sender, BeaconEvArgs e)
    {
      StaInfo sinfo = null;
      switch ((BeaconAssign)e.beacon.Num)
      {
				#region jisui
				case BeaconAssign.TIMS_TrNum://cmp
          //列番数値部4桁, 記号部2桁
          //LETsPIモードの場合, 記号部は別Assign
          if (!Ats.IsLETsPIMode)
          {
            JMode_TrNumChar = (Jisui_TIMS_TrNum_Footer)(e.beacon.Data % 100);//記号部1

            TrNumFooter = Pnl_TIMSMon_TrainNum_Footer.Blank;
            TrNumFooter2 = Pnl_TIMSMon_TrainNum_Footer.Blank;
            TrNum = (e.beacon.Data / 100) % 1000;//数値部

            if (0 < JMode_TrNumChar && JMode_TrNumChar < Jisui_TIMS_TrNum_Footer.Z) TrNumFooter = (Pnl_TIMSMon_TrainNum_Footer)(JMode_TrNumChar.ToString().ToCharArray()[0] - 'A' + 1);
            else
            {
              switch (JMode_TrNumChar)
              {
                case Jisui_TIMS_TrNum_Footer.KR:
                  TrNumFooter = (Pnl_TIMSMon_TrainNum_Footer)('K' - 'A' + 1);
                  TrNumFooter2 = (Pnl_TIMSMon_TrainNum_Footer)('R' - 'A' + 1);
                  break;
                case Jisui_TIMS_TrNum_Footer.SR:
                  TrNumFooter = (Pnl_TIMSMon_TrainNum_Footer)('S' - 'A' + 1);
                  TrNumFooter2 = (Pnl_TIMSMon_TrainNum_Footer)('R' - 'A' + 1);
                  break;
                default:
                  if (Jisui_TIMS_TrNum_Footer.SO_First <= JMode_TrNumChar && JMode_TrNumChar <= Jisui_TIMS_TrNum_Footer.SO_Last) TrNumFooter = (Pnl_TIMSMon_TrainNum_Footer)(JMode_TrNumChar - Jisui_TIMS_TrNum_Footer.SO_First) + (int)Jisui_TIMS_TrNum_Footer.SO_First;
                  break;
              }
            }
            LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information, string.Format("BeaconAssign.TIMS_TrNum : TrNumChar set to {0} and {1}", TrNumFooter.ToString(), TrNumFooter2.ToString()));
          }
          return;

        case BeaconAssign.TIMS_TrNum_Header://cmp
          //列車種別 100以上で通過設定
          IsPassMode = e.beacon.Data >= 100;
          TrNumHeader = (Pnl_TIMSMon_TrainNum_Header)(e.beacon.Data % 100);
          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information, string.Format("Ats_SetBeaconEv.TIMS_TrNum_Header\tIsPassMode:{0}\tTrNumHeader:{1}", IsPassMode, TrNumHeader));
          return;

        case BeaconAssign.TIMS_Location://cmp
          //距離加算設定は, LETsPIモードでは無効(駅ごとの距離設定を随時更新)
          IsLocToMinusMode = e.beacon.Data >= cvs.Jisui_LocSetting_MinusSetBias;
          if (!Ats.IsLETsPIMode) Dst_BIAS = e.beacon.Data % cvs.Jisui_LocSetting_MinusSetBias;
          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information, string.Format("Ats_SetBeaconEv.TIMS_Location\tIsLocToMinusMode:{0}\tDsi_BIAS:{1}", IsLocToMinusMode, Dst_BIAS));
          return;

        case BeaconAssign.TIMS_NextStopComming://次駅接近 cmp
          if (Ats.IsLETsPIMode) return;//LETsPIモードでは無効(駅ごとのLocationをもとに自動再生)
          (e.beacon.Data >= 0 ? SoundAssign.Accidental_Passage_Preventer_Stop_Once : SoundAssign.Accidental_Passage_Preventer_Pass_Once).Play();//正なら停車 負なら通過
          Status.NextStop.StaLocation = (int)((Math.Abs(e.beacon.Data) % 10000) + e.beacon.Z);


          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_NextStopComming\tNew NextStaLocation:{0}", Status.NextStop.StaLocation));
          return;

        case BeaconAssign.TIMS_NextStopStaNum://cmp
          if (Ats.IsLETsPIMode) return;//LETsPIモードでは無効(各駅ごと停通を設定)
          //自駅情報は無視(必要性がわからない)
          NextStopInfo.StaIndex = e.beacon.Data % 1000;

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_NextStopStaNum\tNew StaIndex:{0}", NextStopInfo.StaIndex));
          return;

        case BeaconAssign.TIMS_NextStopArrTime://cmp
          if (Ats.IsLETsPIMode) return;//LETsPIモードでは無効(各駅ごと停通を設定)

          NextStopInfo.Arrive_Sep = e.beacon.Data == 0 ? Pnl_TIMSMon_D01AA_TimeSep.Blank : Pnl_TIMSMon_D01AA_TimeSep.Colon;
          NextStopInfo.Arrive.SetFromBeaconD(e.beacon.Data);

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_NextStopArrTime\tTime:{0}\tSep:{1}", NextStopInfo.Arrive, NextStopInfo.Arrive_Sep));
          return;

        case BeaconAssign.TIMS_NextStopTrack://cmp
          if (Ats.IsLETsPIMode) return;//LETsPIモードでは無効(各駅ごと停通を設定)

          NextStopInfo.TrackNum = e.beacon.Data;

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_NextStopTrack\tNew TrackNum:{0}", NextStopInfo.TrackNum));
          return;


        case BeaconAssign.TIMS_Timetable_StaName://各駅駅名 cmp
          sinfo = StaList.GetStaInfo(e.beacon.Data / cvs.TIMS_StaName_IDLength);
          sinfo.StaIndex = e.beacon.Data % cvs.TIMS_StaName_IDLength;

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_TimeTable_StaName\tStaID:{0}\tNew TrackNum:{1}", StaList.IndexOf(sinfo), sinfo.StaIndex));
          return;

        case BeaconAssign.TIMS_Timetable_ArrTime://cmp
          sinfo = StaList.GetStaInfo(e.beacon.Data / cvs.TIMS_TT_Time_StaIDPos);

          //LETsPIモード時, セパレータは専用Beaconで定義.
          if (!Ats.IsLETsPIMode) sinfo.Arrive_Sep = e.beacon.Data == 0 ? Pnl_TIMSMon_D01AA_TimeSep.DownArrow : Pnl_TIMSMon_D01AA_TimeSep.Colon;

          sinfo.Arrive.SetFromBeaconD(e.beacon.Data);
          
          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_TimeTable_ArrTime\tStaID:{0}\tNew ArrTime:{1}, ArrSep:{2}", StaList.IndexOf(sinfo), sinfo.Arrive, sinfo.Arrive_Sep));
          return;

        case BeaconAssign.TIMS_Timetable_DepTime://cmp
          sinfo = StaList.GetStaInfo(e.beacon.Data / cvs.TIMS_TT_Time_StaIDPos);

          //LETsPIモード時, セパレータは専用Beaconで定義.
          if (!Ats.IsLETsPIMode) sinfo.Depart_Sep = e.beacon.Data == 0 ? Pnl_TIMSMon_D01AA_TimeSep.DownArrow : Pnl_TIMSMon_D01AA_TimeSep.Colon;

          sinfo.Depart.SetFromBeaconD(e.beacon.Data);

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_TimeTable_DepTime\tStaID:{0}\tNew DepTime:{1}, DepSep:{2}", StaList.IndexOf(sinfo), sinfo.Depart, sinfo.Depart_Sep));
          return;

        case BeaconAssign.TIMS_Timetable_Track://cmp
          sinfo = StaList.GetStaInfo(e.beacon.Data / 100);
          sinfo.TrackNum = e.beacon.Data % 100;

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_TimeTable_Track\tStaID{0}\tNew Track:{1}", StaList.IndexOf(sinfo), sinfo.TrackNum));
          return;

        case BeaconAssign.TIMS_Timetable_LimSPD_IN://cmp
          sinfo = StaList.GetStaInfo(e.beacon.Data / 100);
          sinfo.ArrLimitSPD = e.beacon.Data % 100;

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_TimeTable_LimSPD_IN\tStaID:{0}\tNew LSPD_IN:{1}", StaList.IndexOf(sinfo), sinfo.ArrLimitSPD));
          return;

        case BeaconAssign.TIMS_Timetable_LimSPD_OUT://cmp
          sinfo = StaList.GetStaInfo(e.beacon.Data / 100);
          sinfo.DepLimitSPD = e.beacon.Data % 100;

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_TimeTable_LimSPD_OUT\tStaID:{0}\tNew LSPD_OUT:{1}", StaList.IndexOf(sinfo), sinfo.DepLimitSPD));
          return;

        case BeaconAssign.TIMS_Timetable_RunTime://cmp
          sinfo = StaList.GetStaInfo(e.beacon.Data / cvs.TIMS_TT_HHPos);
          sinfo.TimeDst.SetFromBeaconD(e.beacon.Data);//HHにStaIDか書かれるけど, そこは使用しないため無視.

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
            string.Format("Ats_SetBeaconEv.TIMS_TimeTable_LimSPD_OUT\tStaID:{0}\tNew RunTime:{1}", StaList.IndexOf(sinfo), sinfo.TimeDst));
          return;
				#endregion

				#region LETs
          //予めLETsPIモードが有効化されていることを期待して動作するので注意.

				case BeaconAssign.LETsPI_TIMS_Timetable_StaLoc://cmp
          //メートル単位で駅位置を指定
          //9999.999kmまで対応 => DDDPPPPPPP (D:時刻表桁番号, P:位置情報)
          sinfo = StaList.GetStaInfo(e.beacon.Data / cvs.LETsPI_TT_StaPos_PosLen);
          sinfo.StaLocation = e.beacon.Data % cvs.LETsPI_TT_StaPos_PosLen;
          
          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
                      string.Format("Ats_SetBeaconEv.LETsPI_TIMS_Timetable_StaLoc\tStaID:{0}\tNew StaLoc:{1}", StaList.IndexOf(sinfo), sinfo.StaLocation));
          return;

        case BeaconAssign.LETsPI_TIMS_Timetable_StopMode:
          //2桁を用いて停車種別を設定
          //設定可能な値はenums.csのStation_StopModeに定義される.
          sinfo = StaList.GetStaInfo(e.beacon.Data / cvs.ColX2);
          sinfo.StopMode = (Station_StopMode)(e.beacon.Data % cvs.ColX2);
          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
                      string.Format("Ats_SetBeaconEv.LETsPI_TIMS_Timetable_StopMode\tStaID:{0}\tNew StopMode:{1}", StaList.IndexOf(sinfo), sinfo.StopMode));
          break;

        case BeaconAssign.LETsPI_TIMS_TimeTable_TimeSep_Arr:
          //2桁を用いて到着時刻表示に表示するセパレータを設定
          //設定可能な値はenums.csのPnl_TIMSMon_D01AA_TimeSepに定義される.
          sinfo = StaList.GetStaInfo(e.beacon.Data / cvs.LETsPI_TT_TimeSep_SepSetLen);
          sinfo.Arrive_Sep = (Pnl_TIMSMon_D01AA_TimeSep)(e.beacon.Data / cvs.LETsPI_TT_TimeSep_SepSetLen);
          
          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
                      string.Format("Ats_SetBeaconEv.LETsPI_TIMS_Timetable_TimeSep_Arr\tStaID:{0}\tNew TimeSep_Arr:{1}", StaList.IndexOf(sinfo), sinfo.Arrive_Sep));
          return;

        case BeaconAssign.LETsPI_TIMS_TimeTable_TimeSep_Dep:
          //2桁を用いて発車時刻表示に表示するセパレータを設定
          //設定可能な値はenums.csのPnl_TIMSMon_D01AA_TimeSepに定義される.
          sinfo = StaList.GetStaInfo(e.beacon.Data / cvs.LETsPI_TT_TimeSep_SepSetLen);
          sinfo.Depart_Sep = (Pnl_TIMSMon_D01AA_TimeSep)(e.beacon.Data / cvs.LETsPI_TT_TimeSep_SepSetLen);

          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
                      string.Format("Ats_SetBeaconEv.LETsPI_TIMS_Timetable_TimeSep_Dep\tStaID:{0}\tNew TimeSep_Dep:{1}", StaList.IndexOf(sinfo), sinfo.Depart_Sep));
          return;

        case BeaconAssign.LETsPI_TrNum_CharPart:
          //3桁ずつ<=>111222で設定.
          TrNumFooter = (Pnl_TIMSMon_TrainNum_Footer)((e.beacon.Data / cvs.ColX3) % cvs.ColX3);
          TrNumFooter2 = (Pnl_TIMSMon_TrainNum_Footer)(e.beacon.Data % cvs.ColX3);
          LogManager.WriteLine("TimetableManager", LogManager.LogLevel.Information, LogManager.LogCategory.Execute_Information,
                      string.Format("Ats_SetBeaconEv.LETsPI_TrNum_CharPart\tNew TrNum F1:{0}, New TrNum F2:{1}", TrNumFooter, TrNumFooter2));
          return;
          #endregion
      }
    }
  }
}
