using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Reflection;

#if WINDOWS_UWP
using System.Linq;
using System.Text;
using Windows.Storage;
using System.Windows;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media;
#elif WPF
using Microsoft.Win32;
#endif
namespace TR.LimExpTIMSDisp
{
  public class TimeTable
  {
#if WINDOWS_UWP
    internal async void SelectFile(){
          //https://docs.microsoft.com/ja-jp/windows/uwp/files/quickstart-using-file-and-folder-pickers
      StorageFile TimeTableFile = null;
      var Picker = new FileOpenPicker()
      {
        ViewMode = PickerViewMode.List,
        SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
      };
      Picker.FileTypeFilter.Add(".csv");
      TimeTableFile = await Picker.PickSingleFileAsync();
      if(TimeTableFile!=null){
      DecidedTTData = null;
      List<string> FileContentList = new List<string>();
      string filec = string.Empty;
      try
      {
        filec = await FileIO.ReadTextAsync(TTFile);
      }
      catch (Exception e)
      {
        
        UsefulFunc.MsgBxShow(e.ToString(), "File Read Error");
        return;
      }
      try
      {
        if (filec != null && filec != string.Empty) foreach (string s in filec.Replace("\r", string.Empty).Split('\n')) FileContentList.Add(s);
        else UsefulFunc.MsgBxShow("文字列がnull or Empty", "Listing Error");
      }
      catch (Exception e)
      {
        UsefulFunc.MsgBxShow(e.ToString(), "Listing Error");
        return;
      }

      CnvCSVtoClass(in FileContentList);
      }
}
#elif WPF
    internal async void SelectFile()
    {
      
      Assembly asm = Assembly.GetEntryAssembly();
      string AsmFPath = asm.Location;
      string[] AsmFPathArr=AsmFPath.Split('\\');
      AsmFPath = AsmFPathArr[0];
      for (int i = 1; i < AsmFPathArr.Length - 1; i++) AsmFPath += ("\\" + AsmFPathArr[i]);
      
      //https://johobase.com/wpf-file-folder-common-dialog/
      var ofildig = new OpenFileDialog();
      ofildig.Filter = "CSVファイル (*.csv)|*.csv";
      if (ofildig.ShowDialog() == true)
      {
        List<string> FileContentList = new List<string>();
        string filec = string.Empty;
        try
        {
          using (StreamReader sr = new StreamReader(ofildig.OpenFile()))
          {
            filec = await sr.ReadToEndAsync();
          }
          try
          {
            if (filec != null && filec != string.Empty) foreach (string s in filec.Replace("\r", string.Empty).Split('\n')) FileContentList.Add(s);
            else UsefulFunc.MsgBxShow("文字列がnull or Empty", "Listing Error");
          }
          catch (Exception e)
          {
            UsefulFunc.MsgBxShow(e.ToString(), "Listing Error");
            return;
          }
        }
        catch (Exception e)
        {
          UsefulFunc.MsgBxShow(e.Message, "Error LimExpTIMSDisp");
        }
        CnvCSVtoClass(FileContentList);
      }
      else return;
#endif
    }
    //UsefulFunc.MsgBxShow("FileType not corrected");
    private void DDOpenFile(object TTFile)
    {

    }
    private void CLOpenFile(string FilePath)
    {

    }
    
