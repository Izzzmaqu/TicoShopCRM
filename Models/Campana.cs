using System;
using System.ComponentModel.DataAnnotations;

namespace TicoShopCRM.Models
{
    public class Campana
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la campaña es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha de Fin")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        [Required]
        public string Estado { get; set; } = "Activa"; // Activa/Finalizada/Pausada

        [DataType(DataType.Currency)]
        public decimal Presupuesto { get; set; }
    }
}
