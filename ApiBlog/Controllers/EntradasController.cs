using ApiBlog.Modelos.Dtos;
using ApiBlog.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradasController : ControllerBase
    {
        private readonly IEntradaRepositorio _entradaRepo;
        private readonly IMapper _mapper;

        public EntradasController(IEntradaRepositorio entradaRepo, IMapper mapper)
        {
            _entradaRepo = entradaRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEntradas()
        {
            var listaEntradas = _entradaRepo.GetAllEntradas();
            var listaEntradasDto = new List<EntradaDto>();

            foreach (var lista in listaEntradas)
            {
                listaEntradasDto.Add(_mapper.Map<EntradaDto>(lista));
            }

            return Ok(listaEntradasDto);
        }

        [HttpGet("{entradaId:int}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEntradaById (int entradaId)
        {
            //guarda la entrada q le pasamos 
            var entrada = _entradaRepo.GetEntradaById(entradaId);
            //verifica si la entrada es null 
            if(entrada is null)
            {
                return NotFound();
            }
            //transforma la entrada en entradDto
            var entradaDto = _mapper.Map<EntradaDto>(entrada);

            return Ok(entradaDto);
        }




    }
}
