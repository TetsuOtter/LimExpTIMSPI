namespace TR.LimExpTIMS
{

  /// <summary>Panelに表示するデータのグループ/モード名</summary>
  public enum DisplayingModeENum
  {
    D04AA,
    Driving,
    CabNFBShowing,
    CabSeSShowing,
    OutOfCar
  };

  /// <summary>マスコンキーの状態</summary>
  public enum MCKeyStateENum
  {
    Removed,
    OFF,
    ON
  };
  /// <summary>Direction列挙</summary>
  public enum direct
  {
    B = -1, N, F
  }
  /// <summary>架線電圧種類</summary>
  public enum WireVolType
  {
    None, DC1500V, AC20kV50Hz, AC25kV, AC20kV60Hz
  }
  /// <summary>TIMS Page Num列挙</summary>
  public enum TIMSPageENum//あとで適宜変更
  {
    /// <summary>準備中</summary>
    S00AA,
    /// <summary>初期選択</summary>
    S00AB,
    /// <summary>運転士メニュー</summary>
    D00AA,
    /// <summary>運転情報</summary>
    D01AA,
    /// <summary>列番設定</summary>
    D04AA,
    /// <summary>B確認情報</summary>
    D05AA,
    /// <summary>非常通報</summary>
    A01AA,
    /// <summary>P, Ps非常動作</summary>
    A06AA,

    None,//(予備)
  };

  public enum DispBL
  {
    Max, UMid, Mid, LMid, Min, Black, Red
  }


  /// <summary>車両のNFB一覧</summary>
  public enum NFBs
  {
    /// <summary>温風暖房器(助士側)</summary>
    Heater_AssistantSide,
    /// <summary>乗務員室ファン</summary>
    CrewRoom_Fan,
    /// <summary>標識灯</summary>
    SignLight,
    /// <summary>FD連携</summary>
    FDLinkage,
    /// <summary>ホーム検知装置</summary>
    PFDetector,
    /// <summary>限流値</summary>
    CurrentLimitter,
    /// <summary>電気ブレーキ</summary>
    ElecBrake,
    /// <summary>耐雪(対雪)ブレーキ</summary>
    AntiSnowBrake,
    /// <summary>戸じめ連動</summary>
    DoorCloseInterlock,
    /// <summary>出区点検</summary>
    DepartDepotInspection,
    /// <summary>前灯減光</summary>
    DimFLight,
    /// <summary>テーブル灯</summary>
    TableLight,
    /// <summary>乗務員室灯</summary>
    CrewRoomLight,
    /// <summary>熱線入ガラス</summary>
    GrassHeater,
    /// <summary>移動禁止</summary>
    MoveProhibit,
    /// <summary>VCB全入</summary>
    VCB_ON_ALL,
    /// <summary>VCB全切</summary>
    VCB_OFF_ALL,
    /// <summary>低減パターン</summary>
    ReductionPtn,
    /// <summary>停車パターン開放</summary>
    StopP_Release,
    /// <summary>後退検知</summary>
    BackCheck,
    //// <summary>a</summary>
    //a,
    //// <summary>a</summary>
    //a,
    //// <summary>a</summary>
    //a,

  }
  /// <summary>車両のButton一覧</summary>
  public enum Btns
  {
    /// <summary>故障車開放</summary>
    BrokenCarRelease,
    /// <summary>パンタ上</summary>
    PanUp,
    /// <summary>副パンタ上</summary>
    SubPanUp,
    /// <summary>蓄電池全入</summary>
    Battery_ON,
    /// <summary>蓄電池全切</summary>
    Battery_OFF,
    /// <summary>FD分離出発</summary>
    DetachFDDep,
    /// <summary>AC</summary>
    ACVol,
    /// <summary>DC</summary>
    DCVol,
    /// <summary>インチング</summary>
    Inching,
    /// <summary>D-ATC</summary>
    Hoan_DATC,
    /// <summary>ATC(6 埼京線)</summary>
    Hoan_ATC6,
    /// <summary>切</summary>
    Hoan_NO,
    /// <summary>ATS</summary>
    Hoan_ATS,
    /// <summary>ATACS</summary>
    Hoan_ATACS,
    /// <summary>ATC(10 常磐線)</summary>
    Hoan_ATC10,
    /// <summary>ATC(5 横須賀/総武)</summary>
    Hoan_ATC5,
    /// <summary>ATC(L 青函)</summary>
    Hoan_ATCL,
    /// <summary>各停 停止パターン</summary>
    StopP_Local,
    /// <summary>快速 停止パターン</summary>
    StopP_Rapid,
    /// <summary>なし 停止パターン</summary>
    StopP_NO,
    /// <summary>EBリセット</summary>
    ResetEB,
    /// <summary>ATS警報持続</summary>
    PersistATSAlarm,
    /// <summary>連絡ブザ</summary>
    ContactBuzzer,
    /// <summary>防護無線発報</summary>
    EmerSig,
    /// <summary>防護無線試験</summary>
    EmerSigTest,
    /// <summary>緊急列車防護装置</summary>
    TE,
    /// <summary>保護設置スイッチ</summary>
    EGS,
    /// <summary>パンタ下</summary>
    PanDown,
    /// <summary>非常パンタ下げ</summary>
    PanEMDown,
    /// <summary>M3パンタ下</summary>
    PanM3Down,
    /// <summary>定速ボタン</summary>
    ConstSPD,
    /// <summary>リセットボタン</summary>
    Reset,
    /// <summary>勾配起動</summary>
    GradStart,
    /// <summary>ATSボタン</summary>
    ATS,
    //// <summary>a</summary>
    //a,

  }

  #region 各パネル要素表示内容種類
  /// <summary>通告情報ボタン欄の文字</summary>
  public enum Pnl_TIMSMon_TsukokuJoho_Char
  {
    /// <summary>空白 0b000</summary>
    Blank,
    /// <summary>モニタ中 0b001</summary>
    __M,
    /// <summary>ジョウホウ 0b010</summary>
    _J_,
    /// <summary> ジョウホウ モニタ中 0b011</summary>
    _JM,
    /// <summary>ツウコク 0b100</summary>
    T__,
    /// <summary>ツウコク  モニタ中 0b101</summary>
    T_M,
    /// <summary>ツウコク ジョウホウ 0b110</summary>
    TJ_,
    /// <summary>ツウコク ジョウホウ モニタ中 0b111</summary>
    TJM,
  }

  /// <summary>TIMSモニタのボタン状態種類</summary>
  public enum Pnl_TIMSMon_Button_State
  {
    /// <summary>無表示</summary>
    Blank,
    /// <summary>押下状態</summary>
    Pushed,
    /// <summary>離された(通常の)状態</summary>
    Released
  }

  /// <summary>無線チャンネル表示種類</summary>
  public enum Pnl_Radio_CH
  {
    /// <summary>非表示</summary>
    Blank,
    /// <summary>'-'表示</summary>
    No_Signal,
    D1,
    D2,
    D3,
    D4,
    D5,
    D6,
    D7,
    D8,
    D9,
    A1,
    A2,
    A3,
    A4,
    A5,
    A6,
    A7,
    A8,
    A9
  }

  /// <summary>非常通報/便所 ボタン状態種類</summary>
  public enum Pnl_TIMSMon_Emerg_Warning_WC
  {
    /// <summary>非表示</summary>
    Blank,
    /// <summary>非常通報 黄色背景</summary>
    Warning_Positive,
    /// <summary>非常通報 黒色背景</summary>
    Warning_Negative,
    /// <summary>非常便所 黄色背景</summary>
    WC_Positive,
    /// <summary>非常便所 黒色背景</summary>
    WC_Negative,
    /// <summary>非常通報 押下時</summary>
    Warning_Pushed,
    /// <summary>非常便所 押下時</summary>
    WC_Pushed
  }

  /// <summary>上部メッセージエリア表示種類</summary>
  public enum Pnl_TIMSMon_UpperMsgArea
  {
    /// <summary>無表示</summary>
    Blank,
    /// <summary>「駐車」Positive</summary>
    ParkB_P,
    /// <summary>「駐車」Negative</summary>
    ParkB_N,
    /// <summary>「A･S」Positive</summary>
    AirSec_P,
    /// <summary>「A･S」Negative</summary>
    AirSec_N,
    /// <summary>「交直」Positive</summary>
    AC2DC_P,
    /// <summary>「交直」Negative</summary>
    AC2DC_N,
    /// <summary>「交交」Positive</summary>
    AC2AC_P,
    /// <summary>「交交」Negative</summary>
    AC2AC_N,
    /// <summary>「移動禁止」Positive</summary>
    MoveProhibit_P,
    /// <summary>「移動禁止」Negative</summary>
    MoveProhibit_N,
    /// <summary>「駐車」+「移動禁止」Positive</summary>
    ParkB_MoveProhibit_P,
    /// <summary>「駐車」+「移動禁止」Negative</summary>
    ParkB_MoveProhibit_N,

  }

  /// <summary>ICリーダライタ表示種類</summary>
  public enum Pnl_IC_RW_Display
  {
    /// <summary>ICなし&「READY」LED点灯</summary>
    Ready,
    /// <summary>ICなし&「BUSY」LED点灯</summary>
    Busy,
    /// <summary>ICなし&「ERROR」LED点灯</summary>
    Error,
    /// <summary>IC挿入状態かつPOWER LED点灯</summary>
    IC_Ready,
    /// <summary>IC挿入状態かつBUSY LED点灯</summary>
    IC_Busy,
    /// <summary>IC挿入状態かつERROR LED点灯</summary>
    IC_Error,
    /// <summary>ICなし&全LED消灯</summary>
    Blank,
    /// <summary>IC挿入状態かつ全LED消灯</summary>
    IC_Blank
  }

  /// <summary>防護無線機(操作Box)の状態種類</summary>
  public enum Pnl_Bougo_Display
  {
    /// <summary>電源LED点灯</summary>
    Power,
    /// <summary>受信時表示1</summary>
    Receive1,
    /// <summary>受信時表示2(ない場合は1を当てはめる。)</summary>
    Receive2,
    /// <summary>送信時表示1</summary>
    Send1,
    /// <summary>送信時表示2(ない場合は1を当てはめる。)</summary>
    Send2,
    /// <summary>LED消灯状態</summary>
    NO_LED,
    /// <summary>故障LED点灯</summary>
    Crash,
    /// <summary>電源LED+故障LED</summary>
    PW_Crash
  }

  /// <summary>画面下部ショートカットボタンの押下状態種類</summary>
  public enum Pnl_TIMSMon_ShortcutBtn
  {
    /// <summary>表示なし</summary>
    Blank,
    /// <summary>「運転士メニュー」押下</summary>
    Driver_Menu_Push,
    /// <summary>「運転情報」押下</summary>
    Drive_Info_Push,
    /// <summary>「車掌メニュー」押下</summary>
    Conductor_Menu_Push,
    /// <summary>「車掌情報」押下</summary>
    Conductor_Info_Push,
    /// <summary>応急マニュアル押下</summary>
    First_Aid_Man_Push,
    /// <summary>異常扱い押下</summary>
    Abnormal_Treatment_Push
  }

  /// <summary>S00Ax表示状態種類</summary>
  public enum Pnl_TIMSMon_S00Ax
  {
    Blank,
    S00AA,
    S00AB,
    S00AB_DriverBtn_Push,
    S00AB_NO_DATA,
    S00AB_DBtnPush_NODATA
  }

  /// <summary>D00AAページのボタン押下状態種類</summary>
  public enum Pnl_TIMSMon_D00AA_Btn
  {
    /// <summary>空白</summary>
    Blank,
    /// <summary>運転情報ボタン押下</summary>
    Drive_Info_Push,
    /// <summary>ブレーキ確認情報ボタン押下</summary>
    Brake_Info_Push,
    /// <summary>列番設定ボタン押下</summary>
    Train_Number_Push
  }

  /// <summary>TIMSモニタ列番表示の接頭辞種類</summary>
  public enum Pnl_TIMSMon_TrainNum_Header
  {
    /// <summary>空白</summary>
    Blank,
    /// <summary>"回"</summary>
    OutOfService,
    /// <summary>"試"</summary>
    TrialRun,
    /// <summary>"配"</summary>
    InternalPartsCarry,
    /// <summary>"荷"</summary>
    PackageCarry,
    /// <summary>"う"</summary>
    Bypass,
    /// <summary>"現"</summary>
    Gen,
    /// <summary>"改"</summary>
    Kai,
    /// <summary>"救"</summary>
    RescueTrain,
    /// <summary>う回</summary>
    Bypass_OutOfS,
    /// <summary>現回</summary>
    Gen_OutOfS,
    /// <summary>改回</summary>
    Kai_OutOfS,

    /// <summary>"通"</summary>
    PassSetting,

    //以下, 念のために用意した表示種類
    /// <summary>"単"</summary>
    AloneCar,
    /// <summary>"前"</summary>
    FrontHelper,
    /// <summary>"後"</summary>
    BackHelper,
    /// <summary>"雪"</summary>
    SnowRemover,
    /// <summary>"構"</summary>
    Premise,
    /// <summary>"次"</summary>
    Next,
    /// <summary>"シ"</summary>
    TrialRun_Solo,
    /// <summary>"工"</summary>
    Construct,
    /// <summary>"入"</summary>
    EnterTrain,
    /// <summary>"出"</summary>
    LeaveTrain,
    En,
    Hen,
    Sui,
    Kyou,
    /// <summary>"召"</summary>
    Royal,

    //////////Sotetsu//////////
    SO_LimExp,
    SO_Exp,
    SO_ComLimExp,
    SO_ComExp,
    SO_Rapid,
    SO_Local,
    SO_Futsu
  }

  //準備中
  /// <summary>TIMSモニタ列番表示の接尾辞表示</summary>
  public enum Pnl_TIMSMon_TrainNum_Footer
  {
    //準備中
    Blank = 0,
    A = 1,
    Z = 'Z' - 'A' + 1,

    SO_Ebi,
    SO_Atsu,
    SO_Yama,
    SO_Tsuka,
    SO_Kashi,
    SO_Nishi,
    SO_Futa,
    SO_Seya,
    SO_Hama,
    SO_Niyo,
    SO_Hoshi,
    SO_Shou,
    SO_Izu,
    SO_Shiyo,
    SO_Haza,
    SO_Izuchi,

    SO_First = SO_Ebi,
    SO_Last = SO_Izuchi
  }

  public enum Pnl_TIMSMon_D04AA_KeyState
  {
    Blank,
    LBtnPush,
    RBtnPush,
    SetBtW,
    SetBtW_LBtnPush,
    SetBtW_RBtnPush,
    SetBtPush
  }

  public enum Pnl_TIMSMon_D04AA_10KeyMode
  {
    /// <summary>表示なし</summary>
    Blank,
    /// <summary>「数字」Selected</summary>
    Num,
    /// <summary>「英上」Selected</summary>
    Upper,
    /// <summary>「英下」Selected</summary>
    Lower
  }

  public enum Pnl_TIMSMon_LowerMsgArea
  {
    Blank,
    /// <summary>空転 P</summary>
    Spin_P,
    /// <summary>空転 N</summary>
    Spin_N,
    /// <summary>滑走 P</summary>
    Slip_P,
    /// <summary>滑走 N</summary>
    Slip_N
  }

  public enum Pnl_TIMSMon_TsukokuJoho_BtnState
  {
    /// <summary>表示なし</summary>
    Blank,
    /// <summary>水色地 黒文字</summary>
    BlackChar,
    /// <summary>黒色地 緑文字</summary>
    GreenChar,
    /// <summary>黒色地 水文字</summary>
    WaterChar,
    /// <summary>緑文字 押下状態</summary>
    GreenChar_Push,
    /// <summary>水文字 押下状態</summary>
    WaterChar_Push
  }

  public enum Pnl_MCKey_Display
  {
    ON,
    OFF,
    Removed
  }

  public enum Pnl_TIMSMon_D05AA_1
  {
    Blank,
    CabSeS_F,//0b01
    CabSeS_N,//0b10
    CabSeS_R //0b11
  }

  public enum Pnl_ACDC_SW
  {
    None,
    DC,
    AC
  }

  public enum Pnl_TIMSMon_Direction
  {
    Blank,
    Left,
    Right
  }

  public enum Pnl_TIMSMon_BackLight
  {
    L4,
    L3,
    L2,
    L1,
    L0,
    Black,
    Red
  }

  public enum Pnl_TIMSMon_D01AA_TimeSep
  {
    /// <summary>空白</summary>
    Blank,
    /// <summary>":"</summary>
    Colon,
    /// <summary>"↓"</summary>
    DownArrow,
    /// <summary>"→"</summary>
    RightArrow,
    /// <summary>"←"</summary>
    LeftArrow,
    /// <summary>"停"</summary>
    Stop,
    /// <summary>"通"</summary>
    Pass,
    /// <summary>"="</summary>
    LastStop
  }

  /// <summary>行路表示部の文字色</summary>
  public enum Pnl_TIMSMon_D01AA_TTCharColor
  {
    White,
    Yellow,
    Magenta,
    Red,
    Aqua,
    Green,
    Bluw,
    RED_Back//駅名のみ赤地&白文字
  }

  public enum Pnl_TIMSMon_D01AA_UnitState
  {
    /// <summary>主パン上 0A</summary>
    _VNNN,
    /// <summary>主パン上 I+</summary>
    _VPPP,
    /// <summary>主パン上 I-</summary>
    _VBBB,
    /// <summary>主パン上 M1I+</summary>
    _VNNP,
    /// <summary>主パン上 M1I-</summary>
    _VNNB,
    /// <summary>主パン上 M2I+</summary>
    _VNPN,
    /// <summary>主パン上 M2I-</summary>
    _VNBN,
    /// <summary>全パン下 0A</summary>
    __NNN,

  }

  public enum Jisui_TIMS_TrNum_Footer
  {
    Blank,
    A,
    B,
    C,
    D,
    E,
    F,
    G,
    H,
    K,
    M,
    P,
    R,
    S,
    T,
    Y,
    Z,
    KR,
    SR,
    SO_Ebi = 21,
    SO_Atsu,
    SO_Yama,
    SO_Tsuka,
    SO_Kashi,
    SO_Nishi,
    SO_Futa,
    SO_Seya,
    SO_Hama,
    SO_Niyo,
    SO_Hoshi,
    SO_Shou,
    SO_Izu,
    SO_Shiyo,
    SO_Haza,
    SO_Izuchi,

    SO_First = SO_Ebi,
    SO_Last = SO_Izuchi
  }

  public enum Station_StopMode
  {
    /// <summary>通常の停車</summary>
    Stop,
    /// <summary>通過</summary>
    Pass,
    /// <summary>運転停車</summary>
    TemporaryStop,
    /// <summary>終着</summary>
    LastStop,
  }

  public enum Pnl_TIMSMon_NotificationL
  {
    Blank
  }
  public enum Pnl_TIMSMon_NotificationR
  {
    Blank
  }

  static public class Pnl_BitAssign
  {
    public const byte D05AA_1_EBSys = 0b00000100;
    public const byte D05AA_2_P = 0b00001000;


    public const byte D05AA_2_Ps = 0b00000001;
    public const byte D05AA_2_CEB1 = 0b00000010;
    public const byte D05AA_2_CEB2 = 0b00000100;
    public const byte D05AA_2_ParkB = 0b00001000;

    public const byte CabNFBPanel_1_TailLight = 0b00000100;
    public const byte CabNFBPanel_1_PWUp = 0b00000010;
    public const byte CabNFBPanel_1_ElecB = 0b00000001;

    public const byte CabNFBPanel_2_SnowB = 0b00000100;
    public const byte CabNFBPanel_2_TojiRen = 0b00000010;
    public const byte CabNFBPanel_2_PanUp = 0b00000001;
  }

  public enum Panel_AssignEnum
  {
    ATS_White = 0,
    ATS_Red = 1,
    PPower = 2,
    PPatternApproaching = 3,
    PBrakeDisabled = 4,
    PBrakeON = 5,
    //6 Pパターン発生
    PBroken = 7,
    PLamp = 8,
    PEmergBrake = 9,
    EBAlermLamp = 10,
    //11 Ps電源
    //12 Ps表示灯
    PsPatternCreated = 13,
    PsPatternApproaching = 14,
    PsBrakeON = 15,
    PsDisabled = 16,
    PsBroken = 17,
    PsDrivingSpeed = 18,
    PsPatternSpeed = 19,
    StraightBackupBrake = 20,
    SnowResistantBrake = 21,
    //22~27 NULL
    CabSeSLocation = 28,
    MCKeyDisplay = 29,
    BrakeLocationDisplay = 30,
    EmergencyBrakeLamp = 31,
    MasterControllerHandle = 32,
    ReverserHandle = 33,
    /// <summary>定速</summary>
    ConstantSpeedLamp = 34,
    /// <summary>抑速</summary>
    HoldingSpeedLamp = 35,
    //36 NULL
    TIMS_Hour = 37,
    TIMS_Minute = 38,
    TIMS_Second = 39,
    //40~44 NULL
    GCP_Speed100 = 45,
    GCP_Speed10 = 46,
    GCP_Speed1 = 47,
    S00AxPage = 48,
    A06AAPage = 49,
    SpeedMeterNeedle = 50,
    D00AAICButtons = 51,
    D04AA_PassSettingButton = 52,
    D04AA_PrefixSetting = 53,
    D04AA_TenKeyModeSelectButton = 54,
    D04AA_TenKeyPressState = 55,
    D04AA_OtherKey = 56,
    D04AA_Cfgrd_NumPrefix = 57,
    D04AA_Cfgrd_Num1000 = 58,
    D04AA_Cfgrd_Num100 = 59,
    D04AA_Cfgrd_Num10 = 60,
    D04AA_Cfgrd_Num1 = 61,
    D04AA_Cfgrd_NumSuffix1 = 62,
    D04AA_Cfgrd_NumSuffix2 = 63,
    D04AA_Entering_NumPrefix = 64,
    D04AA_Entering_Num1000 = 65,
    D04AA_Entering_Num100 = 66,
    D04AA_Entering_Num10 = 67,
    D04AA_Entering_Num1 = 68,
    D04AA_Entering_NumSuffix1 = 69,
    D04AA_Entering_NumSuffix2 = 70,
    D00AAButtonPushingImage = 71,
    D05AA_DirectionArrow = 72,
    D05AA_CabSeSAndEBState = 73,
    D05AA_DirectBackupBrakeState = 74,
    D05AA_ATSBrakeState = 75,
    D05AA_ConductorEBAndBHEBState = 76,
    D05AA_ParkingBrakeState = 77,
    D05AA_MovementProhibitionSystemState = 78,
    PageNameNum = 79,
    TsukokuJohoMonitoringChar = 80,
    UnkoJohoButton = 81,
    ShireiJohoButton = 82,
    KiseiListButton = 83,
    TsukokuButton = 84,
    ShokiSentakuButton = 85,
    //86~90 NULL
    PTrNum_NumPrefix = 91,
    PTrNum_Num1000 = 92,
    PTrNum_Num100 = 93,
    PTrNum_Num10 = 94,
    PTrNum_Num1 = 95,
    PTrNum_NumSuffix1 = 96,
    PTrNum_NumSuffix2 = 97,
    Location1100 = 98,
    Location10 = 99,
    Location1 = 100,
    LocationPoint1 = 101,
    TIMS_CurrentSpeed1 = 102,
    TIMS_CurrentSpeed110 = 103,
    //104 NULL
    UnitState1 = 105,
    UnitState2 = 106,
    UnitState3 = 107,
    UnitState4 = 108,
    DirectionArrow = 109,
    EmergencyCalledCar = 110,
    D01AA_NumPrefix = 111,
    D01AA_Num1000 = 112,
    D01AA_Num100 = 113,
    D01AA_Num10 = 114,
    D01AA_Num1 = 115,
    D01AA_NumSuffix1 = 116,
    PTrNumSettingEnabledLamp = 117,
    PassSettingStateLamp = 118,
    D01AA_NumSuffix2 = 119,
    MRUnusualBand = 120,
    MRUnusualScale = 121,
    BC0 = 123,
    BC200 = 124,
    BC400 = 125,
    BC600 = 126,
    //127 NULL
    MRNeedle = 128,
    //129 NULL
    StaName1 = 130,
    StaName2 = 131,
    StaName3 = 132,
    StaName4 = 133,
    StaName5 = 134,
    Arr1HH = 135,
    Arr1MM = 136,
    Arr1SS = 137,
    Arr2HH = 138,
    Arr2MM = 139,
    Arr2SS = 140,
    Arr3HH = 141,
    Arr3MM = 142,
    Arr3SS = 143,
    Arr4HH = 144,
    Arr4MM = 145,
    Arr4SS = 146,
    Arr5HH = 147,
    Arr5MM = 148,
    Arr5SS = 149,

    Dep1HH = 150,
    Dep1MM = 151,
    Dep1SS = 152,
    Dep2HH = 153,
    Dep2MM = 154,
    Dep2SS = 155,
    Dep3HH = 156,
    Dep3MM = 157,
    Dep3SS = 158,
    Dep4HH = 159,
    Dep4MM = 160,
    Dep4SS = 161,
    Dep5HH = 162,
    Dep5MM = 163,
    Dep5SS = 164,

    Arr1_Sep = 170,
    Arr2_Sep = 171,
    Arr3_Sep = 172,
    Arr4_Sep = 173,
    Arr5_Sep = 174,

    TrackNum1 = 165,
    TrackNum2 = 166,
    TrackNum3 = 167,
    TrackNum4 = 168,
    TrackNum5 = 169,

    RunTime2MM = 178,
    RunTime2SS = 179,
    RunTime3MM = 180,
    RunTime3SS = 181,
    RunTime4MM = 182,
    RunTime4SS = 183,
    RunTime5MM = 184,
    RunTime5SS = 185,

    LimIN1 = 188,
    LimOUT1 = 189,
    LimIN2 = 190,
    LimOUT2 = 191,
    LimIN3 = 192,
    LimOUT3 = 193,
    LimIN4 = 194,
    LimOUT4 = 195,
    LimIN5 = 196,
    LimOUT5 = 197,

    Dep1_Sep = 198,
    Dep2_Sep = 199,
    Dep3_Sep = 200,
    Dep4_Sep = 201,
    Dep5_Sep = 202,

    StaNameN = 203,
    ArrNHH = 204,
    ArrNMM = 205,
    ArrNSS = 206,
    TrackNumN = 207,
    ArrN_Sep = 208,
    NotificationL = 209,
    NotificationR = 210,
    //211 NULL
    CabNFBBase = 212,
    CabNFB1 = 213,
    CabNFB2 = 214,
    CabNFB3 = 215,
    //216 NULL
    ACDCButton = 217,
    ACDCLamp = 218,
    ControlVolUnusual = 219,
    ControlVol10 = 220,
    ControlVol1 = 221,
    ACVolUnusual = 222,
    ACVol10000 = 223,
    ACVol1000 = 224,
    ACVol110 = 225,
    DCVolUnusual = 226,
    DCVol1000 = 227,
    DCVol100 = 228,
    DCVol10 = 229,
    ControlVolNeedle = 230,
    ACVolNeedle = 231,
    DCVolNeedle = 232,
    AccidentLamp = 233,
    ThreePhaseLamp = 234,
    //235 NULL
    VCBState = 236,
    UpperMessageArea = 237,
    LowerMessageArea = 238,
    ShortCutKeyState = 239,
    HeadState = 240,
    No1BrightAdjust = 241,
    No2BrightAdjust = 242,
    TIMSBrightAdjust = 243,
    No1BrightAdjustButton = 244,
    No2BrightAdjustButton = 245,
    TIMSBrightAdjustButton = 246,
    TIMSVolumeAdjustButton = 247,
    D0nXXBase = 248,
    RadioChannelNum = 249,
    HELP1 = 250,
    HELP2 = 251,
    EmergecyCallButton = 252,
    ICReaderWriter = 253,
    BougoNotificator = 254,
    A01AA_EmergencyCalledCar = 255,
  }

  #endregion
}
