using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
#if WINDOWS_UWP
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
#elif WPF
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows;
#endif
// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace TR.LimExpTIMSDisp.Driver
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class D10AA : Page
  {
    public D10AA()
    {
      InitializeComponent();
    }

    public static event EventHandler TimeTableDecidedEvent;
    DispatcherTimer DT = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, Settings.RefreshRate) };
    int PageNum = 0;
    int MaxPage = 0;
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      TIMS.PageInfoSet("D10AA", "行路選択");
      if (TimeTable.InsertedICInfo != null)
      {
        try
        {
          TimeTable.ICSettingInfo ISI = TimeTable.InsertedICInfo;
        OfficeNameTB.Text = ISI.OfficeName ?? string.Empty;
        WorkNumTB.Text = ISI.WorkNumber ?? string.Empty;
          EffectedDateTB.Text = "[" + ISI.EffectedDateYY + ". " + ISI.EffectedDateMM + ". " + ISI.EffectedDateDD + "]";
        }
        catch (NullReferenceException) { }
        catch(Exception ex)
        {
          UsefulFunc.MsgBxShow("IC設定に失敗しました。\n" + ex.Message, "LimExpTIMSDisp D10AA");
        }
        PageNum = 0;
        MaxPage = (int)Math.Floor(TimeTable.TTList.Count / 5.0);
        DT.Tick += DT_Tick;
        DT.Start();
      }
    }
    int Counter = 0;
    int CheckedNum = -1;
    private void DT_Tick(object sender, EventArgs e)
    {
      if (Counter == 0)
      {
        TTListGrid.Children.Clear();
        TIMS.IsBlueBtnFEnabled = false;
        SetBtn.Content = "戻　る";
        CheckedNum = -1;
        GoBackBtn.Visibility = PageNum <= 0 ? Visibility.Collapsed : Visibility.Visible;
        GoNextBtn.Visibility = PageNum >= MaxPage ? Visibility.Collapsed : Visibility.Visible;
      }
      else
      {
        UIElement uie = TrainGridGet(PageNum * 5 + Counter - 1);
        if (uie != null) TTListGrid.Children.Add(uie);
      }
      if (Counter >= 5)
      {
        Counter = 0;
        DT.Stop();
        return;
      }
      Counter++;
    }

    const int FontSizeINT = 16;
    private Grid TrainGridGet(int num)
    {
      if (num < TimeTable.TTList.Count)
      {
        if (TimeTable.TTList[num] == null) return null;
        TimeTable.TimeTableData TT = TimeTable.TTList[num];
        Grid ReturnGrid = new Grid()
        {
          Margin = new Thickness(0, 60 * (num % 5), 0, 0),
          Height = 60,
          Width = 800,
          HorizontalAlignment = HorizontalAlignment.Left,
          VerticalAlignment = VerticalAlignment.Top
        };
        ReturnGrid.Children.Add(new Rectangle()
        {
          Height = 2,
          Width = 300,
          Margin = new Thickness(250, 50, 0, 0),
          HorizontalAlignment = HorizontalAlignment.Left,
          VerticalAlignment = VerticalAlignment.Top,
          Fill = new SolidColorBrush(Colors.White)
        });
        ReturnGrid.Children.Add(//1stStaName
          new Border(){
          Margin = new Thickness(80, 0, 0, 0),
          Height = 36,
          Width = 180,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Child = new TextBlock()
          {
            Text = TT.TTList[0].StaName,
            Foreground = new SolidColorBrush(Colors.White),
            FontSize = FontSizeINT * 2,
            FontFamily = FontFamily,
            VerticalAlignment = VerticalAlignment.Bottom,
            HorizontalAlignment = HorizontalAlignment.Left
          }
        });
        ReturnGrid.Children.Add(//DepHHMM
          new Border()
        {
          Margin = new Thickness(135, 40, 0, 0),
          Height = 18,
          Width = 90,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Child = new TextBlock()
          {
            Text = TT.TTList[0].DepHH + "：" + TT.TTList[0].DepMM,
            Foreground = new SolidColorBrush(Colors.White),
            FontSize = FontSizeINT,
            FontFamily = FontFamily,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Bottom
          }
        });
        ReturnGrid.Children.Add(//DepSS
          new Border()
          {
            Margin = new Thickness(225, 46, 0, 0),
            Height = 10,
            Width = 20,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Child = new TextBlock()
            {
              Text = (TT.TTList[0].DepSS == string.Empty ? "0" : TT.TTList[0].DepSS).ToWide(),
              Foreground = new SolidColorBrush(Colors.White),
              FontSize = 10,
              FontFamily = FontFamily,
              VerticalAlignment = VerticalAlignment.Bottom,
              HorizontalAlignment = HorizontalAlignment.Left
            }
          });
        ReturnGrid.Children.Add(//LastStaName
          new Border()
          {
            Margin = new Thickness(555, 0, 0, 0),
            Height = 36,
            Width = 180,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Child = new TextBlock()
            {
              Text = TT.TTList.Last().StaName,
              Foreground = new SolidColorBrush(Colors.White),
              FontSize = FontSizeINT * 2,
              FontFamily = FontFamily,
              VerticalAlignment = VerticalAlignment.Bottom,
              HorizontalAlignment = HorizontalAlignment.Left
            }
          });
        ReturnGrid.Children.Add(//ArrHHMM
          new Border()
          {
            Margin = new Thickness(600, 40, 0, 0),
            Height = 18,
            Width = 90,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Child = new TextBlock()
            {
              Text = TT.TTList.Last().DepHH + "：" + TT.TTList.Last().DepMM,
              Foreground = new SolidColorBrush(Colors.White),
              FontSize = FontSizeINT,
              FontFamily = FontFamily,
              HorizontalAlignment = HorizontalAlignment.Right,
              VerticalAlignment = VerticalAlignment.Bottom
            }
          });
        ReturnGrid.Children.Add(//ArrSS
          new Border()
          {
            Margin = new Thickness(690, 46, 0, 0),
            Height = 10,
            Width = 20,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Child = new TextBlock()
            {
              Text = (TT.TTList.Last().DepSS == string.Empty ? "0" : TT.TTList.Last().DepSS).ToWide(),
              Foreground = new SolidColorBrush(Colors.White),
              FontSize = 10,
              FontFamily = FontFamily,
              VerticalAlignment = VerticalAlignment.Bottom,
              HorizontalAlignment = HorizontalAlignment.Left
            }
          });
        RadioButton RD = new RadioButton()
        {
          Name = "RB" + num.ToString(),
          Height = 45,
          Width = 162,
          FontSize = FontSizeINT,
          Margin = new Thickness(320, 0, 0, 0),
          HorizontalAlignment = HorizontalAlignment.Left,
          VerticalAlignment = VerticalAlignment.Top,
          Content = TT.TrainNum.ToWide(),
          Style = RBtnRes.Style,
          GroupName = "TTList"
        };
        RD.Click += RD_Click;
        ReturnGrid.Children.Add(RD);
        return ReturnGrid;
      }
      return null;
    }

    private void RD_Click(object sender, RoutedEventArgs e)
    {
      TIMS.IsBlueBtnFEnabled = true;
      SetBtn.Content = "設　定";
      CheckedNum = int.Parse(((RadioButton)sender).Name.Remove(0, 2));
    }

    private async void DecidedEvent(object sender, RoutedEventArgs e)
    {
      TIMS.IsBlueBtnFEnabled = false;
      TimeTableDecidedEvent?.Invoke(null, null);
      await System.Threading.Tasks.Task.Delay(100);
      TimeTable.TimeTablesPicked(CheckedNum);
    }

    private void GoNextEv(object sender, RoutedEventArgs e)
    {
      if (PageNum < MaxPage)
      {
        PageNum++;
        DT?.Start();
      }
      else GoNextBtn.Visibility = Visibility.Collapsed;
    }

    private void GoBackEv(object sender, RoutedEventArgs e)
    {
      if (0 < PageNum)
      {
        PageNum--;
        DT?.Start();
      }
      else GoNextBtn.Visibility = Visibility.Collapsed;
    }
  }
}
