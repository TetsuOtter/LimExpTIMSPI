using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TR.LimExpTIMS
{
  /// <summary>ログを出力する.</summary>
  public static class LogManager
  {
    public enum LogLevel
    {
      /// <summary>Release BuildでもExceptionをthrowする場合</summary>
      Error,
      /// <summary>Debug BuildでのみExceptionをthrowする場合</summary>
      Warning,
      /// <summary>状態の変更を出力</summary>
      Information,
      /// <summary>トレースできるレベルで出力</summary>
      Debug
    }
    static public bool IsEnabled { get; private set; }
    static public LogLevel MaxPrintLevel { get; private set; }
    static public bool IsDebugBuild
    {
#if DEBUG
      get => true;
#else
      get => false;
#endif
    }
    static public string LogFileName { get; private set; }
    static private StreamWriter strW = null;
    public static void Init()
    {

      LogFileName = string.Format("LETPI.{0}.log", DateTime.UtcNow.ToString("yyyyMMddhhmmss"));

      //Path get (ref:https://tekk.hatenadiary.org/entry/20110307/1299513821)
      string fpath = System.Reflection.Assembly.GetExecutingAssembly().Location + LogFileName;
      try { 
        strW = new StreamWriter(fpath, false, Encoding.UTF8);//ファイル名一致は上書き
      }
      catch(Exception e)
      {
        MessageBox.Show("StreamWriter init failed.\n" + e.Message + "\nfpath:" + fpath, "LimExpTIMSPI LogPrinter.init()", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Dispose(true);
        throw;
      }

#if DEBUG
      switch (MessageBox.Show("LimExpTIMS Plugin Debug Build\n"+"log file name:"+LogFileName+"\nDo you want to include Debug Msg in the log file?","LimExpTIMSPI LogPrinter", MessageBoxButtons.YesNoCancel))
      {
        case DialogResult.Yes:
          MaxPrintLevel = LogLevel.Debug;
          break;
        case DialogResult.No:
          MaxPrintLevel = LogLevel.Information;
          break;
        case DialogResult.Cancel:
          MaxPrintLevel = LogLevel.Error;
          break;
        default://As "Yes"
          MaxPrintLevel = LogLevel.Debug;
          break;
      }
#else
      //設定ファイルから設定を読み込んでレベルを設定。
#endif
      //
    }

    public static void Dispose(bool DoOnlyDispose = false)
    {
      try
      {
        if (!DoOnlyDispose) strW?.Flush();
        strW?.Dispose();
        strW = null;
      }
      catch (Exception e)
      {
        MessageBox.Show("StreamWriter dispose failed.\n" + e.Message, "LimExpTIMSPI LogPrinter.Dispose()", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// ログをファイルに出力します。
    /// </summary>
    /// <param name="className"></param>
    /// <param name="level"></param>
    /// <param name="category"></param>
    /// <param name="logMsg"></param>
    public static void WriteLine(string className, LogLevel level, LogCategory category, string logMsg)
      => WriteLine(className, level, category.ToString(), logMsg);
    /// <summary>
    /// ログをファイルに出力します。
    /// </summary>
    /// <param name="className"></param>
    /// <param name="level"></param>
    /// <param name="category"></param>
    /// <param name="logMsg"></param>
    public static void WriteLine(string className, LogLevel level, string category ,string logMsg)
    {
      if (!IsEnabled) return;
      if (MaxPrintLevel < level) return;

      //timestamp, className, category, logmsg
    }


    public enum LogCategory
    {
      /// <summary>重大なエラー</summary>
      Serious_Error,
      /// <summary>軽微なエラー</summary>
      Minor_Error,
      /// <summary>操作記録(他に影響するような操作を行った場合)</summary>
      Control_Log,
      /// <summary>実行記録(処理順を追える程度のログ出力用)</summary>
      Step_Log,
      /// <summary>実行記録(実行結果のログ出力用)</summary>
      Execute_Information
    }
  }
}
