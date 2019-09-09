using System.Collections.Generic;
using System.Linq;

namespace DJMaxStore.Models
{
//Clase que llama al base de datos Product y Quantity
    public class ShoppingCartItemModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
