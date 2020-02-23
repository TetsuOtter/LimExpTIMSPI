using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  /// <summary>列車のスペックに関する構造体</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct Spec
  {
    /// <summary>ブレーキ段数</summary>
    public int B;
    /// <summary>力行ノッチ段数</summary>
    public int P;
    /// <summary>ATS確認段数</summary>
    public int A;
    /// <summary>常用最大段数</summary>
    public int J;
    /// <summary>編成車両数</summary>
    public int C;
  };
  /// <summary>列車状態に関する構造体</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct State
  {
    /// <summary>列車位置[m]</summary>
    public double Z;
    /// <summary>列車速度[km/h]</summary>
    public float V;
    /// <summary>0時からの経過時間[ms]</summary>
    public int T;
    /// <summary>BC圧力[kPa]</summary>
    public float BC;
    /// <summary>MR圧力[kPa]</summary>
    public float MR;
    /// <summary>ER圧力[kPa]</summary>
    public float ER;
    /// <summary>BP圧力[kPa]</summary>
    public float BP;
    /// <summary>SAP圧力[kPa]</summary>
    public float SAP;
    /// <summary>電流[A]</summary>
    public float I;
  };
  /// <summary>ハンドル位置に関する構造体</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct Hand
  {
    /// <summary>ブレーキハンドル位置</summary>
    public int B;
    /// <summary>力行ノッチハンドル位置</summary>
    public int P;
    /// <summary>レバーサーハンドル位置</summary>
    public int R;
    /// <summary>定速制御状態</summary>
    public int C;
  };
  /// <summary>Beaconに関する構造体</summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct Beacon
  {
    /// <summary>Beaconの番号</summary>
    public int Num;
    /// <summary>対応する閉塞の現示番号</summary>
    public int Sig;
    /// <summary>対応する閉塞までの距離[m]</summary>
    public float Z;
    /// <summary>Beaconの第三引数の値</summary>
    public int Data;
  };
  /// <summary>レバーサー位置</summary>
  public static class Reverser
  {
    /// <summary>後進</summary>
    public const int B = -1;
    /// <summary>中立</summary>
    public const int N = 0;
    /// <summary>前進</summary>
    public const int F = 1;
  }
  /// <summary>定速制御の状態</summary>
  public static class ConstSP
  {
    /// <summary>前回の状態を継続する</summary>
    public const int Continue = 0;
    /// <summary>有効化する</summary>
    public const int Enable = 1;
    /// <summary>無効化する</summary>
    public const int Disable = 2;
  }
  /// <summary>警笛の種類</summary>
  public static class Horn
  {
    /// <summary>Primary Horn</summary>
    public const int Primary = 0;
    /// <summary>Secondary Horn</summary>
    public const int Secondary = 1;
    /// <summary>Music Horn</summary>
    public const int Music = 2;
  }
  /// <summary>サウンド再生に関する操作の情報</summary>
  public static class Sound
  {
    /// <summary>繰り返し再生する</summary>
    public const int Loop = 0;
    /// <summary>一度だけ再生する</summary>
    public const int Once = 1;
    /// <summary>前回の状態を継続する</summary>
    public const int Continue = 2;
    /// <summary>再生を停止する</summary>
    public const int Stop = -1000;
  }
  /// <summary>ハンドルの初期位置設定</summary>
  public static class InitialPos
  {
    /// <summary>常用ブレーキ(B67?)</summary>
    public const int Service = 0;
    /// <summary>非常ブレーキ位置</summary>
    public const int Emergency = 1;
    /// <summary>抜き取り位置</summary>
    public const int Removed = 2;
  }
  /// <summary>ATS Keys</summary>
  public static class ATSKeys
  {
    /// <summary>ATSKey_S (Default : Space)</summary>
    public const int S = 0;
    /// <summary>ATSKey_A1 (Default : Insert)</summary>
    public const int A1 = 1;
    /// <summary>ATSKey_A2 (Default : Delete)</summary>
    public const int A2 = 2;
    /// <summary>ATSKey_B1 (Default : Home)</summary>
    public const int B1 = 3;
    /// <summary>ATSKey_B2 (Default : End)</summary>
    public const int B2 = 4;
    /// <summary>ATSKey_C1 (Default : PageUp)</summary>
    public const int C1 = 5;
    /// <summary>ATSKey_C2 (Default : PageDown)</summary>
    public const int C2 = 6;
    /// <summary>ATSKey_D (Default : D2)</summary>
    public const int D = 7;
    /// <summary>ATSKey_E (Default : D3)</summary>
    public const int E = 8;
    /// <summary>ATSKey_F (Default : D4)</summary>
    public const int F = 9;
    /// <summary>ATSKey_G (Default : D5)</summary>
    public const int G = 10;
    /// <summary>ATSKey_H (Default : D6)</summary>
    public const int H = 11;
    /// <summary>ATSKey_I (Default : D7)</summary>
    public const int I = 12;
    /// <summary>ATSKey_J (Default : D8)</summary>
    public const int J = 13;
    /// <summary>ATSKey_K (Default : D9)</summary>
    public const int K = 14;
    /// <summary>ATSKey_L (Default : D0)</summary>
    public const int L = 15;
  }

  /// <summary>Panelに表示するデータのグループ/モード名</summary>
  public enum DisplayingModeENum
  {
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
    None,
    S00AA,
    S00AB,
    D00AA,
    D01AA,
    D04AA,
    D05AA,
    A01AA,
    A06AA

  };


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
}
