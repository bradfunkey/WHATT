using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatt.Data.Model;


namespace Whatt.Data
{
    public class BetSlipRepository : IBetslipRepository
    {
		 public BetSlipRepository()
		 { 
		 
		 }

		 /// <summary>
		 /// Gets all the Data Files uploaded to the server.
		 /// </summary>
		 /// <returns></returns>
		 public IList<string> GetAllDataFiles()
		 {
			 throw new NotImplementedException();
		 }

		 public IList<BetSlip> GetAllSettledSlips(string fileName)
		 {
			 throw new NotImplementedException();			
		 }


		 public IList<BetSlip> GetAllUnsettledSlips(string fileName)
		 {
			 throw new NotImplementedException();
		 }
    }
}
