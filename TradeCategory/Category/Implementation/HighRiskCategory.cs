using System;
using System.Collections.Generic;
using System.Text;
using TradeCategory.Trade;

namespace TradeCategory.Category.Implementation
{
	public class HighRiskCategory : ICategory
	{
		string ICategory.CategoryName => "HIGHRISK";

		bool ICategory.TradeApplies(ITrade trade, DateTime referenceDate)
		{
			//2. HIGHRISK: Trades with value greater than 1,000,000 and client from Private Sector.
			if (trade.Value > 1000000 && trade.ClientSector == "Private")
				return true;
			return false;
		}
	}
}
