using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TR.LimExpTIMSDisp
{
  /// <summary>
  /// MainWindow.xaml の相互作用ロジック
  /// </summary>
  public partial class MainWindow : NavigationWindow
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    //private void Grid_TouchDown(object sender, TouchEventArgs e) => TouchSound0.Play();
    //private void Grid_MouseDown(object sender, MouseButtonEventArgs e) => TouchSound0.Play();

    SMemTalk SMT = null;

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      SMT = new SMemTalk();
      //MainFrame.Navigate(typeof(TIMS));
    }

    private void Page_Unloaded(object sender, RoutedEventArgs e)
    {
      SMT?.Dispose();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      SMT?.Dispose();
    }
  }
}
