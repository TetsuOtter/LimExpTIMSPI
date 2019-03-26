using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMSDisp
{
  /// <summary>
  /// Shared Memory Read/Write Class
  /// </summary>
  internal class SMemTalk
  {
    internal SMemTalk(uint PID)
    {
      //Write Version
    }
    internal class StationInfoChangedEventArgs : EventArgs
    {

    }
    /// <summary>
    /// Class of Station Info(ID, Location etc.)
    /// </summary>
    internal class StationInfo
    {

      internal uint StationID = 0;

    }
  }
}
