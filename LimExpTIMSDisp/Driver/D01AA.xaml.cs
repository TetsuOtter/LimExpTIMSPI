using System;
using System.Threading.Tasks;
#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#elif WPF
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
//using Windows.UI.Xaml.Media;
#endif
// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace TR.LimExpTIMSDisp.Driver
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class D01AA : Page
  {
    private const int FontSizeDef = 16;
    private double RefreshDistance = 0;
    private double StopStaComingNotice = 0;
    const double StopStaComingNoticeStart = 600;
    internal static int DispingFirstRowStaIndex;
    private int DispDTCounter;
    internal static DispatcherTimer StaListRefreshDT = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, Settings.RefreshRate) };
    DispatcherTimer LocChangeDT = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
    
    public D01AA()
    {
      this.InitializeComponent();
      PageReflesh();
      JokoClear(0);
      JokoGrid.Visibility = Visibility.Collapsed;
      BIDSSMemLib.SMemLib.Events.LocationChanged += Events_LocationChanged;
      LocChangeDT.Tick += LocChangeDT_Tick;
    }

    BIDSSMemLib.SMemLib.Events.LocationChangedEventArgs LCEA = null;
    private void LocChangeDT_Tick(object sender, EventArgs ea)
    {
      if (LCEA != null && TimeTable.DecidedTTData != null) 
      {
        var e = LCEA;
        //停車駅接近
        TIMS.IsStaComingNoticeON = RefreshDistance > e.Location && StopStaComingNotice < e.Location;

        //時刻表更新
        if (RefreshDistance < e.Location)
        {
          DispingFirstRowStaIndex++;

          StaListRefreshDT?.Start();
        }

        //徐行設定
        IsJoko1Enabled = IsJoko2Enabled = false;
        JokoClear(0);//1も2も消去
        foreach (TimeTable.SlowPointData spd in TimeTable.DecidedTTData.SlowPointList)
        {
          if (!IsJoko1Enabled || !IsJoko2Enabled)
          {
            if (spd.NoticeStartPoint <= e.Location && e.Location <= spd.EndPoint)
            {
              if (IsJoko1Enabled)
              {
                JokoSet(false, spd.LimitStartPoint, spd.EndPoint, (int)spd.LimitSpeed);
                IsJoko2Enabled = true;
              }
              else
              {
                IsJoko1Enabled = true;
                JokoSet(true, spd.LimitStartPoint, spd.EndPoint, (int)spd.LimitSpeed);
              }
            }
          }
        }
        if (Joko1Grid.Visibility == Visibility.Collapsed && Joko2Grid.Visibility == Visibility.Collapsed)
        {
          JokoGrid.Visibility = Visibility.Collapsed;
        }
        else JokoGrid.Visibility = Visibility.Visible;
      }
      LocChangeDT.Stop();
    }

    bool IsJoko1Enabled = false;
    bool IsJoko2Enabled = false;
    private void Events_LocationChanged(object sender, BIDSSMemLib.SMemLib.Events.LocationChangedEventArgs e) { LCEA = e; LocChangeDT.Start(); }
    

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      TIMS.PageInfoSet("D01AA", "運転情報");
      TimeTable.TimeTableDecidedEvent += TimeTable_TimeTableDecidedEvent;
      StaListRefreshDT.Tick += StaListRefreshDT_Tick;
    }

    private void StaListRefreshDT_Tick(object sender, object e)
    {

      if (DispDTCounter == 0)
      {
        if (DispingFirstRowStaIndex + 1 < TimeTable.DecidedTTData.TTList.Count)
        {
          RefreshDistance = TimeTable.DecidedTTData.TTList[DispingFirstRowStaIndex + 1].StaLocation;
        }
        else//最終駅
        {
          RefreshDistance = double.MaxValue;
          TimeTable.DecidedTTData = null;
          PageReflesh();
          JokoClear(0);
          JokoGrid.Visibility = Visibility.Collapsed;
          DispDTCounter = 0;
          StaListRefreshDT.Stop();
          return;
        }
        StaListGrid.Children.Clear();
        if (TimeTable.DecidedTTData != null && !TimeTable.DecidedTTData.TTList[DispingFirstRowStaIndex].IsPass)
        {
          NextStopClear();
          for (int i = DispingFirstRowStaIndex + 1; i < TimeTable.DecidedTTData.TTList.Count; i++)
          {
            if (!TimeTable.DecidedTTData.TTList[i].IsPass)
            {
              StopStaComingNotice = TimeTable.DecidedTTData.TTList[i].StaLocation - StopStaComingNoticeStart;
              NextStopTB.Text = TimeTable.DecidedTTData.TTList[i].StaName;
              NextStopArrHHTB.Text = TimeTable.DecidedTTData.TTList[i].ArrHH;
              NextStopArrMMTB.Text = TimeTable.DecidedTTData.TTList[i].ArrMM;
              NextStopArrSSTB.Text = TimeTable.DecidedTTData.TTList[i].ArrSS;
              if (NextStopArrSSTB.Text == "0") NextStopArrSSTB.Text = string.Empty;
              NextStopTrackNameTB.Text = TimeTable.DecidedTTData.TTList[i].TrackName;
              NextStopArrDotTB.Text = TimeTable.DecidedTTData.TTList[i].ArrSymbol;
              if (NextStopArrDotTB.Text == ":") NextStopArrDotTB.Text = "．";
              NextStopArrDotTB.Visibility = Visibility.Visible;
              i = int.MaxValue - 1;
            }
          }
        }
      }
      if (DispDTCounter >= 0 && DispingFirstRowStaIndex + DispDTCounter < TimeTable.DecidedTTData.TTList.Count)
      {
        StaListGrid.Children.Add(StaListGridGet(DispDTCounter, TimeTable.DecidedTTData.TTList[DispingFirstRowStaIndex + DispDTCounter]));
      }
      if (DispDTCounter >= 4)
      {
        DispDTCounter = 0;
        StaListRefreshDT.Stop();
        return;
      }
      DispDTCounter++;
    }

    private async void TimeTable_TimeTableDecidedEvent(object sender, EventArgs e)
    {
      PageReflesh();
      //P列番から
      await Task.Delay(100);
      PTrainNumberTB.Text = TimeTable.DecidedTTData.PTrainNum;
      await Task.Delay(30);
      PTrainNumSetRec.Visibility = Visibility.Visible;
      await Task.Delay(1000);
      TrainNumberTB.Text = TimeTable.DecidedTTData.TrainNum;
      await Task.Delay(30);
      RadioCHTB.Text = TimeTable.DecidedTTData.RadioNum;
      await Task.Delay(30);
      if (TimeTable.DecidedTTData.IsPassDefault)
      {
        PTrainNumTsuTB.Visibility = Visibility.Visible;
        await Task.Delay(30);
        PassSettingSetRec.Visibility = Visibility.Visible;
      }
      
      DispingFirstRowStaIndex = 0;
      DispDTCounter = -1;
      StaListRefreshDT.Start();
    }

    private void PageReflesh()
    {
      PTrainNumTsuTB.Visibility = Visibility.Collapsed;
      NextStopArrDotTB.Visibility = Visibility.Collapsed;
      NextStopTB.Text = string.Empty;
      NextStopArrHHTB.Text = string.Empty;
      NextStopArrMMTB.Text = string.Empty;
      NextStopArrSSTB.Text = string.Empty;
      NextStopTrackNameTB.Text = string.Empty;
      TrainNumberTB.Text = string.Empty;
      PTrainNumberTB.Text = string.Empty;
      RadioCHTB.Text = string.Empty;
      PTrainNumSetRec.Visibility = Visibility.Collapsed;
      PassSettingSetRec.Visibility = Visibility.Collapsed;
      StaListGrid.Children.Clear();
    }

    /// <summary>表示する駅リストのGridを取得します。</summary>
    /// <param name="Num">駅の段番号(0~4)</param>
    /// <param name="sinf">駅情報</param>
    /// <returns>表示するべき駅</returns>
    private Grid StaListGridGet(int Num, TimeTable.StaInfo sinf)
    {
      FontFamily FFDef = FontFamily;
      Grid ReturnGrid = new Grid()
      {
        Margin = new Thickness(0, Num * 40, 0, 0),
        HorizontalAlignment = HorizontalAlignment.Left,
        VerticalAlignment = VerticalAlignment.Top,
        Height = 60,
        Width = 800
      };
      //RunTime
      if (Num != 0)
      {
        //RunTimeMM
        ReturnGrid.Children.Add(new TextBlock()
        {
          Text = sinf.RunMM,
          Margin = new Thickness(9, 0, 0, 0),
          Width = 18,
          Height = 18,
          Padding = new Thickness(0),
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Left,
          Foreground = sinf.DispColor,
          FontFamily = FFDef,
          FontSize = FontSizeDef
        });
        //RunTimeSS
        ReturnGrid.Children.Add(new TextBlock()
        {
          Text = sinf.RunSS,
          Margin = new Thickness(27, 0, 0, 0),
          Width = 10,
          Height = 10,
          Padding = new Thickness(0),
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Left,
          Foreground = sinf.DispColor,
          FontFamily = FFDef,
          FontSize = 10
        });
      }

      //StaName
      ReturnGrid.Children.Add(new TextBlock()
      {
        Text = sinf.StaName,
        Margin = new Thickness(90, 22, 0, 0),
        Foreground = sinf.DispColor,
        FontFamily = FFDef,
        FontSize = FontSizeDef,
        RenderTransform = new ScaleTransform() { ScaleX = 2, ScaleY = 1 }
      });

      //Arrive
      //HH
      ReturnGrid.Children.Add(new TextBlock()
      {
        Text = sinf.ArrHH,
        Margin = new Thickness(280, 22, 0, 0),
        Foreground = sinf.DispColor,
        FontFamily = FFDef,
        FontSize = FontSizeDef,
        RenderTransform = new ScaleTransform() { ScaleX = 2, ScaleY = 1 }
      });
      //Symbol
      TextBlock ArrSymTB = new TextBlock()
      {
        Text = sinf.ArrSymbol,
        Margin = new Thickness(0),
        HorizontalAlignment = HorizontalAlignment.Center,
        VerticalAlignment = VerticalAlignment.Top,
        Foreground = sinf.DispColor,
        FontFamily = FFDef,
        FontSize = FontSizeDef
      };
      ReturnGrid.Children.Add(new Border()
      {
        Background = null,
        Margin = new Thickness(345, 22, 0, 0),
        Width = 22,
        Padding = new Thickness(0),
        HorizontalAlignment = HorizontalAlignment.Left,
        VerticalAlignment = VerticalAlignment.Top,
        Child = ArrSymTB
      });
      //MM
      ReturnGrid.Children.Add(new TextBlock()
      {
        Text = sinf.ArrMM,
        Margin = new Thickness(360, 22, 0, 0),
        Foreground = sinf.DispColor,
        FontFamily = FFDef,
        FontSize = FontSizeDef,
        RenderTransform = new ScaleTransform() { ScaleX = 2, ScaleY = 1 }
      });
      //SS
      int SSKari = 0;
      if (int.TryParse(sinf.ArrSS, out SSKari) && SSKari != 0)
      {
        ReturnGrid.Children.Add(new TextBlock()
        {
          Text = sinf.ArrSS,
          Margin = new Thickness(432, 22, 0, 0),
          Width = 10,
          Height = 10,
          Padding = new Thickness(0),
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Left,
          Foreground = sinf.DispColor,
          FontFamily = FFDef,
          FontSize = 10
        });
      }

      //Departure
      //HH
      ReturnGrid.Children.Add(new TextBlock()
      {
        Text = sinf.DepHH,
        Margin = new Thickness(460, 22, 0, 0),
        Foreground = sinf.DispColor,
        FontFamily = FFDef,
        FontSize = FontSizeDef,
        RenderTransform = new ScaleTransform() { ScaleX = 2, ScaleY = 1 }
      });
      //Symbol
      TextBlock DepSymTB = new TextBlock()
      {
        Text = sinf.DepSymbol,
        Margin = new Thickness(0),
        HorizontalAlignment = HorizontalAlignment.Center,
        VerticalAlignment = VerticalAlignment.Top,
        Foreground = sinf.DispColor,
        FontFamily = FFDef,
        FontSize = FontSizeDef
      };
      ReturnGrid.Children.Add(new Border()
      {
        Background = null,
        Margin = new Thickness(525, 22, 0, 0),
        Width = 22,
        Padding = new Thickness(0),
        HorizontalAlignment = HorizontalAlignment.Left,
        VerticalAlignment = VerticalAlignment.Top,
        Child = DepSymTB
      });

      //MM
      ReturnGrid.Children.Add(new TextBlock()
      {
        Text = sinf.DepMM,
        Margin = new Thickness(540, 22, 0, 0),
        Foreground = sinf.DispColor,
        FontFamily = FFDef,
        FontSize = FontSizeDef,
        RenderTransform = new ScaleTransform() { ScaleX = 2, ScaleY = 1 }
      });
      //SS
      if (int.TryParse(sinf.DepSS, out SSKari) && SSKari != 0)
      {
        ReturnGrid.Children.Add(new TextBlock()
        {
          Text = sinf.DepSS,
          Margin = new Thickness(612, 22, 0, 0),
          Width = 10,
          Height = 10,
          Padding = new Thickness(0),
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Left,
          Foreground = sinf.DispColor,
          FontFamily = FFDef,
          FontSize = 10
        });
      }

      //TrackNum
      ReturnGrid.Children.Add(new TextBlock()
      {
        Text = sinf.TrackName,
        Margin = new Thickness(648, 22, 0, 0),
        Foreground = sinf.DispColor,
        FontFamily = FFDef,
        FontSize = FontSizeDef,
        RenderTransform = new ScaleTransform() { ScaleX = 2, ScaleY = 1 }
      });

      //Run-in Lim
      if (Num <= 3)
      {
        ReturnGrid.Children.Add(new TextBlock()
        {
          Text = sinf.RuninLim,
          Margin = new Thickness(746, 22, 0, 0),
          Foreground = sinf.DispColor,
          FontFamily = FFDef,
          FontSize = FontSizeDef
        });
        if (sinf.RunoutLim != string.Empty)
        {
          ReturnGrid.Children.Add(new TextBlock()
          {
            Text = "/" + sinf.RuninLim,
            Margin = new Thickness(746, 42, 0, 0),
            Foreground = sinf.DispColor,
            FontFamily = FFDef,
            FontSize = FontSizeDef
          });
        }
      }

      return ReturnGrid;
    }

    private void Page_Unloaded(object sender, RoutedEventArgs e)
    {
      BIDSSMemLib.SMemLib.Events.LocationChanged -= Events_LocationChanged;
      LocChangeDT.Tick -= LocChangeDT_Tick;
      TimeTable.TimeTableDecidedEvent -= TimeTable_TimeTableDecidedEvent;
      StaListRefreshDT.Tick -= StaListRefreshDT_Tick;
    }

    const string ShoSho = "000.000";
    const string SeiSho = "D3";
    private void JokoSet(bool IsFirst, double Start, double End, int Speed)
    {
      if (IsFirst)
      {
        Joko1Start.Text = Start.ToString(ShoSho);
        Joko1End.Text = End.ToString(ShoSho);
        Joko1LimSP.Text = Speed.ToString(SeiSho);
        Joko1Grid.Visibility = JokoGrid.Visibility = Visibility.Visible;
      }
      else
      {
        Joko2Start.Text = Start.ToString(ShoSho);
        Joko2End.Text = End.ToString(ShoSho);
        Joko2LimSP.Text = Speed.ToString(SeiSho);
        Joko2Grid.Visibility = Visibility.Visible;
      }
    }
    private void JokoClear(int num)
    {
      if (num != 1)
      {
        Joko2Start.Text = Joko2End.Text = Joko2LimSP.Text = string.Empty;
        Joko2Grid.Visibility = Visibility.Collapsed;
      }
      if (num != 2)
      {
        Joko1Start.Text = Joko1End.Text = Joko1LimSP.Text = string.Empty;
        Joko1Grid.Visibility = Visibility.Collapsed;
      }
    }

    private void NextStopClear()
    {
      StopStaComingNotice = double.MaxValue; ;
      NextStopTB.Text = NextStopArrHHTB.Text = NextStopArrMMTB.Text = NextStopArrSSTB.Text = NextStopTrackNameTB.Text = NextStopArrDotTB.Text = string.Empty;
    }
  }
}
