using System;
using Whatt.Web.Models;

namespace WHATT.Managers
{
	interface IDashboardManager
	{
		DashboardModel LoadModel(string pathToSettled, string pathToUnSettled);
		DashboardModel LoadModel(string[] settledContents, string[] unSettledContents);
	}
}
