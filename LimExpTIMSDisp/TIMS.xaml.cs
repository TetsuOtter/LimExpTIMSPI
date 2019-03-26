using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace TR.LimExpTIMSDisp
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class TIMS : Page
  {
    public TIMS()
    {
      this.InitializeComponent();
    }

    private void OnSPClick(object sender, RoutedEventArgs e)
    {
      //SPBtnImg.Source = new BitmapImage(new Uri("/img/timsp/2b.png"));
    }

    private void OnBLClick(object sender, RoutedEventArgs e)
    {

    }

    private void OnL1BClick(object sender, RoutedEventArgs e)
    {

    }
    private void OnL2BClick(object sender, RoutedEventArgs e)
    {

    }
    private void OnL3BClick(object sender, RoutedEventArgs e)
    {

    }
    private void OnL4BClick(object sender, RoutedEventArgs e)
    {

    }

    private void OnAlarmBtnClicked(object sender, RoutedEventArgs e)
    {

    }

    private void OnKikiJohoBtnClicked(object sender, RoutedEventArgs e)
    {

    }

    private void GoStartPage(object sender, RoutedEventArgs e)
    {

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
    private void SPImgChange(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
    }

    private void BLImgChange(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {

    }
  }
}
