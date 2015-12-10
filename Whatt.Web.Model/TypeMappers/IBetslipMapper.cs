using System;
namespace Whatt.Web.Models.TypeMappers
{
	interface IBetSlipMapper
	{
		Whatt.Web.Models.BetSlipModel CreateBetSlipModel(Whatt.Data.Model.BetSlip dto);
		Whatt.Data.Model.BetSlip CreateDto(Whatt.Web.Models.BetSlipModel model);
	}
}
