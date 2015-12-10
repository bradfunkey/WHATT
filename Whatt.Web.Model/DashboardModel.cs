using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatt.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Whatt.Web.Models
{
	public class DashboardModel
	{
		public DashboardModel()
		{
			SettledBetSlips = new List<BetSlipModel>();
			UnSettledBetSlips = new List<BetSlipModel>();		
		}

		public List<BetSlipModel> SettledBetSlips { get; set; }

		public List<BetSlipModel> UnSettledBetSlips { get; set; }
	}
	
}
