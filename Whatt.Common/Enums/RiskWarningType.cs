using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatt.Common.Enums
{
	public enum RiskWarningType
	{
		WinsAreOverBasePercentage = 1,
		StakeOver10TimesAverage = 2,
		StakeOver30TimesAverage = 3,
		ToWinIsOverOneThousand = 4
	}
}
