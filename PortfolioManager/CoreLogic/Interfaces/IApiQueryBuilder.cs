using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.CoreLogic.Interfaces
{
    public interface IApiQueryBuilder
    {
        Tuple<string, decimal> GetSymbolQuote(string Symbol);
        Dictionary<DateTime, decimal> GetSMA(string Symbol, int Interval, int Period);
        Dictionary<DateTime, decimal> GetWMA(string Symbol, int Interval, int Period);

    }
}
