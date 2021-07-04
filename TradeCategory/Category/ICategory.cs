using System;
using System.Collections.Generic;
using System.Text;
using TradeCategory.Trade;

namespace TradeCategory.Category
{
	public interface ICategory
	{
		public bool TradeApplies(ITrade trade, DateTime referenceDate); //if a trade fits in this category
		string CategoryName { get; } //a string version of this category

	}
}
