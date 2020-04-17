using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TR.LimExpTIMS
{
  class KikuTIMS
  {
    //TIMS装置
    /*public KikuTIMS()
    {

    }
    internal bool Loaded = false;*/

    const string PIPath = "../../../TIMS_new/TIMS_new_m.dll";

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
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void KeyDown(int k);
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void KeyUp(int k);
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void HornBlow(int k);
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void DoorOpen();
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void DoorClose();
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void SetSignal(int s);
    [DllImport(PIPath, CallingConvention = CalCnv)]
    internal static extern void SetBeaconData(Beacon b);
    //[DllImport(PIPath, CallingConvention = CalCnv)]
    //internal static extern void GetPluginVersion();

    static internal bool LoadPI()
    {
      while (true)
      {
        DialogResult dr;
        try
        {
          Load();//読み込み失敗したらDllNotFoundException

          Status.No1DispBL = DispBL.Max;
          Status.TIMSDispBL = DispBL.Max;
          TIMSDisp.PageNum = TIMSPageENum.S00AB;
          
          return true;
        }
        catch (DllNotFoundException e)
        {
          dr = MessageBox.Show("自炊TIMSプラグインが見つかりません。\n" + e.Message, "LimExpTIMS", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
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
