using System;
using System.Collections.Generic;
using System.Text;
using TradeCategory.Category;
using TradeCategory.Category.Implementation;
using TradeCategory.Trade;

namespace TradeCategory.Classifier
{
	class TradeClassifier
	{
		private readonly List<ICategory> categories; //list of our categories, in order
		private readonly DateTime referenceDate;
		private TradeClassifier(List<ICategory> categories, DateTime referenceDate)
		{
			this.categories = categories;
			this.referenceDate = referenceDate;
		}

		private ICategory ApplyCategory(ITrade trade)
		{
			//search for the category that processes this trade
			foreach (var c in categories)
			{
				if (c.TradeApplies(trade, referenceDate))
					return c;
			}

			//none processed. Should be an error? Throw an exception?
			//actually this menas an error in GetDefaultClassifier.
			return new NotRecognizedCategory();
		}


		public List<ICategory> ApplyCategories(IEnumerable<ITrade> trades)
		{
			//applies all the categories
			var ret = new List<ICategory>();
			foreach (var t in trades)
				ret.Add(ApplyCategory(t));
			return ret;
		}

		//gets a classifier
		public static TradeClassifier GetDefaultClassifier(DateTime referenceDate)
		{
			var categoriesList = new List<ICategory>() {
				//list of categorues, in order to be apllied
				new ExpiredCategory(),
				new HighRiskCategory(),
				new MediumRiskCategory(),
				//always the last one
				new NotRecognizedCategory()
			};

			return new TradeClassifier(categoriesList, referenceDate);
		}

	}
}
