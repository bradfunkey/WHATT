using System;
using System.Collections.Generic;
using Whatt.Data.Model;

namespace Whatt.Core
{
	public interface IRiskManagement
	{
		RiskAssessmentResult ProcessRiskRules(List<BetSlip> settledList, List<BetSlip> unsettledList);
	}
}
