using System.Net;

namespace ApiBlog.Modelos
{
    public class RespuestasApi
    {
        public RespuestasApi()
        {
            //para q se llenen con los errrores en caso de haber
            ErrorMessages = new List<string>();
        }


        public HttpStatusCode StatusCode { get; set; }
        //propiedad para capturar si las respuestas son correctas
        public bool IsSuccess { get; set; }
        //propiedad para listar los posibles errores
        public List<string> ErrorMessages { get; set; }
        public Object Results { get; set; }
    }
}
