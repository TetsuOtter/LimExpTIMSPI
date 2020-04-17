namespace TR.LimExpTIMS
{
  public class SoundManager
  {
    public SoundManager(PlayType ptyp, int index)
    {
      PTyp = ptyp;
      Index = index;
    }
    

    /// <summary>LOOP再生かONCE再生かの種類</summary>
    public enum PlayType
    {
      /// <summary>繰り返し再生</summary>
      PlayLoop,
      /// <summary>一度きり再生</summary>
      PlayOnce
    }

    /// <summary>再生タイプの記録</summary>
    public PlayType PTyp { get; }
    /// <summary>サウンドのインデックス</summary>
    public int Index { get; }
    /// <summary>再生ボリュームの設定(設定なし=>null)</summary>
    public int? PlayVolume { get; set; } = null;
    /// <summary>再生状態の設定</summary>
    public bool IsPlaying { get; set; } = false;
    private int outputRec = 0;

    /// <summary>出力すべき値を取得できるメソッド</summary>
    /// <returns>出力すべき値</returns>
    public int GetOutput()
    {
      outputRec = getOutput();
      return outputRec;
    }
    private int getOutput()
    {
      if (IsPlaying) return Sound.Stop;

      switch (outputRec)
      {
        case Sound.Stop://New Playing
          return PTyp == PlayType.PlayLoop ? Sound.Loop : Sound.Once;

        case Sound.Loop://Loop playing
          return PlayVolume ?? Sound.Continue;

        case Sound.Once://OneTime Playing
          return PlayVolume ?? Sound.Continue;

        default:
          return Sound.Continue;
      }
    }
  }
}
