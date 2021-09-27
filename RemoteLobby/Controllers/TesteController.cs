using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authenticate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RemoteLobby.Controllers
{
    [Route("api/teste")]
    public class TesteController : Controller
    {
        [HttpPost("teste")]
        [Authorize("user")]
        public IActionResult EnviaMensagem()
        {
            var retorno = new User();
            retorno.Username = "Teste User";
            retorno.Password = "Teste User";
            retorno.Role = "Teste User";
            retorno.Token = "Teste User";
            var ret = JsonConvert.SerializeObject(retorno);
            return Ok(ret);
        }
    }
}