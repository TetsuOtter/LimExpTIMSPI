using System;
//using Windows.UI.Xaml.Media;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Media.Imaging;
//using Windows.UI.Xaml.Media;
//using Windows.UI;
#if WINDOWS_UWP
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
#elif WPF
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
#endif
using System.Threading.Tasks;


// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace TR.LimExpTIMSDisp
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class TIMS : Page
  {
    Visibility Hide = Visibility.Collapsed;
    public TIMS()
    {
      this.InitializeComponent();
      //FontFamily = "Fonts/JF-Dot-jiskan16s.ttf#JF Dot jiskan16s"
#if WINDOWS_UWP
      //FontFamily = new FontFamily("/Fonts/JF-Dot-jiskan16s.ttf#JF Dot jiskan16s");
#elif WPF
      //FontFamily = new FontFamily("/Fonts/JF-Dot-jiskan16s.ttf#JF Dot jiskan16s");
#endif
      TsukokuStr.Visibility = Hide;
      JohoStr.Visibility = Hide;
      MonitoringStr.Visibility = Hide;
      TsukokuBtn.Visibility = Hide;
      AlarmBtn.Visibility = Hide;
      CmdInfoBtn.Visibility = Hide;
      KikiJohoBtn.Visibility = Hide;
      KiseiListBtn.Visibility = Hide;
      KosyoBtn.Visibility = Hide;
      LowerSecondBtn.IsEnabled = false;
      LowerThirdBtn.IsEnabled = false;
      SPBtn.IsEnabled = false;
      TrainInfoBtn.Visibility = Hide;
      TsukokuBtn.Visibility = Hide;
      OverRec.Visibility = Visibility.Visible;
      PInfoChangeEvent += TIMS_PInfoChangeEvent;

#if WPF
      AngryF.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
      CenterF.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
#endif
    }

    static public DispatcherTimer DT = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 200) };

    private void TIMS_PInfoChangeEvent(object sender, EventArgs e)
    {
      PageNumberStr.Text = PageNum;
      PageNameStr.Text = PageName;
    }

    TimeTable TTCla = new TimeTable();

    public static void PageInfoSet(string PNum, string PName)
    {
      (PageNum, PageName) = (PNum, PName);
      PInfoChangeEvent.Invoke(null, null);
    }
    private static event EventHandler PInfoChangeEvent;
    static private string PageNum = string.Empty;
    static private string PageName = string.Empty;

    private void OnSPClick(object sender, RoutedEventArgs e)
    {
      if (Settings.Volume == 0) Settings.BackLight = 3;
      Settings.Volume--;
      string NumStr = Settings.BackLight.ToString("D1");
      BLBtnImg.Source = new BitmapImage(
#if WINDOWS_UWP
      new Uri("ms-appx:///img/timsp/" + NumStr + ".png"));
#elif WPF
      new Uri("img/timsp/" + NumStr + ".png", UriKind.Relative));
#endif
    }


    private void OnBLClick(object sender, RoutedEventArgs e)
    {
      if (Settings.BackLight == 0) Settings.BackLight = 5;
      Settings.BackLight--;
      string NumStr = Settings.BackLight.ToString("D1");
      BLBtnImg.Source = new BitmapImage(
#if WINDOWS_UWP
      new Uri("ms-appx:///img/timbl/" + NumStr + ".png"));
#elif WPF
      new Uri("img/timbl/" + NumStr + ".png", UriKind.Relative));
