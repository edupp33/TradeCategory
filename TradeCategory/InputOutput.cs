using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TradeCategory.Trade;

namespace TradeCategory
{
	class InputOutput
	{
		#region Input
		public class DataInput
		{
			public readonly DateTime ReferenceDate;

			public readonly List<ITrade> Trades;
			public readonly string? ErrorMessage;

			public DataInput(DateTime referenceDate, List<ITrade> trades)
			{
				ReferenceDate = referenceDate;
				Trades = trades;
				ErrorMessage = null;
			}

			public DataInput(string errorMessage)
			{
				ErrorMessage = $"Error on input: {errorMessage}";
				//to avoid compiler warnings
				Trades = new List<ITrade>();
				ReferenceDate = DateTime.Now;
			}
		}
		static public DataInput ReadInput(TextReader textReader)
		{
			//The first line of the input is the reference date. 
			var line = textReader.ReadLine();
			var referenceDate = ParseDate(line);
			if (referenceDate == null)
				return new DataInput("reference date missing");

			//The second line contains an integer n, the number of trades in the portfolio. 
			line = textReader.ReadLine();
			var numberOfTrades = ParseInt(line);
			if (numberOfTrades == null)
				return new DataInput("number of trade missing");

			//The next n lines contain 3 elements each (separated by a space). 
			List<ITrade> trades = new List<ITrade>();
			for (var currentTrade = 0; currentTrade < numberOfTrades; currentTrade++)
			{
				//First a double that represents trade amount, second a string that represents the client’s sector and third a date that represents the next
				//pending payment. 
				line = textReader.ReadLine();
				if (line == null)
					return new DataInput($"input finished at line {currentTrade + 1} but should have {numberOfTrades}");

				//very boring code.. parse and test each field
				var fields = line.Trim().Split(' ');
				if (fields.Length != 3)
					return new DataInput($"found {fields.Length} fields at line {currentTrade + 1}");

				var amount = ParseDouble(fields[0]);
				if (amount == null)
					return new DataInput($"invalid amount {fields[0]} at line {currentTrade + 1}");

				var sector = fields[1];
				if (sector != "Private" && sector != "Public")
					return new DataInput($"invalid sector {fields[1]} at line {currentTrade + 1}");

				var pending = ParseDate(fields[2]);
				if (pending == null)
					return new DataInput($"invalid pending payment {fields[2]} at line {currentTrade + 1}");

				var thisTrade = new TradeCategory.Trade.TradeElement(amount.Value, sector, pending.Value);
				trades.Add(thisTrade);
			}

			//done!
			return new DataInput(referenceDate.Value, trades);
		}

		static private DateTime? ParseDate(string? line)
		{
			//All dates are in the format mm/dd/yyyy.
			if (!DateTime.TryParseExact(line, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime result))
				return null;
			return result;
		}
		static private int? ParseInt(string? line)
		{
			if (!int.TryParse(line, out int result))
				return null;
			return result;
		}
		static private double? ParseDouble(string? line)
		{
			if (!double.TryParse(line, out double result))
				return null;
			return result;
		}
		#endregion

		#region Output
		//writes output
		static public void WriteToConsole(TextWriter textWriter, IEnumerable<Category.ICategory> categories)
		{
			//Output
			//N lines with the category of each one of the n trades.
			foreach (var category in categories)
				textWriter.WriteLine(category.CategoryName);
		}
		#endregion
	}
}
