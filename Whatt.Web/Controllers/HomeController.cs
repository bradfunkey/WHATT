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
using WHATT.Managers;
using Whatt.Common.Enums;

namespace Whatt.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly DashboardManager _manager; 

		public HomeController(DashboardManager manager) 
		{
			this._manager = manager;
		}


		public ActionResult Index()
		{
			//hard coded here, but could easily get these from a file upload or similar, which is out of scope of the requirements (for now).
			string pathToSettled = HttpContext.Server.MapPath("~/App_Data/files/settled.csv");			
			string pathToUnsettled = HttpContext.Server.MapPath("~/App_Data/files/unsettled.csv");							
			var model = _manager.LoadModel(pathToSettled, pathToUnsettled);

			return View(model);
		}

		

	}
}
