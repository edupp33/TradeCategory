using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TradeCategory.Category;
using TradeCategory.Trade;

namespace TradeCategoryTest.Category.Implementation
{
	[TestClass]
	public class ExpiredCategoryTest
	{
		[TestMethod]
		public void TestExecute()
		{
			//1.EXPIRED: Trades whose next payment date is late by more than 30 days based on a reference date which will be given.
			ICategory expired = new TradeCategory.Category.Implementation.ExpiredCategory();

			Assert.IsTrue(expired.TradeApplies(new TradeElement(1, "Public", DateTime.Now.AddDays(-31)), DateTime.Now));
			Assert.IsFalse(expired.TradeApplies(new TradeElement(1, "Public", DateTime.Now.AddDays(-29)), DateTime.Now));
			Assert.IsFalse(expired.TradeApplies(new TradeElement(1, "Public", DateTime.Now.AddDays(31)), DateTime.Now));
		}
	}
}
