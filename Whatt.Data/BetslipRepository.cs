using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatt.Data.Model;

namespace Whatt.Data
{
    public class BetslipRepository : Whatt.Data.IBetslipRepository
    {
		 public BetslipRepository()
		 { 
		 
		 }

		 public IList<Betslip> GetAllSettledSlips()
		 {
			 throw new NotImplementedException();			
		 }


		 public IList<Betslip> GetAllUnsettledSlips()
		 {
			 throw new NotImplementedException();
		 }
    }
}
