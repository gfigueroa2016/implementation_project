using System.Collections.Generic;
using System.Linq;

namespace DJMaxStore.Models
{
    //se declara la variable items
    public class ShoppingCartModel
    {
        private List<ShoppingCartItemModel> items = new List<ShoppingCartItemModel>();

        public IEnumerable<ShoppingCartItemModel> Items
        {
            get { return items; }
        }

        public void AddItem(Product product, int quantity)
        {
            ShoppingCartItemModel item = 
                items.SingleOrDefault(p => p.Product.ProductID == product.ProductID);

            if (item == null)
            {
                items.Add(new ShoppingCartItemModel
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        //Para añadir y remover la cantidad y el producto
        public void RemoveItem(int productID)
        {
            items.RemoveAll(l => l.Product.ProductID == productID);
        }
        //clase decimal para obtener el total
        public decimal GetCartTotal()
        {
            return items.Sum(e => e.Product.Price * e.Quantity);

        }
        //clase para borrar los articulos
        public void Clear()
        {
            items.Clear();
        }
        //Llama al ShippingInfo y BillingInfo
        public ShippingInfo ShippingInfo { get; set; }

        public BillingInfo BillingInfo { get; set; }

    }

}