#endif
      OverRec.Opacity = (4.0 - Settings.BackLight) / 5;
    }

    private void OnL1BClick(object sender, RoutedEventArgs e)
    {
      TTCla.SelectFile();
    }
    private void OnL2BClick(object sender, RoutedEventArgs e)
    {

    }
    private void OnL3BClick(object sender, RoutedEventArgs e)
    {
#if WINDOWS_UWP
      try
      {
        if (ApplicationView.GetForCurrentView().IsFullScreenMode) ApplicationView.GetForCurrentView().ExitFullScreenMode();
        else ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
      }
      catch (Exception ex)
      {
        UsefulFunc.MsgBxShow( ex.Message, "Displaying-Mode-Changing Failed");
      }
#elif WPF
      WindowState WinState = Application.Current.MainWindow.WindowState;
      WindowStyle WinStyle = Application.Current.MainWindow.WindowStyle;
      if(WinState== WindowState.Maximized)
      {
        if (WinStyle == WindowStyle.None)
        {
          WinStyle = WindowStyle.SingleBorderWindow;
          WinState = WindowState.Normal;
        }
        else WinStyle = WindowStyle.None;
      }
      else
      {
        WinStyle = WindowStyle.None;
        WinState = WindowState.Maximized;
      }
#endif
    }
    private void OnL4BClick(object sender, RoutedEventArgs e) => UsefulFunc.MsgBxShow(Settings.LicenseString, "License");
    

    private void OnAlarmBtnClicked(object sender, RoutedEventArgs e)
    {
      }

    private void OnKikiJohoBtnClicked(object sender, RoutedEventArgs e)
    {

    }

    private async void GoStartPage(object sender, RoutedEventArgs e)
    {
      await Task.Delay(100);//Wait until the Touch Sound Playing Completed
#if WINDOWS_UWP
      Application.Current.Exit();
#elif WPF
      Application.Current.MainWindow.Close();
#endif
    }

    private void OnKosyoBtnClicked(object sender, RoutedEventArgs e)
    {

    }

    private void OnTsukokuBtnClicked(object sender, RoutedEventArgs e)
    {

    }

    private void OnKiseiListBtnClicked(object sender, RoutedEventArgs e)
    {

    }

    private void OnCmdInfoBtnClicked(object sender, RoutedEventArgs e)
    {

    }

    private void OnTrainInfoBtnClicked(object sender, RoutedEventArgs e)
    {

    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
#if WINDOWS_UWP
      CenterF.Navigate(typeof(Driver.D01AA));
#elif WPF
      CenterF.Navigate(new Uri("Driver/D01AA.xaml", UriKind.Relative));
#endif

      DT.Tick += DT_Tick;
      if (!DT.IsEnabled) DT?.Start();
      BIDSSMemLib.SMemLib.BIDSSMemChanged += SMemLib_BIDSSMemChanged;
      BIDSSMemLib.SMemLib.OpenDChanged += SMemLib_OpenDChanged;
      TimeTable.ManyTTDataInput += TimeTable_ManyTTDataInput;
      Driver.D10AA.TimeTableDecidedEvent += D10AA_TimeTableDecidedEvent;
    }

    private void SMemLib_OpenDChanged(object sender, BIDSSMemLib.SMemLib.OpenDChangedEArgs e) => opend = e.NewData;

    private void D10AA_TimeTableDecidedEvent(object sender, EventArgs e)
    {
#if WINDOWS_UWP
      CenterF.Navigate(typeof(Driver.D01AA));
#elif WPF
      CenterF.Navigate(new Uri("Driver/D01AA.xaml", UriKind.Relative));
#endif
    }

    private void TimeTable_ManyTTDataInput(object sender, EventArgs e)
    {
#if WINDOWS_UWP
      CenterF.Navigate(typeof(Driver.D10AA));
#elif WPF
      CenterF.Navigate(new Uri("Driver/D10AA.xaml", UriKind.Relative));
#endif
    }
    BIDSSMemLib.State state = new BIDSSMemLib.State();
    BIDSSMemLib.OpenD opend = new BIDSSMemLib.OpenD();
    bool IsDoorClosed = false;
    private void SMemLib_BIDSSMemChanged(object sender, BIDSSMemLib.SMemLib.BSMDChangedEArgs e)//BIDSSMemが変化したときに呼ばれる。
    {
      IsDoorClosed = e.NewData.IsDoorClosed;
      state = e.NewData.StateData;
      if (IsStaComingNoticeON && !IsDoorClosed)
      {
        IsStaComingNoticeON = false;
        Driver.D01AA.DispingFirstRowStaIndex++;
        Driver.D01AA.StaListRefreshDT.Start();
      }
        TimeHH = ((e.NewData.StateData.T / 1000 / 60 / 60) % 24).ToString().ToWide();
      TimeMM = ((e.NewData.StateData.T / 1000 / 60) % 60).ToString("D2").ToWide();
      TimeSS = ((e.NewData.StateData.T / 1000) % 60).ToString("D2").ToWide();
      SpeedStr = ((int)e.NewData.StateData.V).ToString("D").ToWide();
      if (e.NewData.IsEnabled)
      {
        DistanceInt = ((int)e.NewData.StateData.Z / 1000).ToString("D").ToWide();
        DistanceDec = ((e.NewData.StateData.Z / 100) % 10).ToString().ToWide();
        double dt = e.NewData.StateData.T - e.OldData.StateData.T;
        if (dt != 0)
        {
          dt /= 1000 * 60 * 60;
          double GPSSpd = ((e.NewData.StateData.Z - e.OldData.StateData.Z) / 1000) / dt;
          IsSlipping = GPSSpd > e.NewData.StateData.V + Settings.SpdDifferenceThreshold;
          IsIdling = GPSSpd < e.NewData.StateData.V - Settings.SpdDifferenceThreshold;
        }
      }
      else
      {
        DistanceDec = DistanceInt = string.Empty;
        IsSlipping = IsIdling = IsAirSec = IsACDCSec = IsACACSec = false;
      }
      Location = e.NewData.StateData.Z;
      NowSpeed = e.NewData.StateData.V;
    }

    string DistanceInt = string.Empty;
    string DistanceDec = string.Empty;
    string TimeHH = "０";
    string TimeMM = "００";
    string TimeSS = "００";
    string SpeedStr = "０";
    static double Location = 0;
    static double NowSpeed = 0;
    static internal bool IsStaComingNoticeON = false;
    static internal bool IsAirSec = false;
    static internal bool IsACDCSec = false;
    static internal bool IsACACSec = false;
    static internal bool IsSlipping = false;//滑走
    static internal bool IsIdling = false;//空転
    static internal bool IsBlueBtnFEnabled = false;
    SolidColorBrush YBF1 = new SolidColorBrush(Colors.Yellow);
    SolidColorBrush YBF2 = new SolidColorBrush(Colors.Black);
    SolidColorBrush AqBF1 = new SolidColorBrush(Colors.Aqua);
    SolidColorBrush AqBF2 = new SolidColorBrush(Colors.Black);
    SolidColorBrush StopSta1 = new SolidColorBrush(Colors.Yellow);
    SolidColorBrush StopSta2 = new SolidColorBrush(Colors.Transparent);
    SolidColorBrush BlueBtnF1scb = new SolidColorBrush(Colors.Blue);
    SolidColorBrush BlueBtnF2scb = new SolidColorBrush(Colors.White);
    byte DTCount = 0;
    const Visibility vble = Visibility.Visible;
    const Visibility csed = Visibility.Collapsed;
    private void DT_Tick(object sender, object e)
    {
      if (DTCount++ % 2 == 0)//2回に1回のみ実行
      {
        //イベント距離照合 フラグ処理
        IsAirSec = IsACDCSec = IsACACSec = false;
        if (TimeTable.DecidedTTData != null)
        {
          foreach (TimeTable.SectionData sd in TimeTable.DecidedTTData?.ACACSecList)
          {
            if (!IsACACSec) IsACACSec = sd?.NoticeStartPoint <= Location && Location <= sd?.EndPoint;
          }
          foreach (TimeTable.SectionData sd in TimeTable.DecidedTTData?.ACDCSecList)
          {
            if (!IsACDCSec) IsACDCSec = sd?.NoticeStartPoint <= Location && Location <= sd?.EndPoint;
          }
          if (NowSpeed <= 25)
          {
            foreach (TimeTable.SectionData sd in TimeTable.DecidedTTData?.AirSecList)
            {
              if (!IsAirSec) IsAirSec = sd?.NoticeStartPoint <= Location && Location <= sd?.EndPoint;
            }
          }
        }

        //時刻表更新と徐行はD01AAで処理

        (YBF1, YBF2) = (YBF2, YBF1);//交換
        (AqBF1, AqBF2) = (AqBF2, AqBF1);//交換
        if(IsStaComingNoticeON) (StopSta1, StopSta2) = (StopSta2, StopSta1);//交換
        else
        {
          StopSta1 = new SolidColorBrush(Colors.Yellow);
          StopSta2 = new SolidColorBrush(Colors.Transparent);
        }
        if (IsBlueBtnFEnabled) (BlueBtnF1scb, BlueBtnF2scb) = (BlueBtnF2scb, BlueBtnF1scb);
        else
        {
          BlueBtnF1scb = new SolidColorBrush(Colors.Blue);
          BlueBtnF2scb = new SolidColorBrush(Colors.White);
        }
        if (DistanceInt == null || DistanceDec == null || DistanceInt == string.Empty || DistanceDec == string.Empty) 
        {
          LocationInteger.Text = "-";
          LocationDecimal.Text = string.Empty;
        }
        else
        {
          LocationInteger.Text = DistanceInt+"．";
          LocationDecimal.Text = DistanceDec;
        }
        Speed.Text = SpeedStr;

        KutenRec.Visibility = IsIdling ? vble : csed;
        KassoRec.Visibility = IsSlipping ? vble : csed;
        ACACSecRec.Visibility = IsACACSec ? vble : csed;
        ACDCSecRec.Visibility = IsACDCSec ? vble : csed;
        AirSecRec.Visibility = IsAirSec ? vble : csed;
      }

      DataContext = new
      {
        YBFlush1 = YBF1,
        YBFlush2 = YBF2,
        AqBFlush1 = AqBF1,
        AqBFlush2 = AqBF2,
        StopSta = StopSta1,
        BlueBtnFBG = BlueBtnF1scb,
        BCPresTBText = state.BC.ToString("000.000"),
        MRPresTBText = state.MR.ToString("000.000"),
        BPPresTBText = state.BP.ToString("000.000"),
        ERPresTBText = state.ER.ToString("000.000"),
        SAPPresTBText = state.SAP.ToString("000.000"),
        CurrentTBText = state.I.ToString("0000.00"),
        DoorStateTBText = IsDoorClosed ? "〇" : "×",
        RadiusTBText = opend.Radius.ToString("00000.0"),
        CantTBText = opend.Cant.ToString("000.000"),
        PitchTBText = opend.Pitch.ToString("000.000")
      };
      Hour.Text = TimeHH;
      Minute.Text = TimeMM;
      Second.Text = TimeSS;
      NoticeTextR.Visibility = TimeTable.DecidedTTData == null ? vble : csed;//NULLなら表示。違えば非表示
    }


  }
}
