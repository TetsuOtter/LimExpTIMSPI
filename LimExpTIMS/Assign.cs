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
    public const int ATS_Sn_Bell = 0;
    public const int ATS_Sn_Chime = 1;

    public const int EBSystem_Buzzer = 3;
    public const int ATS_P_Bell = 4;

    public const int ATS_P_EBMsg = 6;
    public const int ATS_P_ReleaseMsg = 7;


    public const int ATS_Ps_Pattern_BrakeOut = 10;
    public const int ATS_Ps_Pattern_Coming = 11;
    public const int ATS_Ps_Pattern_Deleted = 12;
    public const int ATS_Ps_Brake_Trip = 13;

    public const int Accidental_Passage_Preventer_Stop_Once = 15;
    public const int Accidental_Passage_Preventer_Pass_Once = 16;
    public const int Accidental_Passage_Preventer_Stop_Loop = 17;


    public const int BougoR_Sound = 30;
    public const int ElecHorn = 31;
    public const int AirHorn_Intro = 32;
    public const int AirHorn_Loop = 33;
    public const int AirHorn_AfterGlow = 34;
    public const int MusicHorn = 35;


    public const int TiltStart_L = 41;
    public const int TiltStart_R = 42;
    public const int TiltEnd_L = 43;
    public const int TiltEnd_R = 44;


    public const int MCCtrlSound_ToEnd = 50;
    public const int MCCtrlSound_Inner = 51;
    public const int RevCtrlSound_ToN = 52;
    public const int RevCtrlSound_ToFR = 53;
    public const int MCCtrl_Failed = 54;
    public const int RevCtrl_Failed = 55;
    public const int MCKey_Ctrl_Failed = 56;

    public const int MCKey_Remove = 89;
    public const int MCKey_ToON = 90;
    public const int MCKey_ToOFF = 91;
    public const int MCKey_Insert = 92;
    public const int CabSeS_ToN = 93;
    public const int CabSeS_ToFR = 94;
    public const int ReduceSPD_Coming = 95;
    public const int ReduceSPD_Running = 96;
    public const int ReduceSPD_End = 97;

    public const int Brake_Boost_Joyo = 100;
    public const int Brake_Boost_Emerg = 101;
    public const int AirSec_Warning = 102;
    public const int EB_Warning_Msg = 103;
    public const int OP_Info_Updated_Passenger = 104;
    public const int Stop_Warning_Deck_Msg = 107;
    public const int Passenger_Emg_Buzzer = 108;
    public const int IC_Insert = 109;
    public const int IC_Remove = 110;
    public const int TIMS_Touch = 111;
    public const int TIMS_Error_01 = 112;


    public const int Cab_Btn_Push = 115;
    public const int Cab_Btn_Release = 116;
    public const int ACDCChangerBtn_Push = 117;
    public const int ACDCChangerBtn_Release = 118;


    public const int HB_Sound = 225;
    public const int DCtoAC = 226;
    public const int ACtoDC = 227;
    public const int AirCond_OFF = 228;
    public const int AirCond_ON = 229;
    public const int AirCond_Drive = 230;
    
  }
}
