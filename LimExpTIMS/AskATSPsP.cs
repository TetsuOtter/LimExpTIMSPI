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
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void Load();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void Dispose();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void SetVehicleSpec();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void Initialize();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void Elapse();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void SetPower();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void SetBrake();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void SetReverser();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void KeyDown();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void KeyUp();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void HornBlow();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void SetSignal();
    [DllImport("ATS.dll", CallingConvention = CalCnv)]
    internal static extern void SetBeaconData();
    //[DllImport("ATS.dll", CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();

  }
}
