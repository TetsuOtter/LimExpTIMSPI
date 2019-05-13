using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Japanese.Kanaxs;
#if WINDOWS_UWP
#elif WPF
using System.Windows;
#endif
namespace TR.LimExpTIMSDisp
{
  static internal class UsefulFunc
  {
    //Wide-Narrow Converter Wrapper

    static internal string ToWide(this string str) => Kana.ToZenkaku(str);

    static internal string ToNarrow(this string str) => Kana.ToHankaku(str);

    //MessageBoxShowing

#if WINDOWS_UWP
    static async internal void MsgBxShow(string msg, string Title="")
    {
      await (new Windows.UI.Popups.MessageDialog(msg, Title)).ShowAsync();
    }
#elif WPF
    static internal MessageBoxResult MsgBxShow(string msg, string Title = "", MessageBoxButton btn = MessageBoxButton.OK, MessageBoxImage mbi = MessageBoxImage.None)
      => MessageBox.Show(msg, Title, btn, mbi);
    
#endif
  }
}
