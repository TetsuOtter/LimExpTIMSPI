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
    public static bool ICwasRead = false;
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

    private static bool IsACDCBtnPushing = false;
    private static bool IsACDCBtnReleased = false;

    private static bool IsMCControlFailed = false;
    private static bool IsRevControlFailed = false;

    //MCKey関連
    private static bool IsMCKeyToON = false;
    private static bool IsMCKeyToOFF = false;
    private static bool IsMCKeyInserted = false;
    private static bool IsMCKeyRemoved = false;
    private static bool IsMCKeyTurnFailed = false;

    //停車前デッキ放送
    private static bool IsBeforeStoppingAnnouncePlayed = false;

    //IC関連
    private static bool IsICInserted = false;//Sound
    private static bool IsICRemoved = false;//Sound
    /// <summary>false:Removed, true:Inserted</summary>
    private static bool ICInsertState = false;
    private static bool wasICRead = false;
    public static bool IsTimeTableSet = false;

    //バックライト関連
    private static int No1KeikiBL = BLBlack;
    private static int No2KeikiBL = BLBlack;
    private static int TIMSBL = 0;
    private static int TIMSSound = 0;
    private const int BLBlack = 5;
    private const int BLRed = 6;
    private static bool IsTIMSAngry = false;
    private static bool IsNo1BLKeyPushed = false;
    private static bool IsNo2BLKeyPushed = false;
    private static bool IsTIMSBLKeyPushed = false;
    private static bool IsTIMSSoundPushed = false;

    //TIMS Buttons PushingTF
    static private bool IsShokiSentakuPuhsing = false;
    static private byte D00AAButtonPushingNum = 0;
    static private bool IsS00ABUteshiBtnPushing = false;


    //Radio etc.
    internal static int RadioCHNum = 0;
    internal static byte TsuJoState = 0;

    //Others
    internal static bool IsAirSecAleart = false;

    //TIMS PageNumber
    internal enum TIMSPageENum//あとで適宜変更
    {
      None,
      S00AA,
      S00AB,
      D00AA,
      D01AA,
      D04AA,
      D05AA,

    };
    static internal TIMSPageENum TIMSPageNum = TIMSPageENum.S00AA;

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

    private enum ACDCStateENum { None, DC, AC};
    private static ACDCStateENum ACDCState = ACDCStateENum.None;
    private const int DCKeyNum = ATSKeys.K;
    private const int ACKeyNum = ATSKeys.L;

    private const int TIMSFlushTime = 400;

    //Useful Function
    static public void Turn(ref this bool b) => b = !b;

    


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
          KikuTIMS.Load();//読み込み失敗したらDllNotFoundException
          KikuTIMSLoaded = true;
          No1KeikiBL = 0;
          TIMSBL = 0;
          TIMSPageNum = TIMSPageENum.S00AB;
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
          ICInsertState = true;
          wasICRead = true;
          break;
        case -1:
          CabSeSLoc = CabSeSLocationENum.F;
          MCKeyState = MCKeyStateENum.ON;
          ICInsertState = true;
          wasICRead = true;
          break;
      }

    }
    //Attention! This Method uses "UNSAFE".
    static unsafe internal void Elapse(State st, int* Pa, int* Sa)
    {
      //If you want to change the Handle state, please access to Ats.Handle
      Hand hd = default;
      if (TRBIDSppLoaded) hd = TRBIDSpp.Elapse(st, Pa, Sa);
      if (AskATSPsPLoaded) hd = AskATSPsP.Elapse(st, Pa, Sa);
      if (KikuSC59ALoaded) hd = KikuSC59A.Elapse(st, Pa, Sa);
      if (KikuTIMSLoaded) hd = KikuTIMS.Elapse(st, Pa, Sa);
      if (hd.B != BNum || hd.P != PNum || hd.R != RNum)//どれか一つでも違えば出力する。
      {
        Ats.Handle = hd;
      }
      //kikuTIMS出力を統合する処理
      const int ACDisp = 217;
      if (Pa[ACDisp] == 1) { Pa[218] = 2; }//ACDisp==1ならAC, そうでないならDC出力のまま。

      //AC-DCどちらか判別できない場合
      if (Pa[218] != 0) Pa[217] = Pa[218];

      //Location & Speed Display
      int SpeedTenHund = Pa[100] * 10 + Pa[101];
      Pa[101] = Pa[104];//0.1
      Pa[100] = Pa[103] % 10;//1
      Pa[99] = (Pa[103] / 10) % 10;//10
      Pa[98] = Pa[103] / 100;//1100
      Pa[103] = SpeedTenHund;

      //空転 / 滑走表示
      Pa[237] = 0;//とりあえずリセット
      if ((Ats.GPSSpeed + 5) < st.V) Pa[237] = 1 + ((st.T / TIMSFlushTime) % 2);//理論より速い:空転
      if ((Ats.GPSSpeed - 5) > st.V) Pa[237] = 3 + ((st.T / TIMSFlushTime) % 2);//理論より遅い:滑走

      //上部MSエリア設定
      if(CabSeSLoc!= CabSeSLocationENum.F)
      {
        Pa[237] = 1 + ((st.T / TIMSFlushTime) % 2);
      }
      else
      {
        if (Pa[237] > 0)//自炊から交直切換が来てるとき
        {
          Pa[237] += 4;//交直は5,6(自炊1,2), 交交は7,8(3,4)
        }
        else if (IsAirSecAleart) Pa[237] = 3 + ((st.T / TIMSFlushTime) % 2);//エアセク警報
        else Pa[237] = 0;
      }


      //接尾辞2文字設定
      switch (Pa[116])
      {
        case 17://KR
          Pa[116] = 9;
          Pa[119] = 12;
          break;
        case 18://SR
          Pa[116] = 13;
          Pa[119] = 12;
          break;
      }

      //通過設定表示
      if (Pa[117] >= 1)
      {
        const int oPo = 1;
        const int Poo = 2;
        switch (Pa[111])
        {
          case 1://回 o?
            Pa[117] = Poo;
            break;
          case 2://試 o?
            Pa[117] = Poo;
            break;
          case 3://配 o?
            Pa[117] = Poo;
            break;
          case 4://荷 o?
            Pa[117] = Poo;
            break;
          case 5://う x
            Pa[117] = oPo;
            break;
          case 6://現 x?
            Pa[117] = oPo;
            break;
          case 7://改 x?
            Pa[117] = oPo;
            break;
          case 8://救 o?
            Pa[117] = Poo;
            break;
          case 9://(う)回 o?
            Pa[117] = Poo;
            break;
          case 10://(現)回 o?
            Pa[117] = Poo;
            break;
          case 11://(改)回 o?
            Pa[117] = Poo;
            break;
        }
      }

      //ボタン表示関連
      Pa[85] = IsShokiSentakuPuhsing ? 1 : 0;
      Pa[71] = D00AAButtonPushingNum;
      Pa[51] = ICInsertState && wasICRead ? 1 : 0;

      //TIMS Page
      Pa[210] = 0;//下部通知L
      Pa[211] = 0;//下部通知R
      switch (TIMSPageNum)
      {
        case TIMSPageENum.S00AA:
          Pa[48] = 1;
          break;
        case TIMSPageENum.S00AB:
          Pa[48] = IsS00ABUteshiBtnPushing ? 3 : 2;//運転士押下中?
          //無線チャンネルが0 or 1 or 11(A1)以上 or "情報"なし
          if (RadioCHNum <= 1 || RadioCHNum >= 11 || TsuJoState == 0 || TsuJoState == 2) Pa[48] += 2;//運行情報はありません。
          
          break;
        case TIMSPageENum.D00AA:

          break;
        default:
          Pa[48] = 0;
          break;
      }
      if (TIMSPageNum != TIMSPageENum.S00AA && CabSeSLoc == CabSeSLocationENum.F)
      {
        if (!wasICRead)
        {
          if(TIMSPageNum== TIMSPageENum.D04AA) Pa[211] = 2;//IC入れるか列番設定せい
          else Pa[211] = 1;//仕業カード挿入せい
        }
        else if (!IsTimeTableSet) Pa[211] = 3;//列番設定せい
      }

      //通告情報欄関連
      Pa[80] = TsuJoState;
      if (TRBIDSppLoaded) Pa[80] += 4;//モニタ中

      //TIMS Page Number
      Pa[79] = (int)TIMSPageNum;

      //BackLight / Sound Btn Displaying
      BLSoSet(Pa);

      DrivingPanels(Pa);
      CabNFBPanels(Pa);
      CabSeSChangingPanel(Pa);
      OutOfCarPanel(Pa);

      OnceSoundSetting(Sa);

      Keiki.No12.Panel(Pa);

      //MC & Reverser表示
      Pa[33] = 1 - Ats.Handle.R;
      Pa[32] = (Ats.SpecD.B + 1 - Ats.Handle.B) + Ats.Handle.P;

      //HELP1
      if (Ats.IsKeyDown[ATSKeys.S]) Pa[250] = 1 + (int)DispMode;
      else Pa[250] = 0;

      
    }
    static private int PNum = 0;
    static private bool IsPFirst = true;
    static internal void SetPower(int p)
    {
      /*if (IsPFirst) {
        PNum = p; IsPFirst = false;
        if (TRBIDSppLoaded) TRBIDSpp.SetPower(p);
        if (AskATSPsPLoaded) AskATSPsP.SetPower(p);
        if (KikuSC59ALoaded) KikuSC59A.SetPower(p);
        if (KikuTIMSLoaded) KikuTIMS.SetPower(p);
      }*/
      if (Ats.Handle.R != 0)
      {
        if (TRBIDSppLoaded) TRBIDSpp.SetPower(p);
        if (AskATSPsPLoaded) AskATSPsP.SetPower(p);
        if (KikuSC59ALoaded) KikuSC59A.SetPower(p);
        if (KikuTIMSLoaded) KikuTIMS.SetPower(p);
        PNum = p;
      }
      else
      {
        IsMCControlFailed = true;
        Ats.Handle.P = (int)PNum;
      }
    }
    static private int BNum = 0;
    static private bool IsBFirst = true;
    static internal void SetBrake(int b)
    {
      if (IsBFirst) {
        BNum = b; IsBFirst = false;
        if (TRBIDSppLoaded) TRBIDSpp.SetBrake(b);
        if (AskATSPsPLoaded) AskATSPsP.SetBrake(b);
        if (KikuSC59ALoaded) KikuSC59A.SetBrake(b);
        if (KikuTIMSLoaded) KikuTIMS.SetBrake(b);
      }
      if (Ats.Handle.R != 0)
      {
        if (TRBIDSppLoaded) TRBIDSpp.SetBrake(b);
        if (AskATSPsPLoaded) AskATSPsP.SetBrake(b);
        if (KikuSC59ALoaded) KikuSC59A.SetBrake(b);
        if (KikuTIMSLoaded) KikuTIMS.SetBrake(b);
        BNum = b;
      }
      else
      {
        //マスコン操作失敗音
        IsMCControlFailed = true;
        Ats.Handle.B = (int)BNum;
      }
    }
    static private int RNum = 0;
    static private bool IsRFirst = true;
    static internal void SetReverser(int r)
    {
      if (IsRFirst) {
        RNum = r; IsRFirst = false;
        if (TRBIDSppLoaded) TRBIDSpp.SetReverser(r);
        if (AskATSPsPLoaded) AskATSPsP.SetReverser(r);
        if (KikuSC59ALoaded) KikuSC59A.SetReverser(r);
        if (KikuTIMSLoaded) KikuTIMS.SetReverser(r);
      }
      if (Ats.Handle.P == 0 && Ats.Handle.B == Ats.SpecD.B + 1 && MCKeyState == MCKeyStateENum.ON)
      {
        if (TRBIDSppLoaded) TRBIDSpp.SetReverser(r);
        if (AskATSPsPLoaded) AskATSPsP.SetReverser(r);
        if (KikuSC59ALoaded) KikuSC59A.SetReverser(r);
        if (KikuTIMSLoaded) KikuTIMS.SetReverser(r);
        RNum = r;
      }
      else
      {
        IsRevControlFailed = true;
        Ats.Handle.R = (int)RNum;
      }
    }
    static internal void KeyDown(int k)
    {
      if (TRBIDSppLoaded) TRBIDSpp.KeyDown(k);
      if (AskATSPsPLoaded) AskATSPsP.KeyDown(k);
      if (KikuSC59ALoaded) KikuSC59A.KeyDown(k);
      //if(KikuTIMSLoaded) KikuTIMS.KeyDown(k);


      //BL and Sound Keys Setting
      //ACDC Switch Setting
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

          case ACKeyNum:
            //ACDCState = ACDCStateENum.AC;
            IsACDCBtnPushing = true;
            break;
          case DCKeyNum:
            //ACDCState = ACDCStateENum.DC;
            IsACDCBtnPushing = true;
            break;
        }
      }
      else
      {
        switch (DispMode)
        {
          case DisplayingModeENum.Driving:
            switch (TIMSPageNum)
            {
              case TIMSPageENum.S00AB:
                if (k == ATSKeys.C2)
                {
                  IsS00ABUteshiBtnPushing = true;
                  IsTIMSTouching = true;
                }
                break;
              case TIMSPageENum.D00AA:
                switch (k)
                {
                  case ATSKeys.C1://初期選択
                    IsShokiSentakuPuhsing = true;
                    IsTIMSTouching = true;
                    break;
                  case ATSKeys.C2://運転情報
                    D00AAButtonPushingNum = 1;
                    IsTIMSTouching = true;
                    break;
                  case ATSKeys.D://運転情報
                    D00AAButtonPushingNum = 1;
                    IsTIMSTouching = true;
                    break;
                  case ATSKeys.E://ブレーキ確認情報
                    D00AAButtonPushingNum = 2;
                    IsTIMSTouching = true;
                    break;
                  case ATSKeys.F://列番設定
                    D00AAButtonPushingNum = 3;
                    IsTIMSTouching = true;
                    break;
                }
                break;
            }
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

        //ACDCKey
        if (k == ACKeyNum || k == DCKeyNum) IsACDCBtnReleased = true;


      }
      else
      {
        switch (DispMode)
        {
          case DisplayingModeENum.Driving:
            //IC Insert/Remove
            if (k == ATSKeys.J) ICInsertState.Turn();

            switch (TIMSPageNum)
            {
              case TIMSPageENum.S00AB:
                //S00AB UteshiBtn
                if (k == ATSKeys.C2)
                {
                  IsS00ABUteshiBtnPushing = false;
                  TIMSPageNum = TIMSPageENum.D00AA;
                }
                break;
              case TIMSPageENum.D00AA:
                switch (k)
                {
                  case ATSKeys.C1://初期選択
                    IsShokiSentakuPuhsing = false;
                    TIMSPageNum = TIMSPageENum.S00AB;
                    break;
                  case ATSKeys.C2://運転情報
                    D00AAButtonPushingNum = 0;
                    TIMSPageNum = TIMSPageENum.D01AA;
                    break;
                  case ATSKeys.D://運転情報
                    D00AAButtonPushingNum = 0;
                    TIMSPageNum = TIMSPageENum.D01AA;
                    break;
                  case ATSKeys.E://ブレーキ確認情報
                    D00AAButtonPushingNum = 0;
                    //TIMSPageNum = TIMSPageENum.D05AA;//未実装
                    break;
                  case ATSKeys.F://列番設定
                    D00AAButtonPushingNum = 0;
                    //TIMSPageNum = TIMSPageENum.D04AA;//未実装
                    break;
                }
                break;
            }
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
            //Do Nothing
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
      switch (b.Num)
      {
        case 137:
          IsAirSecAleart = true;
          break;
        case 138:
          IsAirSecAleart = false;
          break;
        case 139:
          RadioCHNum = b.Data;
          break;
        case 140:
          TsuJoState = (byte)(b.Data % 4);
          break;
      }
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

      //ACDC Switch
      Sa[117].SPO(ref IsACDCBtnPushing);
      Sa[118].SPO(ref IsACDCBtnReleased);

      //IC Insert/Remove
      Sa[109].SPO(ref IsICInserted);
      Sa[110].SPO(ref IsICRemoved);
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
    //COMP
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
          NFBConfig.TailLamp = !NFBConfig.TailLamp;
          break;
        case 8:
          NFBConfig.CurrentLimUp = !NFBConfig.CurrentLimUp;
          break;
        case 9:
          NFBConfig.ElectricB = !NFBConfig.ElectricB;
          break;
        case 10:
          NFBConfig.SnoBrake = !NFBConfig.SnoBrake;
          break;
        case 11:
          NFBConfig.DoorLinkBreak = !NFBConfig.DoorLinkBreak;
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



    static private unsafe void DrivingPanels(int* Pa)//やることある?
    {
      if (DispMode == DisplayingModeENum.Driving)
      {

      }
      else
      {

      }
    }

    //COMPLETED
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

    //COMPLETED
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

    //COMPLETED
    static private unsafe void MCKeyTurningEvent(int k)
    {
      switch (MCKeyState)
      {
        case MCKeyStateENum.ON:
          if (Ats.Handle.R == 0 && Ats.Handle.P == 0 && Ats.Handle.B == Ats.SpecD.B + 1 && k == ATSKeys.I)
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

    //COMPLETED
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
