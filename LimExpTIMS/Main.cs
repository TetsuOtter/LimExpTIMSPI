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
    private static bool AskATSPsPLoaded = false;
    private static bool KikuSC59ALoaded = false;
    private static bool KikuTIMSLoaded = false;
    private static bool TRBIDSppLoaded = false;
    //そのうちイベントドリブンにしたい。

    //IC R/W関連
    public static bool ICReaded = false;
    public static bool ICReading = false;

    //操作音関連
    /// <summary>TIMS Touching Sound Play TF</summary>
    internal static bool IsTIMSTouching = false;
    /// <summary>NFB Switch Sound Play TF</summary>
    private static bool IsNFBSwitching = false;
    private static bool IsButtonPushed = false;
    static private bool IsButtonPushing = false;
    private static bool IsCabSeSMovingToCenter = false;
    private static bool IsCabSeSMovingToEdge = false;

    //MCKey関連
    private static bool IsMCKeyToON = false;
    private static bool IsMCKeyToOFF = false;
    private static bool IsMCKeyInserted = false;
    private static bool IsMCKeyRemoved = false;
    private static bool IsMCKeyTurnFailed = false;

    //停車前デッキ放送
    private static bool IsBeforeStoppingAnnouncePlayed = false;

    //IC関連
    private static bool IsICInserted = false;
    private static bool IsICRemoved = false;

    //バックライト関連
    private static int No1KeikiBL = BLBlack;
    private static int No2KeikiBL = BLBlack;
    private static int TIMSBL = BLBlack;
    private static int TIMSSound = 0;
    private const int BLBlack = 5;
    private const int BLRed = 6;
    private static bool IsTIMSAngry = false;
    private static bool IsNo1BLKeyPushed = false;
    private static bool IsNo2BLKeyPushed = false;
    private static bool IsTIMSBLKeyPushed = false;
    private static bool IsTIMSSoundPushed = false;

    //TIMS PageNumber
    private enum TIMSPageENum//あとで適宜変更
    {
      None,
      S00AA,
      S00AB,
      D00AA,
      D01AA,
      D04AA,
      D05AA,

    };
    static TIMSPageENum TIMSPageNum = TIMSPageENum.S00AB;

    private enum CabSeSLocationENum { F, N, B };
    static CabSeSLocationENum CabSeSLoc = CabSeSLocationENum.N;

    private enum DisplayingModeENum
    {
      Driving,
      CabNFBShowing,
      CabSeSShowing,
      OutOfCar
    };
    private static DisplayingModeENum DispMode = DisplayingModeENum.Driving;

    private static MCKeyStateENum MCKeyState = MCKeyStateENum.Removed;
    private enum MCKeyStateENum
    {
      Removed,
      OFF,
      ON
    };


    static internal bool Turn(in this bool b) => !b;//BOOLを反転させる

    /// <summary>Sound Play Once Method</summary>
    /// <param name="So">Sound Output State Value</param>
    /// <param name="PlayingState">Playing State</param>
    static private void SPO(ref this int So, ref bool PlayingState)
    {
      if (PlayingState) { So = Sound.Once; PlayingState = false; }
      else So = Sound.Continue;
    }


    static internal void Load()
    {
#if DEBUG
      MessageBox.Show("LimExpTIMSPI Debug Build");//If you don't need, please remove it.
#endif
      //AskATSPsP Load
      while (true) {
        DialogResult dr;
        try
        {
          AskATSPsP.Load();
          AskATSPsPLoaded = true;
          No2KeikiBL = 0;
          break;
        }
        catch (DllNotFoundException e)
        {
          dr = MessageBox.Show("ATS-P/Ps統合型ATSプラグインが見つかりません。\n" + e.Message, "LimExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        catch (Exception e)
        {
          dr = MessageBox.Show("エラーが発生しました。\n" + e.ToString(), "LinExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        if (dr != DialogResult.Retry) break;
      }

      //SC59A Load
      while (true)
      {
        DialogResult dr;
        try
        {
          KikuSC59A.Load();
          KikuSC59ALoaded = true;
          break;
        }
        catch (DllNotFoundException e)
        {
          dr = MessageBox.Show("定速/抑速機能プラグインが見つかりません。\n" + e.Message, "LimExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        catch (Exception e)
        {
          dr = MessageBox.Show("エラーが発生しました。\n" + e.ToString(), "LinExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        if (dr != DialogResult.Retry) break;
      }

      //TIMSPI Load
      while (true)
      {
        DialogResult dr;
        try
        {
          KikuTIMS.Load();
          KikuTIMSLoaded = true;
          No1KeikiBL = 0;
          TIMSBL = 0;
          break;
        }
        catch (DllNotFoundException e)
        {
          dr = MessageBox.Show("自炊TIMSプラグインが見つかりません。\n" + e.Message, "LimExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        catch (Exception e)
        {
          dr = MessageBox.Show("エラーが発生しました。\n" + e.ToString(), "LinExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        if (dr != DialogResult.Retry) break;
      }

      //BIDSpp Load
      while (true)
      {
        try
        {
          TRBIDSpp.Load();
          TRBIDSppLoaded = true;
          break;
        }
        catch (DllNotFoundException) { break; }
        catch (Exception e)
        {
          DialogResult dr = MessageBox.Show("エラーが発生しました。\n" + e.ToString(), "LinExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
          if (dr != DialogResult.Retry) break;
        }
      }

    }
    static internal void Dispose()
    {
      if (TRBIDSppLoaded) TRBIDSpp.Dispose();
      if (AskATSPsPLoaded) AskATSPsP.Dispose();
      //if(KikuSC59ALoaded)KikuSC59A.Dispose();
      //if(KikuTIMSLoaded)KikuTIMS.Dispose();
    }
    static internal void SetVehicleSpec(Spec s)
    {
      if (TRBIDSppLoaded) TRBIDSpp.SetVehicleSpec(s);
      if (AskATSPsPLoaded) AskATSPsP.SetVehicleSpec(s);
      if (KikuSC59ALoaded) KikuSC59A.SetVehicleSpec(s);
      if (KikuTIMSLoaded) KikuTIMS.SetVehicleSpec(s);
    }
    static internal void Initialize(int s)
    {
      if (TRBIDSppLoaded) TRBIDSpp.Initialize(s);
      if (AskATSPsPLoaded) AskATSPsP.Initialize(s);
      if (KikuSC59ALoaded) KikuSC59A.Initialize(s);
      if (KikuTIMSLoaded) KikuTIMS.Initialize(s);

      switch (s)//CabSeS位置選定
      {
        case InitialPos.Emergency:
          CabSeSLoc = CabSeSLocationENum.F;
          MCKeyState = MCKeyStateENum.Removed;
          break;
        case InitialPos.Removed:
          CabSeSLoc = CabSeSLocationENum.N;
          MCKeyState = MCKeyStateENum.Removed;
          break;
        case InitialPos.Service:
          CabSeSLoc = CabSeSLocationENum.F;
          MCKeyState = MCKeyStateENum.ON;
          break;
      }

    }
    //Attention! This Method uses "UNSAFE".
    static unsafe internal void Elapse(State st, int* Pa, int* Sa)
    {
      //If you want to change the Handle state, please access to Ats.Handle
      if (TRBIDSppLoaded) Ats.Handle = TRBIDSpp.Elapse(st, Pa, Sa);
      if (AskATSPsPLoaded) Ats.Handle = AskATSPsP.Elapse(st, Pa, Sa);
      if (KikuSC59ALoaded) Ats.Handle = KikuSC59A.Elapse(st, Pa, Sa);
      if (KikuTIMSLoaded) Ats.Handle = KikuTIMS.Elapse(st, Pa, Sa);


      //BackLight / Sound Btn Displaying
      BLSoSet(Pa);

      DrivingPanels(Pa);
      CabNFBPanels(Pa);
      CabSeSChangingPanel(Pa);
      OutOfCarPanel(Pa);

      OnceSoundSetting(Sa);

      Keiki.No12.Panel(Pa);

      //HELP1
      if (Ats.IsKeyDown[ATSKeys.S]) Pa[250] = 1 + (int)DispMode;
      else Pa[250] = 0;

      
    }
    static internal void SetPower(int p)
    {
      if (TRBIDSppLoaded) TRBIDSpp.SetPower(p);
      if (AskATSPsPLoaded) AskATSPsP.SetPower(p);
      if (KikuSC59ALoaded) KikuSC59A.SetPower(p);
      if (KikuTIMSLoaded) KikuTIMS.SetPower(p);
    }
    static internal void SetBrake(int b)
    {
      if (TRBIDSppLoaded) TRBIDSpp.SetBrake(b);
      if (AskATSPsPLoaded) AskATSPsP.SetBrake(b);
      if (KikuSC59ALoaded) KikuSC59A.SetBrake(b);
      if (KikuTIMSLoaded) KikuTIMS.SetBrake(b);
    }
    static internal void SetReverser(int r)
    {
      if (TRBIDSppLoaded) TRBIDSpp.SetReverser(r);
      if (AskATSPsPLoaded) AskATSPsP.SetReverser(r);
      if (KikuSC59ALoaded) KikuSC59A.SetReverser(r);
      if (KikuTIMSLoaded) KikuTIMS.SetReverser(r);
    }
    static internal void KeyDown(int k)
    {
      if (TRBIDSppLoaded) TRBIDSpp.KeyDown(k);
      if (AskATSPsPLoaded) AskATSPsP.KeyDown(k);
      if (KikuSC59ALoaded) KikuSC59A.KeyDown(k);
      //if(KikuTIMSLoaded) KikuTIMS.KeyDown(k);


      //BL and Sound Keys Setting
      if (Ats.IsKeyDown[0])
      {
        switch (k)
        {
          case 7://No1
            if(!IsNo1BLKeyPushed) BLSoChangeEvent(1);
            IsNo1BLKeyPushed = true;
            break;
          case 8://TIMSSo
            if (!IsTIMSAngry && !IsTIMSSoundPushed) BLSoChangeEvent(4);
            IsTIMSSoundPushed = true;
            break;
          case 9://TIMSBL
            if(!IsTIMSBLKeyPushed) BLSoChangeEvent(3);
            IsTIMSBLKeyPushed = true;
            break;
          case 10://No2
            if(!IsNo2BLKeyPushed) BLSoChangeEvent(2);
            IsNo2BLKeyPushed = true;
            break;
        }
      }
      else
      {
        switch (DispMode)
        {
          case DisplayingModeENum.Driving:
            break;
          case DisplayingModeENum.CabNFBShowing:
            CabNFBModeKeyEvent(k);
            break;
          case DisplayingModeENum.CabSeSShowing:
            break;
          case DisplayingModeENum.OutOfCar:
            break;
        }
      }
    }
    static internal void KeyUp(int k)
    {
      if (TRBIDSppLoaded) TRBIDSpp.KeyUp(k);
      if (AskATSPsPLoaded) AskATSPsP.KeyUp(k);
      //if(KikuSC59ALoaded) KikuSC59A.KeyUp(k);
      //if(KikuTIMSLoaded) KikuTIMS.KeyUp(k);

      //BL and Sound Keys Setting Start
      switch (k)
      {
        case 7://No1
          IsNo1BLKeyPushed = false;
          break;
        case 8://TIMSSo
          IsTIMSSoundPushed = false;
          break;
        case 9://TIMSBL
          IsTIMSBLKeyPushed = false;
          break;
        case 10://No2
          IsNo2BLKeyPushed = false;
          break;
      }
      //BL and Sound Keys Setting End

      //Mode Changing Event
      if (Ats.IsKeyDown[0])
      {
        //Num Up
        if (k == 5)
        {
          switch (DispMode)
          {
            case DisplayingModeENum.CabNFBShowing:
              DispMode = DisplayingModeENum.Driving;
              break;
            case DisplayingModeENum.CabSeSShowing:
              DispMode = DisplayingModeENum.CabNFBShowing;
              break;
            case DisplayingModeENum.OutOfCar:
              DispMode = DisplayingModeENum.CabSeSShowing;
              break;
          }
        }
        //Num Down
        if (k == 6)
        {
          switch (DispMode)
          {
            case DisplayingModeENum.Driving:
              DispMode = DisplayingModeENum.CabNFBShowing;
              break;
            case DisplayingModeENum.CabNFBShowing:
              DispMode = DisplayingModeENum.CabSeSShowing;
              break;
            case DisplayingModeENum.CabSeSShowing:
              DispMode = DisplayingModeENum.OutOfCar;
              break;
          }
        }
        MCKeyTurningEvent(k);
      }
      else
      {
        switch (DispMode)
        {
          case DisplayingModeENum.Driving:
            break;
          case DisplayingModeENum.CabNFBShowing:
            if (k == 12)
            {
              NFBConfig.PantaRaise = false;
              IsButtonPushed = true;
            }
            break;
          case DisplayingModeENum.CabSeSShowing:
            CabSeSTurningEvent(k);
            break;
          case DisplayingModeENum.OutOfCar:
            break;
        }
      }
    }
    static internal void DoorOpen()
    {
      if (TRBIDSppLoaded) TRBIDSpp.DoorOpen();
      if (AskATSPsPLoaded) AskATSPsP.DoorOpen();
      if (KikuSC59ALoaded) KikuSC59A.DoorOpen();
      if (KikuTIMSLoaded) KikuTIMS.DoorOpen();
    }
    static internal void DoorClose()
    {
      if (TRBIDSppLoaded) TRBIDSpp.DoorClose();
      if (AskATSPsPLoaded) AskATSPsP.DoorClose();
      if (KikuSC59ALoaded) KikuSC59A.DoorClose();
      if (KikuTIMSLoaded) KikuTIMS.DoorClose();
    }
    static internal void HornBlow(int h)
    {
      if (TRBIDSppLoaded) TRBIDSpp.HornBlow(h);
      if (AskATSPsPLoaded) AskATSPsP.HornBlow(h);
      //if(KikuSC59ALoaded) KikuSC59A.HornBlow(h);
      //if(KikuTIMSLoaded) KikuTIMS.HornBlow(h);
    }
    static internal void SetSignal(int s)
    {
      if (TRBIDSppLoaded) TRBIDSpp.SetSignal(s);
      if (AskATSPsPLoaded) AskATSPsP.SetSignal(s);
      //if(KikuSC59ALoaded) KikuSC59A.SetSignal(s);
      if (KikuTIMSLoaded) KikuTIMS.SetSignal(s);
    }
    static internal void SetBeaconData(Beacon b)
    {
      if (TRBIDSppLoaded) TRBIDSpp.SetBeaconData(b);
      if (AskATSPsPLoaded) AskATSPsP.SetBeaconData(b);
      //if(KikuSC59ALoaded) KikuSC59A.SetBeaconData(b);
      if (KikuTIMSLoaded) KikuTIMS.SetBeaconData(b);
    }


    static private unsafe void OnceSoundSetting(int* Sa)
    {
      //TIMS Touching Sound
      Sa[111].SPO(ref IsTIMSTouching );

      //CabSeS Turning Sound
      Sa[93].SPO(ref IsCabSeSMovingToCenter );
      Sa[94].SPO(ref IsCabSeSMovingToEdge );

      //NFB Switching Sound
      Sa[102].SPO(ref IsNFBSwitching );

      //Button Pushing/Pushed Sound
      Sa[115].SPO(ref IsButtonPushing );
      Sa[116].SPO(ref IsButtonPushed );

      //MCKeys
      Sa[89].SPO(ref IsMCKeyRemoved);
      Sa[90].SPO(ref IsMCKeyToON);
      Sa[91].SPO(ref IsMCKeyToOFF);
      Sa[92].SPO(ref IsMCKeyInserted);
    }

    static bool CabNFBModeOffed = false;
    static bool IsNFBTurned = false;
    
    internal static class NFBConfig
    {
      //true:入, false:auto
      static public bool TailLamp { get=> _TailLamp; set { _TailLamp = value; IsNFBTurned = true; } }
      static private bool _TailLamp = false;

      //true:増, false:通常
      static public bool CurrentLimUp { get => _CurrentLimUp; set { _CurrentLimUp = value; IsNFBTurned = true; } }
      static private bool _CurrentLimUp = false;

      //true:Enabled, false:Disabled
      static public bool ElectricB { get => _ElectricB; set { _ElectricB = value; IsNFBTurned = true; } }
      static private bool _ElectricB = false;


      //same as above
      static public bool SnoBrake { get => _SnoBrake; set { _SnoBrake = value; IsNFBTurned = true; } }
      static private bool _SnoBrake = false;

      //true:Break, false:Linked
      static public bool DoorLinkBreak { get => _DoorLinkBreak; set { _DoorLinkBreak = value; IsNFBTurned = true; } }
      static private bool _DoorLinkBreak = false;

      //true:Pushed, false:Released
      static public bool PantaRaise { get => _PantaRaise; set { _PantaRaise = value; IsNFBTurned = true; } }
      static private bool _PantaRaise = false;

    }

    static private unsafe void CabNFBPanels(int* Pa)
    {
      const int BaseIndex = 212;
      const int NFB1Index = 213;//Assign33
      const int NFB2Index = 214;//Assign34
      const int NFB3Index = 215;//Assign35
      if (DispMode != DisplayingModeENum.CabNFBShowing)
      {
        Pa[BaseIndex] = 0;
        Pa[NFB1Index] = 0;
        Pa[NFB2Index] = 0;
        Pa[NFB3Index] = 0;
        CabNFBModeOffed = true;
      }
      else if (CabNFBModeOffed || IsNFBTurned)
      {
        Pa[BaseIndex] = 1;
        Pa[NFB1Index] = (NFBConfig.TailLamp ? 4 : 0) + (NFBConfig.CurrentLimUp ? 2 : 0) + (NFBConfig.ElectricB ? 1 : 0);
        Pa[NFB2Index] = (NFBConfig.SnoBrake ? 4 : 0) + (NFBConfig.DoorLinkBreak ? 2 : 0) + (NFBConfig.PantaRaise ? 1 : 0);
        Pa[NFB3Index] = 1;
        CabNFBModeOffed = false;
        IsNFBTurned = false;
      }
    }
    static private void CabNFBModeKeyEvent(int k)
    {
      bool IsPushSW = false;
      switch (k)
      {
        case 7:
          NFBConfig.TailLamp.Turn();
          break;
        case 8:
          NFBConfig.CurrentLimUp.Turn();
          break;
        case 9:
          NFBConfig.ElectricB.Turn();
          break;
        case 10:
          NFBConfig.SnoBrake.Turn();
          break;
        case 11:
          NFBConfig.DoorLinkBreak.Turn();
          break;
        case 12:
          IsPushSW = true;
          NFBConfig.PantaRaise = true;
          break;
        case 5:
          //VCB ON (予約)
          break;
        case 6:
          //VCB OFF (予約)
          break;
      }
      if (IsPushSW) IsButtonPushing = true;
      else IsNFBSwitching = true;
    }


    static private unsafe void DrivingPanels(int* Pa)
    {
      if (DispMode == DisplayingModeENum.Driving)
      {

      }
      else
      {

      }
    }

    static private unsafe void CabSeSChangingPanel(int* Pa) => Pa[28] = DispMode == DisplayingModeENum.CabSeSShowing ? 1 + (int)CabSeSLoc : 0;
    static private void CabSeSTurningEvent(int k)
    {
      if (k == ATSKeys.C1)
      {
        switch (CabSeSLoc)
        {
          case CabSeSLocationENum.N:
            CabSeSLoc = CabSeSLocationENum.F;
            IsCabSeSMovingToEdge = true;
            break;
          case CabSeSLocationENum.B:
            CabSeSLoc = CabSeSLocationENum.N;
            IsCabSeSMovingToCenter = true;
            break;
        }
      }
      if (k == ATSKeys.C2)
      {
        switch (CabSeSLoc)
        {
          case CabSeSLocationENum.F:
            CabSeSLoc = CabSeSLocationENum.N;
            IsCabSeSMovingToCenter = true;
            break;
          case CabSeSLocationENum.N:
            CabSeSLoc = CabSeSLocationENum.B;
            IsCabSeSMovingToEdge = true;
            break;
        }
      }
    }

    static private unsafe void OutOfCarPanel(int* Pa)
    {
      int outnum = 0;
      if (DispMode == DisplayingModeENum.OutOfCar)
      {
        switch (CabSeSLoc)
        {
          case CabSeSLocationENum.F:
            outnum = NFBConfig.TailLamp ? 3 : 1;
            break;
          default:
            outnum = 2;
            break;
        }
      }
      Pa[240] = outnum;
    }

    static private unsafe void MCKeyTurningEvent(int k)
    {
      switch (MCKeyState)
      {
        case MCKeyStateENum.ON:
          if (Ats.Handle.R == 0 && Ats.Handle.P == 0 && Ats.Handle.B == 0 && k == ATSKeys.I)
          {
            IsMCKeyToOFF = true;
            MCKeyState = MCKeyStateENum.OFF;
          }
          else
          {
            IsMCKeyTurnFailed = true;
          }
          break;
        case MCKeyStateENum.OFF:
          if (k == ATSKeys.I)
          {
            IsMCKeyToON = true;
            MCKeyState = MCKeyStateENum.ON;
          }else if (k == ATSKeys.H)
          {
            IsMCKeyRemoved = true;
            MCKeyState = MCKeyStateENum.Removed;
          }
          else
          {
            IsMCKeyTurnFailed = true;
          }
          break;
        case MCKeyStateENum.Removed:
          if (k == ATSKeys.H)
          {
            IsMCKeyInserted = true;
            MCKeyState = MCKeyStateENum.OFF;
          }
          else
          {
            IsMCKeyTurnFailed = true;
          }
          break;
      }
    }


    static private unsafe void BLSoSet(int* Pa)
    {
      //Display
      Pa[241] = No1KeikiBL;
      Pa[242] = No2KeikiBL;
      Pa[243] = TIMSBL;

      //Button
      Pa[244] = No1KeikiBL * 2 + (IsNo1BLKeyPushed ? 2 : 1);
      Pa[245] = No2KeikiBL * 2 + (IsNo2BLKeyPushed ? 2 : 1);
      Pa[246] = TIMSBL * 2 + (IsTIMSBLKeyPushed ? 2 : 1);
      Pa[247] = IsTIMSAngry ? 7 : TIMSSound * 2 + (IsTIMSSoundPushed ? 2 : 1);//Disabledなら7, 違ったら計算
    }

    static private void BLSoChangeEvent(byte DispNum)//1:No.1, 2:No.2, 3:TIMSBL, 4:TIMSSound
    {
      switch (DispNum)
      {
        case 0:
          No1KeikiBL = BLLevelNumReturner(No1KeikiBL);
          break;
        case 1:
          No2KeikiBL = BLLevelNumReturner(No2KeikiBL);
          break;
        case 2:
          TIMSBL = BLLevelNumReturner(TIMSBL);
          break;
        case 3:
          TIMSSound = TIMSSound >= 2 ? 0 : TIMSSound + 1;
          break;
      }
    }

    static private int BLLevelNumReturner(int Level) => Level >= 5 ? Level : Level == 4 ? 0 : Level + 1;
  }
}