    private async void CnvCSVtoClass(List<string> FileContentList)
    {
      bool IsTimeTableEditing = false;
      bool IsOptDataEditing = false;
      TimeTableData TTD = new TimeTableData();
      TTList = new List<TimeTableData>();
      if (FileContentList == default || FileContentList == null)
      {
        UsefulFunc.MsgBxShow("ファイル内容の読み取りに失敗しました。", "Error");
        return;
      }
      foreach (string ContLine in FileContentList)
      {
        if (ContLine == null) continue;
        string Content = ContLine.Replace(" ", string.Empty);
        string[] RowData = ContLine.Split(',');
        if (RowData[0] == string.Empty) continue;//空行なら無視
        if (RowData[0].StartsWith("//")) continue;//"//"ならコメント
        if (RowData[0].StartsWith(";")) continue;//";"ならコメント
        if (RowData[0].StartsWith("#")) continue;//"#"ならコメント
        if (IsTimeTableEditing)
        {
          if (IsOptDataEditing)
          {
            switch (RowData[0])
            {
              case "TRTimeTableOPEOF":
                IsOptDataEditing = false;
                break;
              case "SlowPoint":
                try
                {
                  SlowPointData SPD = new SlowPointData() { LimitSpeed = double.Parse(RowData[1]) };
                  SPD.NoticeStartPoint = double.Parse(RowData[2]);
                  SPD.LimitStartPoint = double.Parse(RowData[3]);
                  SPD.EndPoint = double.Parse(RowData[4]);
                  TTD.SlowPointList.Add(SPD);
                }
                catch (Exception e)
                {
                  UsefulFunc.MsgBxShow("徐行警告機能の位置設定記述が正しくありません。\n" + e.Message, "SlowPoint Location Parsing Error");
                  DecidedTTData = null;
                  InsertedICInfo = null;
                  return;
                }
                break;
              case "AirSec":
                try
                {
                  TTD.AirSecList.Add(new SectionData()
                  {
                    NoticeStartPoint = double.Parse(RowData[1]),
                    EndPoint = double.Parse(RowData[2])
                  });
                }
                catch (Exception e)
                {
                  UsefulFunc.MsgBxShow("エアセクション警告機能の位置設定記述が正しくありません。\n" + e.Message, "AirSection Location Parsing Error");
                  DecidedTTData = null;
                  InsertedICInfo = null;
                }
                break;
              case "ACDCChange":
                try
                {
                  TTD.ACDCSecList.Add(new SectionData()
                  {
                    NoticeStartPoint = double.Parse(RowData[1]),
                    EndPoint = double.Parse(RowData[2])
                  });
                }
                catch (Exception e)
                {
                  UsefulFunc.MsgBxShow("交直切換警告機能の位置設定記述が正しくありません。\n" + e.Message, "AC-DC Section Location Parsing Error");
                  DecidedTTData = null;
                  InsertedICInfo = null;
                }
                break;
              case "ACACSec":
                try
                {
                  TTD.ACACSecList.Add(new SectionData()
                  {
                    NoticeStartPoint = double.Parse(RowData[1]),
                    EndPoint = double.Parse(RowData[2])
                  });
                }
                catch (Exception e)
                {
                  UsefulFunc.MsgBxShow("交交セクション警告機能の位置設定記述が正しくありません。\n" + e.Message, "AC-AC Section Location Parsing Error");
                  DecidedTTData = null;
                  InsertedICInfo = null;
                }
                break;
              case "RadioCH":
                try
                {
                  TTD.RCHChangePList.Add(new RadioCHChangingData()
                  {
                    ChangeTo = RowData[1],
                    ChangePoint = double.Parse(RowData[2])
                  });
                }
                catch (Exception e)
                {
                  UsefulFunc.MsgBxShow("無線チャンネル自動切換機能の設定記述が正しくありません。\n" + e.Message, "Radio Channel Changing Function Error");
                  DecidedTTData = null;
                  InsertedICInfo = null;
                }
                break;
              case "LineColorChange":
                try
                {
                  TTD.LineColorList.Add(new LineColorChangingData()
                  {
                    ColorTo = StrToSCB(RowData[1]),
                    StaID = int.Parse(RowData[2])
                  });
                }
                catch (Exception e)
                {
                  UsefulFunc.MsgBxShow("進行線色変更機能の設定記述が正しくありません。\n" + e.Message, "Line Color Changing Function Error");
                  DecidedTTData = null;
                  InsertedICInfo = null;
                }
                break;
            }
          }
          else
          {
            switch (RowData[0])
            {
              case "TRTimeTableOP100":
                IsOptDataEditing = true;
                break;
              case "TRTimeTableEOF":
                IsTimeTableEditing = false;
                TTList.Add(TTD);
                break;
              default://各駅設定
                StaInfo SI = new StaInfo();
                try
                {
                  int c = 0;
                  SI.StaName = RowData[c++];
                  try
                  {
                    SI.StaLocation = double.Parse(RowData[c++]);
                  }
                  catch (Exception e)
                  {
                    UsefulFunc.MsgBxShow("駅位置の設定記述が正しくありません。\n" + e.Message, "Station Location Parsing Error");
                    DecidedTTData = null;
                    InsertedICInfo = null;
                    return;
                  }
                  SI.RunMM = RowData[c++].ToNarrow();
                  SI.RunSS = RowData[c++].ToNarrow();
                  SI.ArrHH = RowData[c++].ToWide();
                  SI.ArrMM = RowData[c++].ToWide();
                  SI.ArrSS = RowData[c++].ToNarrow();
                  SI.ArrSymbol = RowData[c++];
                  SI.IsPass = RowData[c++] == "1";
                  SI.DepHH = RowData[c++].ToWide();
                  SI.DepMM = RowData[c++].ToWide();
                  SI.DepSS = RowData[c++].ToNarrow();
                  SI.DepSymbol = RowData[c++];
                  SI.TrackName = RowData[c++];
                  SI.RuninLim = RowData[c++].ToNarrow();
                  SI.RunoutLim = RowData[c++].ToNarrow();
                  int StaWorkIndex = c++;
                  if (RowData[StaWorkIndex] != string.Empty)
                  {
                    try
                    {
                      SI.StaWork = (StaWorkEnum)int.Parse(RowData[StaWorkIndex]);
                    }
                    catch (Exception e)
                    {
                      UsefulFunc.MsgBxShow("駅仕業の設定記述が正しくありません。\n" + e.Message, "StationWork Parsing Error");
                      DecidedTTData = null;
                      InsertedICInfo = null;
                      return;
                    }
                  }
                  SI.DispColor = StrToSCB(RowData[c++]);
                  if (SI.ArrSS == string.Empty) SI.ArrSS = "0";
                  if (SI.DepSS == string.Empty) SI.DepSS = "0";
                  TTD.TTList.Add(SI);
                }
                catch (Exception e)
                {
                  UsefulFunc.MsgBxShow("駅の設定記述が正しくありません。\n" + e.Message, "StationData Parsing Error");
                  DecidedTTData = null;
                  InsertedICInfo = null;
                  return;
                }

                break;
            }
          }
        }
        else
        {
          switch (RowData[0])
          {
            case "TRTimeTable100":
              if (RowData.Length >= 8)
              {
                TTD = new TimeTableData();
                TTD.TrainNum = RowData[1].ToWide();
                TTD.PTrainNum = RowData[2].ToWide();
                TTD.IsPassDefault = RowData[3] == "1";
                TTD.IsDirectionLeft = RowData[4] == "1";
                TTD.RadioNum = RowData[5] == string.Empty ? "-" : RowData[5].ToNarrow();
                TTD.LineColor = StrToSCB(RowData[6]);
                TTD.LastStation = RowData[7];
                IsTimeTableEditing = true;
                TTD.LineColorList.Add(new LineColorChangingData() { ColorTo = TTD.LineColor, StaID = 0 });
              }
              else
              {
                UsefulFunc.MsgBxShow("時刻表設定のヘッダー行形式が正しくありません。", "IC File Error");
                DecidedTTData = null;
                InsertedICInfo = null;
                return;
              }
              break;
            case "TRTimeTableIC100":
              if (RowData.Length >= 6)
              {
                InsertedICInfo = new ICSettingInfo();
                InsertedICInfo.OfficeName = RowData[1];
                InsertedICInfo.WorkNumber = RowData[2].ToWide();
                InsertedICInfo.EffectedDateYY = RowData[3].ToNarrow();
                InsertedICInfo.EffectedDateMM = RowData[4].ToNarrow();
                InsertedICInfo.EffectedDateDD = RowData[5].ToNarrow();
              }
              else
              {
                UsefulFunc.MsgBxShow("IC情報設定の形式が正しくありません。", "IC File Error");
                DecidedTTData = null;
                InsertedICInfo = null;
                return;
              }
              break;
          }
        }
      }
      if (IsTimeTableEditing || IsOptDataEditing)
      {
        UsefulFunc.MsgBxShow("行路ICカードファイルの設定が終了していません。\nEOF記述を追加してください。", "EOF Not Found Error");
        DecidedTTData = null;
        InsertedICInfo = null;
        return;
      }
      switch (TTList.Count)
      {
        case 0:
          DecidedTTData = null;
          break;
        case 1:
          TimeTablesPicked(0);
          break;
        default:
          await Task.Delay(100 * TTList.Count);
          ManyTTDataInput?.Invoke(null, null);
          break;
      }
    }
    static public void TimeTablesPicked(int Index)
    {
      if (TTList != null && Index < TTList.Count)  
      {
        DecidedTTData = TTList[Index];
        TimeTableDecidedEvent?.Invoke(null, null);
      }
    }
    public static event EventHandler TimeTableDecidedEvent;
    public static event EventHandler ManyTTDataInput;
    public static TimeTableData DecidedTTData = null;
    public static ICSettingInfo InsertedICInfo;
    /// <summary>string3桁数字をSolidColorBrush形式に変換する</summary>
    /// <param name="s">入力文字列</param>
    /// <returns><出力色/returns>
    public static SolidColorBrush StrToSCB(string s)
    {
      byte[] DClB = new byte[3] { 255, 255, 255 };
      if (s != null && s != string.Empty && s.Length == 3)
      {
        char[] DCL = s.ToCharArray();
        if (DCL.Length == 3)
        {
          DClB[0] = (byte)(DCL[0] == '0' ? 0 : 255);
          DClB[1] = (byte)(DCL[1] == '0' ? 0 : 255);
          DClB[2] = (byte)(DCL[2] == '0' ? 0 : 255);
        }
      }
      return new SolidColorBrush(Color.FromArgb(255, DClB[0], DClB[1], DClB[2]));
    }
    public static List<TimeTableData> TTList;
    /* ファイル構造 (*以外はBlankで非表示. 入力するのは表示したい内容.)
     * Header, 列番, P列番, 通過設定TF, 進行方向(0:R, 1:L), 無線ch(-,D1~D9, A1~A9), LineColor(RGB:111), 終着駅名
     * *駅名, *駅位置[m], 駅間時分(前駅~本駅)[min], 駅間時分(前駅~本駅)[sec], 着時(HH), 着時(MM), 着時(SS), ArrSymbol, IsPass(1:PASS), 発時(HH), 発時(MM), 発時(SS), DepSymbol, 着発番線, 進入制限[km/h], 進出制限[km/h], 駅仕業, 表示色(RGB:111)
     * OPHeader
     * Type, Data1, Data2,,,
     * OPFooter
     * Footer
    */
    /* Header : TRTimeTable100
     * Op.Data Header : TRTimeTableOP100
     * Op.Data Footer : TRTimeTableOPEOF
     * Footer : TRTimeTableEOF
     */
    /* Option List
     * "SlowPoint", LimitSpeed[km/h], Notice Start[m], Section Start[m], Section End[m]
     * "AirSec", Notice Start[m], Notice End[m]
     * "ACDCChange", Notice Start[m], Notice End[m]
     * "ACACSec", Notice Start[m], Notice End[m]
     * "RadioCH", Change To (D:1~9, A:11~19), Change Point[m]
     * "LineColorChange", Change To(RGB:111), Change From(Sta ID)
     * 
     * Sta ID : First Sta:1, Second Sta:2...
     */
    /* IC Setting <= DO NOT INSERT BETWEEN TIMETABLE HEADERS
     * Header("TRTimeTableIC100"), Office Name, Work Number, Effected Date(Year), Effected Date(Month), Effected Date(Day)
     */

