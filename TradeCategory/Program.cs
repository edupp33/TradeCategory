using System;
using System.IO;

namespace TradeCategory
{
	public class Program
	{
		static void Main()
		{
			var consoleIn = Console.In;
			var consoleOut = Console.Out;
			Execute(consoleIn, consoleOut);
		}

		//this is public for testing
		public static void Execute(TextReader consoleIn, TextWriter consoleOut)
		{
			//parse input
			var input = InputOutput.ReadInput(consoleIn);
			if (input.ErrorMessage != null)
			{
				consoleOut.WriteLine(input.ErrorMessage);
				return;
			}

			//gets a classifier
			var classifier = Classifier.TradeClassifier.GetDefaultClassifier(input.ReferenceDate);
			//classifies
			var categories = classifier.ApplyCategories(input.Trades);

			//prints output
			InputOutput.WriteToConsole(consoleOut, categories);
		}
	}
}
