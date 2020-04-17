using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
