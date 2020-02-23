using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
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
          GPSSpeed = ((st.Z - LastLoc) * 60 * 60) / dt;//km/min
        }
        LastLoc = st.Z;
        LastTime = st.T;
      }
      else GPSSpeed = 0;
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
