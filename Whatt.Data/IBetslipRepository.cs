using System;
using System.Collections.Generic;
namespace Whatt.Data
{
	interface IBetslipRepository
	{
		IList<Whatt.Data.Model.Betslip> GetAllSettledSlips();
		IList<Whatt.Data.Model.Betslip> GetAllUnsettledSlips();
	}
}
