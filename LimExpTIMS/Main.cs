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

        //各IFのプロパティより値を入れていく。
        //状態からPanel表示へのコンバートのみを行う。
        //状態変化は各IFから行う。


        #region panels
        #endregion
      }
      #region sounds
      SoundAssign.ATS_S_Chime.GetOutput(sa);
      SoundAssign.ATS_S_Bell.GetOutput(sa);

      SoundAssign.EBSystem_Buzzer.GetOutput(sa);
      SoundAssign.ATS_P_Bell.GetOutput(sa);

      SoundAssign.ATS_P_EBMsg.GetOutput(sa);
      SoundAssign.ATS_P_ReleaseMsg.GetOutput(sa);

      SoundAssign.ATS_Ps_Pattern_BrakeOut.GetOutput(sa);
      SoundAssign.ATS_Ps_Pattern_Coming.GetOutput(sa);
      SoundAssign.ATS_Ps_Pattern_Deleted.GetOutput(sa);
      SoundAssign.ATS_Ps_Brake_Trip.GetOutput(sa);

      SoundAssign.Accidental_Passage_Preventer_Stop_Once.GetOutput(sa);
      SoundAssign.Accidental_Passage_Preventer_Pass_Once.GetOutput(sa);
      SoundAssign.Accidental_Passage_Preventer_Stop_Loop.GetOutput(sa);

      SoundAssign.BougoR_Sound.GetOutput(sa);
      SoundAssign.ElecHorn.GetOutput(sa);
      SoundAssign.AirHorn_Intro.GetOutput(sa);
      SoundAssign.AirHorn_Loop.GetOutput(sa);
      SoundAssign.AirHorn_AfterGlow.GetOutput(sa);
      SoundAssign.MusicHorn.GetOutput(sa);

      SoundAssign.TiltStart_L.GetOutput(sa);
      SoundAssign.TiltStart_R.GetOutput(sa);
      SoundAssign.TiltEnd_L.GetOutput(sa);
      SoundAssign.TiltEnd_R.GetOutput(sa);

      SoundAssign.MCCtrlSound_ToEnd.GetOutput(sa);
      SoundAssign.MCCtrlSound_Inner.GetOutput(sa);
      SoundAssign.RevCtrlSound_ToN.GetOutput(sa);
      SoundAssign.RevCtrlSound_ToFR.GetOutput(sa);
      SoundAssign.MCCtrl_Failed.GetOutput(sa);
      SoundAssign.RevCtrl_Failed.GetOutput(sa);
      SoundAssign.MCKey_Ctrl_Failed.GetOutput(sa);

      SoundAssign.MCKey_Remove.GetOutput(sa);
      SoundAssign.MCKey_ToON.GetOutput(sa);
      SoundAssign.MCKey_ToOFF.GetOutput(sa);
      SoundAssign.MCKey_Insert.GetOutput(sa);
      SoundAssign.CabSeS_ToN.GetOutput(sa);
      SoundAssign.CabSeS_ToFR.GetOutput(sa);
      SoundAssign.ReduceSPD_Coming.GetOutput(sa);
      SoundAssign.ReduceSPD_Running.GetOutput(sa);
      SoundAssign.ReduceSPD_End.GetOutput(sa);

      SoundAssign.Brake_Boost_Joyo.GetOutput(sa);
      SoundAssign.Brake_Boost_Emerg.GetOutput(sa);
      SoundAssign.AirSec_Warning.GetOutput(sa);
      SoundAssign.EB_Warning_Msg.GetOutput(sa);
      SoundAssign.OP_Info_Updated_Passenger.GetOutput(sa);
      SoundAssign.Stop_Warning_Deck_Msg.GetOutput(sa);
      SoundAssign.Passenger_Emg_Buzzer.GetOutput(sa);
      SoundAssign.IC_Insert.GetOutput(sa);
      SoundAssign.IC_Remove.GetOutput(sa);
      SoundAssign.TIMS_Touch.GetOutput(sa);
      SoundAssign.TIMS_Error_01.GetOutput(sa);
      
      SoundAssign.Cab_Btn_Push.GetOutput(sa);
      SoundAssign.Cab_Btn_Release.GetOutput(sa);
      SoundAssign.ACDCChangerBtn_Push.GetOutput(sa);
      SoundAssign.ACDCChangerBtn_Release.GetOutput(sa);

      SoundAssign.HB_Sound.GetOutput(sa);
      SoundAssign.DCtoAC.GetOutput(sa);
      SoundAssign.ACtoDC.GetOutput(sa);
      SoundAssign.AirCond_OFF.GetOutput(sa);
      SoundAssign.AirCond_ON.GetOutput(sa);
      SoundAssign.AirCond_Drive.GetOutput(sa);
      #endregion
    }
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
