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
    S00AA,
    S00AB,
    D00AA,
    D01AA,
    D04AA,
    D05AA,
    A01AA,
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
    /// <summary>空白</summary>
    Blank,
    /// <summary>ツウコク ジョウホウ</summary>
    TJ_,
    /// <summary>ツウコク</summary>
    T__,
    /// <summary>ジョウホウ</summary>
    _J_,
    /// <summary>モニタ中</summary>
    __M,
    /// <summary>ツウコク ジョウホウ モニタ中</summary>
    TJM,
    /// <summary>ツウコク  モニタ中</summary>
    T_M,
    /// <summary> ジョウホウ モニタ中</summary>
    _JM
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

  /// <summary>CabSeS位置表示種類</summary>
  public enum Pnl_CabSeS_Display
  {
    /// <summary>無表示</summary>
    Blank,
    /// <summary>前</summary>
    F,
    /// <summary>中</summary>
    N,
    /// <summary>後</summary>
    R
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

  public enum Pnl_TIMSMon_D04AA_PassS_10KeyMode
  {
    /// <summary>表示なし</summary>
    NoPass_NoSel,
    /// <summary>通過設定なし 「数字」Selected</summary>
    NoPass_Num,
    /// <summary>通過設定なし 「英上」Selected</summary>
    NoPass_Upper,
    /// <summary>通過設定なし 「英下」Selected</summary>
    NoPass_Lower,
    /// <summary>通過設定あり モード選択なし</summary>
    Pass_NoSel,
    /// <summary>通過設定あり 「数字」Selected</summary>
    Pass_Num,
    /// <summary>通過設定あり 「英上」Selected</summary>
    Pass_Upper,
    /// <summary>通過設定あり 「英下」Selected</summary>
    Pass_Lower
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

  #endregion
}
