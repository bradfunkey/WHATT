using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatt.Common.Enums;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Whatt.Web.Models
{
	public class DashboardModel
	{
		public DashboardModel()
		{
			SettledBetSlips = new List<BetSlipModel>();
			UnSettledBetSlips = new List<BetSlipModel>();
			SettledCustomerAverageWinDictAlert = new Dictionary<long, decimal?>();
			SettledCustomerAverageStakeDict = new Dictionary<long, decimal>();

		}

		public List<BetSlipModel> SettledBetSlips { get; set; }

		public List<BetSlipModel> UnSettledBetSlips { get; set; }

		public Dictionary<long, decimal?> SettledCustomerAverageWinDictAlert { get; set; }

		public Dictionary<long, decimal> SettledCustomerAverageStakeDict { get; set; }
	
	}
	
}
