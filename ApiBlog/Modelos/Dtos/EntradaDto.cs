using System.ComponentModel.DataAnnotations;

namespace ApiBlog.Modelos.Dtos
{
    public class EntradaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string Titulo { get; set; } = default!;
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string Descripcion { get; set; } = default!;
        public string? RutaImagen { get; set; } //permite valores nulos
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string Etiquetas { get; set; } = default!;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }
    }
}
