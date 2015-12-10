using System;
using System.Collections.Generic;
namespace Whatt.Data
{
	public interface IBetSlipRepository
	{
		IList<string> GetAllDataFiles();
		IList<Whatt.Data.Model.BetSlip> GetAllSettledSlips(string fileName);
		IList<Whatt.Data.Model.BetSlip> GetAllUnsettledSlips(string fileName);
	}
}
