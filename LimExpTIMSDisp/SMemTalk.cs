using System;
using TR.BIDSSMemLib;

namespace TR.LimExpTIMSDisp
{
  /// <summary>
  /// Shared Memory Read/Write Wrapper Class
  /// </summary>
  internal class SMemTalk : IDisposable
  {
    internal SMemLib SML = null;

    public SMemTalk()
    {
      SML = new SMemLib(3);
      SML.ReadStart(5,100);
      SML.ReadStart(1,100);
    }


    public void Dispose()
    {
      SML?.ReadStop(-1);
      SML?.Dispose();
    }
  }
}
