using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("persona")]
    public class PersonaController : ControllerBase 
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarPersona()
        {
            //Todo el codigo

            List<Persona> personas = new List<Persona>
            {
                new Persona
                {
                    id = "1",
                    correo = "google@gmail.com",
                    edad = "19",
                    nombre = "Bernardo Peña"
                },
                new Persona
                {
                    id = "2",
                    correo = "miguelgoogle@gmail.com",
                    edad = "23",
                    nombre = "Miguel Mantilla"
                }
            };

            return personas;
        }
    

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarPersonaxid(int codigo)
        {
            //obtienes Persona de la db

            return new Persona
            {
                id = codigo.ToString(),
                correo = "google@gmail.com",
                edad = "19",
                nombre = "Bernardo Peña"
            };
        }
        [HttpPost]
        [Route("guardar")]
        public dynamic guardarPersona(Persona persona)
        {
            //Guardar en la db y le asignas un id
            persona.id = "3";

            return new
            {
                success = true,
                message = "registrado",
                result = persona
            };
        }
        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarPersona(Persona persona)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            //eliminas en la db

            if (token != "juan123.")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "eliminado",
                result = persona
            };
        }
    }
}
