using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Whatt.Data.Model
{
	public class BetSlip
	{
		public BetSlip()
		{
			RiskWarningTypes = new List<int>();
		}

		//Using one class to represent both record types.

		public virtual long Customer { get; set; }
		public virtual long Event { get; set; }
		public virtual long Participant { get; set; }
		public virtual decimal Stake { get; set; }
		public virtual decimal? Win { get; set; }
		public virtual decimal? ToWin { get; set; }
		public virtual List<int> RiskWarningTypes { get; set; }
	}
}
