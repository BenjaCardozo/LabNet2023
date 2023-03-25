using System.ComponentModel.DataAnnotations;
namespace Northwind.MVC.Models
{
    public class ShippersViewModel
    {

        public int? ShipperId { get; set; }

        [Required]
        [Display(Name ="Nombre de la compañia")]
        [StringLength(40,ErrorMessage ="El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "El nombre de la compañia solo debe contener letras y espacios.")]
        public string CompanyName { get; set; }

        [Display(Name = "Telefono")]
        [StringLength(24, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [RegularExpression(@"^\(\d{3}\) \d{3}\-\d{4}$", ErrorMessage = "El número de teléfono debe tener el formato (123) 123-1234.")]
        public string Phone { get; set;}
    }
}