using System;

namespace DJMaxStore.Models
{
//Modelo de paginacion del proceso de compras
    public class PaginationModel {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}