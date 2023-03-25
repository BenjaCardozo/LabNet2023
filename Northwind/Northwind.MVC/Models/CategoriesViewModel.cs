using System.ComponentModel.DataAnnotations;

namespace Northwind.MVC.Models
{
    public class CategoriesViewModel
    {

        public int? CategoryID { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "El nombre de la categoria solo debe contener letras y espacios.")]
        public string CategoryName { get; set; }
        [StringLength(25, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-ZñÑ\s]+$", ErrorMessage = "El nombre de la categoria solo debe contener letras y espacios.")]
        public string CategoryDescription { get; set; }
    }
}