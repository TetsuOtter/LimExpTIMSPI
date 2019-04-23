using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TR.LimExpTIMS
{
  /// <summary>メインの機能をここに実装する。</summary>
  static internal class Main
  {

    static internal void Load()
    {
#if DEBUG
      MessageBox.Show("LimExpTIMSPI Debug Build");//If you don't need, please remove it.
#endif

      AskATSPsP.Load();
    }

    static internal void Dispose()
    {
      AskATSPsP.Dispose();
    }

    static internal void GetVehicleSpec(Spec s)
    {

    }

    static internal void Initialize(int s)
    {

    }
    //Attention! This Method uses "UNSAFE".
    static unsafe internal void Elapse(State st, int* Pa, int* Sa)
    {
      //If you want to change the Handle state, please access to Ats.Handle



    }

    static internal void SetPower(int p)
    {

    }

    static internal void SetBrake(int b)
    {

    }

    static internal void SetReverser(int r)
    {

    }
    static internal void KeyDown(int k)
    {

    }

    static internal void KeyUp(int k)
    {

    }

    static internal void DoorOpen()
    {

    }
    static internal void DoorClose()
    {

    }
    static internal void HornBlow(int h)
    {

    }
    static internal void SetSignal(int s)
    {

    }
    static internal void SetBeaconData(Beacon b)
    {

    }
  }
}
