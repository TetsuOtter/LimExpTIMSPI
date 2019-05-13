using System;
using System.IO;
using System.Reflection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using System.Threading;
// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace TR.LimExpTIMSDisp
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
      MainFrame.Navigate(typeof(TIMS));
      
    }

    private void OnTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e) => TouchSound0.Play();

    SMemTalk SMT = null;

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      SMT = new SMemTalk();
    }

    private void Page_Unloaded(object sender, RoutedEventArgs e)
    {
      SMT?.Dispose();
    }

    //SMemLibを使う.


  }
}
