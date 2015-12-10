using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whatt.Common.Utils;
using Whatt.Common;
using Whatt.Core;
using Whatt.Web.Models;
using Whatt.Web.Models.TypeMappers;
using Whatt.Common.Enums;
using Whatt.Data.Model;

namespace WHATT.Managers
{
	public class DashboardManager : IDashboardManager
	{

		private readonly CsvParser _parser; 
		private readonly BetSlipMapper _mapper;
		private readonly RiskManagement _risk;

		public DashboardManager(CsvParser parser, BetSlipMapper mapper, RiskManagement risk) 
		{
			this._mapper = mapper;
			this._parser = parser;
			this._risk = risk;
		}


		public DashboardModel LoadModel(string pathToSettled, string pathToUnSettled)
		{
			return ProcessDataFiles(pathToSettled, pathToUnSettled);
		}

		private DashboardModel ProcessDataFiles(string pathToSettled, string pathToUnSettled)
		{
			var model = new DashboardModel();
			string[] settledContents = System.IO.File.ReadAllLines(pathToSettled);
			string[] unSettledContents = System.IO.File.ReadAllLines(pathToUnSettled);
			var settledDtoList = ParseBetSlipCSV(settledContents, BetSlipType.Settled).ToList();
			var unSettledDtoList = ParseBetSlipCSV(unSettledContents, BetSlipType.UnSettled).ToList();

			var riskResult = _risk.ProcessRiskRules(settledDtoList, unSettledDtoList);

			model.SettledBetSlips = (from c in riskResult.SettledBetSlips
											 select _mapper.CreateBetSlipModel(c)).ToList();

			model.UnSettledBetSlips = (from c in riskResult.UnSettledBetSlips
												select _mapper.CreateBetSlipModel(c)).ToList();

			model.SettledCustomerAverageStakeDict = riskResult.SettledCustomerAverageStakeDict;
			model.SettledCustomerAverageWinDictAlert = riskResult.SettledCustomerAverageWinDictAlert;

			return model;
		}

		private IEnumerable<BetSlip> ParseBetSlipCSV(string[] fileContents, BetSlipType type)
		{
			return _parser.ParseBetSlipCSV(fileContents, type);		
		}
	}
}