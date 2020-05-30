using System.Runtime.CompilerServices;

namespace TR.LimExpTIMS.Assign
{
	using static Sound_AssignEnum;
	public enum Sound_AssignEnum
	{
		ATS_S_Bell = 0,
		ATS_S_Chime = 1,

		EBSystem_Buzzer = 3,
		ATS_P_Bell = 4,

		ATS_P_EBMsg = 6,
		ATS_P_ReleaseMsg = 7,


		ATS_Ps_Pattern_BrakeOut = 10,
		ATS_Ps_Pattern_Coming = 11,
		ATS_Ps_Pattern_Deleted = 12,
		ATS_Ps_Brake_Trip = 13,

		Accidental_Passage_Preventer_Stop_Once = 15,
		Accidental_Passage_Preventer_Pass_Once = 16,
		//Accidental_Passage_Preventer_Stop_Loop = 17,//不要なため削除


		BougoR_Sound = 30,
		ElecHorn = 31,
		AirHorn_Intro = 32,
		AirHorn_Loop = 33,
		AirHorn_AfterGlow = 34,
		MusicHorn = 35,


		TiltStart_L = 41,
		TiltStart_R = 42,
		TiltEnd_L = 43,
		TiltEnd_R = 44,


		MCCtrlSound_ToEnd = 50,
		MCCtrlSound_Inner = 51,
		RevCtrlSound_ToN = 52,
		RevCtrlSound_ToFR = 53,
		MCCtrl_Failed = 54,
		RevCtrl_Failed = 55,
		MCKey_Ctrl_Failed = 56,

		MCKey_Remove = 89,
		MCKey_ToON = 90,
		MCKey_ToOFF = 91,
		MCKey_Insert = 92,
		CabSeS_ToN = 93,
		CabSeS_ToFR = 94,
		ReduceSPD_Coming = 95,//繰り返しはPIで実装
		ReduceSPD_Running = 96,//繰り返しはPIで実装
		ReduceSPD_End = 97,

		Brake_Boost_Joyo = 100,
		Brake_Boost_Emerg = 101,
		AirSec_Warning = 102,//繰り返しはPIで実装
		EB_Warning_Msg = 103,
		OP_Info_Updated_Passenger = 104,
		Stop_Warning_Deck_Msg = 107,
		Passenger_Emg_Buzzer = 108,
		IC_Insert = 109,
		IC_Remove = 110,
		TIMS_Touch = 111,
		TIMS_Error_01 = 112,


		Cab_Btn_Push = 115,
		Cab_Btn_Release = 116,
		ACDCChangerBtn_Push = 117,
		ACDCChangerBtn_Release = 118,


		HB_Sound = 225,
		DCtoAC = 226,
		ACtoDC = 227,
		AirCond_OFF = 228,
		AirCond_ON = 229,
		AirCond_Drive = 230
	}
	public static class SoundAssign
	{
		static SoundAssign()
		{
			ATS_S_Bell.Loop();
			ATS_S_Chime.Loop();

			EBSystem_Buzzer.Loop();
			ATS_P_Bell.Once();

			ATS_P_EBMsg.Once();
			ATS_P_ReleaseMsg.Once();


			ATS_Ps_Pattern_BrakeOut.Once();
			ATS_Ps_Pattern_Coming.Once();
			ATS_Ps_Pattern_Deleted.Once();
			ATS_Ps_Brake_Trip.Once();

			Accidental_Passage_Preventer_Stop_Once.Once();
			Accidental_Passage_Preventer_Pass_Once.Once();
			//Accidental_Passage_Preventer_Stop_Loop.Loop();17//不要なため削除


			BougoR_Sound.Loop();
			ElecHorn.Loop();
			AirHorn_Intro.Once();
			AirHorn_Loop.Loop();
			AirHorn_AfterGlow.Once();
			MusicHorn.Once();


			TiltStart_L.Once();
			TiltStart_R.Once();
			TiltEnd_L.Once();
			TiltEnd_R.Once();


			MCCtrlSound_ToEnd.Once();
			MCCtrlSound_Inner.Once();
			RevCtrlSound_ToN.Once();
			RevCtrlSound_ToFR.Once();
			MCCtrl_Failed.Once();
			RevCtrl_Failed.Once();
			MCKey_Ctrl_Failed.Once();

			MCKey_Remove.Once();
			MCKey_ToON.Once();
			MCKey_ToOFF.Once();
			MCKey_Insert.Once();
			CabSeS_ToN.Once();
			CabSeS_ToFR.Once();
			ReduceSPD_Coming.Once(cvs.ReduceSpeed_ComingMsgCycle);//繰り返しはPIで実装
			ReduceSPD_Running.Once(cvs.ReduceSpeed_RunningMsgCycle);//繰り返しはPIで実装
			ReduceSPD_End.Once();

			Brake_Boost_Joyo.Once();
			Brake_Boost_Emerg.Once();
			AirSec_Warning.Once(cvs.AirSec_Warning_MsgCycle);//繰り返しはPIで実装
			EB_Warning_Msg.Once();
			OP_Info_Updated_Passenger.Once();
			Stop_Warning_Deck_Msg.Once();
			Passenger_Emg_Buzzer.Loop();
			IC_Insert.Once();
			IC_Remove.Once();
			TIMS_Touch.Once();
			TIMS_Error_01.Loop();


			Cab_Btn_Push.Once();
			Cab_Btn_Release.Once();
			ACDCChangerBtn_Push.Once();
			ACDCChangerBtn_Release.Once();


			HB_Sound.Once();
			DCtoAC.Once();
			ACtoDC.Once();
			AirCond_OFF.Once();
			AirCond_ON.Once();
			AirCond_Drive.Loop();
		}

		public static readonly SoundManager[] Elements = new SoundManager[cvs.PSArrayLength];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Loop(this Sound_AssignEnum num, int? loopInterval = null) => Elements[(int)num] = new SoundManager(SoundManager.PlayType.PlayLoop, (int)num, loopInterval);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Once(this Sound_AssignEnum num, int? loopInterval=null)=> Elements[(int)num] = new SoundManager(SoundManager.PlayType.PlayOnce, (int)num, loopInterval);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SoundManager Pick(this Sound_AssignEnum num) => Elements[(int)num];
	}
}
