using GridViewTooltip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridViewTooltip.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GridViewPartial()
        {
            List<SimpleModel> model = SimpleModel.GetData();
            return PartialView(model);
        }
    }
}
