namespace TR.LimExpTIMS
{
  //定数値核種を格納

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
    public const int Stop = -10000;
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

  public static class cvs
  {
    public const double SPDThreshold = 5;//空転/滑走表示の閾値。

    public const int DCKeyNum = ATSKeys.K;
    public const int ACKeyNum = ATSKeys.L;

    /// <summary>TIMSモニタのBlink間隔</summary>
    public const int TIMSFlushTime = 400;
    public const byte ICRWFlushCountMAX = 10;
    /// <summary>IC R/Wの読込間隔</summary>
    public const int ICRWBusyCycle = 250;

    /// <summary>Panel / Soundの配列長</summary>
    public const int PSArrayLength = 256;

    /// <summary>徐行案内をどれくらい前から出すかの設定</summary>
    public const int ReduceSpeed_ShowDistance = 400;
  }
}
