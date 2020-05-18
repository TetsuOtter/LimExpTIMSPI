using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.LimExpTIMS.TIMS;

namespace TR.LimExpTIMS
{
  static class UFunc
  {
    static public int[] GetIntArr(IntPtr ptr, int len)
    {
      throw new NotImplementedException();
      //return null;
    }
    static public IntPtr GetArrPtr(int[] arr)
    {
      throw new NotImplementedException();
      //return IntPtr.Zero;
    }

    /// <summary>真偽を反転させます</summary>
    /// <param name="b">反転させる変数</param>
    static public void Turn(ref this bool b) => b = !b;
    static public void TurnOn(ref this byte b, int bit = 0) => b |= (byte)(0b1 << bit);
    static public void TurnOff(ref this byte b, int bit = 0) => b &= (byte)~(0b1 << bit);
    static public void Turn(ref this byte b, bool turnOn)
    {
      if (turnOn) TurnOn(ref b);
      else TurnOff(ref b);
    }

    static public int ToInt(in this bool val) => val ? cvs.TRUE_VALUE : cvs.FALSE_VALUE;

    /// <summary>ラムダ式を用いて楽にイベントに登録/削除できる関数</summary>
    /// <param name="eh">購読するイベント</param>
    /// <param name="f">イベントで実行する関数(trueが返るまで実行され, trueが返ると購読解除が行われます.)</param>
    static public void EvInL(this EventHandler eh, Func<EventArgs, bool> f)
    {
      //参考 : https://stackoverrun.com/ja/q/4551546
      if (f == null) throw new ArgumentNullException();//実行する関数がnullならそもそも登録しない.

      EventHandler exFunc = null;//イベントに登録するHandler
      exFunc = (s, e) =>
      {
        if (f.Invoke(e)) eh -= exFunc;//trueが返ったら購読解除
      };
      eh += exFunc;//購読開始
    }
    /// <summary>ラムダ式を用いて楽にイベントに登録/削除できる関数</summary>
    /// <typeparam name="T">使用するイベントのEventArgs class</typeparam>
    /// <param name="eh">購読するイベント</param>
    /// <param name="f">イベントで実行する関数(trueが返るまで実行され, trueが返ると購読解除が行われます.)</param>
    static public void EvInL<T>(this EventHandler<T> eh, Func<T, bool> f) where T : EventArgs
    {
      //参考 : https://stackoverrun.com/ja/q/4551546
      if (f == null) throw new ArgumentNullException();//実行する関数がnullならそもそも登録しない.

      EventHandler<T> exFunc = null;//イベントに登録するHandler
      exFunc = (s, e) =>
      {
        if (f.Invoke(e)) eh -= exFunc;//trueが返ったら購読解除
      };
      eh += exFunc;//購読開始
    }

    /// <summary>StaInfoListから指定位置のStaInfoを取得します.</summary>
    /// <param name="ls">取得元のStaInfoList</param>
    /// <param name="pos">位置指定</param>
    /// <returns>目的のStaInfo</returns>
    static public StaInfo GetStaInfo(this List<StaInfo> ls, int pos)
    {
      if (ls == null) ls = new List<StaInfo>();
      if (ls.ElementAt(pos) == null) ls.Insert(pos, new StaInfo());

      return ls[pos];
    }
  }

  public class DoDLLAct
  {
    public bool IsLoaded { get; private set; }
    public void DoDLLAction(Action act)
    {
      if (!IsLoaded) return;
      try
      {
        act.Invoke();
      }
      catch (DllNotFoundException)
      {
        IsLoaded = false;
        return;
      }
      catch (Exception)
      {
        IsLoaded = false;
        throw;
      }
    }
    public void DoDLLAction<T>(Action<T> act, T arg)
    {
      if (!IsLoaded) return;
      try
      {
        act.Invoke(arg);
      }
      catch (DllNotFoundException)
      {
        IsLoaded = false;
        return;
      }
      catch (Exception)
      {
        IsLoaded = false;
        throw;
      }
    }
    public Hand DoDLLElapse(Func<State, IntPtr, IntPtr, Hand> fnc, State state, IntPtr panel, IntPtr sound)
    {
      if (!IsLoaded) return default;
      try
      {
        return fnc.Invoke(state, panel, sound);
      }
      catch (DllNotFoundException)
      {
        IsLoaded = false;
        return default;
      }
      catch (Exception)
      {
        IsLoaded = false;
        throw;
      }
    }
  }
}
