using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TradeCategoryTest
{
	[TestClass]
	public class Program
	{
		[TestMethod]
		public void TestExecute()
		{
			TextReader input = new StringReader(
@"12/11/2020
4
2000000 Private 12/29/2025
400000 Public 07/01/2020
5000000 Public 01/02/2024
3000000 Public 10/26/2023
");

			string desiredOutput =
@"HIGHRISK
EXPIRED
MEDIUMRISK
MEDIUMRISK
";
			var output = new StringWriter();
			TradeCategory.Program.Execute(input, output);

			Assert.AreEqual(desiredOutput, output.ToString());
		}
	}
}
