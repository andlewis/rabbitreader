using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RabbitReader.Controllers
{
    [Authorize]
    public class ViewController : Controller
    {
        public ActionResult Index()
        {

            
            return View();
        }

    }
}
