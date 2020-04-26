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
    public static event EventHandler DisposeEv;
    public static event EventHandler GetPluginVersionEv;
    public static event EventHandler<SpecEvArgs> SetVehicleSpecEv;
    public static event EventHandler<IntValEvArgs> InitializeEv;

    public static event EventHandler<TickEvArgs> ElapseEv;
    
    public static event EventHandler<IntValEvArgs> SetPowerEv;
    public static event EventHandler<IntValEvArgs> SetBrakeEv;
    public static event EventHandler<IntValEvArgs> SetReverserEv;
    public static event EventHandler<IntValEvArgs> KeyDownEv;
    public static event EventHandler<IntValEvArgs> KeyUpEv;
    public static event EventHandler DoorOpenEv;
    public static event EventHandler DoorCloseEv;
    public static event EventHandler<IntValEvArgs> SetSignalEv;
    public static event EventHandler<IntValEvArgs> HornBlowEv;

    public static event EventHandler<BeaconEvArgs> SetBeaconEv;

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

    public static double LastLoc { get; private set; } = 0;
    public static int LastTime { get; private set; } = 0; 

    /// <summary>Called when this plugin is loaded</summary>
    [DllExport(CallingConvention = CalCnv)]
    public static void Load() => Main.Load();

    /// <summary>Called when this plugin is unloaded</summary>
    [DllExport(CallingConvention = CalCnv)]
    public static void Dispose()
    {
      DisposeEv?.Invoke(null, null);
      Main.Dispose();
    }

    /// <summary>Called when the version number is needed</summary>
    /// <returns>plugin version number</returns>
    [DllExport(CallingConvention = CalCnv)]
    public static int GetPluginVersion()
    {
      GetPluginVersionEv?.Invoke(null, null);
      return Version;
    }

    /// <summary>Called when set the Vehicle Spec</summary>
    /// <param name="s">Set Spec</param>
    [DllExport(CallingConvention = CalCnv)]
    public static void SetVehicleSpec(Spec s)
    {

      SpecD = s;
      SetVehicleSpecEv?.Invoke(null, new SpecEvArgs(s));
      Main.SetVehicleSpec(s);
    }

    /// <summary>Called when car is put</summary>
    /// <param name="s">Default Brake Position (Refer to InitialPos class)</param>
    [DllExport(CallingConvention = CalCnv)]
    public static void Initialize(int s)
    {
      InitializeEv?.Invoke(null, new IntValEvArgs(s));
      Main.Initialize(s);
    }

    /// <summary>Called in every refleshing the display</summary>
    /// <param name="st">State</param>
    /// <param name="Pa">Panel (Pointer of int[256])</param>
    /// <param name="Sa">Sound (Pointer of int[256])</param>
    /// <returns></returns>
    [DllExport(CallingConvention = CalCnv)]
    static unsafe public Hand Elapse(State st, IntPtr Pa, IntPtr Sa)
    {
      StateD = st;
      if (LastLoc != st.Z && st.T != LastTime)
      {
        int dt = st.T - LastTime;
        if (dt != 0)
          GPSSpeed = ((st.Z - LastLoc) * 60 * 60) / dt;//km/min
      }
      else GPSSpeed = 0;

      int[] parr = new int[cvs.PSArrayLength];
      int[] sarr = new int[cvs.PSArrayLength];

      Marshal.Copy(Pa, parr, 0, cvs.PSArrayLength);
      Marshal.Copy(Sa, sarr, 0, cvs.PSArrayLength);

      ElapseEv?.Invoke(null, new TickEvArgs() { state = st, panel = parr, sound = sarr });

      Main.Elapse(st, Pa, Sa);
      LastLoc = st.Z;
      LastTime = st.T;
      return Handle;
    }

    /// <summary>Called when Power notch is moved</summary>
    /// <param name="p">Notch Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetPower(int p)
    {
      Handle.P = p;
      SetPowerEv?.Invoke(null, new IntValEvArgs(p));
      Main.SetPower(p);
    }

    /// <summary>Called when Brake Notch is moved</summary>
    /// <param name="b">Brake notch Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetBrake(int b)
    {
      Handle.B = b;
      SetBrakeEv?.Invoke(null, new IntValEvArgs(b));
      Main.SetBrake(b);
    }

    /// <summary>Called when Reverser is moved</summary>
    /// <param name="r">Reverser Position</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetReverser(int r)
    {
      Handle.R = r;
      SetReverserEv?.Invoke(null, new IntValEvArgs(r));
      Main.SetReverser(r);
    }

    /// <summary>Called when Key is Pushed</summary>
    /// <param name="k">Pushed Key Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void KeyDown(int k)
    {
      IsKeyDown[k] = true;
      KeyDownEv?.Invoke(null, new IntValEvArgs(k));
      Main.KeyDown(k);
    }

    /// <summary>Called when Key is Released</summary>
    /// <param name="k">Released Key Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void KeyUp(int k)
    {
      IsKeyDown[k] = false;
      KeyUpEv?.Invoke(null, new IntValEvArgs(k));
      Main.KeyUp(k);
    }

    /// <summary>Called when the Horn is Blown</summary>
    /// <param name="h">Blown Horn Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void HornBlow(int h)
    {
      HornBlowEv?.Invoke(null, new IntValEvArgs(h));
      Main.HornBlow(h);
    }

    /// <summary>Called when Door is opened</summary>
    [DllExport(CallingConvention = CalCnv)]
    static public void DoorOpen()
    {
      DoorClosed = false;
      DoorOpenEv?.Invoke(null, null);
      Main.DoorOpen();
    }

    /// <summary>Called when Door is closed</summary>
    [DllExport(CallingConvention = CalCnv)]
    static public void DoorClose()
    {
      DoorClosed = true;
      DoorCloseEv?.Invoke(null, null);
      Main.DoorClose();
    }

    /// <summary>Called when the Signal Showing Number is changed</summary>
    /// <param name="s">Signal Showing Number</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetSignal(int s)
    {
      SetSignalEv?.Invoke(null, new IntValEvArgs(s));
      Main.SetSignal(s);
    }

    /// <summary>Called when passed above the Beacon</summary>
    /// <param name="b">Beacon info</param>
    [DllExport(CallingConvention = CalCnv)]
    static public void SetBeaconData(Beacon b)
    {
      SetBeaconEv?.Invoke(null, new BeaconEvArgs(b));
      Main.SetBeaconData(b);
    }


  }

  public class TickEvArgs : EventArgs
  {
    public State state;
    public int[] panel;
    public int[] sound;
  }
  public class SpecEvArgs : EventArgs
  {
    public SpecEvArgs(in Spec s) => spec = s;
    public Spec spec;
  }
  public class IntValEvArgs
  {
    public IntValEvArgs(in int v) => val = v;
    public int val;
  }
  public class BeaconEvArgs
  {
    public BeaconEvArgs(in Beacon b) => beacon = b;
    public Beacon beacon;
  }
}
