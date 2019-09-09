using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DJMaxStore.Controllers
{
    //Este controller sirve para enviar una vista al usuario de la pagina Index.cshtml del Home en los Views.
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}