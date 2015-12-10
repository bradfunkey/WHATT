using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Whatt.Common;
using Whatt.Core;
using Whatt.Common.Utils;
using Whatt.Web.Models;
using Whatt.Web.Models.TypeMappers;

namespace Whatt.Web.Controllers
{
	public class HomeController : Controller
	{
		private CsvParser parser = new CsvParser(); //TODO DI once tested
		private BetSlipMapper mapper = new BetSlipMapper();
		private RiskManagement risk = new RiskManagement();

		public ActionResult Index()
		{
			var model = new DashboardModel();
			string pathToSettled = HttpContext.Server.MapPath("~/App_Data/files/settled.csv");
			string pathToUnsettled = HttpContext.Server.MapPath("~/App_Data/files/unsettled.csv");
			string[] settledContents = System.IO.File.ReadAllLines(pathToSettled);
			string[] unSettledContents = System.IO.File.ReadAllLines(pathToUnsettled);

			var settledDtoList = parser.ParseBetSlipCSV(settledContents, Common.Enums.BetSlipType.Settled).ToList();
			var unSettledDtoList = parser.ParseBetSlipCSV(unSettledContents, Common.Enums.BetSlipType.UnSettled).ToList();

			//now run the risk assessment
			var riskResult = risk.ProcessRiskRules(settledDtoList, unSettledDtoList);


			model.SettledBetSlips = (from c in riskResult.SettledBetSlips
									 select mapper.CreateBetSlipModel(c)).ToList();

			model.UnSettledBetSlips = (from c in riskResult.UnSettledBetSlips
									 select mapper.CreateBetSlipModel(c)).ToList();

			

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
