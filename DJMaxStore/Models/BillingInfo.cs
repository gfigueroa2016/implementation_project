using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;

namespace DJMaxStore.Models
{
    //Se declara la clase publica de BillingInfo, si el usuario no ingresa data a los campos, le tira errores
    public class BillingInfo
    {
        [Required(ErrorMessage = "Por favor ingrese su nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su numero de tarjeta de credito")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su direccion")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre de su ciudad")]
        public string City { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre del estado")]
        public string State { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su codigo postal")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la fecha de expiracion")]
        public string ExpirationMonth { get; set; }

        public SelectList Months()
        {
            return new SelectList(new string[] { "January", "February", "March",
                "April", "May", "June", "July", "August", "September", "October",
                "November", "December" });
        }

        [Required(ErrorMessage = "Por favor ingrese la fecha de expiracion")]
        public string ExpirationYear { get; set; }

        public SelectList Years()
        {
            return new SelectList(new string[] { "2015", "2016",
                "2017", "2018", "2019", "2020", "2021", "2022", "2023",
                "2024", "2025" });
        }

    }
}
