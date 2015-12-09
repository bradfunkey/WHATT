using System;
namespace Whatt.Web.Model.TypeMappers
{
	interface IBetslipMapper
	{
		Whatt.Web.Model.BetSlipModel CreateBetSlipModel(Whatt.Data.Model.Betslip dto);
		Whatt.Data.Model.Betslip CreateDto(Whatt.Web.Model.BetSlipModel model);
	}
}
