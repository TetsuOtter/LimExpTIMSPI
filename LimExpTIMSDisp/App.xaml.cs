using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TR.LimExpTIMSDisp
{
  /// <summary>
  /// 既定の Application クラスを補完するアプリケーション固有の動作を提供します。
  /// </summary>
  sealed partial class App : Application
  {
    /// <summary>
    /// 単一アプリケーション オブジェクトを初期化します。これは、実行される作成したコードの
    ///最初の行であるため、main() または WinMain() と論理的に等価です。
    /// </summary>
    public App()
    {
      this.InitializeComponent();
      this.Suspending += OnSuspending;
    }

    /// <summary>
    /// アプリケーションがエンド ユーザーによって正常に起動されたときに呼び出されます。他のエントリ ポイントは、
    /// アプリケーションが特定のファイルを開くために起動されたときなどに使用されます。
    /// </summary>
    /// <param name="e">起動の要求とプロセスの詳細を表示します。</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
      Settings.MyProcessID = Windows.System.Diagnostics.ProcessDiagnosticInfo.GetForCurrentProcess().ProcessId;

      Frame rootFrame = Window.Current.Content as Frame;

      // ウィンドウに既にコンテンツが表示されている場合は、アプリケーションの初期化を繰り返さずに、
      // ウィンドウがアクティブであることだけを確認してください
      if (rootFrame == null)
      {
        // ナビゲーション コンテキストとして動作するフレームを作成し、最初のページに移動します
        rootFrame = new Frame();

        rootFrame.NavigationFailed += OnNavigationFailed;

        // フレームを現在のウィンドウに配置します
        Window.Current.Content = rootFrame;
      }

      if (e.PrelaunchActivated == false)
      {
        if (rootFrame.Content == null)
        {
          // ナビゲーション スタックが復元されない場合は、最初のページに移動します。
          // このとき、必要な情報をナビゲーション パラメーターとして渡して、新しいページを
          //構成します
          rootFrame.Navigate(typeof(MainPage), e.Arguments);
        }
        // 現在のウィンドウがアクティブであることを確認します
        Window.Current.Activate();
      }
    }

    /// <summary>
    /// 特定のページへの移動が失敗したときに呼び出されます
    /// </summary>
    /// <param name="sender">移動に失敗したフレーム</param>
    /// <param name="e">ナビゲーション エラーの詳細</param>
    void OnNavigationFailed(object sender, NavigationFailedEventArgs e) => throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    

    /// <summary>
    /// アプリケーションの実行が中断されたときに呼び出されます。
    /// アプリケーションが終了されるか、メモリの内容がそのままで再開されるかに
    /// かかわらず、アプリケーションの状態が保存されます。
    /// </summary>
    /// <param name="sender">中断要求の送信元。</param>
    /// <param name="e">中断要求の詳細。</param>
    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
      var deferral = e.SuspendingOperation.GetDeferral();
      //TODO: アプリケーションの状態を保存してバックグラウンドの動作があれば停止します
      deferral.Complete();
    }




    //Reference : https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.activation.commandlineactivatedeventargs
    protected override void OnActivated(IActivatedEventArgs args)
    {
      string activationArgString = string.Empty;
      string activationPath = string.Empty;
      string cmdLineString = string.Empty;
      switch (args.Kind)
      {
        case ActivationKind.Launch:
          var launchArgs = args as LaunchActivatedEventArgs;
          activationArgString = launchArgs.Arguments;
          break;

        // A new ActivationKind for console activation of a windowed app.
        case ActivationKind.CommandLineLaunch:
          CommandLineActivatedEventArgs cmdLineArgs = args as CommandLineActivatedEventArgs;
          CommandLineActivationOperation operation = cmdLineArgs.Operation;
          cmdLineString = operation.Arguments;
          activationPath = operation.CurrentDirectoryPath;
          break;
      }

    }
  }
}
