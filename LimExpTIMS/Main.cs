using System;
using System.Windows.Forms;

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
      TIMS.TIMS_IF.Init();
      Cab.Cab_IF.Init();
    }
    static internal void Dispose() { }
    static internal void SetVehicleSpec(Spec s) { }
    static internal void Initialize(int s) { }

    static internal void Elapse(State st, IntPtr pa, IntPtr sa)
    {
      unsafe
      {
        int* p = (int*)pa;

        //Statusより適切な値を入れていく。
        //状態からPanel表示へのコンバートのみを行う。
        //状態変化は各IFから行う。
        //モードによる表示/非表示はこちらで実装

        p[PanelAssign.Ats.White] = Status.ATS_PW.ToInt();
        p[PanelAssign.Ats.Red] = Status.ATS_Trip.ToInt();
        p[PanelAssign.Ats.PPower] = Status.ATSP_PW.ToInt();
        p[PanelAssign.Ats.PPatternApproaching] = Status.ATSP_PatternComing.ToInt();
        p[PanelAssign.Ats.PBrakeDisabled] = Status.ATSP_Brake_Open.ToInt();
        p[PanelAssign.Ats.PBrakeON] = Status.ATSP_Brake_Working.ToInt();
        p[PanelAssign.Ats.PBroken] = Status.ATSP_Broken.ToInt();
        p[PanelAssign.Ats.PLamp] = Status.ATSP_PL.ToInt();
        p[PanelAssign.Ats.PEmergBrake] = Status.ATSP_EmergB.ToInt();
        p[PanelAssign.Ats.EBAlermLamp] = Status.EBAlermLamp.ToInt();
        p[PanelAssign.Ats.PsPatternCreated] = Status.ATSPs_PatternCreated.ToInt();
        p[PanelAssign.Ats.PsPatternApproaching] = Status.ATSPs_PatternComing.ToInt();
        p[PanelAssign.Ats.PsBrakeON] = Status.ATSPs_Brake_Working.ToInt();
        p[PanelAssign.Ats.PsDisabled] = Status.ATSPs_Brake_Open.ToInt();

        p[PanelAssign.Ats.PsDrivingSpeed] = Status.Keiki_ATSPsP_RunSPD;
        p[PanelAssign.Ats.PsPatternSpeed] = Status.Keiki_ATSPsP_LimSPD;

        p[PanelAssign.GCP.StraightBackupBrake] = Status.Keiki_BackupStraightB.ToInt();
        p[PanelAssign.GCP.SnowResistantBrake] = Status.Keiki_SnowResist.ToInt();

        p[PanelAssign.Cab.CabSeSLocation] = Status.DispMode == DisplayingModeENum.CabSeSShowing ? 0 : (((int)Status.CabSeS_kore) + 2);
        p[PanelAssign.Cab.MCKeyDisplay] = (int)Status.MCKey;

        p[PanelAssign.GCP.BrakeLocationDisplay] = Status.Keiki_BPos;
        p[PanelAssign.GCP.EmergencyBrakeLamp] = Status.Keiki_EmergB.ToInt();

        p[PanelAssign.Cab.MasterControllerHandle] = Status.MasCtrlPos;
        p[PanelAssign.Cab.ReverserHandle] = ((int)Status.ReverserPos) + 1;

        p[PanelAssign.GCP.ConstantSpeedLamp] = Status.Keiki_ConstSPD.ToInt();
        p[PanelAssign.GCP.HoldingSpeedLamp] = Status.Keiki_Yokusoku.ToInt();

        p[PanelAssign.TIMS.Hour] = Status.TIMS_DispTime.Hours;
        p[PanelAssign.TIMS.Minute] = Status.TIMS_DispTime.Minutes;
        p[PanelAssign.TIMS.Second] = Status.TIMS_DispTime.Seconds;

        //表示が2桁なら空白表示
        p[PanelAssign.TIMS.Speed100] = Status.TIMS_DispSpeed < 100 ? (Status.TIMS_DispSpeed / 100) % 10 : cvs.PElem_1charNum_BlankPos;

        //表示が1桁なら空白表示
        p[PanelAssign.TIMS.Speed10] = Status.TIMS_DispSpeed < 10 ? (Status.TIMS_DispSpeed / 10) % 10 : cvs.PElem_1charNum_BlankPos;

        p[PanelAssign.TIMS.Speed1] = Status.TIMS_DispSpeed % 10;


        p[PanelAssign.GCP.SpeedMeterNeedle] = Status.Keiki_DispSpeed;

        //TRUE(読み込める)ならBtn表示(Btnを載せたカバーを表示させる) FALSE(読み込めない)なら非表示
        p[PanelAssign.TIMS.D00AAICButtons] = Status.TIMSMon_PageNum == TIMSPageENum.D00AA ? Status.IC_Readable.ToInt() : 0;

        #region D04AA (一部未実装)
        p[PanelAssign.TIMS.D04AA.PassSettingButton] = Status.TIMSMon_PageNum == TIMSPageENum.D04AA ? Status.D04AA_PassSettingBtn.ToInt() : 0;
        p[PanelAssign.TIMS.D04AA.PrefixSetting] = Status.TIMSMon_PageNum == TIMSPageENum.D04AA ? (int)Status.D04AA_PrefixBtn : 0;
        p[PanelAssign.TIMS.D04AA.TenKeyModeSelectButton] = Status.TIMSMon_PageNum == TIMSPageENum.D04AA ? (int)Status.D04AA_10KeyMode : 0;
        p[PanelAssign.TIMS.D04AA.TenKeyPressState] = Status.TIMSMon_PageNum == TIMSPageENum.D04AA ? Status.D04AA_10KeyPressedNum : 0;
        p[PanelAssign.TIMS.D04AA.OtherKey] = Status.TIMSMon_PageNum == TIMSPageENum.D04AA ? (int)Status.D04AA_OtherKey : 0;

				#region Entering Train Num (未実装)

				#endregion
				#endregion

				p[PanelAssign.TIMS.D00AAButtonPushingImage] = Status.TIMSMon_PageNum == TIMSPageENum.D00AA ? (int)Status.D00AA_Btn : 0;

        #region D05AA (未実装)

        #endregion

        p[PanelAssign.TIMS.PageNameNum] = (int)Status.TIMSMon_PageNum;
        p[PanelAssign.TIMS.TsukokuJohoMonitoringChar] = (int)Status.TsukokuJoho_Char;
        p[PanelAssign.TIMS.UnkoJohoButton] = (int)Status.Unkou_Btn;
        p[PanelAssign.TIMS.ShireiJohoButton] = (int)Status.Shirei_Btn;
        p[PanelAssign.TIMS.KiseiListButton] = (int)Status.Kisei_Btn;
        p[PanelAssign.TIMS.TsukokuButton] = (int)Status.Tsukoku_Btn;

        p[PanelAssign.TIMS.ShokiSentakuButton] = Status.ShokiSentakuBtn.ToInt();

        p[PanelAssign.TIMS.D01AA.PTrainNum.NumPrefix] = Status.TIMSMon_PageNum == TIMSPageENum.D01AA ? (int)Status.PTrNum_Header : 0;
        
        if(Status.TIMSMon_PageNum== TIMSPageENum.D01AA)
        {
          p[PanelAssign.TIMS.D01AA.PTrainNum.NumPrefix] = (int)Status.PTrNum_Header;
          p[PanelAssign.TIMS.D01AA.PTrainNum.Num1000] = (Status.PTrNum_Number / 1000) % 10;
          p[PanelAssign.TIMS.D01AA.PTrainNum.Num100] = (Status.PTrNum_Number / 100) % 10;
          p[PanelAssign.TIMS.D01AA.PTrainNum.Num10] = (Status.PTrNum_Number / 10) % 10;
          p[PanelAssign.TIMS.D01AA.PTrainNum.Num1] = Status.PTrNum_Number % 10;
          p[PanelAssign.TIMS.D01AA.PTrainNum.NumSuffix1] = (int)Status.PTrNum_Footer1;
          p[PanelAssign.TIMS.D01AA.PTrainNum.NumSuffix2] = (int)Status.PTrNum_Footer2;
        }
        else
        {
          p[PanelAssign.TIMS.D01AA.PTrainNum.NumPrefix] = 0;
          p[PanelAssign.TIMS.D01AA.PTrainNum.Num1000] = cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.PTrainNum.Num100] = cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.PTrainNum.Num10] = cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.PTrainNum.Num1] = cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.PTrainNum.NumSuffix1] = 0;
          p[PanelAssign.TIMS.D01AA.PTrainNum.NumSuffix2] = 0;
        }

        //ゼロで空白 1~9で1桁, 10~99で2桁 それ以上も可
        p[PanelAssign.TIMS.Location1100] = Status.TIMS_LocationEnabled ? Status.TIMS_LocationINT / 100 : 0;
        //位置有効かつ2桁以上なら数値表示 無効か1桁なら空白
        p[PanelAssign.TIMS.Location10] = Status.TIMS_LocationEnabled && Status.TIMS_LocationINT >= 10 ? (Status.TIMS_LocationINT / 10) % 10 : cvs.PElem_1charNum_BlankPos;
        //位置無効なら空白
        p[PanelAssign.TIMS.Location1] = Status.TIMS_LocationEnabled ? Status.TIMS_LocationINT % 10 : cvs.PElem_1charNum_BlankPos;
        //位置無効なら空白扱いで「-」表示
        p[PanelAssign.TIMS.LocationPoint1] = Status.TIMS_LocationEnabled ? Status.TIMS_LocationDEC : cvs.PElem_1charNum_BlankPos;

        if (Status.TIMSMon_PageNum == TIMSPageENum.D01AA) {
          p[PanelAssign.TIMS.D01AA.UnitState1] = (int)Status.UnitState1;
          p[PanelAssign.TIMS.D01AA.UnitState2] = (int)Status.UnitState2;
          p[PanelAssign.TIMS.D01AA.UnitState3] = (int)Status.UnitState3;
          p[PanelAssign.TIMS.D01AA.UnitState4] = (int)Status.UnitState4;
          p[PanelAssign.TIMS.D01AA.DirectionArrow] = (int)Status.TIMS_DirectArrow;
          p[PanelAssign.TIMS.D01AA.EmergencyCalledCar] = Status.TIMS_EmergencyCaller;

          p[PanelAssign.TIMS.D01AA.TrainNum.NumPrefix] = (int)(Status.IsTrNumEnabled ? Status.TrNum_Header : Pnl_TIMSMon_TrainNum_Header.Blank);
          p[PanelAssign.TIMS.D01AA.TrainNum.Num1000] = Status.IsTrNumEnabled && Status.TrNum_Number >= 1000 ? (Status.TrNum_Number / 1000) % 10 : cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.TrainNum.Num100] = Status.IsTrNumEnabled && Status.TrNum_Number >= 100 ? (Status.TrNum_Number / 100) % 10 : cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.TrainNum.Num10] = Status.IsTrNumEnabled && Status.TrNum_Number >= 10 ? (Status.TrNum_Number / 10) % 10 : cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.TrainNum.Num1] = Status.IsTrNumEnabled ? Status.TrNum_Number % 10 : cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.TrainNum.NumSuffix1]= (int)(Status.IsTrNumEnabled ? Status.TrNum_Footer1 : Pnl_TIMSMon_TrainNum_Footer.Blank);
          p[PanelAssign.TIMS.D01AA.TrainNum.NumSuffix2] = (int)(Status.IsTrNumEnabled ? Status.TrNum_Footer2 : Pnl_TIMSMon_TrainNum_Footer.Blank);

          p[PanelAssign.TIMS.D01AA.PTrNumSettingEnabledLamp] = Status.IsPTrNumEnabled.ToInt();
          p[PanelAssign.TIMS.D01AA.PassSettingStateLamp] = Status.IsPassSettingEnabled.ToInt();
        }
        else
        {
          p[PanelAssign.TIMS.D01AA.UnitState1] = 0;
          p[PanelAssign.TIMS.D01AA.UnitState2] = 0;
          p[PanelAssign.TIMS.D01AA.UnitState3] = 0;
          p[PanelAssign.TIMS.D01AA.UnitState4] = 0;
          p[PanelAssign.TIMS.D01AA.DirectionArrow] = (int)direct.N;
          p[PanelAssign.TIMS.D01AA.EmergencyCalledCar] = 0;

          p[PanelAssign.TIMS.D01AA.TrainNum.NumPrefix] = (int)Pnl_TIMSMon_TrainNum_Header.Blank;
          p[PanelAssign.TIMS.D01AA.TrainNum.Num1000] = cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.TrainNum.Num100] = cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.TrainNum.Num10] = cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.TrainNum.Num1] = cvs.PElem_1charNum_BlankPos;
          p[PanelAssign.TIMS.D01AA.TrainNum.NumSuffix1] = (int)Pnl_TIMSMon_TrainNum_Footer.Blank;
          p[PanelAssign.TIMS.D01AA.TrainNum.NumSuffix2] = (int)Pnl_TIMSMon_TrainNum_Footer.Blank;

          p[PanelAssign.TIMS.D01AA.PTrNumSettingEnabledLamp] = cvs.FALSE_VALUE;
          p[PanelAssign.TIMS.D01AA.PassSettingStateLamp] = cvs.FALSE_VALUE;
        }


      }
			#region sounds
			SoundAssign.ATS_S_Chime.GetOutput(sa);
      SoundAssign.ATS_S_Bell.GetOutput(sa);

      SoundAssign.EBSystem_Buzzer.GetOutput(sa);
      SoundAssign.ATS_P_Bell.GetOutput(sa);

      SoundAssign.ATS_P_EBMsg.GetOutput(sa);
      SoundAssign.ATS_P_ReleaseMsg.GetOutput(sa);

      SoundAssign.ATS_Ps_Pattern_BrakeOut.GetOutput(sa);
      SoundAssign.ATS_Ps_Pattern_Coming.GetOutput(sa);
      SoundAssign.ATS_Ps_Pattern_Deleted.GetOutput(sa);
      SoundAssign.ATS_Ps_Brake_Trip.GetOutput(sa);

      SoundAssign.Accidental_Passage_Preventer_Stop_Once.GetOutput(sa);
      SoundAssign.Accidental_Passage_Preventer_Pass_Once.GetOutput(sa);
      //SoundAssign.Accidental_Passage_Preventer_Stop_Loop.GetOutput(sa);//不要なため削除

      SoundAssign.BougoR_Sound.GetOutput(sa);
      SoundAssign.ElecHorn.GetOutput(sa);
      SoundAssign.AirHorn_Intro.GetOutput(sa);
      SoundAssign.AirHorn_Loop.GetOutput(sa);
      SoundAssign.AirHorn_AfterGlow.GetOutput(sa);
      SoundAssign.MusicHorn.GetOutput(sa);

      SoundAssign.TiltStart_L.GetOutput(sa);
      SoundAssign.TiltStart_R.GetOutput(sa);
      SoundAssign.TiltEnd_L.GetOutput(sa);
      SoundAssign.TiltEnd_R.GetOutput(sa);

      SoundAssign.MCCtrlSound_ToEnd.GetOutput(sa);
      SoundAssign.MCCtrlSound_Inner.GetOutput(sa);
      SoundAssign.RevCtrlSound_ToN.GetOutput(sa);
      SoundAssign.RevCtrlSound_ToFR.GetOutput(sa);
      SoundAssign.MCCtrl_Failed.GetOutput(sa);
      SoundAssign.RevCtrl_Failed.GetOutput(sa);
      SoundAssign.MCKey_Ctrl_Failed.GetOutput(sa);

      SoundAssign.MCKey_Remove.GetOutput(sa);
      SoundAssign.MCKey_ToON.GetOutput(sa);
      SoundAssign.MCKey_ToOFF.GetOutput(sa);
      SoundAssign.MCKey_Insert.GetOutput(sa);
      SoundAssign.CabSeS_ToN.GetOutput(sa);
      SoundAssign.CabSeS_ToFR.GetOutput(sa);
      SoundAssign.ReduceSPD_Coming.GetOutput(sa);
      SoundAssign.ReduceSPD_Running.GetOutput(sa);
      SoundAssign.ReduceSPD_End.GetOutput(sa);

      SoundAssign.Brake_Boost_Joyo.GetOutput(sa);
      SoundAssign.Brake_Boost_Emerg.GetOutput(sa);
      SoundAssign.AirSec_Warning.GetOutput(sa);
      SoundAssign.EB_Warning_Msg.GetOutput(sa);
      SoundAssign.OP_Info_Updated_Passenger.GetOutput(sa);
      SoundAssign.Stop_Warning_Deck_Msg.GetOutput(sa);
      SoundAssign.Passenger_Emg_Buzzer.GetOutput(sa);
      SoundAssign.IC_Insert.GetOutput(sa);
      SoundAssign.IC_Remove.GetOutput(sa);
      SoundAssign.TIMS_Touch.GetOutput(sa);
      SoundAssign.TIMS_Error_01.GetOutput(sa);
      
      SoundAssign.Cab_Btn_Push.GetOutput(sa);
      SoundAssign.Cab_Btn_Release.GetOutput(sa);
      SoundAssign.ACDCChangerBtn_Push.GetOutput(sa);
      SoundAssign.ACDCChangerBtn_Release.GetOutput(sa);

      SoundAssign.HB_Sound.GetOutput(sa);
      SoundAssign.DCtoAC.GetOutput(sa);
      SoundAssign.ACtoDC.GetOutput(sa);
      SoundAssign.AirCond_OFF.GetOutput(sa);
      SoundAssign.AirCond_ON.GetOutput(sa);
      SoundAssign.AirCond_Drive.GetOutput(sa);
      #endregion
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
