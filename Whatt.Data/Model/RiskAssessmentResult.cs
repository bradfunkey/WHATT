using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Whatt.Data.Model
{
	public class RiskAssessmentResult
	{
		public RiskAssessmentResult()
		{
			SettledCustomerAverageWinDictAll = new Dictionary<long, decimal?>();
			SettledCustomerAverageWinDictAlert = new Dictionary<long, decimal?>();
			SettledCustomerAverageStakeDict = new Dictionary<long, decimal>();
			SettledBetSlips = new List<BetSlip>();
			UnSettledBetSlips = new List<BetSlip>();	
		}
		
		public virtual Dictionary<long, decimal?> SettledCustomerAverageWinDictAll { get; set; }
		public virtual Dictionary<long, decimal?> SettledCustomerAverageWinDictAlert { get; set; }
		public virtual Dictionary<long, decimal> SettledCustomerAverageStakeDict { get; set; }

		public virtual List<BetSlip> SettledBetSlips { get; set; }

		public virtual List<BetSlip> UnSettledBetSlips { get; set; }
		
	}
}
