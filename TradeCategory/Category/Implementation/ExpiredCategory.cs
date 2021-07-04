using System;
using System.Collections.Generic;
using System.Text;
using TradeCategory.Trade;

namespace TradeCategory.Category.Implementation
{
	class ExpiredCategory : ICategory
	{
		string ICategory.CategoryName => "EXPIRED";

		bool ICategory.TradeApplies(ITrade trade, DateTime referenceDate)
		{
			//1. EXPIRED: Trades whose next payment date is late by more than 30 days based on a reference date which will be given.
			var diff = trade.NextPaymentDate - referenceDate;
			if (diff.TotalDays < -30)
				return true;
			return false;
		}
	}
}
