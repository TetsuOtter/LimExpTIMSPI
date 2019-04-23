using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  class KikuTIMS
  {
    //TIMS装置

    private const CallingConvention CalCnv = CallingConvention.StdCall;
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void Load();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void Dispose();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetVehicleSpec(Spec s);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void Initialize(int s);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern unsafe void Elapse(State s, int* Pa, int* So);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetPower(int p);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetBrake(int b);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetReverser(int r);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void KeyDown(int k);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void KeyUp(int k);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void HornBlow(int k);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetSignal(int s);
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetBeaconData(Beacon b);
    //[DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();

  }
}
