namespace TR.LimExpTIMSDisp
{
  /// <summary>
  /// 各種設定を格納する
  /// </summary>
  public class Settings
  {
    public const double SpdDifferenceThreshold = 5;
    public const int RefreshRate = 40;
    /// <summary>Process ID(Use as Identification number)</summary>
    static public uint MyProcessID { get; internal set; } = 0;
    /// <summary>Volume Setting (0:None, 1:Half, 2:Full)</summary>
    static public byte Volume { get; internal set; } = 2;
    /// <summary>BackLight Setting (0:None, 1:1/4, 2:Half, 3:3/4, 4:Full)</summary>
    static public byte BackLight { get; internal set; } = 4;
    /// <summary>D01Ax Setting.   If it is D01AA, set "true".</summary>
    static public bool IsRow { get; internal set; } = true;
    /// <summary>Running Line ID</summary>
    static public byte LineID { get; internal set; } = 0;
    /// <summary>Hardware Location & Part Taking Setting (0:Left, 1:Center, 2:Right)</summary>
    static public byte Part { get; internal set; } = 1;
    /// <summary>Displaying Mode Setting (8 Colors : True, 256 Colors : False)</summary>
    static public bool Is8C { get; internal set; } = true;
    public enum LineIDList
    {
      ///<summary>No Assign</summary>
      None,
      ///<summary>Yamanote Line</summary>
      Yate,
      ///<summary>Keihin-Tohoku Line</summary>
      Keto,
      ///<summary>Yokohama & Sagami Line</summary>
      HamaSG,
      ///<summary>Ueno-Tokyo / Shonan-Shinjuku Line</summary>
      UTSS,
      ///<summary>Yokosuka & Sobu(Rapid) Line</summary>
      SukaSBR,
      ///<summary>Joban Line</summary>
      Jiba,
      ///<summary>Saikyo & Rinkai & Sotetsu Line</summary>
      SaikSO,
      ///<summary>Keiyo & Boso(Inner & Outer) Line</summary>
      KeyoBS,
      ///<summary>Musashino Line</summary>
      Musa,
      ///<summary>Nanbu Line</summary>
      Nanb,
      ///<summary>Chuo & Sobu (Local) Line</summary>
      ChuSBL,
      ///<summary>Chuo(Rapid) Line</summary>
      ChuoR,
      ///<summary>Chuo Line (Limited Express)</summary>
      ChuoLE,
      ///<summary>Tokyo Metro Tozai Line</summary>
      MetEW,
      ///<summary>Tokyo Metro Chiyoda & Odakyu & Joban(Local) & Gotenba Line</summary>
      Chiyo,
      ///<summary>Keio & Toei Shinjuku Line</summary>
      Keio,
      ///<summary>Tohoku & Hokkaido Shinkansen</summary>
      ToHoiSnk,
      ///<summary>Tokaido & Sanyo & Kyusyu & Nagasaki Shinkansen</summary>
      ToSaKyuSnk,
      ///<summary>Joetsu / Hokuriku(Nagano) Shinkansen</summary>
      JoeHorSnk,
      ///<summary>Hakodate Line</summary>
      Hakoda,
      ///<summary>Sassho Line</summary>
      Sassho,
      ///<summary>Chitose Line</summary>
      Chitos,
      ///<summary>Sekisho Line</summary>
      Sekish,
      ///<summary>Muroran Line</summary>
      Murora,
      ///<summary>Hidaka Line</summary>
      Hidaka,
      ///<summary>Nemuro Line</summary>
      Nemuro,
      ///<summary>Rumoi Line</summary>
      Rumoi,
      ///<summary>Souya Line</summary>
      Souya,
      ///<summary>Sekihoku Line</summary>
      Sekihk,
      ///<summary>Senmo Line</summary>
      Senmo,
      ///<summary>Sapporo Municipal Subway (Tozai, Nanboku, Toho Line)</summary>
      SaprMS,
      ///<summary>Sapporo Municipal Tram</summary>
      SaprMT,
      ///<summary>Hakodate Municipal Tram</summary>
      HkdtMT,
      ///<summary>Tsugaru Kaikyo (Kaikyo & Esashi(Dounan Isaribi Railway) & Hakodate) Line</summary>
      TsugKK,
      ///<summary>Furano Line</summary>
      Furano,
      ///<summary>Tohoku & Iwate Ginga Railway & Aoi-mori Railway Line(Kuroiso - Aomori)</summary>
      Tohoku,
      ///<summary>Tokaido Line(Atami - Koube)</summary>
      Tkaido,
      ///<summary>Kansai Line</summary>
      Kansai,
      ///<summary>Yagan Railway / Aizu Railway Line(Aizu Kinugawa Line, Aizu Line)</summary>
      YagAiz,
      ///<summary>Uetsu Line</summary>
      UetsuL,
      ///<summary>Ouu Line(Akita Shinkansen Omagari - Akita)</summary>
      OuLine,
      ///<summary>Gonou / Oga Line</summary>
      GonOga,
      ///<summary>Hachinohe / Ominato / Hachinohe Rinkai Railway Line</summary>
      HacOmi,
      ///<summary>Hanawa Line</summary>
      Hanawa,
      ///<summary>Tazawako Line(Akita Shinkansen Morioka - Omagari)</summary>
      Tazawa,
      ///<summary>Tadami Line</summary>
      Tadami,
      ///<summary>Suigun / Oarai Kashima (Kashima Rinkai Railway) Line</summary>
      SuigOK,
      ///<summary>Banetsu East & West Line</summary>
      BaetEW,
      ///<summary>Kitakami / Kamaishi Line</summary>
      KitKmi,
      ///<summary>Yonesaka Line</summary>
      Yonesk,
      ///<summary>Ofunato Line / Iwate Kaihatsu Railway Line</summary>
      OfuIwa,
      ///<summary>Rikuu East & West / Ishinomaki Line</summary>
      RikIsi,
      ///<summary>Senzan / Senseki Line</summary>
      SezSek,
      ///<summary>Abukuma Kyuko Railway Line</summary>
      Abkuma,
      ///<summary>Kounan Railway / Tsugaru Railway Line</summary>
      KouTug,
      ///<summary>Akita Nairiku Jukan Railway / Akita Rinkai Railway Line</summary>
      AkNaRi,
      ///<summary>Kesen-numa Line / Chokai Sanroku Line(Yuri Kogen Railway)</summary>
      KsnCho,
      ///<summary>Sazawa Line / Flower Nagai Line(Yamagata Railway)</summary>
      SazNgi,
      ///<summary>Yamada Line / Sanriku Railway North & South Rias Line</summary>
      YamSan,
      ///<summary>Sendai Airport Railway Line/ Sendai Rinkai Railway Line</summary>
      SeAPRi,
      ///<summary>Sendai Municipal Subway Tozai / Nanboku Line</summary>
      SedaMS,
      ///<summary>Fukushima Kotsu Izaka Line / Fukushima Rinkai Railway Line</summary>
      FuKoRi,
      //Above : Tohoku & Hokkaido Area
    }


    public static string LicenseString
    {
      get
      {
        return
          "LimExpTIMSDispSim (Tetsu Otter)\n\n" +
          "License Name : The MIT License\n(C) 2019 Tetsu Otter\n" +
          "https://github.com/TetsuOtter/LimExpTIMSPI/blob/master/LICENSE \n\n" +
          "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
          "dotnet Library (Microsoft)\n\n" +
          "License Name : MICROSOFT SOFTWARE LICENSE TERMS(MICROSOFT.NET LIBRARY)\n" +
          "https://dotnet.microsoft.com/dotnet_library_license.htm \n\n" +
          "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
          "kanaxs C# 1.0.0(DOBON!)\n\n" +
          "License Name : New BSD License\nCopyright (c) 2011, DOBON! <http://dobon.net>\n" +
          "https://wiki.dobon.net/index.php?free%2FkanaxsCSharp%2Flicense \n";
      }
    }
  }
}
