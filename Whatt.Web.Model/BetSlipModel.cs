using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatt.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Whatt.Web.Model
{
	public class BetSlipModel
	{
		[Display(Name = "Customer #")]
		public long Customer { get; set; }

		[Display(Name = "Event ID")]
		public long Event { get; set; }

		[Display(Name = "Participant #")]
		public long Participant { get; set; }

		[Display(Name = "Stake Amount")]
		public decimal Stake { get; set; }

		[Display(Name = "Win Amount")]
		public decimal? Win { get; set; }

		[Display(Name = "To Win Amount")]
		public decimal? ToWin { get; set; }

		public BetSlipType Type
		{
			get
			{
				return ToWin.HasValue ? BetSlipType.UnSettled : BetSlipType.Settled;
			}
		}
	}
}
