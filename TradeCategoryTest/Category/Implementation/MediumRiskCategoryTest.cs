using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TradeCategory.Category;
using TradeCategory.Trade;

namespace TradeCategoryTest.Category.Implementation
{
	[TestClass]
	public class MediumRiskCategoryTest
	{
		[TestMethod]
		public void TestExecute()
		{
			//3. MEDIUMRISK: Trades with value greater than 1,000,000 and client from Public Sector.
			ICategory mediumRisk = new TradeCategory.Category.Implementation.MediumRiskCategory();

			Assert.IsTrue(mediumRisk.TradeApplies(new TradeElement(1000001, "Public", DateTime.Now), DateTime.Now));
			Assert.IsFalse(mediumRisk.TradeApplies(new TradeElement(1000001, "Private", DateTime.Now), DateTime.Now));
			Assert.IsFalse(mediumRisk.TradeApplies(new TradeElement(1000000, "Public", DateTime.Now), DateTime.Now));
		}
	}
}
