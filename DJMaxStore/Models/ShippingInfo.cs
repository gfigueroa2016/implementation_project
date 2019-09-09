using System.ComponentModel.DataAnnotations;

namespace DJMaxStore.Models
{
    //Este es el modelo de ShippinInfo donde se ingresa los datos de Address, City, State y zip para llamarlos a la
    //base de datos

    public class ShippingInfo {
        [Required(ErrorMessage = "Por favor ingrese su direccion")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre de su ciudad")]
        public string City { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre del estado")]
        public string State { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el codigo postal")]
        public string Zip { get; set; }

    }
}
