using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.LimExpTIMS.TIMS
{
	public static class TIMS_IF
	{
		static TimeManager BlinkTimer = new TimeManager(cvs.TIMSFlushTime, () => Blink_P = !Blink_P);
		static bool Blink_P = false;
		public static void Init()
		{
			BlinkTimer.TimerStart();

			Ats.KeyDownEv += Ats_KeyDownEv;
			Ats.KeyUpEv += Ats_KeyUpEv;
		}

		static private void Ats_KeyUpEv(object sender, IntValEvArgs e)
		{
			
		}

		static private void Ats_KeyDownEv(object sender, IntValEvArgs e)
		{
			
		}


		static internal void SetStaInfo(int index, StaInfo sinfo)
		{
			switch (index)
			{
				case 0:
					Status.FirstRow = sinfo;
					break;
				case 1:
					Status.SecondRow = sinfo;
					break;
				case 2:
					Status.ThirdRow = sinfo;
					break;
				case 3:
					Status.FourthRow = sinfo;
					break;
				case 4:
					Status.FifthRow = sinfo;
					break;
				case 5:
					Status.NextStop = sinfo;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}


	}

}
