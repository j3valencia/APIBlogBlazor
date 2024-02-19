using ApiBlog.Data;
using ApiBlog.Modelos;
using ApiBlog.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiBlog.Repositorio
{
    public class EntradaRepositorio : IEntradaRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EntradaRepositorio(ApplicationDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }
        public bool ActualizarEntrada(Entrada entrada)
        {
            entrada.FechaActualizacion = DateTime.Now;

            //obtener la imagen desde la base de datos el metodo asnotracking hace q cuando actualicemos
            //y no le pasemos la imagen no se bloque y que permita guardar la q ya existe
            var imagenDesdeDb = _context.Entradas.AsNoTracking()
                .FirstOrDefault(x => x.Id == entrada.Id);

            //si no se subio ningun archivo
            if(entrada.RutaImagen is null)
            {
                //la imagen de la nueva entrada va ser igual a la imagen q ya existia en la bdd
                entrada.RutaImagen = imagenDesdeDb.RutaImagen;
            }

            _context.Entradas.Update(entrada);
            return GuardarEntrada();
        }

        public bool BorrarEntrada(Entrada entrada)
        {
            _context.Entradas.Remove(entrada);
            return GuardarEntrada();
        }

        public bool CrearEntrada(Entrada entrada)
        {
            entrada.FechaCreacion = DateTime.Now;
            _context.Entradas.Add(entrada);
            return GuardarEntrada();
        }

        public bool ExisteEntrada(string titulo)
        {
            //va devolver un true o false en caso de que la entrada exista eso lo hacemos con Any
            bool valor = _context.Entradas.Any(c => c.Titulo.ToLower().Trim() == titulo.ToLower().Trim());
            return valor;
        }

        public bool ExisteEntrada(int id)
        {
            return _context.Entradas.Any(c => c.Id == id);  
        }

        public ICollection<Entrada> GetAllEntradas()
        {
            return _context.Entradas.ToList();
        }

        public Entrada GetEntradaById(int entradaId)
        {
            return _context.Entradas.FirstOrDefault(c => c.Id == entradaId);
            
        }

        public bool GuardarEntrada()
        {
            //guarda los cambios si hay registros mas de un registro
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
