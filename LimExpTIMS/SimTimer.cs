using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  /// <summary>シミュレータ内の時刻に基づいたタイマーを1つ提供する。</summary>
  public class SimTimer : IDisposable
  {
    /// <summary>設定した時間経過した際に呼び出されます。</summary>
    public event EventHandler TimerEvent;

    public SimTimer(int len = 0, bool isOneTime = false)
    {
      TimerLength = len;
      IsOneTimeTimer = isOneTime;

      Ats.ElapseEv += Ats_ElapseEv;
    }

    private int tRec = -1;
    private void Ats_ElapseEv(object sender, TickEvArgs e)
    {
      int trec = tRec;
      tRec = e.state.T;

      if (!IsEnabled) return;
      if (trec > e.state.T)//時間逆行を検知でOneTimeタイマー無効化
      {
        //Repeatタイマーは開始時刻を更新
        FireTime = IsOneTimeTimer ? null : FireTime = e.state.T + TimerLength;
        return;
      }

      if (FireTime > e.state.T) return;//まだ設定時刻ではない。

      TimerEvent?.Invoke(this, default);

      while (FireTime <= e.state.T)//null or 発火時刻が現在時刻より後になるまで+++++
        FireTime = IsOneTimeTimer ? null : FireTime + TimerLength;
    }

    /// <summary>時刻監視中であるか否か</summary>
    public bool IsEnabled { get => FireTime != null; }

    /// <summary>イベントの発火間隔[ms]</summary>
    public int TimerLength { get; set; } = 0;
    /// <summary>一回限りの実行であるかどうか</summary>
    public bool IsOneTimeTimer { get; set; } = false;

    /// <summary>イベントの発火時間を指定します。</summary>
    public int? FireTime { get; private set; } = null;

    
    /// <summary>タイマーを開始します。</summary>
    /// <param name="startTime">開始時間[ms]</param>
    /// <returns>設定に成功したかどうか</returns>
    public bool TimerStart(int? startTime = null)
    {
      if (IsEnabled) return false;

      FireTime = (startTime ?? tRec) + TimerLength;

      return true;
    }

    public bool TimerStop()
    {
      if (!IsEnabled) return false;
      FireTime = null;
      return true;
    }

    /// <summary>指定した時刻に発火するタイマーを設定します。</summary>
    /// <param name="fireTime">発火させる時刻</param>
    /// <returns>設定に成功したかどうか</returns>
    public bool SetFireTime(int fireTime)
    {
      if (fireTime < Ats.StateD.T) return false;//指定された時刻は、すでにpassしています。
      if (IsEnabled) return false;//別のタイマーが実行中です。

      IsOneTimeTimer = true;
      FireTime = fireTime;
      
      return true;
    }

    #region IDisposable Support
    private bool disposedValue = false; // 重複する呼び出しを検出するには

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          // TODO: マネージ状態を破棄します (マネージ オブジェクト)。
        }

        // TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
        // TODO: 大きなフィールドを null に設定します。

        TimerStop();//タイマー停止

        disposedValue = true;
      }
    }

    // TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
    // ~SimTimer()
    // {
    //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
    //   Dispose(false);
    // }

    // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
    void IDisposable.Dispose()
    {
      // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
      Dispose(true);
      // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
      // GC.SuppressFinalize(this);
    }
    #endregion
  }
}
