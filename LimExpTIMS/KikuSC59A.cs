using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TR.LimExpTIMS
{
  class KikuSC59A
  {
    //定速 / 抑速 / 低定速
    const string PIPath = "../../../SC59A/SC59A_TRLimExpTIMS.dll";

    private const CallingConvention CalCnv = CallingConvention.StdCall;
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void Load();
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void Dispose();
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void SetVehicleSpec(Spec s);
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void Initialize(int s);
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern unsafe Hand Elapse(State s, int* Pa, int* So);
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void SetPower(int p);
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void SetBrake(int b);
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void SetReverser(int r);
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void KeyDown(int k);
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void KeyUp(int k);
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void HornBlow(int k);
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void SetSignal(int s);
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void SetBeaconData(Beacon b);
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();

    static internal bool LoadPI()
    {
      while (true)
      {
        DialogResult dr;
        try
        {
          Load();

          return true;
        }
        catch (DllNotFoundException e)
        {
          dr = MessageBox.Show("定速/抑速機能プラグインが見つかりません。\n" + e.Message, "LimExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        catch (Exception e)
        {
          dr = MessageBox.Show("エラーが発生しました。\n" + e.ToString(), "LinExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        if (dr != DialogResult.Retry) return false;
      }
    }

  }
}
