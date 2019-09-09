using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace DJMaxStore.Models
{
    //Modelo de Products donde se llama al CategoriID, Products, Pagination, SearcString y en la base de datos
    //se llama al CategoryID y al CategoryName
    public class ProductsModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PaginationModel Pagination { get; set; }
        public int CategoryID { get; set; }
        public string SearchString { get; set; }

        public SelectList Categories()
        {
            DJMaxStoreDbContext db = new DJMaxStoreDbContext();
            var categories = from c in db.Categories
                             orderby c.CategoryName
                             select new
                             {
                                 c.CategoryID,
                                 c.CategoryName,
                             };
            return new SelectList(categories, "CategoryID", "CategoryName");
        }
    }
}