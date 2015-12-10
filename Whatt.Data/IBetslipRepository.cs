using System;
using System.Collections.Generic;
namespace Whatt.Data
{
	interface IBetslipRepository
	{
		IList<string> GetAllDataFiles();
		IList<Whatt.Data.Model.BetSlip> GetAllSettledSlips(string fileName);
		IList<Whatt.Data.Model.BetSlip> GetAllUnsettledSlips(string fileName);
	}
}
