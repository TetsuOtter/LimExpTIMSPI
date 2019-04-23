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

    public const CallingConvention CalCnv = CallingConvention.StdCall;
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void Load();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void Dispose();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetVehicleSpec();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void Initialize();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void Elapse();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetPower();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetBrake();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetReverser();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void KeyDown();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void KeyUp();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void HornBlow();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetSignal();
    [DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    internal static extern void SetBeaconData();
    //[DllImport("Integrated_ATS(Ps).dll", CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();

  }
}
