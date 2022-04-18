//using Business.Main.IbnorcaContext;
using Business.Main.Microventas;
using Business.Main.ModuloSample;
using Domain.Main.Clientes;
using Domain.Main.Wraper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlumbingProps.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundAPIRest.Controllers
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("index")]
        public string index(string name)
        {
            return "API para la gestion de personas";
        }

        [HttpPost("ObtenerClientes")]
        [EnableCors("MyPolicy")]
        public Response ObtenerClientes(RequestObtenerClientes requestObtenerClientes)
        {
            PersonaManager personaManager = new PersonaManager();
            return personaManager.ObtenerClientes(requestObtenerClientes);
        }


        [HttpPost("RegistrarClientreFactura")]
        [EnableCors("MyPolicy")]
        public Response RegistrarClientreFactura(RequestRegistrarClientreFactura requestRegistrarClientreFactura)
        {
            PersonaManager personaManager = new PersonaManager();
            return personaManager.RegistrarClientreFactura(requestRegistrarClientreFactura);
        }
    }
}
