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
    private enum TIMSPageNum//あとで適宜変更
    {
      None,
      S00AA,
      S00AB,
      D00AA,
      D01AA,
      D04AA,
      D05AA,

    };

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
    }
    //Attention! This Method uses "UNSAFE".
    static unsafe internal void Elapse(State st, int* Pa, int* Sa)
    {
      //If you want to change the Handle state, please access to Ats.Handle
      if (TRBIDSppLoaded) Ats.Handle = TRBIDSpp.Elapse(st, Pa, Sa);
      if (AskATSPsPLoaded) Ats.Handle = AskATSPsP.Elapse(st, Pa, Sa);
      if (KikuSC59ALoaded) Ats.Handle = KikuSC59A.Elapse(st, Pa, Sa);
      if (KikuTIMSLoaded) Ats.Handle = KikuTIMS.Elapse(st, Pa, Sa);

      BLSoSet(Pa);
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


      //BL and Sound Keys Setting Start
      if (Ats.IsKeyDown[0])
      {
        switch (k)
        {
          case 7://No1
            if(!IsNo1BLKeyPushed) BLSoChangeEvent(1);
            IsNo1BLKeyPushed = true;
            break;
          case 8://TIMSSo
            if (!IsTIMSAngry && !IsTIMSSoundPushed)
            {
              BLSoChangeEvent(4);
            }
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
      //BL and Sound Keys Setting End

    }

    static internal void KeyUp(int k)
    {
      if (TRBIDSppLoaded) TRBIDSpp.KeyUp(k);
      if (AskATSPsPLoaded) AskATSPsP.KeyUp(k);
      //if(KikuSC59ALoaded) KikuSC59A.KeyUp(k);
      //if(KikuTIMSLoaded) KikuTIMS.KeyUp(k);
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




    static private unsafe void BLSoSet(int* Pa)//
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
