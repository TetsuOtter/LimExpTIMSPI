using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS
{
  public class AskATSPsP
  {
    //統合型ATS車上装置
    //Refer : https://tomosoft.jp/design/?p=4607

    private const CallingConvention CalCnv = CallingConvention.StdCall;
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void Load();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void Dispose();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetVehicleSpec(Spec s);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void Initialize(int s);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern unsafe void Elapse(State s, int* Pa, int* So);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetPower(int p);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetBrake(int b);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetReverser(int r);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void KeyDown(int k);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void KeyUp(int k);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void HornBlow(int k);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetSignal(int s);
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetBeaconData(Beacon b);
    //[DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();

  }
}
