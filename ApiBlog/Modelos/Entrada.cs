namespace ApiBlog.Modelos
{
    public class Entrada
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public string? RutaImagen { get; set; } //permite valores nulos
        public string Etiquetas { get; set; } = default!;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }



    }
}
