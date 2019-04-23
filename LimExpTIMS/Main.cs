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
      KikuSC59A.Load();
      KikuTIMS.Load();
    }

    static internal void Dispose()
    {
      AskATSPsP.Dispose();
      KikuSC59A.Dispose();
      KikuTIMS.Dispose();
    }

    static internal void SetVehicleSpec(Spec s)
    {
      AskATSPsP.SetVehicleSpec(s);
      KikuSC59A.SetVehicleSpec(s);
      KikuTIMS.SetVehicleSpec(s);
    }

    static internal void Initialize(int s)
    {
      AskATSPsP.Initialize(s);
      KikuSC59A.Initialize(s);
      KikuTIMS.Initialize(s);
    }
    //Attention! This Method uses "UNSAFE".
    static unsafe internal void Elapse(State st, int* Pa, int* Sa)
    {
      //If you want to change the Handle state, please access to Ats.Handle
      AskATSPsP.Elapse(st, Pa, Sa);
      KikuSC59A.Elapse(st, Pa, Sa);
      KikuTIMS.Elapse(st, Pa, Sa);


    }

    static internal void SetPower(int p)
    {
      AskATSPsP.SetPower(p);
      KikuSC59A.SetPower(p);
      KikuTIMS.SetPower(p);
    }

    static internal void SetBrake(int b)
    {
      AskATSPsP.SetBrake(b);
      KikuSC59A.SetBrake(b);
      KikuTIMS.SetBrake(b);
    }

    static internal void SetReverser(int r)
    {
      AskATSPsP.SetReverser(r);
      KikuSC59A.SetReverser(r);
      KikuTIMS.SetReverser(r);
    }
    static internal void KeyDown(int k)
    {
      AskATSPsP.KeyDown(k);
      KikuSC59A.KeyDown(k);
      KikuTIMS.KeyDown(k);
    }

    static internal void KeyUp(int k)
    {
      AskATSPsP.KeyUp(k);
      KikuSC59A.KeyUp(k);
      KikuTIMS.KeyUp(k);
    }

    static internal void DoorOpen()
    {
      AskATSPsP.DoorOpen();
      KikuSC59A.DoorOpen();
      KikuTIMS.DoorOpen();
    }
    static internal void DoorClose()
    {
      AskATSPsP.DoorClose();
      KikuSC59A.DoorClose();
      KikuTIMS.DoorClose();
    }
    static internal void HornBlow(int h)
    {
      AskATSPsP.HornBlow(h);
      KikuSC59A.HornBlow(h);
      KikuTIMS.HornBlow(h);
    }
    static internal void SetSignal(int s)
    {
      AskATSPsP.SetSignal(s);
      KikuSC59A.SetSignal(s);
      KikuTIMS.SetSignal(s);
    }
    static internal void SetBeaconData(Beacon b)
    {
      AskATSPsP.SetBeaconData(b);
      KikuSC59A.SetBeaconData(b);
      KikuTIMS.SetBeaconData(b);
    }
  }
}
