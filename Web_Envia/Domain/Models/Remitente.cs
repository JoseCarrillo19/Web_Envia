using System.ComponentModel.DataAnnotations;

namespace Web_Envia.Domain.Models
{
    public class Remitente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Es un campo obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Es un campo obligatorio")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "Es un campo obligatorio")]
        public string? Telefono { get; set; }
    }
}
