using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

using TR.LimExpTIMS.Assign;
using TR.LimExpTIMS.TIMS;

namespace TR.LimExpTIMS
{
		/// <summary>メインの機能をここに実装する。</summary>
		static internal class Main
	{
		static internal void Load()
		{
#if DEBUG
			MessageBox.Show("LimExpTIMSPI Debug Build");//If you don't need, please remove it.
#endif

			ATSPsP.ATSIF.Init();
			TIMS_IF.Init();
			Cab.Cab_IF.Init();
		}
		static internal void Dispose() { }
		static internal void SetVehicleSpec(Spec s) { }
		static internal void Initialize(int s) { }

		static internal void Elapse(State st, IntPtr pa, IntPtr sa)
		{
			Parallel.For(0, PanelAssign.Elements.Length, (i) => PanelAssign.Elements[i]?.GetOutput(pa));

			Parallel.For(0, SoundAssign.Elements.Length, (i) => SoundAssign.Elements[i]?.GetOutput(sa));
		}
		static internal void SetPower(int p) { }
		static internal void SetBrake(int b) { }
		static internal void SetReverser(int r) { }
		static internal void KeyDown(int k) { }
		static internal void KeyUp(int k) { }
		static internal void DoorOpen() { }
		static internal void DoorClose() { }
		static internal void HornBlow(int h) { }
		static internal void SetSignal(int s) { }
		static internal void SetBeaconData(Beacon b) { }
	}
}
