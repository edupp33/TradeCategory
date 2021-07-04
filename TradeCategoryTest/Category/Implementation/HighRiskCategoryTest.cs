using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TradeCategory.Category;
using TradeCategory.Trade;

namespace TradeCategoryTest.Category.Implementation
{
	[TestClass]
	public class HighRiskCategoryTest
	{
		[TestMethod]
		public void TestExecute()
		{
			//2.HIGHRISK: Trades with value greater than 1,000,000 and client from Private Sector.
			ICategory highRisk = new TradeCategory.Category.Implementation.HighRiskCategory();

			Assert.IsTrue(highRisk.TradeApplies(new TradeElement(1000001, "Private", DateTime.Now), DateTime.Now));
			Assert.IsFalse(highRisk.TradeApplies(new TradeElement(1000001, "Public", DateTime.Now), DateTime.Now));
			Assert.IsFalse(highRisk.TradeApplies(new TradeElement(1000000, "Private", DateTime.Now), DateTime.Now));
		}
	}
}
