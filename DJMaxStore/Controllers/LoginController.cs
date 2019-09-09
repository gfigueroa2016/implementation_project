using DJMaxStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DJMaxStore.Controllers
{
    //Se declara la clase de LoginController, se contexta al contexto de la base de datos, se ejecuta la clase
    //Action Result con la funcion Index, se retorna la funcion de vista, se postea del hhttp
    public class LoginController : Controller
    {
        private DJMaxStoreDbContext db = new DJMaxStoreDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //Se declara clase de ActionResult con la funcione index con customer y string de retorno de url
        public ActionResult Index(Customer customer, string returnUrl)
        {
            //si el estado del modelo es valido, se declara customerID como int, si es calido el email, password,
            //se envia al customerID
            if (ModelState.IsValid)
            {
                int customerID;
                if (IsValid(customer.Email, customer.Password, out customerID))
                {
                    //Se autentica con el cookie
                    FormsAuthentication.SetAuthCookie(customerID.ToString(), false);
                    //si el string es nulo, se retorna el login, retorna accion, de index y home
                    if (string.IsNullOrEmpty(returnUrl) ||
                        returnUrl.ToLower().Contains("login"))
                        returnUrl = Url.Action("Index", "Home");
                    return Redirect(returnUrl);
                }
                else
                    //si no el se retorna error de usuario y password
                {
                    ModelState.AddModelError("", "The username and/or password is incorrect, please try again");
                }
            }
            return View(customer);
        }

        public bool IsValid(string Email, string Password, out int CustomerID)
        {
            string passwordHash = SHA256.Encode(Password);
            var data = from u in db.Customers
                       where u.Email == Email && u.Password == passwordHash
                       select new
                       {
                           u.CustomerID,
                           u.Email,
                           u.Password
                       };
            if (data.Count() > 0)
            {
                CustomerID = data.First().CustomerID;
                return true;
            }
            CustomerID = 0;
            return false;
            //se guarda la data en la base de datos de customer y se utiliza la data para autenticar el usuario
        }


    }
}