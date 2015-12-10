using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatt.Common.Enums;
using Whatt.Data.Model;

namespace Whatt.Common.Utils
{
	public class CsvParser
	{		
		/// <summary>
		/// Parses two types BetSlips, Unsettled and Settled. The input data should contain the headers by default.
		/// </summary>
		/// <param name="path"></param>
		/// <param name="type"></param>
		/// <param name="hasHeaders"></param>
		/// <returns></returns>
		public IEnumerable<BetSlip> ParseBetSlipCSV(string[] fileContents, BetSlipType type, bool hasHeaders = true)
		{
			int skip = hasHeaders ? 1 : 0;
	
			IEnumerable<BetSlip> bets = from line in fileContents.Skip(skip)
												 let columns = line.Split(',')
												 
												 select new BetSlip
												 {
													 Customer = int.Parse(columns[0]),
													 Event = int.Parse(columns[1]),
													 Participant = int.Parse(columns[2]),
													 Stake = decimal.Parse(columns[3]),
													 ToWin = type == BetSlipType.UnSettled ? decimal.Parse(columns[4]) : decimal.Zero,
													 Win = type == BetSlipType.Settled ? decimal.Parse(columns[4]) : decimal.Zero
												 };

			return bets;

		}

	}
}
