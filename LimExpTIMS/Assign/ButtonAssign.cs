namespace TR.LimExpTIMS.Assign
{
	public static class ButtonAssign
	{
		#region 単独で機能する操作
		public static readonly ButtonManager TEButton = new ButtonManager(ATSKeys.A1);
		public static readonly ButtonManager EBReset = new ButtonManager(ATSKeys.A2);
		public static readonly ButtonManager ATS_Restitution = new ButtonManager(ATSKeys.B1);
		public static readonly ButtonManager ATSP_Release = new ButtonManager(ATSKeys.B2);
		#endregion

		#region モニタ輝度/音量操作
		public static readonly ButtonManager No1Mon_BL = new ButtonManager(ATSKeys.D, ATSKeys.S);
		public static readonly ButtonManager TIMSMon_Vol = new ButtonManager(ATSKeys.E, ATSKeys.S);
		public static readonly ButtonManager TIMSMon_BL = new ButtonManager(ATSKeys.F, ATSKeys.S);
		public static readonly ButtonManager No2Mon_BL = new ButtonManager(ATSKeys.G, ATSKeys.S);
		#endregion
		public const int CmbKey1 = ATSKeys.S;
		#region combo機能
		//0より下へは移動できないので、モード違い扱い。
		public static readonly ButtonManager ModeChangeToLower = new ButtonManager(ATSKeys.C1, CmbKey1,
			() => Status.DispMode > 0);

		//最大値より上へは移動できないので、モード違い扱い。
		public static readonly ButtonManager ModeChangeToBigger = new ButtonManager(ATSKeys.C2, CmbKey1,
			() => Status.DispMode < (DisplayingModeENum)(cvs.DisplayingModeENum_Count - 1));

		//ON状態でも「操作失敗音」再生のため、モード一致扱い。
		public static readonly ButtonManager MCKey_Ins_Rmv = new ButtonManager(ATSKeys.H, CmbKey1);

		//挿入さえされていれば、操作を実行できる。
		public static readonly ButtonManager MCKey_Turn = new ButtonManager(ATSKeys.I, CmbKey1, () => Status.MCKey != MCKeyStateENum.Removed);

		//音再生/表示切替のため、電源モード不一致でもイベント発火
		public static readonly ButtonManager DCBtnCtrl = new ButtonManager(ATSKeys.K, CmbKey1);
		public static readonly ButtonManager ACBtnCtrl = new ButtonManager(ATSKeys.L, CmbKey1);
		#endregion

		#region モードにより違う機能を提供する操作

		public static bool D04AAMode_Chk()
			=> Cmb_ModChk(DisplayingModeENum.D04AA) && Status.TIMSMon_PageNum == TIMSPageENum.D04AA;

		public static bool DrMode_SpecifPage(TIMSPageENum tpe)
			=> Cmb_ModChk(DisplayingModeENum.Driving) && Status.TIMSMon_PageNum == tpe;

		public static bool Cmb_ModChk(DisplayingModeENum mode)
			=> (!Ats.IsKeyDown[CmbKey1]) && Status.DispMode == mode;
		/* F/F => F
		 * F/T => T
		 * T/F => F
		 * T/T => F
		 */



		public static readonly ButtonManager TIMSMon_ShokiSentaku = new ButtonManager(ATSKeys.C1, null, () =>
		{
			if (!Cmb_ModChk(DisplayingModeENum.Driving)) return false;
			switch (Status.TIMSMon_PageNum)
			{
				case TIMSPageENum.A06AA: return false;
				case TIMSPageENum.None: return false;
				case TIMSPageENum.S00AA: return false;
				case TIMSPageENum.S00AB: return false;
				default: return true;
			}
		});

		public static readonly ButtonManager TIMSMon_S00AB_DriverBtn = new ButtonManager(ATSKeys.C2, null,
			() => DrMode_SpecifPage(TIMSPageENum.S00AB));

		public static readonly ButtonManager TIMSMon_D00AA_DrvInf1 = new ButtonManager(ATSKeys.C2, null,
			() => DrMode_SpecifPage(TIMSPageENum.D00AA));
		public static readonly ButtonManager TIMSMon_D00AA_DrvInf2 = new ButtonManager(ATSKeys.D, null,
			() => DrMode_SpecifPage(TIMSPageENum.D00AA));

		public static readonly ButtonManager TIMSMon_D00AA_BrChkInf = new ButtonManager(ATSKeys.E, null,
			() => DrMode_SpecifPage(TIMSPageENum.D00AA));
		public static readonly ButtonManager TIMSMon_D00AA_TrainNumSet = new ButtonManager(ATSKeys.F, null,
			() => DrMode_SpecifPage(TIMSPageENum.D00AA));

		public static readonly ButtonManager TIMSMon_SC_DrvM = new ButtonManager(ATSKeys.D, null, () =>
		{
			if (!Cmb_ModChk(DisplayingModeENum.Driving)) return false;

			switch (Status.TIMSMon_PageNum)
			{
				case TIMSPageENum.A01AA: return true;
				case TIMSPageENum.A06AA: return true;
				case TIMSPageENum.D01AA: return true;
				case TIMSPageENum.D04AA: return true;
				case TIMSPageENum.D05AA: return true;
				default: return false;
			}
		});
		public static readonly ButtonManager TIMSMon_SC_DrvInf = new ButtonManager(ATSKeys.E, null, () =>
		{
			if (!Cmb_ModChk(DisplayingModeENum.Driving)) return false;

			switch (Status.TIMSMon_PageNum)
			{
				case TIMSPageENum.A01AA: return true;

				case TIMSPageENum.D01AA: return true;
				case TIMSPageENum.D04AA: return true;
				case TIMSPageENum.D05AA: return true;
				default: return false;
			}
		});

		public static readonly ButtonManager TIMSMon_A06AA_GoBack = new ButtonManager(ATSKeys.C1, null,
			() => DrMode_SpecifPage(TIMSPageENum.A06AA));
		public static readonly ButtonManager TIMSMon_A06AA_Check = new ButtonManager(ATSKeys.C2, null,
			() => DrMode_SpecifPage(TIMSPageENum.A06AA));

		public static readonly ButtonManager Drive_ConstSPD = new ButtonManager(ATSKeys.J, null, () => Cmb_ModChk(DisplayingModeENum.Driving));
		public static readonly ButtonManager Drive_PanDown = new ButtonManager(ATSKeys.J, null, () => Cmb_ModChk(DisplayingModeENum.Driving));

		public static readonly ButtonManager CabNFB_VCBON = new ButtonManager(ATSKeys.C1, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
		public static readonly ButtonManager CabNFB_VCBOFF = new ButtonManager(ATSKeys.C2, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
		public static readonly ButtonManager CabNFB_TailLamp = new ButtonManager(ATSKeys.D, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
		public static readonly ButtonManager CabNFB_CurLim = new ButtonManager(ATSKeys.E, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
		public static readonly ButtonManager CabNFB_ElecBr = new ButtonManager(ATSKeys.F, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
		public static readonly ButtonManager CabNFB_SnowResBr = new ButtonManager(ATSKeys.G, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
		public static readonly ButtonManager CabNFB_DoorInterlock = new ButtonManager(ATSKeys.H, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));
		public static readonly ButtonManager CabNFB_PanUp = new ButtonManager(ATSKeys.I, null, () => Cmb_ModChk(DisplayingModeENum.CabNFBShowing));

		public static readonly ButtonManager CabSeS_toF = new ButtonManager(ATSKeys.C1, null,
			() => Cmb_ModChk(DisplayingModeENum.CabSeSShowing) && (Status.CabSeS_kore != direct.F));
		public static readonly ButtonManager CabSeS_toR = new ButtonManager(ATSKeys.C2, null,
			() => Cmb_ModChk(DisplayingModeENum.CabSeSShowing) && (Status.CabSeS_kore != direct.B));

		public static readonly ButtonManager IC_Ins_Rmv = new ButtonManager(ATSKeys.F, null,
			() => Cmb_ModChk(DisplayingModeENum.Driving));

		public static readonly ButtonManager D04AA_SFrameUp = new ButtonManager(ATSKeys.C1, null,
			() => D04AAMode_Chk());
		public static readonly ButtonManager D04AA_SFrameDown = new ButtonManager(ATSKeys.C2, null,
			() => D04AAMode_Chk());
		public static readonly ButtonManager D04AA_LFrameLeft = new ButtonManager(ATSKeys.D, null,
			() => D04AAMode_Chk());
		public static readonly ButtonManager D04AA_LFrameRight = new ButtonManager(ATSKeys.E, null,
			() => D04AAMode_Chk());
		public static readonly ButtonManager D04AA_Bt1Click = new ButtonManager(ATSKeys.F, null,
			() => D04AAMode_Chk());
		public static readonly ButtonManager D04AA_Bt2Click = new ButtonManager(ATSKeys.G, null,
			() => D04AAMode_Chk());
		public static readonly ButtonManager D04AA_Bt3Click = new ButtonManager(ATSKeys.H, null,
			() => D04AAMode_Chk());
		public static readonly ButtonManager D04AA_LArrow = new ButtonManager(ATSKeys.I, null,
			() => D04AAMode_Chk());
		public static readonly ButtonManager D04AA_RArrow = new ButtonManager(ATSKeys.J, null,
			() => D04AAMode_Chk());
		public static readonly ButtonManager D04AA_DataSet = new ButtonManager(ATSKeys.L, null,
			() => D04AAMode_Chk());
		#endregion
	}
}
