using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DJMaxStore.Models;
//Este es el Controller del ShoppingCart
namespace DJMaxStore.Controllers
{
    //Se declara clase publica ShoppinCartController
    public class ShoppingCartController : Controller
    {
        //Se de declara private del contexto de la base de datos a utilizar
        private DJMaxStoreDbContext db = new DJMaxStoreDbContext();

        //Se crea la clase de ShippingCartController
        public ShoppingCartController()
        {
        }

        //Retorna la vista de la accion de html, igualando las cariables Cart y ReturnUrl a Get Cart() y returnUrl
        public ViewResult Index(string returnUrl)
        {
            return View(new ShoppingCartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        //Se declara la variable Product igualado a ProductID de la base de datos, el cual se redirecta al usuario cuando
        //selecciona un articulo
        public RedirectToRouteResult AddToCart(int productID, string returnUrl)
        {
            Product product = db.Products.SingleOrDefault(p => p.ProductID == productID);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        //Clase que declara la remocion de un articulo
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            GetCart().RemoveItem(productId);
            return RedirectToAction("Index", new { returnUrl });
        }
        //Clase que declara la vista en el CartWidget
        public PartialViewResult CartWidget(ShoppingCartModel cart)
        {
            return PartialView(cart);
        }
        //La variable ShoppingCartModel cart es igual a la sesion del cart, si cart es igual a nulo
        //Se genera una nueva sesion del cart
        private ShoppingCartModel GetCart()
        {
            ShoppingCartModel cart = (ShoppingCartModel)Session["Cart"];
            if (cart == null)
            {
                cart = new ShoppingCartModel();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //Se autoriza el usuario el cual retorna el ShippinInfo
        [Authorize]
        public ViewResult ShippingInfo()
        {
            return View(new ShippingInfo());
        }
//Si la infomacion del ShippinInfo es valida se retorna la vista y se redirecta la accion al BillingInfo
        [Authorize]
        [HttpPost]
        public ActionResult ShippingInfo(ShippingInfo shippingInfo)
        {
            if (ModelState.IsValid)
            {
                ShoppingCartModel cart = GetCart();
                cart.ShippingInfo = shippingInfo;
                return RedirectToAction("BillingInfo");
            }
            else
            {
                return View(shippingInfo);
            }
        }
        //Se declara la accion de la vista del BillingInfo
        [Authorize]
        public ViewResult BillingInfo()
        {
            return View(new BillingInfo());
        }
        //Al validar el billing info, se retorna la vista del OrderComplete y se borra el shopping cart
        [Authorize]
        [HttpPost]
        public ViewResult BillingInfo(BillingInfo billingInfo)
        {
            if (ModelState.IsValid)
            {
                ShoppingCartModel cart = GetCart();
                cart.BillingInfo = billingInfo;
                ProcessOrder(cart);
                cart.Clear();
                return View("OrderComplete");
            }
            else
            {
                return View(billingInfo);
            }
        }
        //Se declara la clase de procesar la orden
        private void ProcessOrder(ShoppingCartModel cart)
        {

            Customer customer = new Customer
            {
                FirstName = cart.BillingInfo.FirstName,
                LastName = cart.BillingInfo.LastName,
                BillingAddress = cart.BillingInfo.Address,
                BillingCity = cart.BillingInfo.City,
                BillingState = cart.BillingInfo.State,
                BillingPostalCode = cart.BillingInfo.Zip,
                CardNumber = cart.BillingInfo.CreditCardNumber,
                ExpirationMonth = cart.BillingInfo.ExpirationMonth,
                ExpirationYear = cart.BillingInfo.ExpirationYear
            };
            db.Customers.Add(customer);
            db.SaveChanges();

            Order order = new Order
            {
                CustomerID = customer.CustomerID,
                OrderDate = DateTime.Now,
                ShippingAddress = cart.ShippingInfo.Address,
                ShippingCity = cart.ShippingInfo.City,
                ShippingState = cart.ShippingInfo.State,
                ShippingPostalCode = cart.ShippingInfo.Zip
            };
            db.Orders.Add(order);
            db.SaveChanges();

            foreach (ShoppingCartItemModel item in cart.Items)
            {
                OrderItem orderItem = new OrderItem
                {
                    OrderID = order.OrderID,
                    ProductID = item.Product.ProductID,
                    Quantity = item.Quantity
                };
                db.OrderItems.Add(orderItem);
                db.SaveChanges();
            }

        }
    }
}