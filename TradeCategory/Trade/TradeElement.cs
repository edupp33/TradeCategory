using System;
using System.Collections.Generic;
using System.Text;

namespace TradeCategory.Trade
{
	class TradeElement : ITrade
	{
		private readonly double value;
		double ITrade.Value => value;

		private readonly string clientSector;
		string ITrade.ClientSector => clientSector;

		private readonly DateTime nextPaymentDate;
		DateTime ITrade.NextPaymentDate => nextPaymentDate;

		public TradeElement(double value, string clientSector, DateTime nextPaymentDate)
		{
			this.value = value;
			this.clientSector = clientSector ?? throw new ArgumentNullException(nameof(clientSector));
			this.nextPaymentDate = nextPaymentDate;
		}

	}
}
