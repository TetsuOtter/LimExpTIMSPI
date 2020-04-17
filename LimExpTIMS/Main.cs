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

    //Useful Function
    static public void Turn(ref bool b) => b = !b;
    static public void TurnOn(ref byte b) => b |= b;
    static public void TurnOff(ref byte b) => b &= (byte)~b;
    static public void Turn(ref byte b, bool turnOn)
    {
      if (turnOn) TurnOn(ref b);
      else TurnOff(ref b);
    }

    /// <summary>Sound Play Once Method</summary>
    /// <param name="So">Sound Output State Value</param>
    /// <param name="PlayingState">Playing State</param>
    static private void SPO(ref this int So, ref bool PlayingState)
    {
      if (PlayingState) { So = Sound.Once; PlayingState = false; }
      else So = Sound.Continue;
    }

    static private ATSPsP.ATSIF atsIF;
    static private TIMS.TIMS_IF timsIF;
    static private Cab.Cab_IF cabIF;

    static internal void Load()
    {
#if DEBUG
      MessageBox.Show("LimExpTIMSPI Debug Build");//If you don't need, please remove it.
#endif

      atsIF = new ATSPsP.ATSIF();
      timsIF = new TIMS.TIMS_IF();
      cabIF = new Cab.Cab_IF();
    }
    static internal void Dispose() { }
    static internal void SetVehicleSpec(Spec s) { }
    static internal void Initialize(int s) { }

    static internal void Elapse(State st, IntPtr pa, IntPtr sa)
    {
      unsafe
      {
        int* p = (int*)pa;
        int* s = (int*)sa;
        Parallel.For(0, cvs.PSArrayLength, (i) => s[i] = Sound.Continue);
        //各IFのプロパティより値を入れていく。
        //状態からPanel表示へのコンバートのみを行う。
        //状態変化は各IFから行う。


        #region panels
        #endregion

        #region sounds
        #endregion
      }
    }
    static private int PNum = 0;
    static internal void SetPower(int p) { }
    static internal void SetBrake(int b) { }
    static internal void SetReverser(int r) { }
    static internal void KeyDown(int k) { }
    static internal void KeyUp(int k) { }
    static internal void DoorOpen() { }
    static internal void DoorClose() { }
    static internal void HornBlow(int h) { }
    static internal void SetSignal(int s) { }
    static internal void SetBeaconData(Beacon b) { }
  }
}
