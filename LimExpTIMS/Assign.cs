namespace TR.LimExpTIMS
{
  public static class PanelAssign
  {
    public partial class Ats
    {
      public const int White = 0;
      public const int Red = 1;
      public const int PPower = 2;
      public const int PPatternApproaching = 3;
      public const int PBrakeDisabled = 4;
      public const int PBrakeON = 5;
      //6 Pパターン発生
      public const int PBroken = 7;
      public const int PLamp = 8;
      public const int PEmergBrake = 9;
      public const int EBAlermLamp = 10;
      //11 Ps電源
      //12 Ps表示灯
      public const int PsPatternCreated = 13;
      public const int PsPatternApproaching = 14;
      public const int PsBrakeON = 15;
      public const int PsDisabled = 16;
      public const int PsBroken = 17;
      public const int PsDrivingSpeed = 18;
      public const int PsPatternSpeed = 19;
    }
    public partial class GCP
    {
      public const int StraightBackupBrake = 20;
      public const int SnowResistantBrake = 21;
      //22~27 NULL
    }
    public partial class Cab
    {
      public const int CabSeSLocation = 28;
      public const int MCKeyDisplay = 29;
    }
    public partial class GCP
    {
      public const int BrakeLocationDisplay = 30;
      public const int EmergencyBrakeLamp = 31;
    }
    public partial class Cab
    {
      public const int MasterControllerHandle = 32;
      public const int ReverserHandle = 33;
    }
    public partial class GCP
    {
      public const int ConstantSpeedLamp = 34;
      public const int HoldingSpeedLamp = 35;
      //36 NULL
    }
    public partial class TIMS
    {
      public const int Hour = 37;
      public const int Minute = 38;
      public const int Second = 39;
      //40~44 NULL
      public const int Speed100 = 45;
      public const int Speed10 = 46;
      public const int Speed1 = 47;
      public const int S00AxPage = 48;
      public const int A06AAPage = 49;
    }
    public partial class GCP
    {
      public const int SpeedMeterNeedle = 50;
    }
    public partial class TIMS
    { 
      public const int D00AAICButtons = 51;
      public class D04AA
      {
        public const int PassSettingButton = 52;
        public const int PrefixSetting = 53;
        public const int TenKeyModeSelectButton = 54;
        public const int TenKeyPressState = 55;
        public const int OtherKey = 56;
        public class ConfiguredTrainNum
        {
          public const int NumPrefix = 57;
          public const int Num1000 = 58;
          public const int Num100 = 59;
          public const int Num10 = 60;
          public const int Num1 = 61;
          public const int NumSuffix1 = 62;
          public const int NumSuffix2 = 63;
        }
        public class EnteringTrainNum
        {
          public const int NumPrefix = 64;
          public const int Num1000 = 65;
          public const int Num100 = 66;
          public const int Num10 = 67;
          public const int Num1 = 68;
          public const int NumSuffix1 = 69;
          public const int NumSuffix2 = 70;
        }
      }
      public const int D00AAButtonPushingImage = 71;
      public class D05AA
      {
        public const int DirectionArrow = 72;
        public const int CabSeSAndEBState = 73;
        public const int DirectBackupBrakeState = 74;
        public const int ATSBrakeState = 75;
        public const int ConductorEBAndBHEBState = 76;
        public const int ParkingBrakeState = 77;
        public const int MovementProhibitionSystemState = 78;
      }
      public const int PageNameNum = 79;
      public const int TsukokuJohoMonitoringChar = 80;
      public const int UnkoJohoButton = 81;
      public const int ShireiJohoButton = 82;
      public const int KiseiListButton = 83;
      public const int TsukokuButton = 84;
      public const int ShokiSentakuButton = 85;
      //86~90 NULL
      public partial class D01AA
      {
        public class PTrainNum
        {
          public const int NumPrefix = 91;
          public const int Num1000 = 92;
          public const int Num100 = 93;
          public const int Num10 = 94;
          public const int Num1 = 95;
          public const int NumSuffix1 = 96;
          public const int NumSuffix2 = 97;
        }
      }
      public const int Location1100 = 98;
      public const int Location10 = 99;
      public const int Location1 = 100;
      public const int LocationPoint1 = 101;
      public const int CurrentSpeed1 = 102;
      public const int CurrentSpeed110 = 103;
      //104 NULL
      public partial class D01AA
      {
        public const int UnitState1 = 105;
        public const int UnitState2 = 106;
        public const int UnitState3 = 107;
        public const int UnitState4 = 108;
        public const int DirectionArrow = 109;
        public const int EmergencyCalledCar = 110;
        public partial class TrainNum
        {
          public const int NumPrefix = 111;
          public const int Num1000 = 112;
          public const int Num100 = 113;
          public const int Num10 = 114;
          public const int Num1 = 115;
          public const int NumSuffix1 = 116;
        }
        public const int SettingCompleteLamp = 117;
        public const int PassSettingStateLamp = 118;
        public partial class TrainNum
        {
          public const int NumSuffix2 = 119;
        }
      }
    }
    public partial class GCP
    {
      public const int MRUnusualBand = 120;
      public const int MRUnusualScale = 121;
      public const int BC0 = 123;
      public const int BC200 = 124;
      public const int BC400 = 125;
      public const int BC600 = 126;
      //127 NULL
      public const int MRNeedle = 128;
    }
    //129 NULL
    public partial class TIMS
    {
      public partial class D01AA
      {
        //130~207 触らないため略
      }
      public const int NotificationL = 209;
      public const int NotificationR = 210;
    }
    //211 NULL
    public partial class Cab
    {
      public const int CabNFBBase = 212;
      public const int CabNFB1 = 213;
      public const int CabNFB2 = 214;
      public const int CabNFB3 = 215;
      //216 NULL
      public const int ACDCButton = 217;
    }
    public partial class GCP
    {
      public const int ACDCLamp = 218;
      public const int ControlVolUnusual = 219;
      public const int ControlVol10 = 220;
      public const int ControlVol1 = 221;
      public const int ACVolUnusual = 222;
      public const int ACVol10000 = 223;
      public const int ACVol1000 = 224;
      public const int ACVol110 = 225;
      public const int DCVolUnusual = 226;
      public const int DCVol1000 = 227;
      public const int DCVol100 = 228;
      public const int DCVol10 = 229;
      public const int ControlVolNeedle = 230;
      public const int ACVolNeedle = 231;
      public const int DCVolNeedle = 232;
      public const int AccidentLamp = 233;
      public const int ThreePhaseLamp = 234;
    }
    //235 NULL
    public partial class Cab
    {
      public const int VCBState = 236;
    }
    public partial class TIMS
    {
      public const int UpperMessageArea = 237;
      public const int LowerMessageArea = 238;
      public const int ShortCutKeyState = 239;
    }
    public const int HeadState = 240;
    public partial class GCP
    {
      public const int No1BrightAdjust = 241;
      public const int No2BrightAdjust = 242;
    }
    public partial class TIMS
    {
      public const int TIMSBrightAdjust = 243;
    }
    public partial class GCP
    {
      public const int No1BrightAdjustButton = 244;
      public const int No2BrightAdjustButton = 245;
    }
    public partial class TIMS
    {
      public const int TIMSBrightAdjustButton = 246;
      public const int TIMSVolumeAdjustButton = 247;
    }
    public partial class TIMS
    {
      public const int D0nXXBase = 248;
      public const int RadioChannelNum = 249;
    }
    public const int HELP1 = 250;
    public const int HELP2 = 251;
    public partial class TIMS
    {
      public const int EmergecyCallButton = 252;
    }
    public partial class Cab
    {
      public const int ICReaderWriter = 253;
      public const int BougoNotificator = 254;
    }
    public partial class TIMS
    {
      public class A01AA
      {
        public const int EmergencyCalledCar = 255;
      }
    }
  }

  public static class SoundAssign
  {
    public static readonly SoundManager ATS_S_Bell = new SoundManager(SoundManager.PlayType.PlayLoop, 0);
    public static readonly SoundManager ATS_S_Chime = new SoundManager(SoundManager.PlayType.PlayLoop, 1);

    public static readonly SoundManager EBSystem_Buzzer = new SoundManager(SoundManager.PlayType.PlayLoop, 3);
    public static readonly SoundManager ATS_P_Bell = new SoundManager(SoundManager.PlayType.PlayOnce, 4);

    public static readonly SoundManager ATS_P_EBMsg = new SoundManager(SoundManager.PlayType.PlayOnce, 6);
    public static readonly SoundManager ATS_P_ReleaseMsg = new SoundManager(SoundManager.PlayType.PlayOnce, 7);


    public static readonly SoundManager ATS_Ps_Pattern_BrakeOut = new SoundManager(SoundManager.PlayType.PlayOnce, 10);
    public static readonly SoundManager ATS_Ps_Pattern_Coming = new SoundManager(SoundManager.PlayType.PlayOnce, 11);
    public static readonly SoundManager ATS_Ps_Pattern_Deleted = new SoundManager(SoundManager.PlayType.PlayOnce, 12);
    public static readonly SoundManager ATS_Ps_Brake_Trip = new SoundManager(SoundManager.PlayType.PlayOnce, 13);

    public static readonly SoundManager Accidental_Passage_Preventer_Stop_Once = new SoundManager(SoundManager.PlayType.PlayOnce, 15);
    public static readonly SoundManager Accidental_Passage_Preventer_Pass_Once = new SoundManager(SoundManager.PlayType.PlayOnce, 16);
    public static readonly SoundManager Accidental_Passage_Preventer_Stop_Loop = new SoundManager(SoundManager.PlayType.PlayLoop, 17);


    public static readonly SoundManager BougoR_Sound = new SoundManager(SoundManager.PlayType.PlayLoop, 30);
    public static readonly SoundManager ElecHorn = new SoundManager(SoundManager.PlayType.PlayLoop, 31);
    public static readonly SoundManager AirHorn_Intro = new SoundManager(SoundManager.PlayType.PlayOnce,  32);
    public static readonly SoundManager AirHorn_Loop = new SoundManager(SoundManager.PlayType.PlayLoop, 33);
    public static readonly SoundManager AirHorn_AfterGlow = new SoundManager(SoundManager.PlayType.PlayOnce, 34);
    public static readonly SoundManager MusicHorn = new SoundManager(SoundManager.PlayType.PlayOnce, 35);


    public static readonly SoundManager TiltStart_L = new SoundManager(SoundManager.PlayType.PlayOnce, 41);
    public static readonly SoundManager TiltStart_R = new SoundManager(SoundManager.PlayType.PlayOnce, 42);
    public static readonly SoundManager TiltEnd_L = new SoundManager(SoundManager.PlayType.PlayOnce, 43);
    public static readonly SoundManager TiltEnd_R = new SoundManager(SoundManager.PlayType.PlayOnce, 44);


    public static readonly SoundManager MCCtrlSound_ToEnd = new SoundManager(SoundManager.PlayType.PlayOnce, 50);
    public static readonly SoundManager MCCtrlSound_Inner = new SoundManager(SoundManager.PlayType.PlayOnce, 51);
    public static readonly SoundManager RevCtrlSound_ToN = new SoundManager(SoundManager.PlayType.PlayOnce, 52);
    public static readonly SoundManager RevCtrlSound_ToFR = new SoundManager(SoundManager.PlayType.PlayOnce, 53);
    public static readonly SoundManager MCCtrl_Failed = new SoundManager(SoundManager.PlayType.PlayOnce, 54);
    public static readonly SoundManager RevCtrl_Failed = new SoundManager(SoundManager.PlayType.PlayOnce, 55);
    public static readonly SoundManager MCKey_Ctrl_Failed = new SoundManager(SoundManager.PlayType.PlayOnce, 56);

    public static readonly SoundManager MCKey_Remove = new SoundManager(SoundManager.PlayType.PlayOnce, 89);
    public static readonly SoundManager MCKey_ToON = new SoundManager(SoundManager.PlayType.PlayOnce, 90);
    public static readonly SoundManager MCKey_ToOFF = new SoundManager(SoundManager.PlayType.PlayOnce, 91);
    public static readonly SoundManager MCKey_Insert = new SoundManager(SoundManager.PlayType.PlayOnce, 92);
    public static readonly SoundManager CabSeS_ToN = new SoundManager(SoundManager.PlayType.PlayOnce, 93);
    public static readonly SoundManager CabSeS_ToFR = new SoundManager(SoundManager.PlayType.PlayOnce, 94);
    public static readonly SoundManager ReduceSPD_Coming = new SoundManager(SoundManager.PlayType.PlayOnce, 95, cvs.ReduceSpeed_ComingMsgCycle);//繰り返しはPIで実装
    public static readonly SoundManager ReduceSPD_Running = new SoundManager(SoundManager.PlayType.PlayOnce, 96, cvs.ReduceSpeed_RunningMsgCycle);//繰り返しはPIで実装
    public static readonly SoundManager ReduceSPD_End = new SoundManager(SoundManager.PlayType.PlayOnce, 97);

    public static readonly SoundManager Brake_Boost_Joyo = new SoundManager(SoundManager.PlayType.PlayOnce, 100);
    public static readonly SoundManager Brake_Boost_Emerg = new SoundManager(SoundManager.PlayType.PlayOnce, 101);
    public static readonly SoundManager AirSec_Warning = new SoundManager(SoundManager.PlayType.PlayOnce, 102, cvs.AirSec_Warning_MsgCycle);//繰り返しはPIで実装
    public static readonly SoundManager EB_Warning_Msg = new SoundManager(SoundManager.PlayType.PlayOnce, 103);
    public static readonly SoundManager OP_Info_Updated_Passenger = new SoundManager(SoundManager.PlayType.PlayOnce, 104);
    public static readonly SoundManager Stop_Warning_Deck_Msg = new SoundManager(SoundManager.PlayType.PlayOnce, 107);
    public static readonly SoundManager Passenger_Emg_Buzzer = new SoundManager(SoundManager.PlayType.PlayLoop, 108);
    public static readonly SoundManager IC_Insert = new SoundManager(SoundManager.PlayType.PlayOnce, 109);
    public static readonly SoundManager IC_Remove = new SoundManager(SoundManager.PlayType.PlayOnce, 110);
    public static readonly SoundManager TIMS_Touch = new SoundManager(SoundManager.PlayType.PlayOnce, 111);
    public static readonly SoundManager TIMS_Error_01 = new SoundManager(SoundManager.PlayType.PlayLoop, 112);


    public static readonly SoundManager Cab_Btn_Push = new SoundManager(SoundManager.PlayType.PlayOnce, 115);
    public static readonly SoundManager Cab_Btn_Release = new SoundManager(SoundManager.PlayType.PlayOnce, 116);
    public static readonly SoundManager ACDCChangerBtn_Push = new SoundManager(SoundManager.PlayType.PlayOnce, 117);
    public static readonly SoundManager ACDCChangerBtn_Release = new SoundManager(SoundManager.PlayType.PlayOnce, 118);


    public static readonly SoundManager HB_Sound = new SoundManager(SoundManager.PlayType.PlayOnce, 225);
    public static readonly SoundManager DCtoAC = new SoundManager(SoundManager.PlayType.PlayOnce, 226);
    public static readonly SoundManager ACtoDC = new SoundManager(SoundManager.PlayType.PlayOnce, 227);
    public static readonly SoundManager AirCond_OFF = new SoundManager(SoundManager.PlayType.PlayOnce, 228);
    public static readonly SoundManager AirCond_ON = new SoundManager(SoundManager.PlayType.PlayOnce, 229);
    public static readonly SoundManager AirCond_Drive = new SoundManager(SoundManager.PlayType.PlayLoop, 230);
    
  }

  public static class ButtonAssign
  {
    #region 単独で機能する操作
    public static readonly ButtonManager TEButton = new ButtonManager(ATSKeys.A1);
    public static readonly ButtonManager EBReset = new ButtonManager(ATSKeys.A2);
    public static readonly ButtonManager ATS_Restitution = new ButtonManager(ATSKeys.B1);
    public static readonly ButtonManager ATSP_Release = new ButtonManager(ATSKeys.B2);
    #endregion

    #region モニタ輝度/音量操作
    public static readonly ButtonManager No1Mon_BL = new ButtonManager(ATSKeys.D, ATSKeys.S);
    public static readonly ButtonManager TIMSMon_Vol = new ButtonManager(ATSKeys.E, ATSKeys.S);
    public static readonly ButtonManager TIMSMon_BL = new ButtonManager(ATSKeys.F, ATSKeys.S);
    public static readonly ButtonManager No2Mon_BL = new ButtonManager(ATSKeys.G, ATSKeys.S);
    #endregion
    public const int CmbKey1 = ATSKeys.S;
    #region combo機能
    //0より下へは移動できないので、モード違い扱い。
    public static readonly ButtonManager ModeChangeToLower = new ButtonManager(ATSKeys.C1, CmbKey1,
      () => Status.DispMode > 0);

    //最大値より上へは移動できないので、モード違い扱い。
    public static readonly ButtonManager ModeChangeToBigger = new ButtonManager(ATSKeys.C2, CmbKey1,
      () => Status.DispMode < (DisplayingModeENum)(cvs.DisplayingModeENum_Count - 1));

    //ON状態でも「操作失敗音」再生のため、モード一致扱い。
    public static readonly ButtonManager MCKey_Ins_Rmv = new ButtonManager(ATSKeys.H, CmbKey1);

    //挿入さえされていれば、操作を実行できる。
    public static readonly ButtonManager MCKey_Turn = new ButtonManager(ATSKeys.I, CmbKey1, () => Status.MCKey != MCKeyStateENum.Removed);

    //音再生/表示切替のため、電源モード不一致でもイベント発火
    public static readonly ButtonManager DCBtnCtrl = new ButtonManager(ATSKeys.K, CmbKey1);
    public static readonly ButtonManager ACBtnCtrl = new ButtonManager(ATSKeys.L, CmbKey1);
    #endregion

    #region モードにより違う機能を提供する操作

    public static bool D04AAMode_Chk()
      => Cmb_ModChk(DisplayingModeENum.D04AA) && Status.TIMSMon_PageNum == TIMSPageENum.D04AA;

    public static bool DrMode_SpecifPage(TIMSPageENum tpe)
      => Cmb_ModChk(DisplayingModeENum.Driving) && Status.TIMSMon_PageNum == tpe;
    
    public static bool Cmb_ModChk(DisplayingModeENum mode)
      => (!Ats.IsKeyDown[CmbKey1]) && Status.DispMode == mode;
    /* F/F => F
     * F/T => T
     * T/F => F
     * T/T => F
     */

    

    public static readonly ButtonManager TIMSMon_ShokiSentaku = new ButtonManager(ATSKeys.C1, null, () =>
    {
      if (!Cmb_ModChk(DisplayingModeENum.Driving)) return false;
      switch (Status.TIMSMon_PageNum)
      {
        case TIMSPageENum.A06AA: return false;
        case TIMSPageENum.None: return false;
        case TIMSPageENum.S00AA: return false;
        case TIMSPageENum.S00AB: return false;
        default: return true;
      }
    });

    public static readonly ButtonManager TIMSMon_S00AB_DriverBtn = new ButtonManager(ATSKeys.C2, null,
      () => DrMode_SpecifPage(TIMSPageENum.S00AB));

    public static readonly ButtonManager TIMSMon_D00AA_DrvInf1 = new ButtonManager(ATSKeys.C2, null,
      () => DrMode_SpecifPage(TIMSPageENum.D00AA));
    public static readonly ButtonManager TIMSMon_D00AA_DrvInf2 = new ButtonManager(ATSKeys.D, null,
      () => DrMode_SpecifPage(TIMSPageENum.D00AA));

    public static readonly ButtonManager TIMSMon_D00AA_BrChkInf = new ButtonManager(ATSKeys.E, null,
      () => DrMode_SpecifPage(TIMSPageENum.D00AA));
    public static readonly ButtonManager TIMSMon_D00AA_TrainNumSet = new ButtonManager(ATSKeys.F, null,
      () => DrMode_SpecifPage(TIMSPageENum.D00AA));

    public static readonly ButtonManager TIMSMon_SC_DrvM = new ButtonManager(ATSKeys.D, null, () =>
      {
        if (!Cmb_ModChk(DisplayingModeENum.Driving)) return false;

        switch (Status.TIMSMon_PageNum)
        {
          case TIMSPageENum.A01AA: return true;
          case TIMSPageENum.A06AA: return true;
          case TIMSPageENum.D01AA: return true;
          case TIMSPageENum.D04AA: return true;
          case TIMSPageENum.D05AA: return true;
          default: return false;
        }
      });
    public static readonly ButtonManager TIMSMon_SC_DrvInf = new ButtonManager(ATSKeys.E, null, () =>
    {
      if (!Cmb_ModChk(DisplayingModeENum.Driving)) return false;

      switch (Status.TIMSMon_PageNum)
      {
        case TIMSPageENum.A01AA: return true;

        case TIMSPageENum.D01AA: return true;
        case TIMSPageENum.D04AA: return true;
        case TIMSPageENum.D05AA: return true;
        default: return false;
      }
    });

    public static readonly ButtonManager TIMSMon_A06AA_GoBack = new ButtonManager(ATSKeys.C1, null,
      () => DrMode_SpecifPage(TIMSPageENum.A06AA));
    public static readonly ButtonManager TIMSMon_A06AA_Check = new ButtonManager(ATSKeys.C2, null,
      () => DrMode_SpecifPage(TIMSPageENum.A06AA));

    public static readonly ButtonManager Drive_ConstSPD = new ButtonManager(ATSKeys.J, null, () => Cmb_ModChk(DisplayingModeENum.Driving));
    public static readonly ButtonManager Drive_PanDown = new ButtonManager(ATSKeys.J, null, () => Cmb_ModChk(DisplayingModeENum.Driving));

    public static readonly ButtonManager CabNFB_VCBON = new ButtonManager(ATSKeys.C1, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
    public static readonly ButtonManager CabNFB_VCBOFF = new ButtonManager(ATSKeys.C2, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
    public static readonly ButtonManager CabNFB_TailLamp = new ButtonManager(ATSKeys.D, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
    public static readonly ButtonManager CabNFB_CurLim = new ButtonManager(ATSKeys.E, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
    public static readonly ButtonManager CabNFB_ElecBr = new ButtonManager(ATSKeys.F, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
    public static readonly ButtonManager CabNFB_SnowResBr = new ButtonManager(ATSKeys.G, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
    public static readonly ButtonManager CabNFB_DoorInterlock = new ButtonManager(ATSKeys.H, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
    public static readonly ButtonManager CabNFB_PanUp = new ButtonManager(ATSKeys.I, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));

    public static readonly ButtonManager CabSeS_toF = new ButtonManager(ATSKeys.C1, null,
      () => Cmb_ModChk(DisplayingModeENum.CabSeSShowing) && (Status.CabSeS_kore != direct.F));
    public static readonly ButtonManager CabSeS_toR = new ButtonManager(ATSKeys.C2, null,
      () => Cmb_ModChk(DisplayingModeENum.CabSeSShowing) && (Status.CabSeS_kore != direct.B));

    public static readonly ButtonManager IC_Ins_Rmv = new ButtonManager(ATSKeys.F, null,
      () => Cmb_ModChk(DisplayingModeENum.Driving));

    public static readonly ButtonManager D04AA_SFrameUp = new ButtonManager(ATSKeys.C1, null,
      () => D04AAMode_Chk());
    public static readonly ButtonManager D04AA_SFrameDown = new ButtonManager(ATSKeys.C2, null,
      () => D04AAMode_Chk());
    public static readonly ButtonManager D04AA_LFrameLeft = new ButtonManager(ATSKeys.D, null,
      () => D04AAMode_Chk());
    public static readonly ButtonManager D04AA_LFrameRight = new ButtonManager(ATSKeys.E, null,
      () => D04AAMode_Chk());
    public static readonly ButtonManager D04AA_Bt1Click = new ButtonManager(ATSKeys.F, null,
      () => D04AAMode_Chk());
    public static readonly ButtonManager D04AA_Bt2Click = new ButtonManager(ATSKeys.G, null,
      () => D04AAMode_Chk());
    public static readonly ButtonManager D04AA_Bt3Click = new ButtonManager(ATSKeys.H, null,
      () => D04AAMode_Chk());
    public static readonly ButtonManager D04AA_LArrow = new ButtonManager(ATSKeys.I, null,
      () => D04AAMode_Chk());
    public static readonly ButtonManager D04AA_RArrow = new ButtonManager(ATSKeys.J, null,
      () => D04AAMode_Chk());
    public static readonly ButtonManager D04AA_DataSet = new ButtonManager(ATSKeys.L, null,
      () => D04AAMode_Chk());
    #endregion
  }

}
