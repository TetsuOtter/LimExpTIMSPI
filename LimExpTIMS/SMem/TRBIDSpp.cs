using System;
using System.Runtime.InteropServices;

namespace TR.LimExpTIMS
{
	public class TRBIDSpp : IAtsPI
	{
		DoDLLAct dda = new DoDLLAct();
		public bool IsLoaded { get => dda.IsLoaded; }

		//TR.BIDSpp.dll
		const string PIPath = "../../../TR/TR.BIDSSMemLib.bve5.dll";
		private const CallingConvention CalCnv = CallingConvention.StdCall;
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void Load();
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void Dispose();
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void SetVehicleSpec(Spec s);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void Initialize(int s);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern Hand Elapse(State s, IntPtr Pa, IntPtr So);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void SetPower(int p);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void SetBrake(int b);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void SetReverser(int r);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void KeyDown(int k);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void KeyUp(int k);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void HornBlow(int k);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void DoorOpen();
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void DoorClose();
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void SetSignal(int s);
		[DllImport(PIPath, CallingConvention = CalCnv)]
		private static extern void SetBeaconData(Beacon b);
		//[DllImport(PIPath, CallingConvention = CalCnv)]
		//private static extern void GetPluginVersion();

		void IAtsPI.Load() => dda.DoDLLAction(Load);

		void IAtsPI.Dispose() => dda.DoDLLAction(Dispose);

		void IAtsPI.SetVehicleSpec(Spec s) => dda.DoDLLAction(SetVehicleSpec, s);

		void IAtsPI.Initialize(int s) => dda.DoDLLAction(Initialize, s);

		Hand IAtsPI.Elapse(State s, IntPtr Pa, IntPtr So) => dda.DoDLLElapse(Elapse, s, Pa, So);

		void IAtsPI.SetPower(int p) => dda.DoDLLAction(SetPower, p);

		void IAtsPI.SetBrake(int b) => dda.DoDLLAction(SetBrake, b);

		void IAtsPI.SetReverser(int r) => dda.DoDLLAction(SetReverser, r);

		void IAtsPI.KeyDown(int k) => dda.DoDLLAction(KeyDown, k);

		void IAtsPI.KeyUp(int k) => dda.DoDLLAction(KeyUp, k);

		void IAtsPI.HornBlow(int k) => dda.DoDLLAction(HornBlow, k);

		void IAtsPI.DoorOpen() => dda.DoDLLAction(DoorOpen);

		void IAtsPI.DoorClose() => dda.DoDLLAction(DoorClose);

		void IAtsPI.SetSignal(int s) => dda.DoDLLAction(SetSignal, s);

		void IAtsPI.SetBeaconData(Beacon b) => dda.DoDLLAction(SetBeaconData, b);

		uint IAtsPI.GetPluginVersion() => IAtsPIClass.VersionNum;
	}
}
