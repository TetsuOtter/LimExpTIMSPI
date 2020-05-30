using System;
using System.Runtime.CompilerServices;

using TR.LimExpTIMS.Manager;

namespace TR.LimExpTIMS.Assign
{
	using static Panel_AssignEnum;
	public enum Panel_AssignEnum
	{
		ATS_White = 0,
		ATS_Red = 1,
		PPower = 2,
		PPatternApproaching = 3,
		PBrakeDisabled = 4,
		PBrakeON = 5,
		//6 Pパターン発生
		PBroken = 7,
		PLamp = 8,
		PEmergBrake = 9,
		EBAlermLamp = 10,
		//11 Ps電源
		//12 Ps表示灯
		PsPatternCreated = 13,
		PsPatternApproaching = 14,
		PsBrakeON = 15,
		PsDisabled = 16,
		PsBroken = 17,
		PsDrivingSpeed = 18,
		PsPatternSpeed = 19,
		StraightBackupBrake = 20,
		SnowResistantBrake = 21,
		//22~27 NULL
		CabSeSLocation = 28,
		MCKeyDisplay = 29,
		BrakeLocationDisplay = 30,
		EmergencyBrakeLamp = 31,
		MasterControllerHandle = 32,
		ReverserHandle = 33,
		/// <summary>定速</summary>
		ConstantSpeedLamp = 34,
		/// <summary>抑速</summary>
		HoldingSpeedLamp = 35,
		//36 NULL
		TIMS_Hour = 37,
		TIMS_Minute = 38,
		TIMS_Second = 39,
		//40~44 NULL
		GCP_Speed100 = 45,
		GCP_Speed10 = 46,
		GCP_Speed1 = 47,
		S00AxPage = 48,
		A06AAPage = 49,
		SpeedMeterNeedle = 50,
		D00AAICButtons = 51,
		D04AA_PassSettingButton = 52,
		D04AA_PrefixSetting = 53,
		D04AA_TenKeyModeSelectButton = 54,
		D04AA_TenKeyPressState = 55,
		D04AA_OtherKey = 56,
		/// <summary>設定済列番 接頭辞</summary>
		D04AA_Cfgrd_NumPrefix = 57,
		D04AA_Cfgrd_Num1000 = 58,
		D04AA_Cfgrd_Num100 = 59,
		D04AA_Cfgrd_Num10 = 60,
		D04AA_Cfgrd_Num1 = 61,
		D04AA_Cfgrd_NumSuffix1 = 62,
		D04AA_Cfgrd_NumSuffix2 = 63,
		D04AA_Entering_NumPrefix = 64,
		D04AA_Entering_Num1000 = 65,
		D04AA_Entering_Num100 = 66,
		D04AA_Entering_Num10 = 67,
		D04AA_Entering_Num1 = 68,
		D04AA_Entering_NumSuffix1 = 69,
		D04AA_Entering_NumSuffix2 = 70,
		D00AAButtonPushingImage = 71,
		D05AA_DirectionArrow = 72,
		D05AA_CabSeSAndEBState = 73,
		D05AA_DirectBackupBrakeState = 74,
		D05AA_ATSBrakeState = 75,
		D05AA_ConductorEBAndBHEBState = 76,
		D05AA_ParkingBrakeState = 77,
		D05AA_MovementProhibitionSystemState = 78,
		PageNameNum = 79,
		TsukokuJohoMonitoringChar = 80,
		UnkoJohoButton = 81,
		ShireiJohoButton = 82,
		KiseiListButton = 83,
		TsukokuButton = 84,
		ShokiSentakuButton = 85,
		//86~90 NULL
		PTrNum_NumPrefix = 91,
		PTrNum_Num1000 = 92,
		PTrNum_Num100 = 93,
		PTrNum_Num10 = 94,
		PTrNum_Num1 = 95,
		PTrNum_NumSuffix1 = 96,
		PTrNum_NumSuffix2 = 97,
		Location1100 = 98,
		Location10 = 99,
		Location1 = 100,
		LocationPoint1 = 101,
		TIMS_CurrentSpeed1 = 102,
		TIMS_CurrentSpeed110 = 103,
		//104 NULL
		UnitState1 = 105,
		UnitState2 = 106,
		UnitState3 = 107,
		UnitState4 = 108,
		DirectionArrow = 109,
		EmergencyCalledCar = 110,
		D01AA_NumPrefix = 111,
		D01AA_Num1000 = 112,
		D01AA_Num100 = 113,
		D01AA_Num10 = 114,
		D01AA_Num1 = 115,
		D01AA_NumSuffix1 = 116,
		PTrNumSettingEnabledLamp = 117,
		PassSettingStateLamp = 118,
		D01AA_NumSuffix2 = 119,
		MRUnusualBand = 120,
		MRUnusualScale = 121,
		BC0 = 123,
		BC200 = 124,
		BC400 = 125,
		BC600 = 126,
		//127 NULL
		MRNeedle = 128,
		//129 NULL
		StaName1 = 130,
		StaName2 = 131,
		StaName3 = 132,
		StaName4 = 133,
		StaName5 = 134,
		Arr1HH = 135,
		Arr1MM = 136,
		Arr1SS = 137,
		Arr2HH = 138,
		Arr2MM = 139,
		Arr2SS = 140,
		Arr3HH = 141,
		Arr3MM = 142,
		Arr3SS = 143,
		Arr4HH = 144,
		Arr4MM = 145,
		Arr4SS = 146,
		Arr5HH = 147,
		Arr5MM = 148,
		Arr5SS = 149,

