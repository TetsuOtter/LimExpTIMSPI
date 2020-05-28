using System;

namespace TR.LimExpTIMS.Manager
{
	/// <summary>Panel表示を管理するクラス</summary>
	/// <typeparam name="T">Raw値の型</typeparam>
	public abstract class PanelManager<T> where T : struct
	{
		/// <summary>非表示状態を意味する値を指定します.</summary>
		public abstract int HiddenValue { get; }
		/// <summary>Panel表示を管理するクラスを初期化します.</summary>
		/// <param name="assign">Panel要素のアサイン</param>
		/// <param name="showChecker">表示非表示を判定する際に使用する関数</param>
		/// <param name="rawValueGetter">値の取得処理を実装した関数</param>
		public PanelManager(int assign, Func<bool> showChecker = null, Func<PanelManager<T>, T> rawValueGetter = null)
		{
			Assign = assign;
			ShowChecker = showChecker;
			RawValueGetter = rawValueGetter;
		}
		/// <summary>Panel表示を管理するクラスを初期化します.</summary>
		/// <param name="assign">Panel要素のアサイン</param>
		/// <param name="showChecker">表示非表示を判定する際に使用する関数</param>
		/// <param name="rawValueGetter">値の取得処理を実装した関数</param>
		public PanelManager(int assign, Func<PanelManager<T>, T> rawValueGetter)
		{
			Assign = assign;
			RawValueGetter = rawValueGetter;
		}
		/// <summary>
		/// 任意に設定できる非表示設定
		/// <para>この設定に有意な値が入った場合, ShowCheckerよりも優先されます.</para>
		/// </summary>
		public bool? IsVisible { get; set; } = null;
		private int __value = 0;
		/// <summary>当該インスタンスが表示する値</summary>
		public int Value
		{
			get
			{
				if (RawValueGetter != null) RawValue = RawValueGetter(this);
				//IsVがtrue(nullでもfalseでもない)=>表示
				// OR
				//IsVがnullかつShowChkがfalseでない(null or true)=>表示
				//上記以外は非表示
				return IsVisible == true || (IsVisible == null && ShowChecker?.Invoke() != false) ? __value : HiddenValue;
			}
			protected set => __value = value;
		}
		/// <summary>当該インスタンスのアサイン</summary>
		public int Assign { get; }
		/// <summary>値の入力を受け, 適切な値をValueに入れます.</summary>
		public abstract T RawValue { get; set; }//Valueへの代入はoverrideで実装してもらう.

		/// <summary>表示非表示を設定します.</summary>
		private Func<bool> ShowChecker { get; }
		/// <summary>Assign決定時に値の取得処理も実装してしまう</summary>
		private Func<PanelManager<T>, T> RawValueGetter { get; }
	}

	public class DigitalNumber : PanelManager<int>
	{
		public DigitalNumber(int assign, Func<bool> showChecker = null, Func<PanelManager<int>, int> rawVGetter = null) : base(assign, showChecker, rawVGetter)
		{
			//特にすることはない.
		}
		public DigitalNumber(int assign, Func<PanelManager<int>, int> rawVGetter) : base(assign, rawVGetter)//assignだけなら上のを使う
		{
			//特にすることはない.
		}
		public override int HiddenValue { get; } = int.MaxValue;//さすがにPanel表示で最大までは使い切らないと信じて
		
		private int __RawValue = 0;//RawValueのキャッシュ
		public override int RawValue
		{
			get => __RawValue;
			set => __RawValue = Value = value;
		}
	}
	public class PilotLamp : PanelManager<bool>
	{
		public PilotLamp(int assign, Func<bool> showChecker = null, Func<PanelManager<bool>, bool> rawVGetter = null) : base(assign, showChecker, rawVGetter)
		{
			//特にすることはない.
		}
		public PilotLamp(int assign, Func<PanelManager<bool>, bool> rawVGetter) : base(assign, rawVGetter)//assignだけなら上のを使う
		{
			//特にすることはない.
		}
		public override int HiddenValue { get; } = cvs.FALSE_VALUE;//さすがに最大までは使い切らないと信じて
		private bool __RawValue = false;
		public override bool RawValue
		{
			get => __RawValue;
			set
			{
				__RawValue = value;
				Value = value ? cvs.TRUE_VALUE : HiddenValue;
			}
		}
	}
}
