namespace TR.LimExpTIMS
{
  public class Panel
  {
    public partial class Ats
    {
      int White = 0;
      int Red = 1;
      int PPower = 2;
      int PPatternApproaching = 3;
      int PBrakeDisabled = 4;
      int PBrakeON = 5;
      //6 Pパターン発生
      int PBroken = 7;
      int PLamp = 8;
      int PEmergBrake = 9;
      int EBAlermLamp = 10;
      //11 Ps電源
      //12 Ps表示灯
      int PsPatternCreated = 13;
      int PsPatternApproaching = 14;
      int PsBrakeON = 15;
      int PsDisabled = 16;
      int PsBroken = 17;
      int PsDrivingSpeed = 18;
      int PsPatternSpeed = 19;
    }
    public partial class GCP
    {
      int StraightBackupBrake = 20;
      int SnowResistantBrake = 21;
      //22~27 NULL
    }
    public partial class Cab
    {
      int CabSeSLocation = 28;
      int MCKeyDisplay = 29;
    }
    public partial class GCP
    {
      int BrakeLocationDisplay = 30;
      int EmergencyBrakeLamp = 31;
    }
    public partial class Cab
    {
      int MasterControllerHandle = 32;
      int ReverserHandle = 33;
    }
    public partial class GCP
    {
      int ConstantSpeedLamp = 34;
      int HoldingSpeedLamp = 35;
      //36 NULL
    }
    public partial class TIMS
    {
      int Hour = 37;
      int Minute = 38;
      int Second = 39;
      //40~44 NULL
      int Speed100 = 45;
      int Speed10 = 46;
      int Speed1 = 47;
      int S00AxPage = 48;
      int A06AAPage = 49;
    }
    public partial class GCP
    {
      int SpeedMeterNeedle = 50;
    }
    public partial class TIMS
    { 
      int D00AAICButtons = 51;
      public class D04AA
      {
        int PassSettingButton = 52;
        int PrefixSetting = 53;
        int TenKeyModeSelectButton = 54;
        int TenKeyPressState = 55;
        int OtherKey = 56;
        public class ConfiguredTrainNum
        {
          int NumPrefix = 57;
          int Num1000 = 58;
          int Num100 = 59;
          int Num10 = 60;
          int Num1 = 61;
          int NumSuffix1 = 62;
          int NumSuffix2 = 63;
        }
        public class EnteringTrainNum
        {
          int NumPrefix = 64;
          int Num1000 = 65;
          int Num100 = 66;
          int Num10 = 67;
          int Num1 = 68;
          int NumSuffix1 = 69;
          int NumSuffix2 = 70;
        }
      }
      int D00AAButtonPushingImage = 71;
      public class D05AA
      {
        int DirectionArrow = 72;
        int CabSeSAndEBState = 73;
        int DirectBackupBrakeState = 74;
        int ATSBrakeState = 75;
        int ConductorEBAndBHEBState = 76;
        int ParkingBrakeState = 77;
        int MovementProhibitionSystemState = 78;
      }
      int PageNameNum = 79;
      int TsukokuJohoMonitoringChar = 80;
      int UnkoJohoButton = 81;
      int ShireiJohoButton = 82;
      int KiseiListButton = 83;
      int TsukokuButton = 84;
      int ShokiSentakuButton = 85;
      //86~90 NULL
      public partial class D01AA
      {
        public class PTrainNum
        {
          int NumPrefix = 91;
          int Num1000 = 92;
          int Num100 = 93;
          int Num10 = 94;
          int Num1 = 95;
          int NumSuffix1 = 96;
          int NumSuffix2 = 97;
        }
      }
      int Location1100 = 98;
      int Location10 = 99;
      int Location1 = 100;
      int LocationPoint1 = 101;
      int CurrentSpeed1 = 102;
      int CurrentSpeed110 = 103;
      //104 NULL
      public partial class D01AA
      {
        int UnitState1 = 105;
        int UnitState2 = 106;
        int UnitState3 = 107;
        int UnitState4 = 108;
        int DirectionArrow = 109;
        int EmergencyCalledCar = 110;
        public partial class TrainNum
        {
          int NumPrefix = 111;
          int Num1000 = 112;
          int Num100 = 113;
          int Num10 = 114;
          int Num1 = 115;
          int NumSuffix1 = 116;
        }
        int SettingCompleteLamp = 117;
        int PassSettingStateLamp = 118;
        public partial class TrainNum
        {
          int NumSuffix2 = 119;
        }
      }
    }
    public partial class GCP
    {
      int MRUnusualBand = 120;
      int MRUnusualScale = 121;
      int BC0 = 123;
      int BC200 = 124;
      int BC400 = 125;
      int BC600 = 126;
      //127 NULL
      int MRNeedle = 128;
    }
    //129 NULL
    public partial class TIMS
    {
      public partial class D01AA
      {
        //130~207 触らないため略
      }
      int NotificationL = 209;
      int NotificationR = 210;
    }
    //211 NULL
    public partial class Cab
    {
      int CabNFBBase = 212;
      int CabNFB1 = 213;
      int CabNFB2 = 214;
      int CabNFB3 = 215;
      //216 NULL
      int ACDCButton = 217;
    }
    public partial class GCP
    {
      int ACDCLamp = 218;
      int ControlVolUnusual = 219;
      int ControlVol10 = 220;
      int ControlVol1 = 221;
      int ACVolUnusual = 222;
      int ACVol10000 = 223;
      int ACVol1000 = 224;
      int ACVol110 = 225;
      int DCVolUnusual = 226;
      int DCVol1000 = 227;
      int DCVol100 = 228;
      int DCVol10 = 229;
      int ControlVolNeedle = 230;
      int ACVolNeedle = 231;
      int DCVolNeedle = 232;
      int AccidentLamp = 233;
      int ThreePhaseLamp = 234;
    }
    //235 NULL
    public partial class Cab
    {
      int VCBState = 236;
    }
    public partial class TIMS
    {
      int UpperMessageArea = 237;
      int LowerMessageArea = 238;
      int ShortCutKeyState = 239;
    }
    int HeadState = 240;
    public partial class GCP
    {
      int No1BrightAdjust = 241;
      int No2BrightAdjust = 242;
    }
    public partial class TIMS
    {
      int TIMSBrightAdjust = 243;
    }
    public partial class GCP
    {
      int No1BrightAdjustButton = 244;
      int No2BrightAdjustButton = 245;
    }
    public partial class TIMS
    {
      int TIMSBrightAdjustButton = 246;
      int TIMSVolumeAdjustButton = 247;
    }
    public partial class TIMS
    {
      int D0nXXBase = 248;
      int RadioChannelNum = 249;
    }
    int HELP1 = 250;
    int HELP2 = 251;
    public partial class TIMS
    {
      int EmergecyCallButton = 252;
    }
    public partial class Cab
    {
      int ICReaderWriter = 253;
      int BougoNotificator = 254;
    }
    public partial class TIMS
    {
      public class A01AA
      {
        int EmergencyCalledCar = 255;
      }
    }
  }
}
