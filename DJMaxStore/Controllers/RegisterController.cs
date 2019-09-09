using DJMaxStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DJMaxStore.Controllers
{
    //Controlador de Registro de usuario, se conecta a la base de datos, se ejecuta accion de resultado de index,
    //retorna vista de customer, redirecta el password encriptado de customer a la base de datos y se actualiza
    public class RegisterController : Controller
    {
        private DJMaxStoreDbContext db = new DJMaxStoreDbContext();

        public ActionResult Index()
        {
            return View(new Customer());
        }

        public RedirectToRouteResult Register(Customer customer)
        {
            customer.Password = SHA256.Encode(customer.Password);

            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}