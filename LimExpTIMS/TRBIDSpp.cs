using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  class TRBIDSpp
  {
    //TR.BIDSpp.dll

    private const CallingConvention CalCnv = CallingConvention.StdCall;
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void Load();
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void Dispose();
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void SetVehicleSpec(Spec s);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void Initialize(int s);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern unsafe Hand Elapse(State s, int* Pa, int* So);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void SetPower(int p);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void SetBrake(int b);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void SetReverser(int r);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void KeyDown(int k);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void KeyUp(int k);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void HornBlow(int k);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void SetSignal(int s);
    [DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    internal static extern void SetBeaconData(Beacon b);
    //[DllImport("TR.BIDSpp.dll", CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();
  }
}
