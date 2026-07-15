using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicoShopCRM.Models
{
    public class Caso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }

        [Required]
        public string Estado { get; set; } = "Abierto"; // Abierto/EnProceso/Resuelto

        [Display(Name = "Fecha de Creación")]
        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Fecha de Resolución")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaResolucion { get; set; }
    }
}
