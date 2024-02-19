using ApiBlog.Modelos;
using ApiBlog.Modelos.Dtos;
using AutoMapper;

namespace ApiBlog.Mapper
{
    public class BlogMapper : Profile
    {
        public BlogMapper()
        {
            CreateMap<Entrada, EntradaDto>().ReverseMap();
            CreateMap<Entrada, EntradaCrearDto>().ReverseMap();
            CreateMap<Entrada, EntradaActualizarDto>().ReverseMap();
        }
    }
}
