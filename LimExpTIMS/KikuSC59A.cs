using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  class KikuSC59A
  {
    //定速 / 抑速 / 低定速

    public const CallingConvention CalCnv = CallingConvention.StdCall;
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void Load();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void Dispose();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetVehicleSpec();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void Initialize();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void Elapse();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetPower();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetBrake();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetReverser();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void KeyDown();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void KeyUp();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void HornBlow();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetSignal();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetBeaconData();
    //[DllImport("SC59A.dll", CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();

  }
}
