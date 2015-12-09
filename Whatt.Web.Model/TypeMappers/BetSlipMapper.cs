using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatt.Data;

namespace Whatt.Web.Model.TypeMappers
{
	public class BetslipMapper : IBetslipMapper 
	{
		public BetSlipModel CreateBetSlipModel(Data.Model.Betslip dto)
		{
			return new BetSlipModel
			{
				Customer = dto.Customer,
				Event = dto.Event,
				Participant = dto.Participant,
				Stake = dto.Stake,
				ToWin = dto.ToWin,
				Win = dto.Win
			};
		}

		public Data.Model.Betslip CreateDto(BetSlipModel model)
		{
			return new Data.Model.Betslip
			{
				Customer = model.Customer,
				Event = model.Event,
				Participant = model.Participant,
				Stake = model.Stake,
				ToWin = model.ToWin,
				Win = model.Win
			};
		}
	}
}
