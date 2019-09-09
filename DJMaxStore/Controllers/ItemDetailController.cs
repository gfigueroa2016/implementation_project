using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DJMaxStore.Models;

namespace DJMaxStore.Controllers
{
    public class ItemDetailController : Controller
    {
        private DJMaxStoreDbContext db = new DJMaxStoreDbContext();

        public ActionResult Index(int id)
        {
            var data = db.Products.SingleOrDefault(p => p.ProductID == id);
            return View(data);
            //se declara data que es igual a ProductID de la base de datos y se retorna la data cuando el producto es
            //seleccionado.
        }
	}
}