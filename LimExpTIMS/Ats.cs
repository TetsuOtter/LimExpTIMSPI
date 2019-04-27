﻿using System;
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

  /// <summary>処理を実装するクラス</summary>
  static public class Ats
  {
    private const int Version = 0x00020000;
    public const CallingConvention CalCnv = CallingConvention.StdCall;

    /// <summary>Is the Door Closed TF</summary>
    public static bool DoorClosed { get; set; } = false;
    /// <summary>Current State of Handles</summary>
    public static Hand Handle = default;
    /// <summary>Spec Info</summary>
    public static Spec SpecD = default;
    /// <summary>Current State</summary>
    public static State StateD = default;
    /// <summary>Current Key State</summary>
    public static bool[] IsKeyDown { get; set; } = new bool[16];
    /// <summary>Theoretical Speed</summary>
    public static double GPSSpeed = 0;

    private static double LastLoc = 0;
    private static int LastTime = 0; 

    /// <summary>Called when this plugin is loaded</summary>
    [DllExport(CallingConvention = CalCnv)]
    public static void Load() => Main.Load();

    /// <summary>Called when this plugin is unloaded</summary>
    [DllExport(CallingConvention = CalCnv)]
    public static void Dispose() => Main.Dispose();

    /// <summary>Called when the version number is needed</summary>
    /// <returns>plugin version number</returns>
    [DllExport(CallingConvention = CalCnv)]
    public static int GetPluginVersion() => Version;

    /// <summary>Called when set the Vehicle Spec</summary>
    /// <param name="s">Set Spec</param>
    [DllExport(CallingConvention = CalCnv)]
    public static void SetVehicleSpec(Spec s) { SpecD = s; Main.SetVehicleSpec(s); }

    /// <summary>Called when car is put</summary>
    /// <param name="s">Default Brake Position (Refer to InitialPos class)</param>
    [DllExport(CallingConvention = CalCnv)]
    public static void Initialize(int s) => Main.Initialize(s);

    /// <summary>Called in every refleshing the display</summary>
    /// <param name="st">State</param>
    /// <param name="Pa">Panel (Pointer of int[256])</param>
    /// <param name="Sa">Sound (Pointer of int[256])</param>
    /// <returns></returns>
    [DllExport(CallingConvention = CalCnv)]
    static unsafe public Hand Elapse(State st, int* Pa, int* Sa)
    {
      StateD = st;
      if (LastLoc != st.Z && st.T != LastTime)
      {
        int dt = st.T - LastTime;
        if (dt != 0)
        {
          GPSSpeed = (st.Z - LastLoc) / dt;
        }
        LastLoc = st.Z;
        LastTime = st.T;
      }
      Main.Elapse(st, Pa, Sa);
      return Handle;
    }

    /// <summary>Called when Power notch is moved</summary>
    /// <param name="p">Notch Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetPower(int p)
    {
      Handle.P = p;
      Main.SetPower(p);
    }

    /// <summary>Called when Brake Notch is moved</summary>
    /// <param name="b">Brake notch Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetBrake(int b)
    {
      Handle.B = b;
      Main.SetBrake(b);
    }

    /// <summary>Called when Reverser is moved</summary>
    /// <param name="r">Reverser Position</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetReverser(int r)
    {
      Handle.R = r;
      Main.SetReverser(r);
    }

    /// <summary>Called when Key is Pushed</summary>
    /// <param name="k">Pushed Key Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void KeyDown(int k)
    {
      IsKeyDown[k] = true;
      Main.KeyDown(k);
    }

    /// <summary>Called when Key is Released</summary>
    /// <param name="k">Released Key Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void KeyUp(int k)
    {
      IsKeyDown[k] = false;
      Main.KeyUp(k);
    }

    /// <summary>Called when the Horn is Blown</summary>
    /// <param name="h">Blown Horn Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void HornBlow(int h) => Main.HornBlow(h);

    /// <summary>Called when Door is opened</summary>
    [DllExport(CallingConvention = CalCnv)]
    static public void DoorOpen()
    {
      DoorClosed = false;
      Main.DoorOpen();
    }

    /// <summary>Called when Door is closed</summary>
    [DllExport(CallingConvention = CalCnv)]
    static public void DoorClose()
    {
      DoorClosed = true;
      Main.DoorClose();
    }

    /// <summary>Called when the Signal Showing Number is changed</summary>
    /// <param name="s">Signal Showing Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetSignal(int s) => Main.SetSignal(s);

    /// <summary>Called when passed above the Beacon</summary>
    /// <param name="b">Beacon info</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetBeaconData(Beacon b) => Main.SetBeaconData(b);


  }


}
