﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Models.Interfaces
{
    public interface IPortfolio
    {
        void UpdateTrade(ITrade Trade);
        decimal GetPortfolioValue();
        List<ITrade> GetTradeHistory();
    }
}