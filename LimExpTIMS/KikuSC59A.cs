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

    private const CallingConvention CalCnv = CallingConvention.StdCall;
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void Load();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void Dispose();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetVehicleSpec(Spec s);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void Initialize(int s);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern unsafe void Elapse(State s, int* Pa, int* So);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetPower(int p);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetBrake(int b);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetReverser(int r);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void KeyDown(int k);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void KeyUp(int k);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void HornBlow(int k);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetSignal(int s);
    [DllImport("SC59A.dll", CallingConvention = CalCnv)]
    internal static extern void SetBeaconData(Beacon b);
    //[DllImport("SC59A.dll", CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();

  }
}
