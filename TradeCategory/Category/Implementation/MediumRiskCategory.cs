using System;
using System.Collections.Generic;
using System.Text;
using TradeCategory.Trade;

namespace TradeCategory.Category.Implementation
{
	class MediumRiskCategory : ICategory
	{
		string ICategory.CategoryName => "MEDIUMRISK";

		bool ICategory.TradeApplies(ITrade trade, DateTime referenceDate)
		{
			//3. MEDIUMRISK: Trades with value greater than 1,000,000 and client from Public Sector.
			if (trade.Value > 1000000 && trade.ClientSector == "Public")
				return true;
			return false;
		}
	}
}
