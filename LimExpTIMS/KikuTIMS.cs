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

    public const CallingConvention CalCnv = CallingConvention.StdCall;
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void Load();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void Dispose();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetVehicleSpec();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void Initialize();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void Elapse();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetPower();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetBrake();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetReverser();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void KeyDown();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void KeyUp();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void HornBlow();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetSignal();
    [DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    internal static extern void SetBeaconData();
    //[DllImport("TIMS_new_m.dll", CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();

  }
}
