using ApiBlog.Modelos;

namespace ApiBlog.Repositorio.IRepositorio
{
    public interface IEntradaRepositorio
    {
        ICollection<Entrada> GetAllEntradas();
        Entrada GetEntradaById(int entradaId);
        bool ExisteEntrada(string titulo);
        bool ExisteEntrada(int id);
        bool CrearEntrada(Entrada entrada);
        bool ActualizarEntrada(Entrada entrada);
        bool BorrarEntrada(Entrada entrada);
        bool GuardarEntrada();
    }
}
