using System;

namespace TR.LimExpTIMS
{
	/// <summary>ボタン操作の入力を処理します。</summary>
	public class ButtonManager
	{
		public event EventHandler Pushed;
		public event EventHandler Released;

		/// <summary>操作に使用するキー</summary>
		public int Key_toCtrl { get; }
		/// <summary>操作するために必要なキー(先に押しておく必要があります。)</summary>
		public int? Key_toUse { get; }
		
		/// <summary>モード一致を確認. trueで一致状態</summary>
		public Func<bool> ModeChecker { get; }

		public bool IsPushed { get; private set; }
		public bool ModeMismatch_Pushed { get; private set; }

		/// <summary>ボタンの組み合わせを設定します。</summary>
		/// <param name="key_toCtrl">操作に使用するキー(key_toUseを指定した場合、先にそれを押しておく必要があります。)</param>
		/// <param name="key_toUse">操作するために必要なキー(指定した場合、操作にはこのキーの押下が必要になります。)</param>
		/// <param name="mode">操作の入力を受け付けるモード名</param>
		public ButtonManager(int key_toCtrl, int? key_toUse = null, Func<bool> modeChecker = null)
		{
			Key_toCtrl = key_toCtrl;
			Key_toUse = key_toUse;
			ModeChecker = modeChecker;

			Ats.KeyDownEv += Ats_KeyDownEv;
			Ats.KeyUpEv += Ats_KeyUpEv;
			if (modeChecker != null) Ats.ElapseEv += Ats_ElapseEv;//モードチェックなしの場合、そもそもイベントを購読しない。
		}

		private void Ats_ElapseEv(object sender, TickEvArgs e)
		{
			//モードチェックなしの場合、そもそもイベントを購読しない。
			if (!IsPushed && !ModeMismatch_Pushed) return;//押下状態でなく、またモード違い押下状態でもないならチェックしない。

			//モードチェック実行
			bool mcRes = ModeChecker.Invoke();//モード一致でtrue
			//モード不一致に伴うRelease扱い
			if (IsPushed && !mcRes)
			{
				IsPushed = false;
				ModeMismatch_Pushed = true;

				Released?.Invoke(this, default);

				return;
			}

			//モード一致に伴うPush扱い
			if (ModeMismatch_Pushed && mcRes)
			{
				IsPushed = true;
				ModeMismatch_Pushed = false;

				Pushed?.Invoke(null, default);

				return;
			}
		}

		private void Ats_KeyUpEv(object sender, IntValEvArgs e)
		{
			if (e.val == Key_toCtrl)
			{
				if (IsPushed) Released?.Invoke(this, default);//押下状態であった場合に限りReleaseイベントを発火させる。
				IsPushed = false;
				ModeMismatch_Pushed = false;
			}
		}

		private void Ats_KeyDownEv(object sender, IntValEvArgs e)
		{
			if (e.val == Key_toCtrl && (Key_toUse == null || Ats.IsKeyDown[Key_toUse ?? 0] == true))
			{
				//モード識別モードチェック
				if (ModeChecker != null)
				{
					//モード識別を行う
					if (ModeChecker.Invoke())//trueでモード一致
					{
						//モード一致
						IsPushed = true;
						ModeMismatch_Pushed = false;

						Pushed?.Invoke(this, default);

						return;
					}
					else
					{
						//モード不一致
						IsPushed = false;
						ModeMismatch_Pushed = false;

						return;
					}
				}
				else
				{
					//モード識別必要なし
					IsPushed = true;
					Pushed?.Invoke(this, default);

					return;
				}
			}
		}
	}
}