		Dep1HH = 150,
		Dep1MM = 151,
		Dep1SS = 152,
		Dep2HH = 153,
		Dep2MM = 154,
		Dep2SS = 155,
		Dep3HH = 156,
		Dep3MM = 157,
		Dep3SS = 158,
		Dep4HH = 159,
		Dep4MM = 160,
		Dep4SS = 161,
		Dep5HH = 162,
		Dep5MM = 163,
		Dep5SS = 164,

		Arr1_Sep = 170,
		Arr2_Sep = 171,
		Arr3_Sep = 172,
		Arr4_Sep = 173,
		Arr5_Sep = 174,

		TrackNum1 = 165,
		TrackNum2 = 166,
		TrackNum3 = 167,
		TrackNum4 = 168,
		TrackNum5 = 169,

		RunTime2MM = 178,
		RunTime2SS = 179,
		RunTime3MM = 180,
		RunTime3SS = 181,
		RunTime4MM = 182,
		RunTime4SS = 183,
		RunTime5MM = 184,
		RunTime5SS = 185,

		LimIN1 = 188,
		LimOUT1 = 189,
		LimIN2 = 190,
		LimOUT2 = 191,
		LimIN3 = 192,
		LimOUT3 = 193,
		LimIN4 = 194,
		LimOUT4 = 195,
		LimIN5 = 196,
		LimOUT5 = 197,

		Dep1_Sep = 198,
		Dep2_Sep = 199,
		Dep3_Sep = 200,
		Dep4_Sep = 201,
		Dep5_Sep = 202,

