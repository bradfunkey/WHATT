using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatt.Data.Model;
using Whatt.Common.Enums;

namespace Whatt.Core
{
	public class RiskManagement : IRiskManagement
	{
		private int _rule1Percentage = 60; //todo: allow this to be configured?

		public RiskAssessmentResult ProcessRiskRules(List<BetSlip> settledList, List<BetSlip> unsettledList)
		{			
			//Rules
			//1. A customer wins on more than 60% of their bets
			//2. Bets where the stake is more than 10 times higher than that customer’s average bet in their betting history should be highlighted as unusual ) 
			//3. Bets where the stake is more than 30 times higher than that customer’s average bet in their betting history should be highlighted as highly unusual 
			//4. Bets where the amount to be won is $1000 or more

			var result = new RiskAssessmentResult();

			//first get all the customer ID's from each list
			long[] settledCustomerIds = settledList.AsEnumerable()
				  .Select(r => r.Customer).Distinct()
				  .ToArray();

			long[] unSettledCustomerIds = unsettledList.AsEnumerable()
				  .Select(r => r.Customer).Distinct()
				  .ToArray();
			
			//now get the average stake for each customer's settled bets 
			var settledCustomerAverageStakeDict = GetAverageStakes(settledCustomerIds, settledList);

			//Now we can execute the rules (finally)

			//1. A customer wins on more than 60% of their bets
			result.SettledCustomerAverageWinDictAll = GetCustomersWinningPercentage(settledCustomerIds, settledList); //might be nice to return to show all customers' %'s
			result.SettledCustomerAverageWinDictAlert = result.SettledCustomerAverageWinDictAll.Where(o => o.Value >= _rule1Percentage).ToDictionary(x => x.Key, x => x.Value); //this contains the risky ones
			
			//now process the settledList flagging those risky punters on each record with this risk warning type
			foreach(var slip in settledList)
			{
				foreach (var dict in result.SettledCustomerAverageWinDictAlert)
				{
					if (slip.Customer == dict.Key)
					{
						slip.RiskWarningTypes.Add((int)RiskWarningType.WinsAreOverBasePercentage);
					}
				}
			}
			//return the processed list
			result.SettledBetSlips = settledList;

			//Unsettled Risk Rules

			//2. Bets where the stake is more than 10 times higher than that customer’s average bet in their betting history should be highlighted as unusual ) 
			//3. Bets where the stake is more than 30 times higher than that customer’s average bet in their betting history should be highlighted as highly unusual 
		
			foreach (var slip in unsettledList)
			{
				foreach (var dict in settledCustomerAverageStakeDict)
				{
					if (slip.Customer == dict.Key)
					{
						if (slip.Stake > dict.Value * 30)
							slip.RiskWarningTypes.Add((int)RiskWarningType.StakeOver30TimesAverage);
						else if(slip.Stake > dict.Value * 10)
							slip.RiskWarningTypes.Add((int)RiskWarningType.StakeOver10TimesAverage);
					}
				}

				//4. Bets where the amount to be won is $1000 or more
				if(slip.ToWin.HasValue && slip.ToWin.Value >= 1000)
					slip.RiskWarningTypes.Add((int)RiskWarningType.ToWinIsOverOneThousand);
			}
			
			result.UnSettledBetSlips = unsettledList;

			return result;
		}

		/// <summary>
		/// Creates a dictionary CustomerId/Average as a percentage
		/// </summary>
		/// <param name="settledCustomerIds"></param>
		/// <param name="settledList"></param>
		/// <param name="percentage"></param>
		/// <returns></returns>
		private Dictionary<long, decimal?> GetCustomersWinningPercentage(long[] settledCustomerIds, List<BetSlip> settledList)
		{
			var settledCustomerAverageWinDict = new Dictionary<long, decimal?>();
			decimal? betSlipsAverage;
			foreach (long customer in settledCustomerIds)
			{
				betSlipsAverage = settledList.Where(o => o.Customer == customer).Average(o => o.Win);
				betSlipsAverage = decimal.Round(betSlipsAverage.Value, 2);
				settledCustomerAverageWinDict.Add(customer, betSlipsAverage);
			}
			return settledCustomerAverageWinDict;
		
		}

		private Dictionary<long, decimal> GetAverageStakes(long[] settledCustomerIds, List<BetSlip> settledList)
		{
			var settledCustomerAverageStakeDict = new Dictionary<long, decimal>();
			decimal betSlipsAverage;
			foreach (long customer in settledCustomerIds)
			{
				betSlipsAverage = settledList.Where(o => o.Customer == customer).Average(o => o.Stake);
				betSlipsAverage = decimal.Round(betSlipsAverage, 2);
				settledCustomerAverageStakeDict.Add(customer, betSlipsAverage);
			}
			return settledCustomerAverageStakeDict;
		}
	}
}