    public class StaInfo
    {
      public string StaName;
      public double StaLocation;
      public string RunMM;
      public string RunSS;
      public string ArrHH;
      public string ArrMM;
      public string ArrSS;
      public string ArrSymbol;
      public bool IsPass;
      public string DepHH;
      public string DepMM;
      public string DepSS;
      public string DepSymbol;
      public string TrackName;
      public string RuninLim;
      public string RunoutLim;
      public StaWorkEnum StaWork;
      public Brush DispColor;
    }
    public enum StaWorkEnum
    {
      None
    }
    public class ICSettingInfo
    {
      public string OfficeName;
      public string WorkNumber;
      public string EffectedDateYY;
      public string EffectedDateMM;
      public string EffectedDateDD;
    }
    public class SlowPointData
    {
      public double LimitSpeed;
      public double NoticeStartPoint;
      public double LimitStartPoint;
      public double EndPoint;
    }
    public class SectionData
    {
      public double NoticeStartPoint;
      public double EndPoint;
    }
    public class RadioCHChangingData
    {
      public string ChangeTo;
      public double ChangePoint;
    }
    public class LineColorChangingData
    {
      public SolidColorBrush ColorTo;
      public int StaID;
    }
    public class TimeTableData
    {
      public string TrainNum;
      public string PTrainNum;
      public bool IsPassDefault;
      public bool IsDirectionLeft;
      public string RadioNum;
      public SolidColorBrush LineColor;
      public string LastStation;
      public List<StaInfo> TTList = new List<StaInfo>();
      public List<SlowPointData> SlowPointList = new List<SlowPointData>();
      public List<SectionData> AirSecList = new List<SectionData>();
      public List<SectionData> ACDCSecList = new List<SectionData>();
      public List<SectionData> ACACSecList = new List<SectionData>();
      public List<RadioCHChangingData> RCHChangePList = new List<RadioCHChangingData>();
      public List<LineColorChangingData> LineColorList = new List<LineColorChangingData>();
    }
  }
}
