using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TR.LimExpTIMSDisp
{
  public class CarsImage
  {
    static public List<CarInfo> ImgList;

    public struct CarInfo
    {
      public bool IsEnabled;

      public string CarNumber;

      public PantographInfo LPan;
      public bool IsLPanRaised;

      public PantographInfo RPan;
      public bool IsRPanRaised;

      public bool IsL_Motored;
      public bool IsR_Motored;

      public bool IsDoubleDeck;
      public bool IsLController;
      public bool IsRController;

      public Colors RGB;

      public bool IsDoorAvailable;


      public enum PantographInfo
      {
        None, Greater, Less, Diamond
      }
    }
  }
}
