using System.ComponentModel.DataAnnotations;

namespace TicoShopCRM.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(50)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Categoria { get; set; }

        [Required]
        [Display(Name = "Precio Unitario")]
        [DataType(DataType.Currency)]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public int Stock { get; set; }

        private string _estado;
        public string Estado
        {
            get
            {
                if (Stock <= 0)
                {
                    return "SinStock";
                }
                return _estado ?? "Activo"; // Activo/Inactivo/SinStock
            }
            set
            {
                _estado = value;
            }
        }
    }
}
