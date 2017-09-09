using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Models.Interfaces
{
    public interface IStock
    {
        decimal GetCurrentQuote();
    }
}