		StaNameN = 203,
		ArrNHH = 204,
		ArrNMM = 205,
		ArrNSS = 206,
		TrackNumN = 207,
		ArrN_Sep = 208,
		NotificationL = 209,
		NotificationR = 210,
		//211 NULL
		CabNFBBase = 212,
		CabNFB1 = 213,
		CabNFB2 = 214,
		CabNFB3 = 215,
		//216 NULL
		ACDCButton = 217,
		ACDCLamp = 218,
		ControlVolUnusual = 219,
		ControlVol10 = 220,
		ControlVol1 = 221,
		ACVolUnusual = 222,
		ACVol10000 = 223,
		ACVol1000 = 224,
		ACVol100 = 225,
		DCVolUnusual = 226,
		DCVol1000 = 227,
		DCVol100 = 228,
		DCVol10 = 229,
		ControlVolNeedle = 230,
		ACVolNeedle = 231,
		DCVolNeedle = 232,
		AccidentLamp = 233,
		ThreePhaseLamp = 234,
		//235 NULL
		VCBState = 236,
		UpperMessageArea = 237,
		LowerMessageArea = 238,
		ShortCutKeyState = 239,
		HeadState = 240,
		No1BrightAdjust = 241,
		No2BrightAdjust = 242,
		TIMSBrightAdjust = 243,
		No1BrightAdjustButton = 244,
		No2BrightAdjustButton = 245,
		TIMSBrightAdjustButton = 246,
		TIMSVolumeAdjustButton = 247,
		D0nXXBase = 248,
		RadioChannelNum = 249,
		HELP1 = 250,
		HELP2 = 251,
		EmergecyCallButton = 252,
		ICReaderWriter = 253,
		BougoNotificator = 254,
		A01AA_EmergencyCalledCar = 255
	}
	public static class PanelAssign
	{
		static PanelAssign()
		{
			//PanelAssign配列の初期値はnull
			ATS_White.PLSet((_) => Status.ATS_PW);
			ATS_Red.PLSet((_) => Status.ATS_Trip);
			PPower.PLSet((_) => Status.ATSP_PW);
			PPatternApproaching.PLSet((_) => Status.ATSP_PatternComing);
			PBrakeDisabled.PLSet((_) => Status.ATSP_Brake_Open);
			PBrakeON.PLSet((_) => Status.ATSP_Brake_Working);
			PBroken.PLSet((_) => Status.ATSP_Broken);
			PLamp.PLSet((_) => Status.ATSP_PL);
			PEmergBrake.PLSet((_) => Status.ATSP_EmergB);
			EBAlermLamp.PLSet((_) => Status.EBAlermLamp);
			PsPatternCreated.PLSet((_) => Status.ATSPs_PatternCreated);
			PsPatternApproaching.PLSet((_) => Status.ATSPs_PatternComing);
			PsBrakeON.PLSet((_) => Status.ATSPs_Brake_Working);
			PsDisabled.PLSet((_) => Status.ATSPs_Brake_Open);
			PsDrivingSpeed.DNSet((_) => Status.Keiki_ATSPsP_RunSPD);
			PsPatternSpeed.DNSet((_) => Status.Keiki_ATSPsP_LimSPD);
			StraightBackupBrake.PLSet((_) => Status.Keiki_BackupStraightB);
			SnowResistantBrake.PLSet((_) => Status.Keiki_SnowResist);
			CabSeSLocation.DNSet(PanelElemShowStates.CabSeSLocation, (_) => Status.CabSeS_kore + 2);//CabSeSの表示バイアスは「2」
			MCKeyDisplay.DNSet((_) => Status.MCKey);
			BrakeLocationDisplay.DNSet((_) => Status.Keiki_BPos);
			EmergencyBrakeLamp.PLSet((_) => Status.Keiki_EmergB);
			MasterControllerHandle.DNSet((_) => Status.MasCtrlPos);
			ReverserHandle.DNSet((_) => Status.ReverserPos + 1);//レバーサーの表示バイアスは「1」
			ConstantSpeedLamp.PLSet((_) => Status.Keiki_ConstSPD);
			HoldingSpeedLamp.PLSet((_) => Status.Keiki_Yokusoku);
			TIMS_Hour.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.TIMS_DispTime.Hours);
			TIMS_Minute.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.TIMS_DispTime.Minutes);
			TIMS_Second.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.TIMS_DispTime.Seconds);
			GCP_Speed100.DNSet(PanelElemShowStates.GCP_Speed100, (_) => Status.Keiki_DispSpeed.NumPlaceOf(100));
			GCP_Speed10.DNSet(PanelElemShowStates.GCP_Speed10, (_) => Status.Keiki_DispSpeed.NumPlaceOf(10));
			GCP_Speed1.DNSet((_) => Status.Keiki_DispSpeed % 10);
			S00AxPage.DNSet(PanelElemShowStates.S00AxPage, (_) =>
			{
				if (Status.TIMSMon_PageNum == TIMSPageENum.S00AA) return Pnl_TIMSMon_S00Ax.S00AA;
				else if (Status.TIMSMon_PageNum == TIMSPageENum.S00AB)
				{
					if (Status.IsThereOpInfo)
					{
						if (Status.S00AB_UteshiBtnPushed) return Pnl_TIMSMon_S00Ax.S00AB_DriverBtn_Push;//運行情報あり Btn押下あり
						else return (int)Pnl_TIMSMon_S00Ax.S00AB;//運行情報あり Btn押下なし
					}
					else if (Status.S00AB_UteshiBtnPushed) return Pnl_TIMSMon_S00Ax.S00AB_DBtnPush_NODATA;//運行情報なし Btn押下あり
					else return Pnl_TIMSMon_S00Ax.S00AB_NO_DATA;//運行情報なし Btn押下なし
				}
				else return Pnl_TIMSMon_S00Ax.Blank;
			});
			A06AAPage.DNSet(PanelElemShowStates.A06AAPage, (_) => 0);//NotImplemented////////////////////////////////////////////////
			SpeedMeterNeedle.DNSet((_) => Status.Keiki_DispSpeed);
			D00AAICButtons.PLSet(PanelElemShowStates.IsD00AA, (_) => Status.IC_Readable);
			D04AA_PassSettingButton.PLSet(PanelElemShowStates.IsD04AA, (_) => Status.D04AA_PassSettingBtnPushed);
			D04AA_PrefixSetting.DNSet(PanelElemShowStates.IsD04AA, (_) => Status.D04AA_SelectedPrefixBtn);
			D04AA_TenKeyModeSelectButton.DNSet(PanelElemShowStates.IsD04AA, (_) => Status.D04AA_Selected10KeyMode);
			D04AA_TenKeyPressState.DNSet(PanelElemShowStates.IsD04AA, (_) => Status.D04AA_10KeyPressedNum);
			D04AA_OtherKey.DNSet(PanelElemShowStates.IsD04AA, (_) => Status.D04AA_OtherKey);

			D04AA_Cfgrd_NumPrefix.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Cfgrd_Num1000.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Cfgrd_Num100.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Cfgrd_Num10.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Cfgrd_Num1.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Cfgrd_NumSuffix1.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Cfgrd_NumSuffix2.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Entering_NumPrefix.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Entering_Num1000.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Entering_Num100.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Entering_Num10.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Entering_Num1.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Entering_NumSuffix1.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D04AA_Entering_NumSuffix2.DNSet(PanelElemShowStates.IsD04AA);//NotImplemented////////////////////////////////////////////////
			D00AAButtonPushingImage.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.D00AA_Btn);
			D05AA_DirectionArrow.DNSet(PanelElemShowStates.IsD05AA);
			D05AA_CabSeSAndEBState.DNSet(PanelElemShowStates.IsD05AA);
			D05AA_DirectBackupBrakeState.DNSet(PanelElemShowStates.IsD05AA);
			D05AA_ATSBrakeState.DNSet(PanelElemShowStates.IsD05AA);
			D05AA_ConductorEBAndBHEBState.DNSet(PanelElemShowStates.IsD05AA);
			D05AA_ParkingBrakeState.DNSet(PanelElemShowStates.IsD05AA);
			D05AA_MovementProhibitionSystemState.DNSet(PanelElemShowStates.IsD05AA);
			PageNameNum.DNSet((_) => Status.TIMSMon_PageNum);
			TsukokuJohoMonitoringChar.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.TsukokuJoho_Char);
			UnkoJohoButton.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.Unkou_Btn);
			ShireiJohoButton.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.Shirei_Btn);
			KiseiListButton.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.Kisei_Btn);
			TsukokuButton.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.Tsukoku_Btn);
			ShokiSentakuButton.PLSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.ShokiSentakuBtnPushed);
			//86~90 NULL
			PTrNum_NumPrefix.DNSet(PanelElemShowStates.ATS_Enabled, (_) => Status.PTrNum_Header);//通過設定/P列番系はATSが有効化されてないと効果なし
			PTrNum_Num1000.DNSet(PanelElemShowStates.ATS_Enabled, (_) => Status.PTrNum_Number.NumPlaceOf(1000));//通過設定/P列番系はATSが有効化されてないと効果なし
			PTrNum_Num100.DNSet(PanelElemShowStates.ATS_Enabled, (_) => Status.PTrNum_Number.NumPlaceOf(100));//通過設定/P列番系はATSが有効化されてないと効果なし
			PTrNum_Num10.DNSet(PanelElemShowStates.ATS_Enabled, (_) => Status.PTrNum_Number.NumPlaceOf(10));//通過設定/P列番系はATSが有効化されてないと効果なし
			PTrNum_Num1.DNSet(PanelElemShowStates.ATS_Enabled, (_) => Status.PTrNum_Number);//通過設定/P列番系はATSが有効化されてないと効果なし
			PTrNum_NumSuffix1.DNSet(PanelElemShowStates.ATS_Enabled, (_) => Status.PTrNum_Footer1);//通過設定/P列番系はATSが有効化されてないと効果なし
			PTrNum_NumSuffix2.DNSet(PanelElemShowStates.ATS_Enabled, (_) => Status.PTrNum_Footer2);//通過設定/P列番系はATSが有効化されてないと効果なし
			Location1100.DNSet(PanelElemShowStates.TIMS_Location, (_) => Status.TIMS_LocationINT / 100);
			Location10.DNSet(PanelElemShowStates.TIMS_Location, (_) => Status.TIMS_LocationINT.NumPlaceOf(10));
			Location1.DNSet(PanelElemShowStates.TIMS_Location, (_) => Status.TIMS_LocationINT % 10);
			LocationPoint1.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.TIMS_LocationEnabled ? Status.TIMS_LocationDEC : cvs.PElem_LocationDEC_DisabledChar);
			TIMS_CurrentSpeed1.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.TIMS_DispSpeed % 10);
			TIMS_CurrentSpeed110.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.TIMS_DispSpeed / 10);
			//104 NULL
			UnitState1.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.UnitState1);
			UnitState2.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.UnitState2);
			UnitState3.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.UnitState3);
			UnitState4.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.UnitState4);
			DirectionArrow.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.TIMS_DirectArrow + 1);//バイアスは「1」
			EmergencyCalledCar.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.TIMS_EmergencyCaller);
			D01AA_NumPrefix.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.TrNum_Header);
			D01AA_Num1000.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.TrNum_Number >= 1000 ? Status.TrNum_Number.NumPlaceOf(1000) : int.MaxValue);
			D01AA_Num100.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.TrNum_Number >= 100 ? Status.TrNum_Number.NumPlaceOf(100) : int.MaxValue);
			D01AA_Num10.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.TrNum_Number >= 10 ? Status.TrNum_Number.NumPlaceOf(10) : int.MaxValue);
			D01AA_Num1.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.TrNum_Number >= 1 ? Status.TrNum_Number % 10 : int.MaxValue);
			D01AA_NumSuffix1.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.TrNum_Footer1);
			PTrNumSettingEnabledLamp.PLSet(PanelElemShowStates.ATS_Enabled, (_) => Status.IsPTrNumEnabled);//通過設定/P列番系はATSが有効化されてないと効果なし
			PassSettingStateLamp.PLSet(PanelElemShowStates.ATS_Enabled, (_) => Status.IsPassSettingEnabled);//通過設定/P列番系はATSが有効化されてないと効果なし
			D01AA_NumSuffix2.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.TrNum_Footer2);
			MRUnusualBand.DNSet(PanelElemShowStates.MR_Unusual, PanelElemShowStates.MRPres_DispNum);
			MRUnusualScale.PLSet(PanelElemShowStates.MR_Unusual, (_) => true);
			BC0.DNSet((_) => Status.Keiki_BCPres >= 200 ? 10 : (Status.Keiki_BCPres / cvs.BC_PresDisp_PresStep));
			BC200.DNSet((_) => Status.Keiki_BCPres >= 400 ? 10 : ((Status.Keiki_BCPres - 200) / cvs.BC_PresDisp_PresStep));
			BC400.DNSet((_) => Status.Keiki_BCPres >= 600 ? 10 : ((Status.Keiki_BCPres - 400) / cvs.BC_PresDisp_PresStep));
			BC600.DNSet((_) => (Status.Keiki_BCPres - 600) / cvs.BC_PresDisp_PresStep);//800kPa以上は任意実装
			//127 NULL
			MRNeedle.DNSet(PanelElemShowStates.MRPres_DispNum);
			//129 NULL
			StaName1.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.StaIndex);
			StaName2.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.StaIndex);
			StaName3.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.StaIndex);
			StaName4.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.StaIndex);
			StaName5.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.StaIndex);
			Arr1HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.Arrive.HH ?? int.MaxValue);//nullなら非表示
			Arr1MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.Arrive.MM ?? int.MaxValue);//nullなら非表示
			Arr1SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.Arrive.SS);
			Arr2HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.Arrive.HH ?? int.MaxValue);//nullなら非表示
			Arr2MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.Arrive.MM ?? int.MaxValue);//nullなら非表示
			Arr2SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.Arrive.SS);
			Arr3HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.Arrive.HH ?? int.MaxValue);//nullなら非表示
			Arr3MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.Arrive.MM ?? int.MaxValue);//nullなら非表示
			Arr3SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.Arrive.SS);
			Arr4HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.Arrive.HH ?? int.MaxValue);//nullなら非表示
			Arr4MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.Arrive.MM ?? int.MaxValue);//nullなら非表示
			Arr4SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.Arrive.SS);
			Arr5HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.Arrive.HH ?? int.MaxValue);//nullなら非表示
			Arr5MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.Arrive.MM ?? int.MaxValue);//nullなら非表示
			Arr5SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.Arrive.SS);

			Dep1HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.Depart.HH ?? int.MaxValue);//nullなら非表示
			Dep1MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.Depart.MM ?? int.MaxValue);//nullなら非表示
			Dep1SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.Depart.SS);
			Dep2HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.Depart.HH ?? int.MaxValue);//nullなら非表示
			Dep2MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.Depart.MM ?? int.MaxValue);//nullなら非表示
			Dep2SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.Depart.SS);
			Dep3HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.Depart.HH ?? int.MaxValue);//nullなら非表示
			Dep3MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.Depart.MM ?? int.MaxValue);//nullなら非表示
			Dep3SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.Depart.SS);
			Dep4HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.Depart.HH ?? int.MaxValue);//nullなら非表示
			Dep4MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.Depart.MM ?? int.MaxValue);//nullなら非表示
			Dep4SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.Depart.SS);
			Dep5HH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.Depart.HH ?? int.MaxValue);//nullなら非表示
			Dep5MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.Depart.MM ?? int.MaxValue);//nullなら非表示
			Dep5SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.Depart.SS);

			Arr1_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.Arrive_Sep);
			Arr2_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.Arrive_Sep);
			Arr3_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.Arrive_Sep);
			Arr4_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.Arrive_Sep);
			Arr5_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.Arrive_Sep);

			TrackNum1.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.TrackNum);
			TrackNum2.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.TrackNum);
			TrackNum3.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.TrackNum);
			TrackNum4.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.TrackNum);
			TrackNum5.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.TrackNum);

			RunTime2MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.TimeDst.MM ?? int.MaxValue);
			RunTime2SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.TimeDst.SS);
			RunTime3MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.TimeDst.MM ?? int.MaxValue);
			RunTime3SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.TimeDst.SS);
			RunTime4MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.TimeDst.MM ?? int.MaxValue);
			RunTime4SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.TimeDst.SS);
			RunTime5MM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.TimeDst.MM ?? int.MaxValue);
			RunTime5SS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.TimeDst.SS);

			LimIN1.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.ArrLimitSPD ?? int.MaxValue);
			LimOUT1.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.DepLimitSPD ?? int.MaxValue);
			LimIN2.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.ArrLimitSPD ?? int.MaxValue);
			LimOUT2.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.DepLimitSPD ?? int.MaxValue);
			LimIN3.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.ArrLimitSPD ?? int.MaxValue);
			LimOUT3.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.DepLimitSPD ?? int.MaxValue);
			LimIN4.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.ArrLimitSPD ?? int.MaxValue);
			LimOUT4.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.DepLimitSPD ?? int.MaxValue);
			LimIN5.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.ArrLimitSPD ?? int.MaxValue);
			LimOUT5.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.DepLimitSPD ?? int.MaxValue);

			Dep1_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FirstRow?.Depart_Sep);
			Dep2_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.SecondRow?.Depart_Sep);
			Dep3_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.ThirdRow?.Depart_Sep);
			Dep4_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FourthRow?.Depart_Sep);
			Dep5_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.FifthRow?.Depart_Sep);

			StaNameN.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.NextStop?.StaIndex);
			ArrNHH.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.NextStop?.Arrive.HH ?? int.MaxValue);
			ArrNMM.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.NextStop?.Arrive.MM ?? int.MaxValue);
			ArrNSS.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.NextStop?.Arrive.SS);
			TrackNumN.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.NextStop?.TrackNum);
			ArrN_Sep.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.NextStop?.Arrive_Sep);
			NotificationL.DNSet(PanelElemShowStates.TIMS_Notification, (_) => 0);//NotImplemented////////////////////////////////////////////////
			NotificationR.DNSet(PanelElemShowStates.TIMS_Notification, (_) => 0);//NotImplemented////////////////////////////////////////////////
			//211 NULL
			CabNFBBase.PLSet(PanelElemShowStates.CabNFB, (_) => true);
			CabNFB1.DNSet(PanelElemShowStates.CabNFB, (_) => 0);//NotImplemented////////////////////////////////////////////////
			CabNFB2.DNSet(PanelElemShowStates.CabNFB, (_) => 0);//NotImplemented////////////////////////////////////////////////
			CabNFB3.DNSet(PanelElemShowStates.CabNFB, (_) => 0);//NotImplemented////////////////////////////////////////////////
			//216 NULL
			ACDCButton.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			ACDCLamp.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			ControlVolUnusual.PLSet(PanelElemShowStates.CtrlVUnusual, (_) => true);
			ControlVol10.DNSet(PanelElemShowStates.CtrlVUnusual, (_) => Status.Voltage_DC100V >= 10 ? Status.Voltage_DC100V.NumPlaceOf(10) : int.MaxValue);
			ControlVol1.DNSet(PanelElemShowStates.CtrlVUnusual, (_) => Status.Voltage_DC100V % 10);
			ACVolUnusual.PLSet(PanelElemShowStates.SourceACUnusual, (_) => true);
			ACVol10000.DNSet(PanelElemShowStates.SourceACUnusual, (_) => Status.SourceVoltage_AC >= 10000 ? Status.SourceVoltage_AC.NumPlaceOf(10000) : int.MaxValue);
			ACVol1000.DNSet(PanelElemShowStates.SourceACUnusual, (_) => Status.SourceVoltage_AC >= 1000 ? Status.SourceVoltage_AC.NumPlaceOf(1000) : int.MaxValue);
			ACVol100.DNSet(PanelElemShowStates.SourceACUnusual, (_) => Status.SourceVoltage_AC >= 100 ? Status.SourceVoltage_AC.NumPlaceOf(100) : cvs.PElem_Num_BlankPos);//通常は空白文字が配置されるところに「0」を配置する. arr[0]は"000"
			DCVolUnusual.PLSet(PanelElemShowStates.SourceDCUnusual, (_) => true);
			DCVol1000.DNSet(PanelElemShowStates.SourceDCUnusual, (_) => Status.SourceVoltage_DC >= 1000 ? Status.SourceVoltage_DC.NumPlaceOf(1000) : int.MaxValue);
			DCVol100.DNSet(PanelElemShowStates.SourceDCUnusual, (_) => Status.SourceVoltage_DC >= 100 ? Status.SourceVoltage_DC.NumPlaceOf(100) : int.MaxValue);
			DCVol10.DNSet(PanelElemShowStates.SourceDCUnusual, (_) => Status.SourceVoltage_DC >= 10 ? Status.SourceVoltage_DC.NumPlaceOf(10) : cvs.PElem_Num_BlankPos);//通常は空白文字が配置されるところに「0」を配置する. arr[0]は"00"
			ControlVolNeedle.DNSet((_) => Status.Voltage_DC100V);
			ACVolNeedle.DNSet((_) => Status.SourceVoltage_AC);
			DCVolNeedle.DNSet((_) => Status.SourceVoltage_DC);
			AccidentLamp.PLSet((_) => Status.Keiki_Jiko);
			ThreePhaseLamp.PLSet((_) => Status.Keiki_3Phase);
			//235 NULL
			VCBState.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			UpperMessageArea.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => 0);//NotImplemented////////////////////////////////////////////////
			LowerMessageArea.DNSet(PanelElemShowStates.TIMS_LowerBar, (_) => 0);//NotImplemented////////////////////////////////////////////////
			ShortCutKeyState.DNSet(PanelElemShowStates.TIMS_LowerBar, (_) => 0);//NotImplemented////////////////////////////////////////////////
			HeadState.DNSet(PanelElemShowStates.OutOfCar, (_) => 0);
			No1BrightAdjust.DNSet((_) => Status.No1DispBL);
			No2BrightAdjust.DNSet((_) => Status.No2DispBL);
			TIMSBrightAdjust.DNSet((_) => Status.TIMSDispBL);
			No1BrightAdjustButton.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			No2BrightAdjustButton.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			TIMSBrightAdjustButton.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			TIMSVolumeAdjustButton.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			D0nXXBase.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			RadioChannelNum.DNSet(PanelElemShowStates.IsD01AA, (_) => Status.Radio_CH);
			HELP1.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			HELP2.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			EmergecyCallButton.DNSet(PanelElemShowStates.TIMS_UpperBar, (_) => Status.Emerg_Warning_WC_Btn);
			ICReaderWriter.DNSet((_) => Status.IC_RW);
			BougoNotificator.DNSet((_) => 0);//NotImplemented////////////////////////////////////////////////
			A01AA_EmergencyCalledCar.DNSet(PanelElemShowStates.IsA01AA, (_) => Status.TIMS_EmergencyCaller);

		}

		public static readonly PanelManager[] Elements = new PanelManager[cvs.PSArrayLength];
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void PLSet(this Panel_AssignEnum num, Func<bool> showChecker = null, Func<PanelManager, object> rawVGetter = null) => Elements[(int)num] = new PilotLamp((int)num, showChecker, rawVGetter);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void PLSet(this Panel_AssignEnum num, Func<PanelManager, object> rawVGetter) => PLSet(num, null, rawVGetter);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void DNSet(this Panel_AssignEnum num, Func<bool> showChecker = null, Func<PanelManager, object> rawVGetter = null) => Elements[(int)num] = new DigitalNumber((int)num, showChecker, rawVGetter);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void DNSet(this Panel_AssignEnum num, Func<PanelManager, object> rawVGetter) => DNSet(num, null, rawVGetter);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PanelManager Pick(this Panel_AssignEnum num) => Elements[(int)num];
	}
}
