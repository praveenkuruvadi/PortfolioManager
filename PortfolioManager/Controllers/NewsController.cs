using PortfolioManager.CoreLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioManager.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult GetTopNews()
        {
            var FetchNews = new NewsApi().getTopNews();
            return View(FetchNews);
        }

        
    }
}
