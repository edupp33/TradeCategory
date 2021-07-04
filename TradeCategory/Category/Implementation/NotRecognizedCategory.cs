using System;
using System.Collections.Generic;
using System.Text;
using TradeCategory.Trade;

namespace TradeCategory.Category.Implementation
{
	/* 
	 * this is a fallback category
	 * in case other categories don't catch the trade
	 * Should always be the last one.
	 * */
	class NotRecognizedCategory : ICategory
	{
		string ICategory.CategoryName => "NOTRECOGNIZED";

		bool ICategory.TradeApplies(ITrade trade, DateTime referenceDate) => true;
	}
}
