using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class TipoAplicacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de Tipo de Aplicacion es obligatorio.")]
        public string? Nombre { get; set; }
    }
}
